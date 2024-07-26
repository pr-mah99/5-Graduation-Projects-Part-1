Imports System.Data.SqlClient

Public Class Total
    Private Sub Total_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sql_Show()
    End Sub
    Private Sub Sql_Show()
        Dim sql As String = "select count(*) from products"
        Dim sql2 As String = "select sum(Total) from stores"
        Dim sql4 As String = "select sum(Total) from Report"
        Dim sql6 As String = "select count(*) from Report"
        Dim sql7 As String = "select count(*) from users"
        Dim command As New SqlCommand(sql, cn)
        Dim command2 As New SqlCommand(sql2, cn)
        Dim command4 As New SqlCommand(sql4, cn)
        Dim command6 As New SqlCommand(sql6, cn)
        Dim command7 As New SqlCommand(sql7, cn)
        cn.Open()
        Label10.Text = command.ExecuteScalar().ToString()
        Label11.Text = command2.ExecuteScalar().ToString()
        Label12.Text = command4.ExecuteScalar().ToString() & " الف دينار "
        Label14.Text = command6.ExecuteScalar().ToString()
        Label13.Text = command7.ExecuteScalar().ToString()
        cn.Close()
    End Sub
End Class