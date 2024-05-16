Imports MySql.Data.MySqlClient

Public Class Admin

    Dim connectionString As String = "Server=localhost;Database=velocityhub;Uid=root;Pwd=pass;"

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataIntoDataGridView()
    End Sub

    Private Sub LoadDataIntoDataGridView()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT * FROM Admin"
                Using cmd As New MySqlCommand(query, connection)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)

                        DataGridView1.DataSource = dataTable
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading admin data: " & ex.Message)
        End Try
    End Sub

    Private Sub InsertData()
        Try
            If ValidateInputs() Then
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim query As String = "INSERT INTO Admin (Username, Password) VALUES (@Username, @Password)"
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@Username", TextBox1.Text)
                        cmd.Parameters.AddWithValue("@Password", TextBox2.Text)

                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Admin data inserted successfully!")
                    End Using
                End Using

                LoadDataIntoDataGridView()
                ResetFields()

            End If

        Catch ex As Exception
            MessageBox.Show("Error inserting admin data: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateData()
        Try
            If ValidateInputs() Then
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim query As String = "UPDATE Admin SET Password = @Password WHERE Username = @Username"
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@Username", TextBox1.Text)
                        cmd.Parameters.AddWithValue("@Password", TextBox2.Text)

                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Admin data updated successfully!")
                    End Using
                End Using

                LoadDataIntoDataGridView()
                ResetFields()

            End If

        Catch ex As Exception
            MessageBox.Show("Error updating admin data: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteData()
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedUsername As String = DataGridView1.SelectedRows(0).Cells("Username").Value.ToString()

            Try
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim query As String = "DELETE FROM Admin WHERE Username = @Username"
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@Username", selectedUsername)

                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Admin data deleted successfully!")
                    End Using
                End Using

                LoadDataIntoDataGridView()
                ResetFields()

            Catch ex As Exception
                MessageBox.Show("Error deleting admin data: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub

    Private Sub ResetFields()
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub
    Private Function ValidateInputs() As Boolean
        ' Perform any additional validation here if needed
        ' For example, check if mandatory fields are filled
        If String.IsNullOrEmpty(TextBox1.Text) OrElse String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Please enter all the fields correctly.")
            Return False
        End If

        Return True
    End Function
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            TextBox1.Text = DataGridView1.SelectedRows(0).Cells("Username").Value.ToString()
            TextBox2.Text = DataGridView1.SelectedRows(0).Cells("Password").Value.ToString()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InsertData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UpdateData()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DeleteData()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ResetFields()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Customer.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Bike.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Home.Show()
        Me.Hide()
    End Sub
End Class
