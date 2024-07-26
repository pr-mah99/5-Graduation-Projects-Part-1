<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_SHA_2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(C_SHA_2))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckedListBoxListFiles = New System.Windows.Forms.CheckedListBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 22.0!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Location = New System.Drawing.Point(462, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(288, 36)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "خوارزمية تشفير قديمة"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 28.0!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(340, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(537, 46)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Cryptography SHA1 Algorithm "
        '
        'Button3
        '
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button3.ForeColor = System.Drawing.Color.Maroon
        Me.Button3.Location = New System.Drawing.Point(209, 21)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(294, 100)
        Me.Button3.TabIndex = 27
        Me.Button3.Text = "التشفير - Encrypt"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button2.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Button2.Location = New System.Drawing.Point(528, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(294, 100)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "فك التشفير - Decrypt"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 58)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "SHA1"
        '
        'Button1
        '
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(1050, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 63)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CheckedListBoxListFiles)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Location = New System.Drawing.Point(165, 158)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(859, 482)
        Me.Panel1.TabIndex = 30
        '
        'CheckedListBoxListFiles
        '
        Me.CheckedListBoxListFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckedListBoxListFiles.BackColor = System.Drawing.Color.DarkSlateGray
        Me.CheckedListBoxListFiles.ColumnWidth = 10
        Me.CheckedListBoxListFiles.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBoxListFiles.ForeColor = System.Drawing.Color.White
        Me.CheckedListBoxListFiles.FormattingEnabled = True
        Me.CheckedListBoxListFiles.HorizontalExtent = 10
        Me.CheckedListBoxListFiles.Location = New System.Drawing.Point(16, 146)
        Me.CheckedListBoxListFiles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CheckedListBoxListFiles.Name = "CheckedListBoxListFiles"
        Me.CheckedListBoxListFiles.Size = New System.Drawing.Size(826, 319)
        Me.CheckedListBoxListFiles.TabIndex = 29
        '
        'Button4
        '
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Button4.ForeColor = System.Drawing.Color.Gold
        Me.Button4.Location = New System.Drawing.Point(43, 21)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(141, 100)
        Me.Button4.TabIndex = 28
        Me.Button4.Text = "أضافة ملف - Add"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 22.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(411, 636)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(398, 36)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "قم بتحديد ملف ثم اضغط تشفير"
        '
        'C_SHA_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSlateGray
        Me.ClientSize = New System.Drawing.Size(1204, 685)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "C_SHA_2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "C_SHA_2"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CheckedListBoxListFiles As CheckedListBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Label2 As Label
End Class
