Imports System.Data.SqlClient

Public Class Show_A_D
    Private Sub Show_A_D_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code()
    End Sub
    Private Sub code()
        Try
            Dim sql As String = "select Employee.id as 'التسلسل' ,fname as 'الاسم الاول' ,lname as 'الاسم الثاني',Attendance As 'تاريخ الحضور',departure As 'تاريخ الانصراف'  from Employee,Attendance,departure where Attendance.employee_id=employee.id and departure.employee_id=employee.id"
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
End Class