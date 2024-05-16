Imports MySql.Data.MySqlClient

Public Class Register

    Dim connectionString As String = "Server=localhost;Database=velocityhub;Uid=root;Pwd=pass;"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RegisterAdmin
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub RegisterAdmin()
        Try
            If ValidateInputs() Then
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim query As String = "INSERT INTO Admin (Username, Password) VALUES (@Username, @Password)"
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@Username", TextBox1.Text)
                        cmd.Parameters.AddWithValue("@Password", TextBox2.Text)

                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Admin registered successfully!")
                        TextBox1.Text = ""
                        TextBox2.Text = ""
                    End Using
                End Using

            End If

        Catch ex As Exception
            MessageBox.Show("Error registering admin: " & ex.Message)
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        ' Validate username
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Please enter a username.")
            Return False
        ElseIf Not TextBox1.Text.All(Function(c) Char.IsLetterOrDigit(c)) Then
            MessageBox.Show("Username must be alphanumeric.")
            Return False
        End If

        ' Validate password (you can add more validation as needed)
        If String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Please enter a password.")
            Return False
        End If

        Return True
    End Function

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Login.Show()
        Me.Hide()
    End Sub
End Class

