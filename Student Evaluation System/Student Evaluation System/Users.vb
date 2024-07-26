Imports System.Data.SqlClient

Public Class Users
    Private Sub Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code()
    End Sub
    Private Sub code()
        Try
            Dim sql As String = "select id_user as 'التسلسل',fullname as 'الاسم الكامل',username as 'اسم المستخدم',password as 'كلمة المرور',age as 'العمر',type_user as 'النوع الحساب',allow as 'السماحية' from users"
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
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذا المستخدم ?", MsgBoxStyle.YesNo, " !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM users WHERE id_user =" & TextBox1.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
                'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
                code()
                'أعادة استدعاء للبيانات لغرض التحديث                
            ElseIf DialogResult.No Then
                MsgBox("تم الغاء الحذف", MsgBoxStyle.Information, "Warning !")
            Else
                MsgBox("Erorr", "حدث خطا ما !!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim allow As String
        If CheckBox1.Checked = True Then
            allow = "True"
        Else
            allow = "False"
        End If
        Try
            Dim sql As String = "Update users set allow='" & allow & "' where id_user='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم التحديث الصلاحيات بنجاح", MsgBoxStyle.Information, "Warning !")
            code()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
End Class