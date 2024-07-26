<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.Label1.Location = New System.Drawing.Point(481, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(423, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Point of  Sale Software System"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tajawal", 28.0!)
        Me.Label2.Location = New System.Drawing.Point(1017, 247)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(167, 66)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "أعداد  : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tajawal", 28.0!)
        Me.Label3.Location = New System.Drawing.Point(157, 247)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(202, 66)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "أشراف  : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1009, 373)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(223, 52)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "محمود شمران عذيب"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label6.Location = New System.Drawing.Point(1009, 282)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(223, 36)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "_____________"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label7.Location = New System.Drawing.Point(159, 282)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(223, 36)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "_____________"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(172, 393)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(181, 52)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "د . اسم المشرف"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Point_of__Sale_Software_System.My.Resources.Resources.point
        Me.PictureBox1.Location = New System.Drawing.Point(359, 373)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(654, 365)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("TanseekModernProArabic-Regular", 22.2!)
        Me.Label9.Location = New System.Drawing.Point(616, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(147, 52)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "نظام مبيعات"
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1325, 692)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1343, 739)
        Me.MinimumSize = New System.Drawing.Size(1343, 739)
        Me.Name = "About"
        Me.Opacity = 0.97R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label9 As Label
End Class
