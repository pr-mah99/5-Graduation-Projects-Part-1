Imports System.Data.SqlClient
Imports DGVPrinterHelper

Public Class Bonuses
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel2.Size = New Point(1217, 705)
        Panel2.Location = New Point(12, 12)
        Panel2.BringToFront()
        Panel2.Dock = DockStyle.Fill
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
            TextBox3.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString()
            DateTimePicker1.Value = DataGridView1.CurrentRow.Cells(4).Value
            Dim timeValue As TimeSpan = TimeSpan.Parse(DataGridView1.CurrentRow.Cells(5).Value.ToString())
            DateTimePicker2.Value = DateTime.Today + timeValue
            TextBox4.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Reward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code_sql_Reward()
        fillItemName("select * from Employee", ComboBox1)
    End Sub
    Private Sub code_sql_Reward()
        Try
            Dim sql As String = "select Bonuses.id as 'التسلسل',fname as 'الاسم الاول',lname as 'الاسم الثاني',bonuses as 'العلاوة',date as 'التاريخ',time as 'الوقت',Note as 'ملاحظة' from Bonuses,Employee where Employee_id=Employee.id"
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
            Dim sql As String = "Select max(id) from Bonuses"
            Dim command As New SqlCommand(sql, cn)
            'cn.Open()
            Dim x = command.ExecuteScalar().ToString()
            Dim max = Val(x) + 1
            cn.Close()
            TextBox1.Text = max
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MsgBox("عليك ان تحتار الموظف", MsgBoxStyle.Information, "!!")
            ComboBox1.Focus()
        Else
            Dim year As Integer = DateTime.Now.Year
            Dim firstDayOfYear As New DateTime(year, 1, 1) '2023/1/1

            Dim daysInMonth As Integer = DateTime.DaysInMonth(year, 12)
            Dim lastDayOfYear As New DateTime(year, 12, daysInMonth) '2023/12/30

            Try
                Dim sql As SqlCommand = New SqlCommand("Select * from Bonuses where Employee_id='" + TextBox2.Text + "' And date BETWEEN '" + firstDayOfYear.ToString("yyyy-MM-dd") + "' and '" + lastDayOfYear.ToString("yyyy-MM-dd") + "'", cn)
                Dim dt As New DataTable()
                cn.Open()
                Dim dataadapter As New SqlDataAdapter(sql)
                dataadapter.Fill(dt)
                If (dt.Rows.Count > 2) Then
                    MsgBox("لا يمكن , لان الموظف لدية 3 علاوات بالفعل", MsgBoxStyle.Critical)
                Else
                    id_max()
                    Try
                        Dim sql2 As String = "INSERT INTO Bonuses (id,bonuses,Employee_id,date,Note)  " _
            & "VALUES ('" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Value.Date & "','" & TextBox4.Text & "')"
                        Dim cmd As New SqlCommand(sql2, cn)
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
                cn.Close()
            Catch ex As Exception
                'MsgBox(ex.Message, vbCritical)
                ''MsgBox("Erorr !!", vbCritical)
            Finally
                cn.Close()
            End Try


        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim sql As String = "Update Bonuses set Employee_id='" & TextBox2.Text & "',bonuses='" & TextBox3.Text & "',Note='" & TextBox4.Text & "' where id='" & TextBox1.Text & "'"
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
                    Dim DeleteQuery As String = "DELETE FROM Bonuses WHERE id =" & TextBox1.Text
                    Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                    Dim com = New SqlCommand(DeleteQuery, cn)
                    cn.Open()
                    com.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم اسقاط العلاوات بنجاح", MsgBoxStyle.Information, "Warning !")
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

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Dim xx = TextBox1.Text
        clear()
        TextBox1.Text = xx
        Try
            Dim sql As String = "select * from Reward where id=" & TextBox1.Text
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox3.Text = reader(1)
                TextBox2.Text = reader(2)
                TextBox4.Text = reader(5)
                DateTimePicker1.Value = reader(3)
            End If
            cn.Close()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Printer = New DGVPrinter
        Printer.Title = "نظام أدارة موارد بشرية - طباعة علاوات الموظفين"
        Printer.SubTitle = "-------------------------------------------------"
        Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
        Printer.PageNumbers = True
        Printer.PageNumberInHeader = False
        Printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional
        Printer.HeaderCellAlignment = StringAlignment.Near
        Printer.Footer = "Reward"
        Printer.FooterSpacing = 15
        Printer.PrintDataGridView(DataGridView1)
    End Sub
End Class