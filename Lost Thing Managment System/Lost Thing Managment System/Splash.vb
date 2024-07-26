Public Class Splash
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label4.Text = Val(Label4.Text) + 1
        If Label4.Text = 1 Then
            ProgressBar1.Value = 7
        ElseIf Label4.Text = 2 Then
            ProgressBar1.Value = 37
        ElseIf Label4.Text = 3 Then
            ProgressBar1.Value = 77
        ElseIf Label4.Text = 4 Then
            ProgressBar1.Value = 100
        ElseIf Label4.Text = 5 Then
            Login.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class