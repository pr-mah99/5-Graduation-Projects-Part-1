Imports System.IO

Public Class C_SHA_2
    Dim LstFiles As New List(Of FileInfo)
    Dim EncryptDecryptFiles As New ClsEncryptDecryptFiles("VB.NET")
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim OFP As New OpenFileDialog
        OFP.Multiselect = True
        OFP.Filter = "Application|*.exe|Icon|*.ico|Image|*.jpg|PNG|*.PNG|PDF|*.PDF"
        If OFP.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each F In OFP.FileNames
                Dim File = New FileInfo(F)
                LstFiles.Add(File)
                CheckedListBoxListFiles.Items.Add(File.Name)
            Next
            'LblCountFile.Text = LstFiles.Count
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Th As New Threading.Thread(AddressOf Encrypt)
        Th.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Th As New Threading.Thread(AddressOf Decrypt)
        Th.Start()
    End Sub

    Private Sub C_SHA_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
    End Sub
    Sub Encrypt()

        Button3.Enabled = False
        Button2.Enabled = True

        For i = 0 To LstFiles.Count - 1

            Try

                Dim FileEncrypted = EncryptDecryptFiles.Encryption(LstFiles.Item(i).FullName)

                If FileEncrypted.Length > 0 Then

                    My.Computer.FileSystem.WriteAllBytes(LstFiles.Item(i).FullName, FileEncrypted, False)

                    CheckedListBoxListFiles.SetItemCheckState(i, CheckState.Checked)

                    CheckedListBoxListFiles.SetSelected(i, True)

                    Label2.Text = "تم تشفير الملف بنجاح"

                End If

            Catch ex As Exception

            End Try

            Threading.Thread.Sleep(100)

        Next
    End Sub

    Sub Decrypt()

        Button3.Enabled = True
        Button2.Enabled = False

        For i = 0 To LstFiles.Count - 1

            Try

                Dim FileEncrypted = EncryptDecryptFiles.Decryption(LstFiles.Item(i).FullName)

                If FileEncrypted.Length > 0 Then

                    My.Computer.FileSystem.WriteAllBytes(LstFiles.Item(i).FullName, FileEncrypted, False)

                    CheckedListBoxListFiles.SetItemCheckState(i, CheckState.Checked)

                    CheckedListBoxListFiles.SetSelected(i, True)

                    Label2.Text = "تم فك تشفير الملف بنجاح"
                End If

            Catch ex As Exception
            End Try
            Threading.Thread.Sleep(100)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main.Show()
        Me.Close()
    End Sub
End Class