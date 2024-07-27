Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Acknowledgments
    Private Sub code_sql()
        Try
            Dim sql As String = "Select Acknowledgments.id as '#',Employee.fname as 'الاسم',Employee.lname as 'الاب',acknow as 'عنوان الشكر والتقدير',date as 'تاريخ الاضافة' from Acknowledgments,Employee where emp=Employee.id and emp='" & TextBox2.Text & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "column_name"
            If ds.Tables("column_name").Rows.Count = 0 Then
                Label1.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub add()
        Try
            Dim sql As String = "Select max(id) from Acknowledgments"
            Dim command As New SqlCommand(sql, cn)
            'cn.Open()
            Dim x = command.ExecuteScalar().ToString()
            Dim max = Val(x) + 1
            cn.Close()
            TextBox5.Text = max
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try

        Try
            Dim sql As String = "INSERT INTO Acknowledgments (id,emp,acknow)  " _
& "VALUES ('" & TextBox5.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            With cmd
                cn.Open()
                .ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الادخال بنجاح", MsgBoxStyle.Information, "!!")
            End With
            code_sql()
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("حدث خطا ما", MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MsgBox("أدخل اسم الموظف اولا", MsgBoxStyle.Information, "!!")
            TextBox2.Focus()
        Else
            Dim year As Integer = DateTime.Now.Year
            Dim firstDayOfYear As New DateTime(year, 1, 1) '2023/1/1

            Dim daysInMonth As Integer = DateTime.DaysInMonth(year, 12)
            Dim lastDayOfYear As New DateTime(year, 12, daysInMonth) '2023/12/30

            Try
                Dim sql As SqlCommand = New SqlCommand("Select * from Acknowledgments where emp='" + TextBox2.Text + "' And date BETWEEN '" + firstDayOfYear.ToString("yyyy-MM-dd") + "' and '" + lastDayOfYear.ToString("yyyy-MM-dd") + "'", cn)
                Dim dt As New DataTable()
                cn.Open()
                Dim dataadapter As New SqlDataAdapter(sql)
                dataadapter.Fill(dt)
                If (dt.Rows.Count > 2) Then
                    MsgBox("لا يمكن , لان الموظف لدية 3 شهادات بالفعل", MsgBoxStyle.Critical)
                Else
                    add()
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
            Dim sql As String = "Update Acknowledgments set emp='" & TextBox2.Text & "',acknow='" & TextBox3.Text & "' where id='" & TextBox5.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            code_sql()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذا ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM Acknowledgments WHERE id =" & TextBox5.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
                code_sql()
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox5.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        code_sql()
    End Sub
End Class