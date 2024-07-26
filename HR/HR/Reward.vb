Imports System.Data.SqlClient

Public Class Reward
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel2.Size = New Point(1217, 705)
        Panel2.Location = New Point(12, 12)
        Panel2.BringToFront()
        Panel2.Dock = DockStyle.Fill
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        Button5.PerformClick()
        ComboBox1.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
    End Sub

    Private Sub Reward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code_sql_Reward()
        fillItemName("select * from Employee", ComboBox1)
    End Sub
    Private Sub code_sql_Reward()
        Try
            Dim sql As String = "select Reward.id as 'التسلسل',fname as 'الاسم الاول',lname as 'الاسم الثاني',reward as 'عدد المكافئات',date as 'التاريخ',time as 'الوقت',Note as 'ملاحظة' from Reward,Employee where Employee_id=Employee.id"
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

    Private Sub id_max()
        Try
            Dim sql As String = "Select max(id) from Reward"
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MsgBox("عليك ان تحتار الموظف", MsgBoxStyle.Information, "!!")
            ComboBox1.Focus()
        Else
            id_max()
            Try
                Dim sql As String = "INSERT INTO Reward (id,reward,Employee_id,date,Note)  " _
            & "VALUES ('" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Value.Date & "','" & TextBox4.Text & "')"
                Dim cmd As New SqlCommand(sql, cn)
                With cmd
                    cn.Open()
                    .ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم مكافئة هذا الموظف بنجاح", MsgBoxStyle.Information, "!!")
                    code_sql_Reward()
                    clear()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("حدث خطا ما", MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim sql As String = "Update Reward set Employee_id='" & TextBox2.Text & "',reward='" & TextBox3.Text & "',Note='" & TextBox4.Text & "' where id='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم التحديث البيانات بنجاح")
            code_sql_Reward()
            clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ComboBox1.Text = "" Then
            MsgBox("عليك ان تختار الموظف اولاً", MsgBoxStyle.Information, "!!")
            ComboBox1.Focus()
        Else
            Try
                If MsgBox("هل انت متاكد اسقاط المكافاءة عن هذا الشخص ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                    'Delete Code
                    Dim DeleteQuery As String = "DELETE FROM Reward WHERE id =" & TextBox1.Text
                    Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                    Dim com = New SqlCommand(DeleteQuery, cn)
                    cn.Open()
                    com.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم اسقاط المكافاءة بنجاح", MsgBoxStyle.Information, "Warning !")
                    code_sql_Reward()
                    clear()
                ElseIf DialogResult.No Then
                    MsgBox("تم الغاء عملية الاسقاط", MsgBoxStyle.Information, "Warning !")
                Else
                    MsgBox("غير موجود", "حدث خطا ما !!")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cn.Close()
            End Try
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select id From Employee WHERE fname='" & ComboBox1.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox2.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim xx = TextBox1.Text
        clear()
        TextBox1.Text = xx
        Try
            Dim sql As String = "select * from Reward where id=" & TextBox1.Text
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            Dim x
            If reader.HasRows Then
                x = reader(1)
                TextBox2.Text = reader(2)
                TextBox4.Text = reader(5)
                DateTimePicker1.Value = reader(3)
                cn.Close()
            End If
            TextBox3.Text = x
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
        TextBox4.Text = ""
        ComboBox1.Text = ""
    End Sub
    Private Sub fillItemName(sql As String, ItemName As ComboBox)
        ItemName.Items.Clear()
        Dim adp As New SqlClient.SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            'combo box نختار اسم الحقل الي نريدة ان يظهر في ال 
            ItemName.Items.Add(dt.Rows(i).Item("fname"))
        Next
    End Sub
End Class