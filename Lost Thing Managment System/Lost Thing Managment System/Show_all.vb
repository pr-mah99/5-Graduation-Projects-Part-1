Imports System.Data.SqlClient
Imports DGVPrinterHelper

Public Class Show_all
    Private Sub Show_all_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code_sql_thing()
    End Sub
    Private Sub code_sql_thing()
        Try
            Dim sql As String = "select lose_id as 'التسلسل',lose_name as 'اسم المفقود',lose_type as 'النوع',lose_city as 'المكان',date as 'التاريخ',describe as 'الوصف' from Lose"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "column_name"
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel1.Visible = True

        DataGridView2.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Visible = False

        DataGridView2.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        code_sql_thing()
        ComboBox1.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        code_sort_lose()
    End Sub
    Private Sub code_sort_lose()
        Try
            Dim sql As String = "select lose_id as 'التسلسل',lose_name as 'اسم المفقود',lose_type as 'النوع',lose_city as 'المكان',date as 'التاريخ',describe as 'الوصف' from Lose where lose_type ='" & ComboBox1.Text & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "column_name"
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub code_sort_date()
        Try
            Dim sql As String = "select lose_id as 'التسلسل',lose_name as 'اسم المفقود',lose_type as 'النوع',lose_city as 'المكان',date as 'التاريخ',describe as 'الوصف' from Lose where date between '" & DateTimePicker1.Value.Date & "' and '" & DateTimePicker2.Value.Date & "'"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "column_name"
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "" Then
        Else
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        code_sort_date()
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        FilterData2(TextBox2.Text)
    End Sub
    Public Sub FilterData2(valueToSearch As String)
        If TextBox2.Text = "" Then
            code_sql_thing()
        Else
            Dim searchQuery As String = "select lose_id as 'التسلسل',lose_name as 'اسم المفقود',lose_type as 'النوع',lose_city as 'المكان',date as 'التاريخ',describe as 'الوصف' from Lose where CONCAT(date,lose_city ,lose_name,lose_type,describe) like '%" & valueToSearch & "%'"
            Dim command As New SqlCommand(searchQuery, cn)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView2.DataSource = table
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        code_sql_thing()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.WindowState = FormWindowState.Normal
        DataGridView2.Size = New Point(400, 400)
        Me.Hide()
        Dim Printer = New DGVPrinter
        Printer.Title = "Lost Thing Management System"
        Printer.SubTitle = "-------------------------------------------------"
        Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
        Printer.PageNumbers = True
        Printer.PageNumberInHeader = False
        Printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional
        Printer.HeaderCellAlignment = StringAlignment.Near
        Printer.Footer = "تقرير الاشياء المفقودة"
        Printer.FooterSpacing = 15
        Printer.PrintDataGridView(DataGridView2)
        DataGridView2.Size = New Point(1172, 516)
        Me.Show()
        'If Me.WindowState = FormWindowState.Maximized Then
        '    DataGridView2.Size = New Point(1517, 686)
        'Else
        '    DataGridView2.Size = New Point(1172, 516)
        'End If
    End Sub
End Class