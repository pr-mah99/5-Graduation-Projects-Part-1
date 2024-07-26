Public Class splash
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = Val(Label2.Text) + 1
        If Label2.Text = 1 Then
            Label1.Visible = True
        ElseIf Label2.Text = 2 Then
            ProgressBar1.Visible = True
            ProgressBar1.Value = 12
        ElseIf Label2.Text = 3 Then
            ProgressBar1.Value = 27
        ElseIf Label2.Text = 4 Then
            ProgressBar1.Value = 67
        ElseIf Label2.Text = 5 Then
            ProgressBar1.Value = 89
        ElseIf Label2.Text = 6 Then
            ProgressBar1.Value = 100
        ElseIf Label2.Text = 7 Then
            Main.Show()
            Me.Close()
        End If
    End Sub
End Class