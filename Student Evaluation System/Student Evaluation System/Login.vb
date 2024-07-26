Imports System.Data.SqlClient

Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'login
        Try
            Dim sql As SqlCommand = New SqlCommand("Select allow from Users where username='" + TextBox1.Text + "' And password='" + TextBox2.Text + "'", cn)
            Dim dt As New DataTable()
            cn.Open()
            Dim dataadapter As New SqlDataAdapter(sql)
            dataadapter.Fill(dt)
            Dim reader2 As SqlDataReader = sql.ExecuteReader
            reader2.Read()
            If reader2.HasRows Then
                Dim x = reader2(0)
                If x = "False" Then
                    MsgBox("لم يتم الموافقة عليك بعد من قبل مدير الموقع", MsgBoxStyle.Critical)
                ElseIf x = "True" Then
                    If (dt.Rows.Count > 0) Then
                            Main.Show()
                            Main.TextBox1.Text = TextBox10.Text
                            Main.TextBox2.Text = TextBox3.Text
                            Me.Close()

                        End If

                    End If
                    cn.Close()


                Else
                    MsgBox("تفقد اسم المستخدم وكلمة المرور", MsgBoxStyle.Critical)
            End If
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("Erorr !!", vbCritical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'registry
        Panel1.Visible = True
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'جلب نوع الحساب
        TextBox4.Text = ""
        TextBox3.Text = ""
        TextBox10.Text = ""
        Try
            Dim sql As String = "Select type_user from Users where username='" + TextBox1.Text + "'"
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox4.Text = reader(0)
                TextBox3.Text = TextBox4.Text
            End If
            cn.Close()

            If TextBox3.Text = "مدير" Then
            Else
                Dim sql2 As String = "Select Users.allow,type_user,id_teacher from Users,Teacher where user_id=id_user and username='" + TextBox1.Text + "'"
                Dim com2 As SqlCommand = New SqlCommand(sql2, cn)
                cn.Open()
                Dim reader2 As SqlDataReader = com2.ExecuteReader
                reader2.Read()
                If reader2.HasRows Then
                    Dim x = reader2(0)
                    If x = "True" Then
                        TextBox4.Text = reader2(1)
                        TextBox3.Text = TextBox4.Text
                        TextBox10.Text = reader2(2)
                    End If

                End If
                cn.Close()
            End If

        Catch ex As Exception
            TextBox4.Text = ""
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        TextBox3.Text = TextBox4.Text
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel1.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'انشاء حساب
        If TextBox9.Text = "" Then
            MsgBox("أدخل اسم المستخدم رجاءاً", MsgBoxStyle.Critical)
        Else
            Dim max As Integer
            Try
                Dim sql As String = "Select max(id_user) from Users"
                Dim command As New SqlCommand(sql, cn)
                cn.Open()
                Dim x = command.ExecuteScalar().ToString()
                max = x + 1
                cn.Close()
            Catch ex As Exception
            Finally
                cn.Close()
            End Try
            Try
                Dim sql As String = "INSERT INTO Users (id_user,fullname,username,password,age,type_user)  " _
            & "VALUES ('" & max & "','" & TextBox6.Text & "','" & TextBox9.Text & "','" & TextBox8.Text & "','" & TextBox5.Text & "','" & ComboBox1.Text & "')"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم أنشاء الحساب بنجاح", MsgBoxStyle.Information, "!!")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                MsgBox("حدث خطا ؟؟", MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class