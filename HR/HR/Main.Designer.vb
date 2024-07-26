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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateBlue
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(267, 800)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1331, 41)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(69, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 39)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(876, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Welcome to HR System "
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateBlue
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(267, 841)
        Me.Panel2.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Technical", 52.2!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(121, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 110)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "R"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Technical", 52.2!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(54, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 110)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "H"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel4.AutoScroll = True
        Me.Panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel4.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.Panel4.Controls.Add(Me.Button9)
        Me.Panel4.Controls.Add(Me.Button8)
        Me.Panel4.Controls.Add(Me.Button7)
        Me.Panel4.Controls.Add(Me.Button6)
        Me.Panel4.Controls.Add(Me.Button5)
        Me.Panel4.Controls.Add(Me.Button4)
        Me.Panel4.Controls.Add(Me.Button3)
        Me.Panel4.Controls.Add(Me.Button2)
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Location = New System.Drawing.Point(7, 130)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(255, 705)
        Me.Panel4.TabIndex = 5
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(267, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1331, 800)
        Me.Panel3.TabIndex = 4
        '
        'Button9
        '
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 19.8!, System.Drawing.FontStyle.Bold)
        Me.Button9.ForeColor = System.Drawing.Color.White
        Me.Button9.Image = Global.HR.My.Resources.Resources.icons8_shutdown_48px
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(0, 672)
        Me.Button9.Margin = New System.Windows.Forms.Padding(0)
        Me.Button9.Name = "Button9"
        Me.Button9.Padding = New System.Windows.Forms.Padding(9)
        Me.Button9.Size = New System.Drawing.Size(234, 138)
        Me.Button9.TabIndex = 8
        Me.Button9.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "تسجيل الخروج"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 19.8!, System.Drawing.FontStyle.Bold)
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Image = Global.HR.My.Resources.Resources.icons8_help_48px
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(0, 588)
        Me.Button8.Margin = New System.Windows.Forms.Padding(9)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(234, 84)
        Me.Button8.TabIndex = 7
        Me.Button8.Text = "حول المشروع"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 19.8!, System.Drawing.FontStyle.Bold)
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.Image = Global.HR.My.Resources.Resources.icons8_total_sales_48px
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(0, 504)
        Me.Button7.Margin = New System.Windows.Forms.Padding(9)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(234, 84)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "أحصائيات"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 19.8!, System.Drawing.FontStyle.Bold)
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Image = Global.HR.My.Resources.Resources.icons8_event_declined_48px
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(0, 420)
        Me.Button6.Margin = New System.Windows.Forms.Padding(9)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(234, 84)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "الحضور والانصراف"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 19.8!, System.Drawing.FontStyle.Bold)
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Image = Global.HR.My.Resources.Resources.icons8_medal_first_place_48px
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(0, 336)
        Me.Button5.Margin = New System.Windows.Forms.Padding(9)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(234, 84)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "المكافات"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 19.8!, System.Drawing.FontStyle.Bold)
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Image = Global.HR.My.Resources.Resources.icons8_curriculum_48px
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(0, 252)
        Me.Button4.Margin = New System.Windows.Forms.Padding(9)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(234, 84)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "العمل"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 19.8!, System.Drawing.FontStyle.Bold)
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = Global.HR.My.Resources.Resources.icons8_unit_48px
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(0, 168)
        Me.Button3.Margin = New System.Windows.Forms.Padding(9)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(234, 84)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "الاقسام"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 19.8!, System.Drawing.FontStyle.Bold)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = Global.HR.My.Resources.Resources.icons8_worker_48px
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(0, 84)
        Me.Button2.Margin = New System.Windows.Forms.Padding(9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(234, 84)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "الموظفين"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = Global.HR.My.Resources.Resources.icons8_home_48px
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Margin = New System.Windows.Forms.Padding(9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(234, 84)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "القائمة الرئيسية"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(11, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(231, 112)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1598, 841)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "القائمة الرئيسية"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button9 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel3 As Panel
End Class
