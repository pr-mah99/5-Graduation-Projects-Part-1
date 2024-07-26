Imports System.Data.SqlClient

Public Class login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim sql As SqlCommand = New SqlCommand("Select * from Users where username='" + TextBox1.Text + "' And password='" + TextBox2.Text + "'", cn)
            Dim dt As New DataTable()
            cn.Open()
            Dim dataadapter As New SqlDataAdapter(sql)
            dataadapter.Fill(dt)
            If (dt.Rows.Count > 0) Then
                Main.Show()
                Main.Button1.PerformClick()
                Me.Close()
            Else
                MsgBox("تفقد اسم المستخدم وكلمة المرور", MsgBoxStyle.Critical)
            End If
            cn.Close()
        Catch ex As Exception
            MsgBox("Erorr !!", vbCritical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class