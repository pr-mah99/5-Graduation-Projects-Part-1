Imports System.Data.SqlClient
Imports System.IO

Public Class Employee
    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code_sql_Hr()
    End Sub
    Private Sub code_sql_Hr()
        Try
            Dim sql As String = "select id as 'التسلسل',fname as 'الاسم الاول',lname as 'الاسم الثاني',city as 'السكن',mobile as 'الهاتف',email as 'الايميل',work_type as 'نوع الوظيفه',Graduate as 'الشهادة',Scientific_title as 'اللقب العلمي',job_name as 'العمل',department_name as 'القسم',salary as 'الراتب' from Employee,job,department where department.department_id=Employee.department_id and job.job_id=Employee.job_id"
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
        Employee_Manage.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim searchQuery As String = "select id as 'التسلسل',fname as 'الاسم الاول',lname as 'الاسم الثاني',city as 'السكن',mobile as 'الهاتف',email as 'الايميل',work_type as 'نوع الوظيفه',Graduate as 'الشهادة',Scientific_title as 'اللقب العلمي',job_name as 'العمل',department_name as 'القسم',salary as 'الراتب' from employee,job,department where department.department_id=employee.department_id and job.job_id=employee.job_id and CONCAT(id ,fname,lname,department_name,city,mobile) like '%" & TextBox1.Text & "%'"
        Dim command As New SqlCommand(searchQuery, cn)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim form As New Employee_Manage
        form.TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        form.ShowDialog()
    End Sub
End Class