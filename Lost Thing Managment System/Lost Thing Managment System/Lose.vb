Imports System.Data.SqlClient

Public Class Lose
    Private Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        TextBox4.Text = ""
        TextBox6.Text = ""
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            MsgBox("ادخل اسم الشي المفقود اولاً", MsgBoxStyle.Critical)
        Else
            id_max()
            Try
                Dim sql As String = "INSERT INTO Lose (lose_id,lose_name,lose_type,lose_city,date,describe)  " _
            & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & TextBox4.Text & "','" & DateTimePicker1.Value.Date & "','" & TextBox6.Text & "')"
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
    Private Sub id_max()
        Try
            Dim sql As String = "Select max(lose_id) from Lose"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Dim x = command.ExecuteScalar().ToString()
            Dim max = x + 1
            cn.Close()
            TextBox1.Text = max
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text = "" Then
            MsgBox("اختر الشي المفقود اولاً", MsgBoxStyle.Critical)
        Else
            Try
                Dim sql As String = "Update Lose set lose_name='" & TextBox2.Text & "',lose_type='" & ComboBox1.Text & "',lose_city='" & TextBox4.Text & "',date='" & DateTimePicker1.Value.Date & "',describe='" & TextBox6.Text & "'where lose_id='" & TextBox1.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox2.Text = "" Then
            MsgBox("اختر الشي المفقود اولاً", MsgBoxStyle.Critical)
        Else
            Try
                If MsgBox("هل انت متاكد من حذف هذا الشي ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                    'Delete Code
                    Dim DeleteQuery As String = "DELETE FROM lose WHERE lose_id =" & TextBox1.Text
                    Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                    Dim com = New SqlCommand(DeleteQuery, cn)
                    cn.Open()
                    com.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
                    clear()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim x = TextBox1.Text
        clear()
        TextBox1.Text = x
        Try
            Dim sql As String = "select * from lose where lose_id ='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox2.Text = reader(1)
                ComboBox1.Text = reader(2)
                TextBox4.Text = reader(3)
                DateTimePicker1.Value = reader(4)
                TextBox6.Text = reader(5)
                cn.Close()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Lose_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class