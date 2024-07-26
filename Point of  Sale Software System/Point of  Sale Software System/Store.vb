Imports System.Data.SqlClient

Public Class Store
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Visible = True
        Panel1.Visible = True
        Label1.Visible = True
        Label5.Visible = True
        Button1.Visible = False
        DataGridView1.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel1.Visible = False
        Label1.Visible = False
        Label5.Visible = False
        Button1.Visible = True
        DataGridView1.Visible = True
        code()
    End Sub

    Private Sub Store_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code()
        fillItemName("select * from Products", ComboBox1)
    End Sub
    Private Sub fillItemName(sql As String, ItemName As ComboBox)
        ItemName.Items.Clear()
        Dim adp As New SqlClient.SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            'combo box نختار اسم الحقل الي نريدة ان يظهر في ال 
            ItemName.Items.Add(dt.Rows(i).Item("product_name"))
        Next
    End Sub
    Private Sub code()
        Try
            Dim sql As String = "select * from view_Stores"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "column_name"
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select product_id From products WHERE product_name='" & ComboBox1.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox5.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        clear()
        max()
    End Sub
    Private Sub max()
        Try
            Dim sql As String = "Select max(stores_id) from stores"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Dim x = 1 + command.ExecuteScalar().ToString()
            cn.Close()
            TextBox4.Text = x
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        select_store()
    End Sub
    Private Sub clear()
        TextBox5.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
    End Sub
    Private Sub select_store()
        Try
            Dim sql As String = "select total,product_name from products,stores where stores.product_id=products.product_id and stores_id='" & TextBox4.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox3.Text = reader(0)
                ComboBox1.Text = reader(1)
                cn.Close()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox5.Text = "" Then
            MsgBox("حدد المنتج اولاً", MsgBoxStyle.Critical)
        Else
            Try
                Dim sql As String = "INSERT INTO Stores (stores_id,product_id,Total)  " _
            & "VALUES ('" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox3.Text & "')"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                With cmd
                    cn.Open()
                    .ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم الادخال بنجاح", MsgBoxStyle.Information, "!!")
                    clear()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("حدث خطا ما", MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox5.Text = "" Then
            MsgBox("حدد المنتج اولاً", MsgBoxStyle.Critical)
        Else
            Try
                Dim sql As String = "Update Stores set Total='" & TextBox3.Text & "'where stores_id='" & TextBox4.Text & "'"
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم التحديث بنجاح", MsgBoxStyle.Information, "Warning !")
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox5.Text = "" Then
            MsgBox("حدد المنتج اولاً", MsgBoxStyle.Critical)
        Else
            Try
                If MsgBox("هل انت متاكد من حذف هذا المخزن ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                    'Delete Code
                    Dim DeleteQuery As String = "DELETE FROM Stores WHERE stores_id =" & TextBox4.Text
                    Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                    Dim com = New SqlCommand(DeleteQuery, cn)
                    cn.Open()
                    com.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
                    clear()
                    Button2.PerformClick()
                ElseIf DialogResult.No Then
                    MsgBox("تم الغاء عملية الحذف", MsgBoxStyle.Information, "Warning !")
                Else
                    MsgBox("غير موجود", "حدث خطا ما !!")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        TextBox4.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        Try
            Dim sql2 As String = "Select product_id From Stores WHERE stores_id='" & TextBox4.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox5.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        Button1.PerformClick()
        Button5.PerformClick()
    End Sub
End Class