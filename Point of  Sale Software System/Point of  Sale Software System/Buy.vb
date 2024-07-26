Imports System.Data.SqlClient
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports Bytescout.BarCodeReader

Public Class Buy
    Private Sub sql()
        Dim q As String = "select products.product_id as 'Id' ,product_name as 'Product Name' ,type as 'Type',price_buy as 'Price',Barcode as 'Barcode',Total as 'Store' from products,Stores where Stores.product_id=products.product_id order by products.product_id"
        Dim dataadapter As New SqlDataAdapter(q, cn)
        Dim ds As New DataSet()
        cn.Open()
        dataadapter.Fill(ds, "column_name")
        cn.Close()
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "column_name"
    End Sub
    Private Sub clear()
        TextBox9.Text = ""
        TextBox8.Text = ""
        TextBox5.Text = ""
        TextBox4.Text = "0"
    End Sub
    Private Sub Buy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql()
        Label20.Text = Now.ToString
        max_report()
        create_report()
    End Sub
    Private Sub max_report()
        Dim x, max As Integer
        Try
            Dim SQL As String = "Select max(report_id) from Report"
            Dim command As New SqlCommand(SQL, cn)
            cn.Open()
            x = command.ExecuteScalar().ToString()
            max = Val(x) + 1
            Label19.Text = max
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Store_plus()
        Dim plus As Integer = Val(TextBox9.Text) - 1
        TextBox9.Text = plus
        Try
            Dim sql As String = "Update Stores set Total='" & plus & "' where product_id='" & TextBox8.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        sql()
    End Sub
    Private Sub Store_Min()
        Dim Min As Integer = Val(TextBox9.Text) + 1
        TextBox9.Text = Min
        Try
            Dim sql As String = "Update Stores set Total='" & Min & "' where product_id='" & TextBox8.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        sql()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox9.Text = "" Then
            MsgBox("You Have to Select One Product", MsgBoxStyle.Critical)
        ElseIf TextBox9.Text = 0 Then
            MsgBox("Store Is Emplty", "!!", MsgBoxStyle.Critical)
        Else
            TextBox4.Text = Val(TextBox4.Text) + 1
            Store_plus()
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox4.Text = 0 Then
        Else
            TextBox4.Text = Val(TextBox4.Text) - 1
            Store_Min()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox8.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        TextBox5.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
        TextBox9.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString()
        TextBox11.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString()
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            If MsgBox("Webcamهل تريد استخدام ال?", MessageBoxButtons.YesNo + MessageBoxIcon.Question, "جهاز ام كامرة !!") = DialogResult.Yes Then
                Panel4.Visible = True
                DataGridView1.Visible = False
                Label20.Visible = False
            ElseIf DialogResult.No Then
                MsgBox("سوف انتظر قارئ الباركود", MsgBoxStyle.Critical)
                TextBox7.Focus()
            End If
            Panel2.Visible = True
        Else
            Panel2.Visible = False
        End If
        TextBox7.Focus()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim item As String = TextBox5.Text
        Dim qty As Integer = TextBox4.Text
        Dim price As Integer = TextBox11.Text
        Dim subtotal As Integer = qty * price
        'txtsub.Text = Val(TextBox4.Text) * pricev
        DataGridView2.Rows.Add(item, qty, price, subtotal)
        TextBox10.Text = Val(TextBox10.Text) + subtotal


        Dim tot As String = 0
        For i As Integer = 0 To DataGridView2.RowCount - 1
            tot += DataGridView2.Rows(i).Cells(3).Value
        Next
        If tot = 0 Then
            MessageBox.Show("No Records Found")
        End If
        TextBox6.Text = tot.ToString()

        save_bill()
        'Dim tqty As Double
        'For Each row As DataGridViewRow In DataGridView2.Rows
        '    If row.Cells.Item(0).Value = TextBox6.Text Then
        '        tqty += row.Cells.Item(2).Value
        '        TextBox6.Text = tqty
        '        Exit For
        '    End If
        'Next
    End Sub
    Private Sub create_report()
        Try
            Dim sql As String = "INSERT INTO Report (report_id)  " _
& "VALUES ('" & Label19.Text & "')"

            Dim cmd As New SqlCommand(sql, cn)
            With cmd
                cn.Open()
                .ExecuteNonQuery()
                cn.Close()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub save_report()
        Try
            If MsgBox("هل تريد تاكيد الطلب ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                Dim sql As String = "update Report set customer ='" & TextBox13.Text & "',Total='" & TextBox6.Text & "' where report_id='" & Label19.Text & "'"
                Dim cmd As New SqlCommand(sql, cn)
                With cmd
                    cn.Open()
                    .ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم الشراء بنجاح", MsgBoxStyle.Information, "!!")
                End With
            ElseIf DialogResult.No Then
                MsgBox("تم الغاء عملية الطلب", MsgBoxStyle.Information, "Warning !")
            Else
                MsgBox("غير موجود", "حدث خطا ما !!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub save_bill()
        Dim x, max As Integer
        Try
            Dim SQL As String = "Select max(Bill_number) from Bill"
            Dim command As New SqlCommand(SQL, cn)
            cn.Open()
            x = command.ExecuteScalar().ToString()
            max = x + 1
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        Try
            Dim sql As String = "INSERT INTO Bill (Bill_number,product,producct_price,Quantity,Subtotal,report_id)  " _
    & "VALUES ('" & max & "','" & TextBox8.Text & "','" & TextBox11.Text & "','" & TextBox4.Text & "','" & TextBox10.Text & "','" & Label19.Text & "')"

            Dim cmd As New SqlCommand(sql, cn)
            With cmd
                cn.Open()
                .ExecuteNonQuery()
                cn.Close()
                MsgBox("تم أضافة الى السلة بنجاح", MsgBoxStyle.Information, "!!")
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Dim x = Val(TextBox11.Text)
        Dim y = Val(TextBox4.Text)
        Dim subtotal = x * y
        TextBox10.Text = subtotal
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PrintPreviewDialog1.Size = Me.Size
        PrintPreviewDialog1.StartPosition = FormStartPosition.CenterScreen
        If PrintPreviewDialog1.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
        save_report()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'e.Graphics.DrawImage(Bitmap, 120, 30)
        'Dim printview As RectangleF = e.PageSettings.PrintableArea
        'If Me.DataGridView1.Height - printview.Height > 0 Then
        '    e.HasMorePages = True
        'End If

        'كود فاشل
        'Dim c1 = DataGridView1.CurrentCell.RowIndex
        'e.Graphics.DrawString(DataGridView1.Item(DataGridView.cell.headertext, c1).Value.tostring, SystemFonts.DefaultFont, Brushes.Black, 300, 200)

        Dim margin As Single = 40
        Dim marginBetween As Single = 5
        Dim currentTop As Single = margin

        Dim fnt As New Font("Arial", 20, FontStyle.Bold)
        Dim p_fnt As New Font("Arial", 16, FontStyle.Bold)

        Dim strNo As String = "#NO " & Label19.Text
        Dim strDate As String = "التاريخ: " & Now.ToString
        Dim strName As String = "مطلوب من السيد: " & TextBox13.Text
        Dim com As String = "  حميد كرزات  "


        Dim Company As SizeF = e.Graphics.MeasureString(com, fnt)



        Dim fontsizeNo As SizeF = e.Graphics.MeasureString(strNo, fnt)
        Dim fontsizeDate As SizeF = e.Graphics.MeasureString(strDate, fnt)
        Dim fontsizeName As SizeF = e.Graphics.MeasureString(strName, fnt)
        e.Graphics.DrawImage(My.Resources.icons8_billing_machine_100px, 3, 3, 200, 200)



        e.Graphics.DrawString(com, fnt, Brushes.Fuchsia, (e.PageBounds.Width - Company.Width) + 2, 2)
        currentTop += Company.Height + marginBetween



        e.Graphics.DrawString(strNo, fnt, Brushes.Fuchsia, (e.PageBounds.Width - fontsizeNo.Width) / 2, 0)
        currentTop += fontsizeNo.Height + marginBetween
        e.Graphics.DrawString(strDate, fnt, Brushes.Red, e.PageBounds.Width - fontsizeDate.Width - margin, currentTop)
        currentTop += fontsizeDate.Height + marginBetween
        e.Graphics.DrawString(strName, fnt, Brushes.Navy, e.PageBounds.Width - fontsizeName.Width - margin, currentTop)
        currentTop += fontsizeName.Height + marginBetween + 40
        e.Graphics.DrawRectangle(Pens.Black, margin, currentTop, e.PageBounds.Width - margin * 2, e.PageBounds.Height - currentTop - margin)
        currentTop += marginBetween

        Dim colHight As Single = 40

        Dim col1Width As Single = 300
        Dim col2Width As Single = 125 + col1Width
        Dim col3Width As Single = 125 + col2Width
        Dim col4Width As Single = 125 + col3Width

        e.Graphics.DrawLine( Pens.Black, margin, currentTop + colHight, e.PageBounds.Width - margin, currentTop + colHight)

        e.Graphics.DrawString("الصنف", fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - (col1Width / 2), currentTop)
        e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col1Width, currentTop - marginBetween, e.PageBounds.Width - margin * 2 - col1Width, e.PageBounds.Height - margin)

        e.Graphics.DrawString("الكمية", fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - (col2Width - 40), currentTop)
        e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col2Width, currentTop - marginBetween, e.PageBounds.Width - margin * 2 - col2Width, e.PageBounds.Height - margin)

        e.Graphics.DrawString("السعر", fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - (col3Width - 40), currentTop)
        e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col3Width, currentTop - marginBetween, e.PageBounds.Width - margin * 2 - col3Width, e.PageBounds.Height - margin)

        e.Graphics.DrawString("اجمالي فرعي", fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - 16 - (col4Width - 3), currentTop)

        '----------------------------------------------

        Dim rowHeight As Single = 55

        For x = 0 To DataGridView2.Rows.Count - 1

            e.Graphics.DrawString(DataGridView2.Rows(x).Cells(0).Value.ToString(), p_fnt, Brushes.Navy, e.PageBounds.Width - margin * 2 - col1Width + 20, currentTop + rowHeight + 5)
            e.Graphics.DrawString(DataGridView2.Rows(x).Cells(1).Value.ToString(), p_fnt, Brushes.Navy, e.PageBounds.Width - margin * 2 - col2Width + 40, currentTop + rowHeight + 5)
            e.Graphics.DrawString(DataGridView2.Rows(x).Cells(2).Value.ToString(), p_fnt, Brushes.Navy, e.PageBounds.Width - margin * 2 - col3Width + 10, currentTop + rowHeight + 5)
            e.Graphics.DrawString(DataGridView2.Rows(x).Cells(3).Value.ToString(), p_fnt, Brushes.Navy, e.PageBounds.Width - margin * 2 - col4Width + 10, currentTop + rowHeight + 5)

            e.Graphics.DrawLine(Pens.Black, margin, currentTop + rowHeight + colHight, e.PageBounds.Width - margin, currentTop + rowHeight + colHight)

            rowHeight += 55
        Next
        e.Graphics.DrawString("الأجمالي", fnt, Brushes.Red, e.PageBounds.Width - margin * 2 - col3Width + 10, currentTop + rowHeight)
        e.Graphics.DrawString(TextBox6.Text, fnt, Brushes.Blue, e.PageBounds.Width - margin * 2 - col4Width + 10, currentTop + rowHeight)
        e.Graphics.DrawLine(Pens.Black, margin, currentTop + rowHeight + colHight, e.PageBounds.Width - margin, currentTop + rowHeight + colHight)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not DataGridView2.CurrentRow Is Nothing Then
            If TextBox12.Text = "" And TextBox1.Text = "" Then
                MsgBox("!! حدد المنتج اولاً للحذف", MsgBoxStyle.Critical)
            Else
                '  DataGridView1.Rows.Remove(DataGridView2.CurrentRow)
                DataGridView2.Rows.RemoveAt(DataGridView2.CurrentRow.Index)
                Dim x = Val(TextBox12.Text) 'سعر
                Dim y = Val(TextBox6.Text) 'الاجمالي
                Dim z = y - x
                TextBox6.Text = z
            End If
            TextBox12.Text = ""
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        TextBox1.Text = DataGridView2.CurrentRow.Cells(0).Value.ToString()
        TextBox12.Text = DataGridView2.CurrentRow.Cells(3).Value.ToString()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        FilterData(TextBox2.Text)
    End Sub
    Public Sub FilterData(valueToSearch As String)
        If TextBox2.Text = "" Then
            sql()
        Else
            Dim searchQuery As String = "select products.product_id as 'Id' ,product_name as 'Product Name' ,type as 'Type',price_buy as 'Price',Barcode as 'Barcode',Total as 'Store' from products,Stores where Stores.product_id=products.product_id and CONCAT(price_buy ,product_name,type) like '%" & valueToSearch & "%' order by products.product_id"
            Dim command As New SqlCommand(searchQuery, cn)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        If TextBox14.Text = TextBox7.Text Then
            TextBox4.Text = Val(TextBox4.Text) + 1
        Else
            Try
                Dim sql As String = "select product_id ,product_name ,price_buy  from Products where barcode='" & TextBox7.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim com As SqlCommand = New SqlCommand(sql, cn)
                cn.Open()
                Dim reader As SqlDataReader = com.ExecuteReader
                reader.Read()
                If reader.HasRows Then
                    TextBox8.Text = reader(0)
                    TextBox5.Text = reader(1)
                    TextBox11.Text = reader(2)
                    cn.Close()
                    TextBox4.Text = 1
                    TextBox14.Text = TextBox7.Text
                End If
            Catch ex As Exception
                'MsgBox(ex.Message)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged
        TextBox7.Text = TextBox15.Text
    End Sub
    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Dim bmp As Bitmap
    Dim camera As VideoCaptureDevice
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        PictureBox3.BringToFront()
        TextBox4.Clear()
        Dim cameras As VideoCaptureDeviceForm = New VideoCaptureDeviceForm()
        If cameras.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            camera = cameras.VideoDevice
            AddHandler camera.NewFrame, New NewFrameEventHandler(AddressOf captured)
            camera.Start()
            Timer1.Enabled = True
        End If
    End Sub
    Private Sub barcode()
        Try
            Dim reader As Reader = New Reader()
            reader.RegistrationKey = "demo"
            reader.RegistrationName = "demo"
            'reader.BarcodeTypesToFind.QRCode = True
            reader.BarcodeTypesToFind.All = True
            Dim barcodes As FoundBarcode() = reader.ReadFrom(PictureBox3.Image)

            For Each barcode As FoundBarcode In barcodes
                TextBox15.Text = barcode.Value
                MsgBox("QR تم اكتشافة!", MsgBoxStyle.Information)
                If CheckBox4.Checked = True Then
                    camera.Stop()
                    Timer1.Stop()
                Else

                End If
            Next
            reader.Dispose()
        Catch ex As Exception
            'MsgBox("QR لم يكتشف ال!", MsgBoxStyle.Critical)
        Finally
        End Try
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        barcode()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Panel4.Visible = False
        DataGridView1.Visible = True
        Label20.Visible = True
    End Sub
    Private Sub captured(Sender As Object, eventargs As NewFrameEventArgs)
        bmp = DirectCast(eventargs.Frame.Clone(), Bitmap)
        PictureBox3.Image = DirectCast(eventargs.Frame.Clone(), Bitmap)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label23.Text = Val(Label23.Text) + 1
        If Label23.Text = 1 Then
            'PictureBox4.Image = PictureBox3.Image
            barcode()
        ElseIf Label23.Text = 2 Then
            'PictureBox4.Image = PictureBox3.Image
            barcode()
        ElseIf Label23.Text = 3 Then
            'PictureBox4.Image = PictureBox3.Image
            barcode()
        ElseIf Label23.Text = 4 Then
            'PictureBox4.Image = PictureBox3.Image
            barcode()
            Label23.Text = 0
        End If
    End Sub
End Class