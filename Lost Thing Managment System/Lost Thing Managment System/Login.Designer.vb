<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tajawal", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(414, 382)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(276, 28)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "أضغط على الدخول لفتح البرنامج"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tajawal", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(498, 438)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 28)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "مرحبا بك"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.Location = New System.Drawing.Point(281, 501)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(525, 71)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "الدخول"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button2.Location = New System.Drawing.Point(923, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(167, 43)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "الخروج"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Green
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkTurquoise
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button3.Location = New System.Drawing.Point(305, 590)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(477, 71)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "التسجيل"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tajawal", 17.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(389, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(301, 40)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "نافذة الدخول الى البرنامج"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Lost_Thing_Managment_System.My.Resources.Resources.icons8_cloud_account_login_male_500px
        Me.PictureBox2.Location = New System.Drawing.Point(553, 95)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(273, 189)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Lost_Thing_Managment_System.My.Resources.Resources.icons8_cloud_account_login_female_500px
        Me.PictureBox1.Location = New System.Drawing.Point(244, 95)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(273, 189)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1102, 713)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1120, 760)
        Me.MinimumSize = New System.Drawing.Size(1120, 760)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Login"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label3 As Label
End Class
