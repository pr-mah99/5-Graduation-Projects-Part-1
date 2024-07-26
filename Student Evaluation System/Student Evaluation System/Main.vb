Public Class Main
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        About.Show()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Users.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Teacher.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Evaluation.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Student.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Subject.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Login.Show()
        Me.Close()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "استاذ" Then
            Button3.Enabled = False
            Button5.Enabled = False
        ElseIf TextBox2.Text = "مدير" Then
            Button6.Enabled = True
            Button2.Enabled = False
        End If
    End Sub
End Class