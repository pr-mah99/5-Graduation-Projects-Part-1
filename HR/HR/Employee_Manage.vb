Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO

Public Class Employee_Manage

    Private Sub id_max()
        Try
            Dim sql As String = "Select max(id) from Employee"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Dim x = command.ExecuteScalar().ToString()
            Dim max = x + 1
            cn.Close()
            TextBox1.Text = max
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub fillItemName_department(sql As String, ItemName As ComboBox)
        ItemName.Items.Clear()
        Dim adp As New SqlClient.SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            'combo box نختار اسم الحقل الي نريدة ان يظهر في ال 
            ItemName.Items.Add(dt.Rows(i).Item("department_name"))
        Next
    End Sub
    Private Sub fillItemName_job(sql As String, ItemName As ComboBox)
        ItemName.Items.Clear()
        Dim adp As New SqlClient.SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            'combo box نختار اسم الحقل الي نريدة ان يظهر في ال 
            ItemName.Items.Add(dt.Rows(i).Item("job_name"))
        Next
    End Sub
    Private Sub img()
        Try
            Dim cmd As New SqlCommand("select image from Employee where id='" & TextBox1.Text & "'", cn)
            cn.Open()
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            cn.Close()
            PictureBox1.Image = Image.FromStream(ImgStream)
        Catch ex As Exception

            PictureBox1.Image = Nothing
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub upate_image()
        Try
            Dim ms As New MemoryStream
            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
            Dim arrPic() As Byte = ms.GetBuffer()
            Dim command As New SqlCommand("update Employee set image=@emPic where id='" & TextBox1.Text & "'", cn)
            With command
                .Parameters.AddWithValue("@emPic", SqlDbType.Image).Value = ms.ToArray
                cn.Open()
                .ExecuteNonQuery()
                cn.Close()
                MsgBox("Saved Done")
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Employee_Manage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillItemName_job("select * from job", ComboBox1)
        fillItemName_department("select * from Department", ComboBox2)
    End Sub

    Private Sub Employee_Manage_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Main.Button2.PerformClick()
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Dim sql As String = "select fname ,lname ,born_in,city,mobile,email,work_type,Graduate,Scientific_title,salary,job_name,department_name,Employee.department_id,Employee.job_id from Employee,job,department where department.department_id=Employee.department_id and job.job_id=Employee.job_id and id=" & TextBox1.Text
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            img()
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()

            If reader.HasRows Then
                TextBox2.Text = reader(0)
                TextBox3.Text = reader(1)
                TextBox4.Text = reader(2)
                TextBox5.Text = reader(3)
                TextBox6.Text = reader(4)
                TextBox7.Text = reader(5)
                TextBox8.Text = reader(6)
                TextBox9.Text = reader(7)
                TextBox10.Text = reader(8)
                TextBox11.Text = reader(9)
                TextBox12.Text = reader(13)
                TextBox13.Text = reader(12)
                ComboBox1.Text = reader(10)
                ComboBox2.Text = reader(11)
                cn.Close()
            End If

        Catch ex As Exception

            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذا الشخص ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM Employee WHERE id =" & TextBox1.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
                'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
                'أعادة استدعاء للبيانات لغرض التحديث                
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

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Then
            MsgBox("عليك ان تحتار العمل", MsgBoxStyle.Information, "!!")
            ComboBox1.Focus()
        ElseIf ComboBox2.Text = "" Then
            MsgBox("يجب اختيار القسم", MsgBoxStyle.Information, "!!")
            ComboBox2.Focus()
        Else
            id_max()
            Try
                Dim ms As New MemoryStream
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                Dim arrPic() As Byte = ms.GetBuffer()
                Dim sql As String = "INSERT INTO Employee (id,fname,lname,born_in,city,mobile,email,work_type,Graduate,Scientific_title,salary,image,job_id,department_id)  " _
            & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "','@emPic','" & TextBox12.Text & "','" & TextBox13.Text & "')"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                With cmd
                    .Parameters.AddWithValue("@emPic", SqlDbType.Image).Value = ms.ToArray
                    cn.Open()
                    .ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم الادخال بنجاح", MsgBoxStyle.Information, "!!")
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("حدث خطا ما", MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim sql As String = "Update Employee set fname='" & TextBox2.Text & "',lname='" & TextBox3.Text & "',born_in='" & TextBox4.Text & "',city='" & TextBox5.Text & "',mobile='" & TextBox6.Text & "',email='" & TextBox7.Text & "',work_type='" & TextBox8.Text & "',Graduate='" & TextBox9.Text & "',Scientific_title='" & TextBox10.Text & "',salary='" & TextBox11.Text & "',job_id='" & TextBox12.Text & "',department_id='" & TextBox13.Text & "'where id='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            upate_image()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select job_id From job WHERE job_name='" & ComboBox1.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox12.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select department_id From Department WHERE department_name='" & ComboBox2.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox13.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With OpenFileDialog1
            'المكان الافتراضي
            .InitialDirectory = Application.StartupPath & "\images"
            'فلاتر امتداد الملفات
            .Filter = "JPEG Files|*.jpg|AllFiles|*.*"
            .FilterIndex = 1
        End With
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub
End Class