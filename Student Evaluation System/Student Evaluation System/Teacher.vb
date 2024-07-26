Imports System.Data.SqlClient

Public Class Teacher
    Private Sub fillItemName(sql As String, ItemName As ComboBox)
        'combo box الدالة الخاصة بال
        ItemName.Items.Clear()
        Dim adp As New SqlClient.SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            'combo box نختار اسم الحقل الي نريدة ان يظهر في ال 
            ItemName.Items.Add(dt.Rows(i).Item("fullname"))
        Next
    End Sub
    Private Sub Teacher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code()
        fillItemName("select * from Users where type_user='استاذ'", ComboBox1)
    End Sub
    Private Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox8.Text = ""
        ComboBox1.Text = ""
    End Sub
    Private Sub code()
        Try
            Dim sql As String = "select id_teacher as 'التسلسل' ,name as 'الاسم' ,age as 'العمر' ,specialty as 'التخصص' ,email as 'الايميل' ,mobile as 'الهاتف',user_id from Teacher"
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

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        FilterData2(TextBox7.Text)
    End Sub
    Public Sub FilterData2(valueToSearch As String)
        If TextBox7.Text = "" Then
            code()
        Else
            Dim searchQuery As String = "select id_teacher as 'التسلسل' ,name as 'الاسم' ,age as 'العمر' ,specialty as 'التخصص' ,email as 'الايميل' ,mobile as 'الهاتف',user_id from Teacher where CONCAT(name,specialty ,mobile,user_id) like '%" & valueToSearch & "%'"
            Dim command As New SqlCommand(searchQuery, cn)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim allow As String
        If TextBox2.Text = "" Then
            MsgBox("أدخل اسم الاستاذ رجاءاً", MsgBoxStyle.Critical)
        Else
            Try
                Dim sql As String = "Select max(id_teacher) from Teacher"
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
                If CheckBox1.Checked = True Then
                    allow = "True"
                Else
                    allow = "False"
                End If
                Dim sql As String = "INSERT INTO Teacher (id_teacher,name,age,specialty,email,mobile,user_id,allow)  " _
            & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox8.Text & "','" & allow & "')"
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim sql As String = "select * from Teacher where id_teacher ='" & TextBox1.Text & "'"
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
                TextBox8.Text = reader(6)
                Dim x = reader(7)
                If x = "True" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If
                cn.Close()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim allow As String
        If CheckBox1.Checked = True Then
            allow = "True"
        Else
            allow = "False"
        End If
        Try
            Dim sql As String = "Update Teacher set name='" & TextBox2.Text & "',age='" & TextBox3.Text & "',specialty='" & TextBox4.Text & "',email='" & TextBox5.Text & "',mobile='" & TextBox6.Text & "',user_id='" & TextBox8.Text & "',allow='" & allow & "' where id_teacher='" & TextBox1.Text & "'"
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
                Dim DeleteQuery As String = "DELETE FROM Teacher WHERE id_teacher =" & TextBox1.Text
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        clear()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select id_user From Users WHERE fullname='" & ComboBox1.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox8.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub
End Class