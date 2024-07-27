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

    Private Sub Employee_Manage_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Main.Button2.PerformClick()
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Dim sql As String = "select fname ,lname ,born_in,city,mobile,email,work_type,Graduate,Scientific_title,salary from Employee where id=" & TextBox1.Text
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
                cn.Close()
            Else
                clear()
            End If

        Catch ex As Exception

            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
        If TextBox1.Text = "" Then
            Button6.Enabled = False
        Else
            Button6.Enabled = True
        End If
        total()
    End Sub
    Private Sub clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
    End Sub

    Private Sub total()
        Dim year As Integer = DateTime.Now.Year
        Dim firstDayOfYear As New DateTime(year, 1, 1) '2023/1/1

        Dim daysInMonth As Integer = DateTime.DaysInMonth(year, 12)
        Dim lastDayOfYear As New DateTime(year, 12, daysInMonth) '2023/12/30

        Dim bonus = 3 'العلاوات المستحقة في السنة 3
        Dim previous_bonus As New Integer 'العلاوة السابقة
        Dim bonus_due As New Integer 'العلاوة المستحقة
        Dim Thank_books As New Integer 'كتب الشكر والتقدير

        Dim sql_Acknowledgments As String = "select count(*) from Acknowledgments WHERE emp='" + TextBox1.Text + "' And date BETWEEN '" + firstDayOfYear + "' and '" + lastDayOfYear + "'"
        Dim sql2 As String = "select count(*) from Upgrades WHERE employee_id='" + TextBox1.Text + "' And date BETWEEN '" + firstDayOfYear + "' and '" + lastDayOfYear + "'"
        Dim sqlbonus As String = "select count(*) from Bonuses WHERE employee_id='" + TextBox1.Text + "' And date BETWEEN '" + firstDayOfYear + "' and '" + lastDayOfYear + "'"

        Dim command1 As New SqlCommand(sql_Acknowledgments, cn)
        Dim command2 As New SqlCommand(sql2, cn)
        Dim command_bonus As New SqlCommand(sqlbonus, cn)

        cn.Open()
        Thank_books = Convert.ToInt32(command1.ExecuteScalar().ToString()) 'كتب الشكر والتقدير   
        previous_bonus = Convert.ToInt32(command_bonus.ExecuteScalar().ToString()) 'العلاوات السابقة
        bonus_due = bonus - previous_bonus 'العلاوة المستحقة = العلاوة السابقة - كل العلاوات
        cn.Close()

        Dim x = "العلاوة السابقة : " + previous_bonus.ToString + " / العلاوة المستحقة : " + bonus_due.ToString
        Dim r1 = Thank_books - previous_bonus
        Dim r2 = Thank_books - previous_bonus
        Dim total = "العلاوة السابقة - عدد كتب شكر وتقدير :" + r1.ToString + " / ترفيعات - عدد كتب شكر وتقدير :" + r2.ToString

        Label2.Text = x.ToString
        Label1.Text = total.ToString
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
        If TextBox2.Text = "" Then
            MsgBox("أدخل اسم الموظف اولا", MsgBoxStyle.Information, "!!")
            TextBox2.Focus()
        Else
            id_max()
            Try
                Dim sql As String = "INSERT INTO Employee (id,fname,lname,born_in,city,mobile,email,work_type,Graduate,Scientific_title,salary)  " _
            & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "')"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                With cmd
                    cn.Open()
                    .ExecuteNonQuery()
                    cn.Close()
                    upate_image()
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
            Dim sql As String = "Update Employee set fname='" & TextBox2.Text & "',lname='" & TextBox3.Text & "',born_in='" & TextBox4.Text & "',city='" & TextBox5.Text & "',mobile='" & TextBox6.Text & "',email='" & TextBox7.Text & "',work_type='" & TextBox8.Text & "',Graduate='" & TextBox9.Text & "',Scientific_title='" & TextBox10.Text & "',salary='" & TextBox11.Text & "' where id='" & TextBox1.Text & "'"
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Acknowledgments.Show()
        Acknowledgments.TextBox2.Text = TextBox1.Text
        Acknowledgments.ComboBox1.Text = TextBox2.Text
    End Sub
End Class