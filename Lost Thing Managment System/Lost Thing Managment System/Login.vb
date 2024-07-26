Imports System.Data.SqlClient

Public Class Login
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main.Show()
        Me.Close()
        'Try
        '    Dim sql As SqlCommand = New SqlCommand("Select * from Users where username='" + TextBox1.Text + "' And password='" + TextBox2.Text + "'", cn)
        '    Dim dt As New DataTable()
        '    cn.Open()
        '    Dim dataadapter As New SqlDataAdapter(sql)
        '    dataadapter.Fill(dt)
        '    If (dt.Rows.Count > 0) Then
        '        Main.Show()
        '        Me.Close()
        '    Else
        '        MsgBox("تفقد اسم المستخدم وكلمة المرور !!", MsgBoxStyle.Critical)
        '    End If
        '    cn.Close()
        'Catch ex As Exception
        '    MsgBox("حدث الخطأ !!", vbCritical)
        'End Try
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs)
        'If TextBox3.Text = "" Then
        '    MsgBox("ادخل اسم المستخدم رجاءاً !?", MsgBoxStyle.Critical)
        'Else
        '    Dim max As Integer
        '    Try
        '        Dim sql As String = "Select max(user_id) from Users"
        '        Dim command As New SqlCommand(sql, cn)
        '        cn.Open()
        '        Dim x = command.ExecuteScalar().ToString()
        '        max = x + 1
        '        cn.Close()
        '    Catch ex As Exception
        '    Finally
        '        cn.Close()
        '    End Try
        '    Try
        '        Dim sql As String = "INSERT INTO Users (user_id ,username,password,age,type)  " _
        '    & "VALUES ('" & max & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.Text & "')"
        '        Dim sda As New SqlDataAdapter(sql, cn)
        '        Dim cmd As New SqlCommand(sql, cn)
        '        cn.Open()
        '        cmd.ExecuteNonQuery()
        '        cn.Close()
        '        MsgBox("تم انشاء الحساب بنجاح", MsgBoxStyle.Information, "!!")
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical)
        '        MsgBox("حدث خطا ما ؟؟", MsgBoxStyle.Critical)
        '    Finally
        '        cn.Close()
        '    End Try
        'End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("ليس هنالك داعي للتسجيل, البرنامج مجاني للجميع", MsgBoxStyle.Exclamation)
    End Sub
End Class