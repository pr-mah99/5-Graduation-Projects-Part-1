Imports System.Data.SqlClient

Public Class Total
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Total_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sql_Show()
    End Sub
    Private Sub Sql_Show()
        Dim sql As String = "select count(*) from Lose"
        Dim sql6 As String = "select count(*) from users"
        Dim command As New SqlCommand(sql, cn)
        Dim command6 As New SqlCommand(sql6, cn)
        cn.Open()
        Label7.Text = command.ExecuteScalar().ToString()
        Label10.Text = command6.ExecuteScalar().ToString()
        cn.Close()
    End Sub
End Class