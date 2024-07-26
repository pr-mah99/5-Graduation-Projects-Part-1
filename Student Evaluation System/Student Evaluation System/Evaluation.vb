Imports System.Data.SqlClient

Public Class Evaluation
    Private Sub fillItemName(sql As String, ItemName As ComboBox)
        'combo box الدالة الخاصة بال
        ItemName.Items.Clear()
        Dim adp As New SqlClient.SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            'combo box نختار اسم الحقل الي نريدة ان يظهر في ال 
            ItemName.Items.Add(dt.Rows(i).Item("Subject"))
        Next
    End Sub
    Private Sub Evaluation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Student()
        Teacher()
        fillItemName("select * from Subject", ComboBox1)
    End Sub
    Private Sub Student()
        Try
            Dim sql As String = "select id_student as 'التسلسل',name as 'اسم الطالب',level_student as 'المرحلة' from student"
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
    Private Sub Teacher()
        Dim sql As String = "select id_teacher as 'التسلسل' ,name as 'الاسم',specialty as 'التخصص' from Teacher where allow='True' and id_teacher='" & Main.TextBox1.Text & "'"
        Dim dataadapter As New SqlDataAdapter(sql, cn)
        Dim ds As New DataSet()
        cn.Open()
        dataadapter.Fill(ds, "column_name")
        cn.Close()
        DataGridView2.DataSource = ds
        DataGridView2.DataMember = "column_name"
        'Try
        '    If Main.TextBox2.Text = "مدير" Then
        '        Dim sql As String = "select id_teacher as 'التسلسل' ,name as 'الاسم',specialty as 'التخصص' from Teacher"
        '        Dim dataadapter As New SqlDataAdapter(sql, cn)
        '        Dim ds As New DataSet()
        '        cn.Open()
        '        dataadapter.Fill(ds, "column_name")
        '        cn.Close()
        '        DataGridView2.DataSource = ds
        '        DataGridView2.DataMember = "column_name"
        '    Else
        '        Dim sql As String = "select id_teacher as 'التسلسل' ,name as 'الاسم',specialty as 'التخصص' from Teacher where id_teacher='" & Main.TextBox1.Text & "'"
        '        Dim dataadapter As New SqlDataAdapter(sql, cn)
        '        Dim ds As New DataSet()
        '        cn.Open()
        '        dataadapter.Fill(ds, "column_name")
        '        cn.Close()
        '        DataGridView2.DataSource = ds
        '        DataGridView2.DataMember = "column_name"
        '    End If
        'Catch ex As Exception

        'Finally
        '    cn.Close()
        'End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If Main.TextBox2.Text = "مدير" Then
            Dim f As New Show_All
            f.TextBox3.Text = "show"
            f.ShowDialog()
        Else
            Show_All.Show()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            MsgBox("أدخل درجة تقيم الطالب رجاءاً", MsgBoxStyle.Critical)
        Else
            Try
                Dim sql As String = "Select max(id) from Assess"
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
                Dim sql As String = "INSERT INTO Assess (id,Assess,student,teacher,Subject)  " _
            & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم ادخال البيانات بنجاح", MsgBoxStyle.Information, "!!")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                MsgBox("حدث خطا ؟؟", MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Try
            Dim sql2 As String = "Select id_student From Student WHERE name='" & TextBox3.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox5.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Try
            Dim sql2 As String = "Select id_teacher From Teacher WHERE name='" & TextBox4.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox6.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
            TextBox6.Clear()
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select id From Subject WHERE Subject='" & ComboBox1.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox7.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox3.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        TextBox4.Text = DataGridView2.CurrentRow.Cells(1).Value.ToString()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذا الشي ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM Assess WHERE id =" & TextBox1.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox6.Text = "" Then
            MsgBox("قم باختيار الاستاذ اولاً", MsgBoxStyle.Information, "Warning !")
        Else
            Try
                Dim sql As String = "Update Assess set Assess='" & TextBox2.Text & "' where id='" & TextBox1.Text & "' and teacher='" & TextBox6.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم التحديث بنجاح", MsgBoxStyle.Information, "Warning !")
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cn.Close()
            End Try
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
        ComboBox1.Text = ""
        'Try
        '    Dim sql As String = "select * from Assess where id ='" & TextBox1.Text & "'"
        '    Dim sda As New SqlDataAdapter(sql, cn)
        '    Dim com As SqlCommand = New SqlCommand(sql, cn)
        '    cn.Open()
        '    Dim reader As SqlDataReader = com.ExecuteReader
        '    reader.Read()
        '    If reader.HasRows Then
        '        TextBox2.Text = reader(1)
        '        TextBox5.Text = reader(3)
        '        TextBox6.Text = reader(4)
        '        TextBox7.Text = reader(5)
        '        cn.Close()
        '    End If
        'Catch ex As Exception
        '    'MsgBox(ex.Message)
        'Finally
        '    cn.Close()
        'End Try
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text = "" Then
            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Enabled = False
        Else
            Button1.Enabled = True
            Button2.Enabled = True
            Button4.Enabled = True
        End If
    End Sub
End Class