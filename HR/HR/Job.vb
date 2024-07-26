Imports System.Data.SqlClient

Public Class Job
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel2.Size = New Point(1217, 705)
        Panel2.Location = New Point(12, 12)
        Panel2.BringToFront()
        Panel2.Dock = DockStyle.Fill
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
    End Sub

    Private Sub Job_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code_sql_Job()
    End Sub
    Private Sub code_sql_Job()
        Try
            Dim sql As String = "select job_id as 'التسلسل',job_name as 'العمل',min_salary as 'الحد الاقل للراتب',max_salary as 'الحد الاعلى للراتب' from Job"
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
            Dim sql As String = "Select max(job_id) from Job"
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
            MsgBox("عليك ان تكتب اسم العمل", MsgBoxStyle.Information, "!!")
            TextBox2.Focus()
        Else
            id_max()
            Try
                Dim sql As String = "INSERT INTO Job (job_id,job_name,min_salary,max_salary)  " _
            & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                With cmd
                    cn.Open()
                    .ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم الادخال بنجاح", MsgBoxStyle.Information, "!!")
                    code_sql_Job()
                    clear()
                    TextBox1.Text = ""
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
        If TextBox1.Text = "" Then
            MsgBox("عليك ان تكتب تسلسل العمل", MsgBoxStyle.Information, "!!")
            TextBox1.Focus()
        Else
            Try
                Dim sql As String = "Update Job set job_name='" & TextBox2.Text & "',min_salary='" & TextBox3.Text & "',max_salary='" & TextBox4.Text & "'where job_id='" & TextBox1.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم التحديث البيانات بنجاح")
                code_sql_Job()
                clear()
                TextBox1.Text = ""
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Then
            MsgBox("عليك ان تكتب تسلسل العمل", MsgBoxStyle.Information, "!!")
            TextBox1.Focus()
        Else
            Try
                If MsgBox("هل انت متاكد من حذف هذا العمل ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                    'Delete Code
                    Dim DeleteQuery As String = "DELETE FROM Job WHERE job_id =" & TextBox1.Text
                    Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                    Dim com = New SqlCommand(DeleteQuery, cn)
                    cn.Open()
                    com.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
                    code_sql_Job()
                    clear()
                    TextBox1.Text = ""
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
        End If
    End Sub
    Private Sub clear()
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox1.Text = "" Then
            MsgBox("أدخل رقم العمل اولاً", MsgBoxStyle.Exclamation, "Warning !")
        Else
            clear()
            Try
                Dim sql As String = "select * from Job where job_id=" & TextBox1.Text
                Dim com As SqlCommand = New SqlCommand(sql, cn)
                cn.Open()
                Dim reader As SqlDataReader = com.ExecuteReader
                reader.Read()
                If reader.HasRows Then
                    TextBox2.Text = reader(1)
                    TextBox3.Text = reader(2)
                    TextBox4.Text = reader(3)
                    cn.Close()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cn.Close()
            End Try
        End If
    End Sub
End Class