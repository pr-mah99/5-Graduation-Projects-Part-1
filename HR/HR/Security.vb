Imports System.Data.SqlClient

Public Class Security
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dlg As FolderBrowserDialog = New FolderBrowserDialog()
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = dlg.SelectedPath
            Button4.Visible = False
            Button3.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dlg As OpenFileDialog = New OpenFileDialog()
        dlg.Filter = "SQL SERVER database backup ملف|*.bak"
        dlg.Title = "أستعادة قاعدة البيانات"
        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = dlg.FileName
            Button3.Visible = False
            Button4.Visible = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim database As String = cn.Database.ToString
        Try
            If TextBox2.Text Is String.Empty Then
                MsgBox("الرجاء حفظ مسار الملف النسخة الاحتياطية")
            Else
                Dim cmd As String = "BACKUP DATABASE [" + database + "] TO DISK='" + TextBox2.Text + "\" + "database" + "-" + Date.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'"
                Using Command As SqlCommand = New SqlCommand(cmd, cn)
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If
                    Command.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم أنشاء قاعدة البيانات بنجاح", MsgBoxStyle.MsgBoxRight)
                    Process.Start(TextBox2.Text)
                    Button3.Enabled = False
                End Using
            End If
        Catch ex As Exception
            MsgBox("حدث خطا" + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim database As String = cn.Database.ToString()
        If cn.State <> ConnectionState.Open Then
            cn.Open()
        End If
        Try
            Dim sqlStmt2 As String = String.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE")
            Dim bu2 As SqlCommand = New SqlCommand(sqlStmt2, cn)
            bu2.ExecuteNonQuery()
            Dim sqlStmt3 As String = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + TextBox2.Text + "'WITH REPLACE"
            Dim bu3 As SqlCommand = New SqlCommand(sqlStmt3, cn)
            bu3.ExecuteNonQuery()
            Dim sqlStmt4 As String = String.Format("ALTER DATABASE [" + database + "] SET MULTI_USER")
            Dim bu4 As New SqlCommand(sqlStmt4, cn)
            bu4.ExecuteNonQuery()
            MsgBox("تم أستعادة قاعدة بيانات بنجاح", MsgBoxStyle.Information)
            Button4.Enabled = False
            cn.Close()
        Catch ex As Exception
            MsgBox("حدث خطا" + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Security_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class