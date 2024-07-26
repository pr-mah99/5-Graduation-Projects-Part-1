<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Subject
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tajawal", 15.8!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tajawal", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.Location = New System.Drawing.Point(464, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 26
        Me.DataGridView1.Size = New System.Drawing.Size(740, 671)
        Me.DataGridView1.TabIndex = 1
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.SlateBlue
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.Snow
        Me.Button3.Location = New System.Drawing.Point(311, 616)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(143, 54)
        Me.Button3.TabIndex = 44
        Me.Button3.Text = "حذف البيانات"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Turquoise
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(162, 616)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 54)
        Me.Button1.TabIndex = 43
        Me.Button1.Text = "تحديث البيانات"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Wheat
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(13, 616)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(143, 54)
        Me.Button2.TabIndex = 42
        Me.Button2.Text = "أضافة البيانات"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tanseek Modern Pro Arabic", 39.8!)
        Me.Label3.Location = New System.Drawing.Point(42, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(392, 94)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "ادارة المواد الدراسية"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Location = New System.Drawing.Point(26, 277)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(409, 315)
        Me.Panel1.TabIndex = 40
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker2.Location = New System.Drawing.Point(148, 237)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(211, 32)
        Me.DateTimePicker2.TabIndex = 48
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(148, 171)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(211, 32)
        Me.DateTimePicker1.TabIndex = 47
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tanseek Modern Pro Arabic", 17.8!)
        Me.Label8.Location = New System.Drawing.Point(51, 231)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 42)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "الوقت"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tanseek Modern Pro Arabic", 17.8!)
        Me.Label7.Location = New System.Drawing.Point(53, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 42)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "التاريخ"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tanseek Modern Pro Arabic", 17.8!)
        Me.Label5.Location = New System.Drawing.Point(33, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 42)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "اسم المادة"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Turquoise
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(291, 41)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(96, 38)
        Me.Button5.TabIndex = 34
        Me.Button5.Text = "جلب البيانات"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tanseek Modern Pro Arabic", 17.8!)
        Me.Label4.Location = New System.Drawing.Point(38, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 42)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "التسلسل"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TextBox1.Location = New System.Drawing.Point(148, 44)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(137, 32)
        Me.TextBox1.TabIndex = 29
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TextBox2.Location = New System.Drawing.Point(148, 108)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(211, 32)
        Me.TextBox2.TabIndex = 30
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tanseek Modern Pro Arabic", 17.8!)
        Me.Label9.Location = New System.Drawing.Point(168, 200)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 42)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "البحث عن مادة"
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TextBox5.Location = New System.Drawing.Point(59, 161)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(355, 32)
        Me.TextBox5.TabIndex = 45
        '
        'Subject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1216, 695)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Subject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subject"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
