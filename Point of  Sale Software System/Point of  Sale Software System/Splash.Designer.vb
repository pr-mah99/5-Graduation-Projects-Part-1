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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Splash))
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(119, 483)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(853, 10)
        Me.ProgressBar1.TabIndex = 0
        Me.ProgressBar1.Value = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 68.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(203, 163)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(764, 138)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Splash Screen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(484, 502)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(156, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "الرجاء الانتظار..........."
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1010, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "0"
        Me.Label3.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(6, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1077, 564)
        Me.Panel1.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Tanseek Modern Pro Arabic", 36.2!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label5.Location = New System.Drawing.Point(465, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(175, 86)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "مرحبا بك"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 38.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(377, 291)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(389, 77)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Point of Sale"
        '
        'Splash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(1089, 580)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Splash"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Splash"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
End Class
