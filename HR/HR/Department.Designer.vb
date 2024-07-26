<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Department
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
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button6
        '
        Me.Button6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button6.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Button6.Location = New System.Drawing.Point(254, 12)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(253, 38)
        Me.Button6.TabIndex = 48
        Me.Button6.Text = "توسيع الجدول"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Location = New System.Drawing.Point(524, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(939, 791)
        Me.Panel2.TabIndex = 47
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 26
        Me.DataGridView1.Size = New System.Drawing.Size(939, 791)
        Me.DataGridView1.TabIndex = 0
        '
        'TextBox13
        '
        Me.TextBox13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox13.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TextBox13.Location = New System.Drawing.Point(438, 407)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(63, 32)
        Me.TextBox13.TabIndex = 87
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox3.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TextBox3.Location = New System.Drawing.Point(167, 346)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(265, 32)
        Me.TextBox3.TabIndex = 86
        '
        'ComboBox2
        '
        Me.ComboBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ComboBox2.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(167, 407)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(265, 32)
        Me.ComboBox2.TabIndex = 85
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tanseek Modern Pro Arabic", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(52, 401)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 39)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "مدير القسم :"
        '
        'Button5
        '
        Me.Button5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button5.BackColor = System.Drawing.Color.Turquoise
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(323, 216)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(96, 38)
        Me.Button5.TabIndex = 83
        Me.Button5.Text = "جلب البيانات"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tanseek Modern Pro Arabic", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(86, 340)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 39)
        Me.Label4.TabIndex = 82
        Me.Label4.Text = "الموقع :"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tanseek Modern Pro Arabic", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(49, 279)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 39)
        Me.Label9.TabIndex = 81
        Me.Label9.Text = "اسم القسم :"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tanseek Modern Pro Arabic", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(66, 215)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 39)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "التسلسل :"
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox2.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TextBox2.Location = New System.Drawing.Point(167, 285)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(265, 32)
        Me.TextBox2.TabIndex = 79
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TextBox1.Location = New System.Drawing.Point(167, 221)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(147, 32)
        Me.TextBox1.TabIndex = 78
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button4.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(119, 683)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(334, 77)
        Me.Button4.TabIndex = 90
        Me.Button4.Text = "حذف البيانات"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(119, 583)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(334, 77)
        Me.Button3.TabIndex = 89
        Me.Button3.Text = "تحديث البيانات"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(119, 485)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(334, 77)
        Me.Button2.TabIndex = 88
        Me.Button2.Text = "أضافة البيانات"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tanseek Modern Pro Arabic", 56.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(164, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(259, 133)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "ألاقسام"
        '
        'Department
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.ClientSize = New System.Drawing.Size(1475, 815)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox13)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Department"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Department"
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button6 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
End Class
