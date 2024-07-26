<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tajawal", 26.2!)
        Me.Label1.Location = New System.Drawing.Point(541, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(313, 62)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "القائمة الرئيسية"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tajawal", 12.2!)
        Me.Label2.Location = New System.Drawing.Point(1038, 249)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(249, 29)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Student Evaluation System"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tajawal", 12.2!)
        Me.Label3.Location = New System.Drawing.Point(1016, 259)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(293, 29)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "___________________________________"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1080, 358)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(181, 24)
        Me.TextBox1.TabIndex = 14
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(1080, 388)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(181, 24)
        Me.TextBox2.TabIndex = 15
        Me.TextBox2.Visible = False
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orchid
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Tajawal", 13.8!)
        Me.Button6.Image = Global.Student_Evaluation_System.My.Resources.Resources.icons8_pencil_48px
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(12, 557)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(225, 73)
        Me.Button6.TabIndex = 16
        Me.Button6.Text = "المستخدم"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.Button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro
        Me.Button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Tajawal", 12.8!)
        Me.Button7.Image = Global.Student_Evaluation_System.My.Resources.Resources.icons8_Logout_40px
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(1023, 291)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(278, 61)
        Me.Button7.TabIndex = 13
        Me.Button7.Text = "تسجيل خروج"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Tajawal", 15.8!)
        Me.Button5.Image = Global.Student_Evaluation_System.My.Resources.Resources.icons8_book_40px1
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(877, 579)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(404, 119)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "المواد الدراسية"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Student_Evaluation_System.My.Resources.Resources.icons8_resume_500px
        Me.PictureBox1.Location = New System.Drawing.Point(938, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(448, 250)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Button4
        '
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orchid
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Tajawal", 13.8!)
        Me.Button4.Image = Global.Student_Evaluation_System.My.Resources.Resources.icons8_borrow_book_48px
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(12, 636)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(225, 73)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "حول المشوع"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Tajawal", 15.8!)
        Me.Button3.Image = Global.Student_Evaluation_System.My.Resources.Resources.icons8_teacher_40px
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(644, 413)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(404, 119)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "المعلمين"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tajawal", 15.8!)
        Me.Button2.Image = Global.Student_Evaluation_System.My.Resources.Resources.icons8_read_online_40px
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(334, 249)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(404, 119)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "تقيم الطلاب"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tajawal", 15.8!)
        Me.Button1.Image = Global.Student_Evaluation_System.My.Resources.Resources.icons8_man_student_48px
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(54, 91)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(404, 119)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "أضافة طلاب"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(1348, 721)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1366, 768)
        Me.MinimumSize = New System.Drawing.Size(1366, 768)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "القائمة الرئيسية"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button6 As Button
End Class
