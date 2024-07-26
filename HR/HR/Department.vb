Imports System.Data.SqlClient

Public Class Department
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel2.Size = New Point(1217, 705)
        Panel2.Location = New Point(12, 12)
        Panel2.BringToFront()
        Panel2.Dock = DockStyle.Fill
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub fillItemName(sql As String, ItemName As ComboBox)
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
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select id_user From users WHERE fullname='" & ComboBox2.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox13.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox2.Text = "" Then
            MsgBox("عليك ان تحتار المدير", MsgBoxStyle.Information, "!!")
            ComboBox2.Focus()
        Else
            id_max()
            Try
                Dim sql As String = "INSERT INTO Department (department_id,department_name,location,manager)  " _
            & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox13.Text & "')"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                With cmd
                    cn.Open()
                    .ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم الادخال بنجاح", MsgBoxStyle.Information, "!!")
                    code_sql_Department()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("حدث خطا ما", MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub
    Private Sub id_max()
        Try
            Dim sql As String = "Select max(department_id) from Department"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Dim x = command.ExecuteScalar().ToString()
            Dim max = Val(x) + 1
            cn.Close()
            TextBox1.Text = max
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim sql As String = "select * from department where department_id=" & TextBox1.Text
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox2.Text = reader(1)
                TextBox3.Text = reader(2)
                TextBox13.Text = reader(3)
                cn.Close()
            End If
            Dim sql2 As String = "select * from users where id_user=" & TextBox1.Text
            Dim com2 As SqlCommand = New SqlCommand(sql2, cn)
            cn.Open()
            Dim reader2 As SqlDataReader = com2.ExecuteReader
            reader2.Read()
            If reader2.HasRows Then
                ComboBox2.Text = reader2(1)
                cn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Department_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code_sql_Department()
        fillItemName("select * from users where type_user='Manager'", ComboBox2)
    End Sub
    Private Sub code_sql_Department()
        Try
            Dim sql As String = "select department_id as 'الترتيب',department_name as 'القسم',location as 'الموقع',fullname as 'المدير' from Department,users where manager=id_user"
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذا القسم ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM department WHERE department_id =" & TextBox1.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
                code_sql_Department()
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim sql As String = "Update department set department_name='" & TextBox2.Text & "',Location='" & TextBox3.Text & "',manager='" & TextBox13.Text & "'where department_id='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم التحديث البيانات بنجاح")
            code_sql_Department()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox13.Text = ""
        ComboBox2.Text = ""
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        clear()
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        ComboBox2.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Dim sql As String = "select * from department where department_id=" & TextBox1.Text
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()

            If reader.HasRows Then
                TextBox2.Text = reader(1)
                TextBox3.Text = reader(2)
                TextBox13.Text = reader(3)
                cn.Close()
            End If

        Catch ex As Exception

            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
End Class