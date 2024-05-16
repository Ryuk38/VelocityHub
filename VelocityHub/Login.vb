Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class Login

    Dim connectionString As String = "Server=localhost;Database=velocityhub;Uid=root;Pwd=pass;"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Front-end validation
        If String.IsNullOrEmpty(TextBox1.Text) OrElse String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Please enter both username and password.")
            Return
        End If

        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        If ValidateUser(username, password) Then
            Home.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid username or password. Please try again.")
        End If
    End Sub

    Private Function ValidateUser(username As String, password As String) As Boolean
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT COUNT(*) FROM Admin WHERE Username = @Username AND Password = @Password"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@Username", username)
                cmd.Parameters.AddWithValue("@Password", password)

                Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                Return result > 0
            End Using
        End Using
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Register.show()
        Me.Hide()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
