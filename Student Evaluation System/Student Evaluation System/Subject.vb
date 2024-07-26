Imports System.Data.SqlClient

Public Class Subject
    Private Sub Subject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code()
    End Sub
    Private Sub code()
        Try
            Dim sql As String = "select id as 'التسلسل', Subject as 'المادة',Date as 'التاريخ',Time as 'الوقت' from Subject"
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

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        FilterData2(TextBox5.Text)
    End Sub
    Public Sub FilterData2(valueToSearch As String)
        If TextBox5.Text = "" Then
            code()
        Else
            Dim searchQuery As String = "select id as 'التسلسل', Subject as 'المادة',Date as 'التاريخ',Time as 'الوقت' from Subject where Subject like '%" & valueToSearch & "%'"
            Dim command As New SqlCommand(searchQuery, cn)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim sql As String = "select * from Subject where id ='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox2.Text = reader(1)
                DateTimePicker1.Value = reader(2)
                cn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MsgBox("أدخل اسم الطالب رجاءاً", MsgBoxStyle.Critical)
        Else
            Try
                Dim sql As String = "Select max(id) from Subject"
                Dim command As New SqlCommand(sql, cn)
                cn.Open()
                Dim x = command.ExecuteScalar().ToString()
                TextBox1.Text = Val(x) + 1
                cn.Close()
            Catch ex As Exception
            Finally
                cn.Close()
            End Try
            Try
                Dim sql As String = "INSERT INTO Subject (id,Subject,Date,Time)  " _
            & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Value.Date & "','" & DateTimePicker2.Value.ToShortTimeString & "')"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم ادخال البيانات بنجاح", MsgBoxStyle.Information, "!!")
                code()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                MsgBox("حدث خطا ؟؟", MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim sql As String = "Update Subject set Subject='" & TextBox2.Text & "',Date='" & DateTimePicker1.Value.Date & "',Time='" & DateTimePicker2.Value.ToLocalTime & "'where id='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم التحديث بنجاح", MsgBoxStyle.Information, "Warning !")
            code()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذا الشي ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM Subject WHERE id =" & TextBox1.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
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
End Class