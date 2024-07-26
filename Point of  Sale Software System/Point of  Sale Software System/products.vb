Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports Bytescout.BarCodeReader
Imports DirectShowLib
Imports QRCoder

Public Class products
    Public Function RandomNumber(ByVal n As Integer) As Integer
        'initialize random number generator
        Dim r As New Random(System.DateTime.Now.Millisecond)
        Return r.Next(1, 1000000000)
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim code As Integer
        TextBox7.Text = RandomNumber(code)
        barcode_c()
    End Sub
    Private Sub barcode_c()
        Dim gen As New QRCodeGenerator
        Dim data = gen.CreateQrCode(TextBox7.Text, QRCodeGenerator.ECCLevel.Q)
        Dim code As New QRCode(data)
        PictureBox1.Image = code.GetGraphic(6)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox7.Text = "" Then
            MessageBox.Show("Click On Barcode", "Please", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf TextBox1.Text = "" Then
            TextBox1.Focus()
            MessageBox.Show("You Have To Complete Information", "Please", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else
            SaveFileDialog1.FileName = "Barcode_" & TextBox1.Text & ".jpg"
            SaveFileDialog1.ShowDialog()

        End If
    End Sub
    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        Dim FileToSaveAs As String = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Temp, SaveFileDialog1.FileName)
        PictureBox1.Image.Save(FileToSaveAs, System.Drawing.Imaging.ImageFormat.Jpeg)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            TextBox1.Focus()
            MessageBox.Show("You Have To Complete Information", "Please", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                Dim sql As String = "INSERT INTO Products (product_id,product_name,type,Expiry,price_sale,price_buy,Barcode)  " _
        & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & DateTimePicker1.Value.Date & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"

                Dim cmd As New SqlCommand(sql, cn)
                With cmd
                    cn.Open()
                    .ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم الادخال بنجاح", MsgBoxStyle.Information, "!!")
                    code()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub products_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code()
        'عند فتح المشروع      
    End Sub
    Private Sub code()
        Try
            Dim sql As String = "select product_id as'التسلسل',product_name as'اسم المنتج',type as'النوع',Expiry as'تاريخ انتهاء الصلاحية',price_sale as'سعر البيع',price_buy as'سعر الشراء',Barcode as'باركود' from Products ORDER BY product_id"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "column_name"
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub max()
        Try
            Dim sql As String = "Select max(product_id) from products"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Dim x = 1 + command.ExecuteScalar().ToString()
            cn.Close()
            TextBox1.Text = x
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub clear()
        TextBox2.Text = ""
        ComboBox1.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        TextBox7.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString()
        barcode_c()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        clear()
        max()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Panel3.Visible = True
    End Sub
    Private Sub select_product()
        Try
            Dim sql As String = "select products.product_id ,product_name ,type,Expiry ,price_sale,price_buy ,barcode from Products where barcode='" & TextBox7.Text & "' ORDER BY products.product_id"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox1.Text = reader(0)
                TextBox2.Text = reader(1)
                ComboBox1.Text = reader(2)
                DateTimePicker1.Value = reader(3)
                TextBox5.Text = reader(4)
                TextBox6.Text = reader(5)

                cn.Close()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        If TextBox7.Text = "" Then
            Button8.PerformClick()
        Else
            'barcode()
            select_product()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذا المنتج ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM Products WHERE product_id =" & TextBox1.Text
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
                code()
            ElseIf DialogResult.No Then
                MsgBox("تم الغاء عملية الحذف", MsgBoxStyle.Information, "Warning !")
            Else
                MsgBox("غير موجود", "حدث خطا ما !!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox5.Text = "" Then
            MsgBox("حدد المنتج اولاً", MsgBoxStyle.Critical)
        Else
            Try
                Dim sql As String = "Update Products set product_name='" & TextBox2.Text & "',type='" & ComboBox1.Text & "' ,Expiry='" & DateTimePicker1.Value.Date & "',price_sale='" & TextBox5.Text & "',price_buy='" & TextBox6.Text & "',Barcode='" & TextBox7.Text & "' where product_id='" & TextBox1.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم التحديث المنتج بنجاح", MsgBoxStyle.Information, "Warning !")
                code()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Panel3.Visible = False
        camera.Stop()
    End Sub
    Private Sub captured(Sender As Object, eventargs As NewFrameEventArgs)
        bmp = DirectCast(eventargs.Frame.Clone(), Bitmap)
        PictureBox3.Image = DirectCast(eventargs.Frame.Clone(), Bitmap)
    End Sub
    Dim bmp As Bitmap
    Dim camera As VideoCaptureDevice
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        PictureBox3.BringToFront()
        TextBox4.Clear()
        Dim cameras As VideoCaptureDeviceForm = New VideoCaptureDeviceForm()
        If cameras.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            camera = cameras.VideoDevice
            AddHandler camera.NewFrame, New NewFrameEventHandler(AddressOf captured)
            camera.Start()
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        TextBox7.Text = TextBox4.Text
        Timer1.Enabled = False
        If TextBox2.Text = "" Then
        Else
            Button9.PerformClick()
        End If
    End Sub
    Private Sub barcode()
        Try
            Dim reader As Reader = New Reader()
            reader.RegistrationKey = "demo"
            reader.RegistrationName = "demo"
            reader.BarcodeTypesToFind.All = True
            Dim barcodes As FoundBarcode() = reader.ReadFrom(PictureBox3.Image)

            For Each barcode As FoundBarcode In barcodes
                TextBox4.Text = barcode.Value
                MsgBox("QR تم اكتشافة!", MsgBoxStyle.Information)
                camera.Stop()
            Next
            reader.Dispose()
        Catch ex As Exception
            'MsgBox("QR لم يكتشف ال!", MsgBoxStyle.Critical)
        Finally
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        barcode()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label11.Text = Val(Label11.Text) + 1
        If Label11.Text = 1 Then
            barcode()
        ElseIf Label11.Text = 2 Then
            barcode()
        ElseIf Label11.Text = 3 Then
            barcode()
        ElseIf Label11.Text = 4 Then
            barcode()
            Label11.Text = 0
        End If
    End Sub
End Class