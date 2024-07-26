Imports System.Data.SqlClient

Public Class Attendance_and_Departure
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'انصراف
        TextBox1.Text = ""
        TextBox2.Text = ""
        Button2.ForeColor = Color.Gray
        Button1.ForeColor = Color.Black
        'DataGridView1.Enabled = False
        Label1.Visible = False
        'DataGridView2.Enabled = True
        Label2.Visible = True
        code_sql_leaving()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'الحضور
        TextBox1.Text = ""
        TextBox2.Text = ""
        Button1.ForeColor = Color.Gray
        Button2.ForeColor = Color.Black
        'DataGridView1.Enabled = True
        Label1.Visible = True
        'DataGridView2.Enabled = False
        Label2.Visible = False
        code_sql_comming()
    End Sub

    Private Sub Attendance_and_Departure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code_sql_all()
    End Sub
    Private Sub code_sql_comming()
        Try
            'Dim sql As String = "select * from Attendance"
            Dim sql As String = "select Employee.id as 'التسلسل' ,fname as 'الاسم الاول' ,lname as 'الاسم الثاني',Attendance As 'تاريخ الحضور' from Employee,Attendance where Attendance.employee_id=employee.id and Attendance='" & Label3.Text & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "column_name"
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub code_sql_leaving()
        Try

            Dim sql As String = "select Employee.id as 'التسلسل' ,fname as 'الاسم الاول' ,lname as 'الاسم الثاني',departure As 'تاريخ الانصراف' from Employee,departure where departure.employee_id=employee.id and departure='" & Label3.Text & "'"
            'Dim sql As String = "select * from Departure"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "column_name"
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub code_sql_all()
        Try
            Dim sql As String = "select Employee.id as 'التسلسل' ,fname as 'الاسم الاول' ,lname as 'الاسم الثاني'from Employee"
            'Dim sql As String = "select * from Departure"
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = Now.ToString("yyyy/MM/dd")
        Label4.Text = Now.ToString("HH:mm:ss tt")
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Show_A_D.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Label2.Visible = True Then
            'انصراف
            depar()
            Button2.PerformClick()
        ElseIf Label1.Visible = True Then
            'حضور
            atten()
            Button1.PerformClick()
        Else
            MsgBox("اختر نوع اولاً", MsgBoxStyle.Critical)

        End If
    End Sub
    Private Sub atten()
        Dim max As Integer
        Try
            Dim sql As String = "Select max(id) from Attendance"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Dim x = command.ExecuteScalar().ToString()
            max = x + 1
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        Try
            Dim sql As String = "INSERT INTO Attendance (id,Attendance,employee_id)  " _
            & "VALUES ('" & max & "','" & Label3.Text & "','" & TextBox1.Text & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            With cmd
                cn.Open()
                .ExecuteNonQuery()
                cn.Close()
                MsgBox("تم تسجيل الحضور بنجاح", MsgBoxStyle.Information, "!!")
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("حدث خطا ما", MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub depar()
        Dim max As Integer
        Try
            Dim sql As String = "Select max(id) from Departure"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Dim x = command.ExecuteScalar().ToString()
            max = x + 1
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        Try
            Dim sql As String = "INSERT INTO Departure (id,Departure,employee_id)  " _
            & "VALUES ('" & max & "','" & Label3.Text & "','" & TextBox1.Text & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            With cmd
                cn.Open()
                .ExecuteNonQuery()
                cn.Close()
                MsgBox("تم تسجيل الانصراف بنجاح", MsgBoxStyle.Information, "!!")
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("حدث خطا ما", MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Show_A_D.Show()
    End Sub

End Class