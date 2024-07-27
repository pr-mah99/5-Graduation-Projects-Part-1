Imports System.Data.SqlClient
Imports System.IO
Imports DGVPrinterHelper

Public Class Employee
    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code_sql_Hr()
    End Sub
    Private Sub code_sql_Hr()
        Try
            Dim sql As String = "select id as 'التسلسل',fname as 'الاسم الاول',lname as 'الاسم الثاني',city as 'السكن',mobile as 'الهاتف',email as 'الايميل',work_type as 'نوع الوظيفه',Graduate as 'الشهادة',Scientific_title as 'اللقب العلمي',salary as 'الراتب' from Employee"
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Employee_Manage.ShowDialog()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Dim searchQuery As String = "select id as 'التسلسل',fname as 'الاسم الاول',lname as 'الاسم الثاني',city as 'السكن',mobile as 'الهاتف',email as 'الايميل',work_type as 'نوع الوظيفه',Graduate as 'الشهادة',Scientific_title as 'اللقب العلمي',salary as 'الراتب' from employee where CONCAT(id ,fname,lname,city,mobile) like '%" & TextBox1.Text & "%'"
            Dim command As New SqlCommand(searchQuery, cn)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim form As New Employee_Manage
        form.TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        form.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Printer = New DGVPrinter
        Printer.Title = "نظام أدارة موارد بشرية - طباعة بيانات الموظفين"
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