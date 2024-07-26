Imports System.Data.SqlClient

Public Class Show_All

    Private Sub SQL()
        If TextBox3.Text = "show" Then
            Dim sql As String = "select Assess.id as 'التسلسل',Student.name as 'اسم الطالب',Subject.Subject as 'اسم المادة',Teacher.name as 'المعلم',level_student as 'المرحلة',class as 'الصف',Assess.Assess as'التقيم',assess.date as 'تاريخ' from student,Assess,Teacher,Subject where assess.student=id_student and assess.teacher=id_teacher and assess.Subject=Subject.id"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "column_name"
        ElseIf Main.TextBox2.Text = "مدير" Then
            Dim sql As String = "select Assess.id as 'التسلسل',Student.name as 'اسم الطالب',Subject.Subject as 'اسم المادة',Teacher.name as 'المعلم',level_student as 'المرحلة',class as 'الصف',Assess.Assess as'التقيم',assess.date as 'تاريخ' from student,Assess,Teacher,Subject where assess.student=id_student and assess.teacher=id_teacher and assess.Subject=Subject.id and student='" & TextBox2.Text & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "column_name"

        ElseIf TextBox2.Text = "" Then
            Dim sql As String = "select Assess.id as 'التسلسل',Student.name as 'اسم الطالب',Subject.Subject as 'اسم المادة',Teacher.name as 'المعلم',level_student as 'المرحلة',class as 'الصف',Assess.Assess as'التقيم',assess.date as 'تاريخ' from student,Assess,Teacher,Subject where assess.student=id_student and assess.teacher=id_teacher and assess.Subject=Subject.id and id_teacher='" & TextBox1.Text & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "column_name"
        Else
            Dim sql As String = "select Assess.id as 'التسلسل',Student.name as 'اسم الطالب',Subject.Subject as 'اسم المادة',Teacher.name as 'المعلم',level_student as 'المرحلة',class as 'الصف',Assess.Assess as'التقيم',assess.date as 'تاريخ' from student,Assess,Teacher,Subject where assess.student=id_student and assess.teacher=id_teacher and assess.Subject=Subject.id and id_teacher='" & TextBox1.Text & "' and student='" & TextBox2.Text & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "column_name"
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        SQL()
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        SQL()
    End Sub

    Private Sub Show_All_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Main.TextBox1.Text
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        SQL()
    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        Evaluation.TextBox1.Clear()
        Evaluation.TextBox3.Clear()
        Evaluation.ComboBox1.Text = ""
        Evaluation.TextBox4.Clear
        Evaluation.TextBox2.Clear

        Evaluation.TextBox1.Text = DataGridView2.CurrentRow.Cells(0).Value.ToString()
        Evaluation.TextBox3.Text = DataGridView2.CurrentRow.Cells(1).Value.ToString()
        Evaluation.ComboBox1.Text = DataGridView2.CurrentRow.Cells(2).Value.ToString()
        Evaluation.TextBox4.Text = DataGridView2.CurrentRow.Cells(3).Value.ToString()
        Evaluation.TextBox2.Text = DataGridView2.CurrentRow.Cells(4).Value.ToString()
        Me.Close()
    End Sub
End Class