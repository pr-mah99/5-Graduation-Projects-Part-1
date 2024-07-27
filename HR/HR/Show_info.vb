Imports System.Data.SqlClient
Imports DGVPrinterHelper

Public Class Show_info
    Private Sub code_sql_Bonuses()
        Try
            Dim sql As String = "select Bonuses.id as 'رقم المكافئة', employee.id as 'رقم الموظف',fname as 'الاسم الاول',lname as 'الاسم الثاني',city as 'السكن',mobile as 'الهاتف',bonuses as 'المكاقئة',Bonuses.date as 'التاريخ',time as 'الوقت',Note as 'ملاحظة' from Employee,Bonuses where employee_id =employee.id"
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
    Private Sub code_sql_Upgrades()
        Try
            Dim sql As String = "select Upgrades.id as 'رقم الترفيع',employee_id as 'رقم الموظف',fname as 'الاسم الاول',lname as 'الاسم الثاني',city as 'السكن',mobile as 'الهاتف',Upgrades as 'الترفيع',Upgrades.date as 'التاريخ',time as 'الوقت',Note as 'سبب الترفيع' from Employee,Upgrades where employee_id =employee.id"
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
    Private Sub code_sql_Bonuses_sort()
        Try
            Dim sql As String = "select Bonuses.id as 'رقم العلاوة', employee.id as 'رقم الموظف',fname as 'الاسم الاول',lname as 'الاسم الثاني',city as 'السكن',mobile as 'الهاتف',bonuses as 'المكاقئة',Bonuses.date as 'التاريخ',time as 'الوقت',Note as 'ملاحظة' from Employee,Bonuses where employee_id =employee.id and Bonuses.date='" & DateTimePicker1.Value & "'"
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
    Private Sub code_sql_Upgrades_sort()
        Try
            Dim sql As String = "select Upgrades.id as 'رقم الترفيع',employee_id as 'رقم الموظف',fname as 'الاسم الاول',lname as 'الاسم الثاني',city as 'السكن',mobile as 'الهاتف',Upgrades as 'الترفيع',Upgrades.date as 'التاريخ',time as 'الوقت',Note as 'سبب العقوبة' from Employee,Upgrades where employee_id =employee.id and Upgrades.date='" & DateTimePicker1.Value & "'"
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

    Private Sub code_sql_Bonuses_total()
        Try
            Dim sql As String = "select Employee.fname as 'الاسم',Employee.lname as 'اسم الاب',city as 'السكن',COUNT(*) as 'أجمالي العلاوات' from Bonuses,Employee where employee_id=Employee.id group by Employee.fname,Employee.lname,city"
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
    Private Sub code_sql_Upgrades_total()
        Try
            Dim sql As String = "select Employee.fname as 'الاسم',Employee.lname as 'اسم الاب',city as 'السكن',COUNT(*) as 'أجمالي الترفيعات' from Upgrades,Employee where employee_id=Employee.id group by Employee.fname,Employee.lname,city"
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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "Bonuses" Then
            code_sql_Bonuses()
            ComboBox2.Text = "العلاوات"
        ElseIf TextBox1.Text = "Upgrades" Then
            code_sql_Upgrades()
            ComboBox2.Text = "الترفيعات"
        End If
    End Sub

    Private Sub Show_info_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "True" Then
            If TextBox1.Text = "Bonuses" Then
                code_sql_Bonuses_sort()
            ElseIf TextBox1.Text = "Upgrades" Then
                code_sql_Upgrades_sort()
            End If
        Else
            If TextBox1.Text = "Bonuses" Then
                code_sql_Bonuses()
            ElseIf TextBox1.Text = "Upgrades" Then
                code_sql_Upgrades()
            End If
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If TextBox1.Text = "Bonuses" Then
            code_sql_Bonuses_sort()
        ElseIf TextBox1.Text = "Upgrades" Then
            code_sql_Upgrades_sort()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "العلاوات" Then
            code_sql_Bonuses_total()
        ElseIf ComboBox1.Text = "الترفيعات" Then
            code_sql_Upgrades_total()
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "احصائية" Then
            Label2.Visible = True
            ComboBox1.Visible = True
            code_sql_Bonuses_total()
        ElseIf ComboBox2.Text = "العلاوات" Then
            code_sql_Bonuses()
            Label2.Visible = False
            ComboBox1.Visible = False
        ElseIf ComboBox2.Text = "الترفيعات" Then
            Label2.Visible = False
            ComboBox1.Visible = False
            code_sql_Upgrades()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Printer = New DGVPrinter
        Printer.Title = "نظام أدارة موارد بشرية"
        Printer.SubTitle = "-------------------------------------------------"
        Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
        Printer.PageNumbers = True
        Printer.PageNumberInHeader = False
        Printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional
        Printer.HeaderCellAlignment = StringAlignment.Near
        Printer.Footer = "Employee"
        Printer.FooterSpacing = 15
        Printer.PrintDataGridView(DataGridView1)
    End Sub
End Class