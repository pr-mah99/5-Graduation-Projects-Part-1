<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Splash
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 28.0!)
        Me.Label1.Location = New System.Drawing.Point(188, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(581, 57)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Student Evaluation System"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tajawal", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(280, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(397, 67)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "نظام تقييم الطلاب"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(415, 396)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "الرجاء الانتظار....."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(54, 354)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(829, 10)
        Me.ProgressBar1.TabIndex = 3
        Me.ProgressBar1.Value = 80
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tanseek Modern Pro Arabic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(885, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 42)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "0"
        Me.Label4.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Splash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkCyan
        Me.ClientSize = New System.Drawing.Size(941, 462)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Splash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Splash"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label4 As Label
    Friend WithEvents Timer1 As Timer
End Class
