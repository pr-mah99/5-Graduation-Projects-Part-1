<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 45.8!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.BlueViolet
        Me.Label6.Location = New System.Drawing.Point(538, 386)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 108)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "HR"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 25.8!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.BlueViolet
        Me.Label1.Location = New System.Drawing.Point(388, 315)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(426, 60)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "مشروع نظام ادارة الموارد اليشرية"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 45.8!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.BlueViolet
        Me.Label2.Location = New System.Drawing.Point(443, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(302, 108)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "مرحباً بك في"
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1241, 729)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
