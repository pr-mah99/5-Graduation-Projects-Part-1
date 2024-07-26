Public Class Main
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = Now.ToString("yyyy/MM/dd") & Now.ToString("  -   hh:mm:ss tt")
    End Sub
    Private currentForm As Form = Nothing
    Private Sub openChildForm(childForm As Form)
        Me.BackColor = Color.White
        If currentForm IsNot Nothing Then currentForm.Close()
        currentForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        Panel3.Controls.Add(childForm)
        Panel3.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        openChildForm(New About)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        openChildForm(New Total)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        openChildForm(New Attendance_and_Departure)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        openChildForm(New Reward)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        openChildForm(New Job)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        openChildForm(New Department)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        openChildForm(New Employee)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        openChildForm(New Home)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        login.Show()
        Me.Hide()
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        splash.Show()
    End Sub
End Class