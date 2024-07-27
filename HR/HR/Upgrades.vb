Imports System.Data.SqlClient

Public Class Upgrades
    Private Sub id_max()
        Try
            Dim max = 0
            Dim sql As String = "Select max(id) from Upgrades"
            Dim command As New SqlCommand(sql, cn)
            'cn.Open()
            Dim x = command.ExecuteScalar().ToString()
            cn.Close()
            max = Val(x) + 1
            TextBox1.Text = max
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Then
            MsgBox("حدد الترقيمة اولا", MsgBoxStyle.Information, "!!")
            TextBox1.Focus()
        Else
            Try
                If MsgBox("هل انت متاكد اسقاط العقوبة عن هذا الشخص ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                    'Delete Code
                    Dim DeleteQuery As String = "DELETE FROM Upgrades WHERE id =" & TextBox1.Text
                    Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                    Dim com = New SqlCommand(DeleteQuery, cn)
                    cn.Open()
                    com.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("تم اسقاط العقوبة بنجاح", MsgBoxStyle.Information, "Warning !")
                    clear()
                ElseIf DialogResult.No Then
                    MsgBox("تم الغاء عملية الاسقاط", MsgBoxStyle.Information, "Warning !")
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim sql As String = "Update Upgrades set employee_id='" & TextBox3.Text & "',upgrades='" & TextBox2.Text & "',newSalary=,'" & TextBox3.Text & "',date='" & DateTimePicker1.Value.Date & "',time='" & DateTimePicker2.Value.ToShortTimeString & "',Note='" & TextBox4.Text & "'where id='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم التحديث البيانات بنجاح")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Then
            MsgBox("عليك ان تختار الموظف لفرض العقوبة", MsgBoxStyle.Information, "!!")
            ComboBox1.Focus()
        Else
            'كود تحديد 4 سنوات         
            Dim currentYear As Integer = DateTime.Now.Year
            Dim fourYearsAgo As Integer = currentYear - 4

            Dim firstDayOfFourYearsAgo As New DateTime(fourYearsAgo, 1, 1)
            Dim lastDayOfFourYearsAgo As DateTime = DateTime.Now.Date


            'MsgBox(firstDayOfFourYearsAgo.ToString("yyyy-MM-dd"))
            'MsgBox(lastDayOfFourYearsAgo.ToString("yyyy-MM-dd"))

            Try
                Dim sql As SqlCommand = New SqlCommand("Select * from Upgrades where employee_id='" + TextBox3.Text + "' And date BETWEEN '" + firstDayOfFourYearsAgo.ToString("yyyy-MM-dd") + "' and '" + lastDayOfFourYearsAgo.ToString("yyyy-MM-dd") + "'", cn)
                Dim dt As New DataTable()
                cn.Open()
                Dim dataadapter As New SqlDataAdapter(sql)
                dataadapter.Fill(dt)
                If (dt.Rows.Count > 0) Then
                    MsgBox("لا يمكن , لان الموظف لدية ترقية بالفعل", MsgBoxStyle.Critical)
                Else
                    id_max()
                    Try
                        Dim sql2 As String = "INSERT INTO Upgrades (id,employee_id,newSalary,upgrades,date,time,Note)  " _
            & "VALUES ('" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox5.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Value.Date & "','" & DateTimePicker2.Value.ToShortTimeString & "','" & TextBox4.Text & "')"
                        Dim sda As New SqlDataAdapter(sql2, cn)
                        Dim cmd As New SqlCommand(sql2, cn)
                        With cmd
                            cn.Open()
                            .ExecuteNonQuery()
                            cn.Close()
                            MsgBox("تم الادخال بنجاح", MsgBoxStyle.Information, "!!")
                            clear()
                            TextBox1.Text = ""
                        End With
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        MsgBox("حدث خطا ما", MsgBoxStyle.Critical)
                    Finally
                        cn.Close()
                    End Try
                End If
                cn.Close()
            Catch ex As Exception
                'MsgBox(ex.Message, vbCritical)
                ''MsgBox("Erorr !!", vbCritical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub Punishments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillItemName("select * from Employee", ComboBox1)
    End Sub
    Private Sub fillItemName(sql As String, ItemName As ComboBox)
        ItemName.Items.Clear()
        Dim adp As New SqlClient.SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            'combo box نختار اسم الحقل الي نريدة ان يظهر في ال 
            ItemName.Items.Add(dt.Rows(i).Item("fname"))
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim sql As String = "select * from Upgrades where id=" & TextBox1.Text
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            Dim x As Integer
            If reader.HasRows Then
                x = reader(1)
                TextBox5.Text = reader(2)
                TextBox2.Text = reader(3)
                TextBox4.Text = reader(6)
                DateTimePicker1.Value = reader(3)
                'DateTimePicker2.Value = reader(4)

                cn.Close()
            End If
            TextBox3.Text = x
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim sql2 As String = "Select fname From Employee WHERE id='" & TextBox3.Text & "'"
        If String.IsNullOrEmpty(TextBox3.Text) Then
            'MsgBox("Please enter a valid employee ID.")
        Else
            Dim command As New SqlCommand(sql2, cn)
            Try
                cn.Open()
                Dim result As Object = command.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    ComboBox1.Text = result.ToString()
                Else
                    'MsgBox("Employee not found.")
                End If
            Catch ex As Exception
                'MsgBox("An error occurred while fetching employee data: " & ex.Message)
            Finally
                cn.Close()
            End Try
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select id From Employee WHERE fname='" & ComboBox1.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox3.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) 
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Show_info.Show()
        Show_info.TextBox1.Text = "Upgrades"
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Show_info.TextBox2.Text = "True"
            Show_info.DateTimePicker1.Value = DateTimePicker3.Value
        Else
            Show_info.TextBox2.Text = "False"
        End If
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        If CheckBox1.Checked = True Then
            Show_info.TextBox2.Text = "True"
            Show_info.DateTimePicker1.Value = DateTimePicker3.Value
        Else
            Show_info.TextBox2.Text = "False"
        End If
    End Sub
End Class