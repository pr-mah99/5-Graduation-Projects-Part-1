Public Class Splash
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = Val(Label3.Text) + 1
        If Label3.Text = 1 Then
            ProgressBar1.Value = 24
        ElseIf Label3.Text = 2 Then
            ProgressBar1.Value = 75
        ElseIf Label3.Text = 3 Then
            ProgressBar1.Value = 100
        ElseIf Label3.Text = 4 Then
            Login.Show()
            Me.Close()
        End If
    End Sub
End Class