Imports System.Data.SqlClient

Public Class Student
    Private Sub Student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code()
        If Main.TextBox2.Text = "استاذ" Then
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
        End If
    End Sub
    Private Sub code()
        Try
            Dim sql As String = "select id_student as 'التسلسل',name as 'اسم الطالب',born as 'المواليد',level_student as 'المرحلة',city as 'السكن',mobile as 'الهاتف',email as 'الايميل',class as 'الصف' from student"
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

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        FilterData2(TextBox8.Text)
    End Sub
    Public Sub FilterData2(valueToSearch As String)
        If TextBox8.Text = "" Then
            code()
        Else
            Dim searchQuery As String = "select id_student as 'التسلسل',name as 'اسم الطالب',born as 'المواليد',level_student as 'المرحلة',city as 'السكن',mobile as 'الهاتف',email as 'الايميل',class as 'الصف' from student where CONCAT(name,mobile) like '%" & valueToSearch & "%'"
            Dim command As New SqlCommand(searchQuery, cn)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim sql As String = "select * from Student where id_student ='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox2.Text = reader(1)
                TextBox3.Text = reader(2)
                TextBox4.Text = reader(3)
                TextBox5.Text = reader(4)
                TextBox6.Text = reader(5)
                TextBox7.Text = reader(6)
                ComboBox2.Text = reader(7)
                cn.Close()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MsgBox("أدخل اسم الطالب رجاءاً", MsgBoxStyle.Critical)
        Else
            Try
                Dim sql As String = "Select max(id_student) from Student"
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
                Dim sql As String = "INSERT INTO Student (id_student,name,born,level_student,city,mobile,email,class)  " _
            & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & ComboBox2.Text & "')"
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
    Private Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذا الشي ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM Student WHERE id_student =" & TextBox1.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
                clear()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim sql As String = "Update Student set name='" & TextBox2.Text & "',born='" & TextBox3.Text & "',level_student='" & TextBox4.Text & "',city='" & TextBox5.Text & "',mobile='" & TextBox6.Text & "',email='" & TextBox7.Text & "',class='" & ComboBox2.Text & "'where id_student='" & TextBox1.Text & "'"
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

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim f As New Show_All
        f.TextBox2.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        f.ShowDialog()
    End Sub
End Class