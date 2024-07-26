Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Diagnostics


Imports DirectShowLib 'You must add a reference to the newest DirectShowLib.dll file if this line has an error

Public Class DSCamCapture

    Implements ISampleGrabberCB
    Implements IDisposable

    Private WithEvents TmrCaptured As New Timer With {.Interval = 10}
    Private WithEvents TmrSaved As New Timer With {.Interval = 10}
    Public Event FrameCaptured(ByVal capImage As Bitmap)
    Public Event FrameSaved(ByVal capImage As Bitmap, ByVal imgPath As String)

    Private m_graphBuilder As IFilterGraph2 = Nothing
    Private m_mediaCtrl As IMediaControl = Nothing
    Private sampGrabber As ISampleGrabber = Nothing

    Private mediaEventEx As IMediaEventEx = Nothing
    Private videoWindow As IVideoWindow = Nothing
    Private Const WM_APP As Integer = &H8000
    Private Const WM_GRAPHNOTIFY As Integer = (WM_APP + 1)

    Private capturedPic As Bitmap = Nothing
    Private parentHandle As IntPtr = IntPtr.Zero
    Private saveImage As Boolean = False
    Private getImage As Boolean = False
    Private ImagePathName As String = ""
    Private ImgFormat As Imaging.ImageFormat = Nothing

    Private unsupportedVideo As Boolean
    Private m_videoWidth As Integer
    Private m_videoHeight As Integer
    Private m_stride As Integer

    Private Running As Boolean = False
    Private Connected As Boolean = False

#If DEBUG Then
    Private m_rot As DsROTEntry = Nothing
#End If

    ''' <summary>
    ''' Indicates if this instance is currently connected to a device.
    ''' </summary>
    Public ReadOnly Property IsConnected() As Boolean
        Get
            Return Connected
        End Get
    End Property

    ''' <summary>
    ''' Indicates if the capture graph is running or paused/stoped.
    ''' </summary>
    Public ReadOnly Property IsRunning() As Boolean
        Get
            Return Running
        End Get
    End Property

    ''' <summary>
    ''' Enum of common video frame sizes. Used to set the (frameSize) parameter of the (ConnectToDevice) function.
    ''' </summary>
    Public Enum FrameSizes As Integer
        s160x120 = 0
        s176x144 = 1
        s320x240 = 2
        s352x288 = 3
        s640x480 = 4
    End Enum

    ''' <summary>
    ''' Connects this instance of the Capture class to the specified capture device index.
    ''' </summary>
    ''' <param name="deviceIndex">The Zero Based Index Of Capture Device To Connect To.</param>
    ''' <param name="frameRate">The Capture Rate. Equivilant to FPS.</param>
    ''' <param name="windowSize">The size of the visible video window.</param>
    ''' <param name="frameSize">The size used for the video frames. This will also be the size images are saved as.</param>
    ''' <param name="hParent">A Handle To The Parent Window.</param>
    Public Function ConnectToDevice(ByVal deviceIndex As Integer, ByVal frameRate As Integer, ByVal windowSize As Size, ByVal frameSize As FrameSizes, ByVal hParent As IntPtr) As Boolean
        parentHandle = hParent

        ' Get the collection of video devices
        Dim capDevices As DsDevice() = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice)

        If (deviceIndex + 1 > capDevices.Length) Then Throw New Exception("No video capture devices found at that index!")

        Dim dev As DsDevice = capDevices(deviceIndex)

        Dim iSize As New Size(CInt(frameSize.ToString.Substring(1, 3)), CInt(frameSize.ToString.Substring(5, 3)))

        Try
            SetupGraph(dev, frameRate, windowSize, iSize)
        Catch
            Dispose()
            If unsupportedVideo Then
                MessageBox.Show("The (imageSize) resolution isn't supported by the camera.")
            Else
                MessageBox.Show("An unknown error happened when connecting to the camera.")
            End If
            Return False
        End Try

        Connected = True
        Return True
    End Function

    ''' <summary>
    ''' Used to resize and/or change the location of the visible video window.
    ''' </summary>
    ''' <param name="xLoc">The new X location.</param>
    ''' <param name="yLoc">The new Y location.</param>
    ''' <param name="sWidth">The new Width of the window.</param>
    ''' <param name="sHeight">The new Height of the window.</param>
    ''' <remarks></remarks>
    Public Sub ResizeWindow(ByVal xLoc As Integer, ByVal yLoc As Integer, ByVal sWidth As Integer, ByVal sHeight As Integer)
        If Not parentHandle.Equals(IntPtr.Zero) Then
            Dim hr As Integer
            hr = videoWindow.SetWindowPosition(xLoc, yLoc, sWidth, sHeight)
            DsError.ThrowExceptionForHR(hr)
        End If
    End Sub

    ''' <summary>
    ''' Returns a string array containing all video capture device names in the device index order that are currently available.
    ''' </summary>
    Public Function GetCaptureDevices() As String()
        Dim capDevices As DsDevice() = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice)
        Dim dvcList As New List(Of String)
        For Each cd As DsDevice In capDevices
            dvcList.Add(cd.Name)
        Next
        Return dvcList.ToArray
    End Function

    ' <summary> 
    ' Disconnects from any devices and clears all resources.
    ' </summary>
    Public Sub Dispose() Implements IDisposable.Dispose
        CloseInterfaces()
    End Sub

    Protected Overloads Overrides Sub finalize()
        CloseInterfaces()
    End Sub

    ''' <summary>
    ''' Starts the capture graph.
    ''' </summary>
    Public Sub Start()
        If Not Running And Connected Then
            Dim hr As Integer = m_mediaCtrl.Run()
            DsError.ThrowExceptionForHR(hr)
            Running = True
        End If
    End Sub

    ''' <summary>
    ''' Pauses the capture graph. Running the graph takes up a lot of resources. (Pause) it when it isn't needed at the time and (Start) it when needed again.
    ''' </summary>
    Public Sub Pause()
        If Running And Connected Then
            Dim hr As Integer = m_mediaCtrl.Pause()
            DsError.ThrowExceptionForHR(hr)
            Running = False
        End If
    End Sub

    ''' <summary>
    ''' Saves an image file of the current video frame and passes the captured image to the (capImage) parameter in the (FrameSaved) event.
    ''' </summary>
    ''' <param name="strFileName">The full path, name, and extension to save the image as.</param>
    ''' <param name="iFormat">The image format for saving the file. Make sure the file extension matches.</param>
    Public Sub SaveCurrentFrame(ByVal strFileName As String, ByVal iFormat As Imaging.ImageFormat)
        ImagePathName = strFileName
        ImgFormat = iFormat
        saveImage = True
        TmrSaved.Start()
    End Sub

    'Used to save the image and trigger the FrameSaved event to notify the owner application the image was saved.
    Private Sub Tmr2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TmrSaved.Tick
        If Not saveImage Then
            TmrSaved.Stop()
            capturedPic.Save(ImagePathName, ImgFormat)
            RaiseEvent FrameSaved(capturedPic, ImagePathName)
        End If
    End Sub

    ''' <summary>
    ''' Gets the current video frame and passes the captured image as the (capImage) parameter in the (FrameCaptured) event.
    ''' </summary>
    Public Sub GetCurrentFrame()
        getImage = True
        TmrCaptured.Start()
    End Sub

    'Used to raise the (FrameCaptured) event to notify the owner application the image is ready and pass the image.
    Private Sub Tmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TmrCaptured.Tick
        If Not getImage Then
            TmrCaptured.Stop()
            RaiseEvent FrameCaptured(capturedPic)
        End If
    End Sub

    Private Sub SetupGraph(ByVal dev As DsDevice, ByVal iFrameRate As Integer, ByVal winSize As Size, ByVal imgSize As Size)
        Dim hr As Integer
        Dim baseGrabFlt As IBaseFilter = Nothing
        Dim capFilter As IBaseFilter = Nothing
        Dim capGraph As ICaptureGraphBuilder2 = Nothing

        m_graphBuilder = DirectCast(New FilterGraph(), IFilterGraph2)
        m_mediaCtrl = DirectCast(m_graphBuilder, IMediaControl)
        mediaEventEx = DirectCast(m_graphBuilder, IMediaEventEx)
        videoWindow = DirectCast(m_graphBuilder, IVideoWindow)

#If DEBUG Then
        m_rot = New DsROTEntry(m_graphBuilder)
#End If

        Try
            capGraph = DirectCast(New CaptureGraphBuilder2(), ICaptureGraphBuilder2)
            sampGrabber = DirectCast(New SampleGrabber(), ISampleGrabber)

            hr = capGraph.SetFiltergraph(DirectCast(m_graphBuilder, IGraphBuilder))
            DsError.ThrowExceptionForHR(hr)

            hr = m_graphBuilder.AddSourceFilterForMoniker(dev.Mon, Nothing, dev.Name, capFilter)
            DsError.ThrowExceptionForHR(hr)

            baseGrabFlt = DirectCast(sampGrabber, IBaseFilter)
            ConfigureSampleGrabber(sampGrabber)

            hr = m_graphBuilder.AddFilter(baseGrabFlt, "DShow Capture")
            DsError.ThrowExceptionForHR(hr)

            SetConfigParms(capGraph, capFilter, iFrameRate, imgSize.Width, imgSize.Height)

            hr = capGraph.RenderStream(PinCategory.Capture, MediaType.Video, capFilter, baseGrabFlt, Nothing)
            DsError.ThrowExceptionForHR(hr)

            hr = mediaEventEx.SetNotifyWindow(parentHandle, WM_GRAPHNOTIFY, IntPtr.Zero)
            DsError.ThrowExceptionForHR(hr)

            hr = videoWindow.put_Owner(parentHandle)
            DsError.ThrowExceptionForHR(hr)

            hr = videoWindow.SetWindowPosition(0, 0, winSize.Width, winSize.Height)
            DsError.ThrowExceptionForHR(hr)

            hr = videoWindow.put_WindowStyle(WindowStyle.Child)
            DsError.ThrowExceptionForHR(hr)

            SaveSizeInfo(sampGrabber)

        Finally

            If (Not capFilter Is Nothing) Then
                Marshal.ReleaseComObject(capFilter)
                capFilter = Nothing
            End If
            If (Not sampGrabber Is Nothing) Then
                Marshal.ReleaseComObject(sampGrabber)
                sampGrabber = Nothing
            End If
        End Try
    End Sub

    Private Sub SaveSizeInfo(ByVal sampGrabber As ISampleGrabber)
        Dim hr As Integer
        Dim media As AMMediaType = New AMMediaType()
        hr = sampGrabber.GetConnectedMediaType(media)
        DsError.ThrowExceptionForHR(hr)

        If (Not (media.formatType.Equals(FormatType.VideoInfo)) AndAlso Not (media.formatPtr.Equals(IntPtr.Zero))) Then
            Throw New NotSupportedException("Unknown Media Format")
        End If

        Dim vInfoHeader As VideoInfoHeader = New VideoInfoHeader()
        Marshal.PtrToStructure(media.formatPtr, vInfoHeader)
        m_videoWidth = vInfoHeader.BmiHeader.Width
        m_videoHeight = vInfoHeader.BmiHeader.Height
        m_stride = CInt(m_videoWidth * (vInfoHeader.BmiHeader.BitCount / 8))

        DsUtils.FreeAMMediaType(media)
        media = Nothing
    End Sub

    Private Sub ConfigureSampleGrabber(ByVal sampGrabber As ISampleGrabber)
        Dim hr As Integer
        Dim media As AMMediaType = New AMMediaType()

        media.majorType = MediaType.Video
        media.subType = MediaSubType.RGB24
        media.formatType = FormatType.VideoInfo

        hr = sampGrabber.SetMediaType(media)
        DsError.ThrowExceptionForHR(hr)

        DsUtils.FreeAMMediaType(media)
        media = Nothing

        hr = sampGrabber.SetOneShot(False)
        DsError.ThrowExceptionForHR(hr)

        hr = sampGrabber.SetCallback(Me, 0)
        DsError.ThrowExceptionForHR(hr)

        sampGrabber.SetBufferSamples(False)
    End Sub

    Private Sub SetConfigParms(ByVal capGraph As ICaptureGraphBuilder2, ByVal capFilter As IBaseFilter, ByVal iFrameRate As Integer, ByVal iWidth As Integer, ByVal iHeight As Integer)
        Dim hr As Integer
        Dim obj As Object = Nothing
        Dim media As AMMediaType = Nothing
        Dim videoStreamConfig As IAMStreamConfig
        Dim videoControl As IAMVideoControl = DirectCast(capFilter, IAMVideoControl)

        hr = capGraph.FindInterface(PinCategory.Capture, MediaType.Video, capFilter, GetType(IAMStreamConfig).GUID, obj)

        videoStreamConfig = DirectCast(obj, IAMStreamConfig)

        Try
            If (videoStreamConfig Is Nothing) Then Throw New Exception("Failed to get IAMStreamConfig")

            hr = videoStreamConfig.GetFormat(media)
            DsError.ThrowExceptionForHR(hr)

            Dim vih As VideoInfoHeader = New VideoInfoHeader()
            Marshal.PtrToStructure(media.formatPtr, vih)

            vih.AvgTimePerFrame = CLng(10000000 / iFrameRate)
            vih.BmiHeader.Width = iWidth
            vih.BmiHeader.Height = iHeight

            Marshal.StructureToPtr(vih, media.formatPtr, False)

            hr = videoStreamConfig.SetFormat(media)
            If hr <> 0 Then unsupportedVideo = True Else unsupportedVideo = False
            DsError.ThrowExceptionForHR(hr)

            DsUtils.FreeAMMediaType(media)
            media = Nothing
        Finally
            Marshal.ReleaseComObject(videoStreamConfig)
        End Try
    End Sub

    Private Sub CloseInterfaces()
        Dim hr As Integer
        Try
            If m_mediaCtrl IsNot Nothing Then

                hr = m_mediaCtrl.Stop()
                m_mediaCtrl = Nothing
                Running = False

                hr = videoWindow.put_Visible(OABool.False)
                DsError.ThrowExceptionForHR(hr)

                hr = videoWindow.put_Owner(IntPtr.Zero)
                DsError.ThrowExceptionForHR(hr)

                If mediaEventEx IsNot Nothing Then
                    hr = mediaEventEx.SetNotifyWindow(IntPtr.Zero, 0, IntPtr.Zero)
                    DsError.ThrowExceptionForHR(hr)
                End If

            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

#If DEBUG Then
        If m_rot IsNot Nothing Then
            m_rot.Dispose()
            m_rot = Nothing
        End If
#End If

        If m_graphBuilder IsNot Nothing Then
            Marshal.ReleaseComObject(m_graphBuilder)
            m_graphBuilder = Nothing
        End If

        Connected = False
        parentHandle = IntPtr.Zero
        saveImage = False
        getImage = False
        ImagePathName = ""
        ImgFormat = Nothing

        GC.Collect()
    End Sub

    Private Function SampleCB(ByVal SampleTime As Double, ByVal pSample As IMediaSample) As Integer Implements ISampleGrabberCB.SampleCB
        If IsDBNull(pSample) = True Then Return -1
        Dim dataLen As Integer = pSample.GetActualDataLength()
        Dim buffPtr As IntPtr
        If pSample.GetPointer(buffPtr) = 0 And dataLen > 0 Then
            Dim buf As Byte() = New Byte(dataLen) {}
            Marshal.Copy(buffPtr, buf, 0, dataLen)

            If saveImage Or getImage Then
                Dim bmp As New Bitmap(m_videoWidth, m_videoHeight, Imaging.PixelFormat.Format24bppRgb)
                Dim bounds As Rectangle = New Rectangle(0, 0, m_videoWidth, m_videoHeight)

                Dim bmpData As BitmapData = bmp.LockBits(bounds, Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format24bppRgb)

                Marshal.Copy(buf, 0, bmpData.Scan0, dataLen)
                capturedPic = bmp

                bmp.UnlockBits(bmpData)

                bmpData = Nothing
                bmp = Nothing
                buf = Nothing

                capturedPic.RotateFlip(RotateFlipType.RotateNoneFlipY)

                getImage = False
                saveImage = False
            End If
        End If
        Marshal.ReleaseComObject(pSample)
        Return 0
    End Function

    Private Function BufferCB(ByVal SampleTime As Double, ByVal pBuffer As IntPtr, ByVal BufferLen As Integer) As Integer Implements ISampleGrabberCB.BufferCB
        SyncLock Me
            'Empty....
        End SyncLock
        Return 0
    End Function

End Class
