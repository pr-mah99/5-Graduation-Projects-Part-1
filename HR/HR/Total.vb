Imports System.Data.SqlClient

Public Class Total
    Private Sub Total_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sql_Show()
    End Sub
    Private Sub Sql_Show()
        Dim sql2 As String = "select count(*) from users"
        Dim sql4 As String = "select count(*) from Upgrades"
        Dim sql6 As String = "select count(*) from employee"
        Dim sql7 As String = "select count(*) from Bonuses"


        Dim command2 As New SqlCommand(sql2, cn)
        Dim command4 As New SqlCommand(sql4, cn)
        Dim command6 As New SqlCommand(sql6, cn)
        Dim command7 As New SqlCommand(sql7, cn)


        cn.Open()
        Label10.Text = command2.ExecuteScalar().ToString()
        Label11.Text = command4.ExecuteScalar().ToString()
        Label13.Text = command6.ExecuteScalar().ToString()
        Label8.Text = command7.ExecuteScalar().ToString()
        cn.Close()
    End Sub
End Class