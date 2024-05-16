
Imports MySql.Data.MySqlClient



Public Class Bike

    Dim connectionString As String = "Server=localhost;Database=velocityhub;Uid=root;Pwd=pass;"

    Private Sub Bike_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataIntoDataGridView()
    End Sub

    Private Sub LoadDataIntoDataGridView()
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT * FROM bike"
            Using cmd As New MySqlCommand(query, connection)
                Using adapter As New MySqlDataAdapter(cmd)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    DataGridView1.DataSource = dataTable
                End Using
            End Using
        End Using
    End Sub

    Private Sub InsertData()
        Try
            If ValidateInputs() Then
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim query As String = "INSERT INTO bike (bikeid, model, regno, available, price) VALUES (@BikeID, @Model, @RegNo, @Available, @Price)"
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@BikeID", TextBox1.Text)
                        cmd.Parameters.AddWithValue("@Model", TextBox2.Text)
                        cmd.Parameters.AddWithValue("@RegNo", TextBox5.Text)
                        cmd.Parameters.AddWithValue("@Available", TextBox3.Text)
                        cmd.Parameters.AddWithValue("@Price", TextBox4.Text)

                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Data inserted successfully!")
                    End Using
                End Using

                LoadDataIntoDataGridView()
                ResetFields()

            End If

        Catch ex As Exception
            MessageBox.Show("Error inserting data: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateData()
        Try
            If ValidateInputs() Then
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim query As String = "UPDATE bike SET model = @Model, regno = @RegNo, available = @Available, price = @Price WHERE bikeid = @BikeID"
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@BikeID", TextBox1.Text)
                        cmd.Parameters.AddWithValue("@Model", TextBox2.Text)
                        cmd.Parameters.AddWithValue("@RegNo", TextBox5.Text)
                        cmd.Parameters.AddWithValue("@Available", TextBox3.Text)
                        cmd.Parameters.AddWithValue("@Price", TextBox4.Text)

                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Data updated successfully!")
                    End Using
                End Using

                LoadDataIntoDataGridView()
                ResetFields()

            End If

        Catch ex As Exception
            MessageBox.Show("Error updating data: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteData()
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedBikeID As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("bikeid").Value)

            Try
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim query As String = "DELETE FROM bike WHERE bikeid = @BikeID"
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@BikeID", selectedBikeID)

                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Data deleted successfully!")
                    End Using
                End Using

                LoadDataIntoDataGridView()
                ResetFields()

            Catch ex As Exception
                MessageBox.Show("Error deleting data: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub

    Private Sub ResetFields()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            TextBox1.Text = DataGridView1.SelectedRows(0).Cells("bikeid").Value.ToString()
            TextBox2.Text = DataGridView1.SelectedRows(0).Cells("model").Value.ToString()
            TextBox5.Text = DataGridView1.SelectedRows(0).Cells("regno").Value.ToString()
            TextBox3.Text = DataGridView1.SelectedRows(0).Cells("available").Value.ToString()
            TextBox4.Text = DataGridView1.SelectedRows(0).Cells("price").Value.ToString()
        End If
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InsertData()
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UpdateData()
    End Sub

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DeleteData()
    End Sub

    Private Sub button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ResetFields()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Allow only numeric input for BikeID
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("Please enter numeric values for Bike ID.")
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        ' Allow only numeric input for Price
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
            MessageBox.Show("Please enter numeric values for Price.")
        End If
    End Sub



    Private Function ValidateInputs() As Boolean
        ' Perform any additional validation here if needed
        ' For example, check if mandatory fields are filled
        If String.IsNullOrEmpty(TextBox1.Text) OrElse String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Please enter both Bike ID and Model.")
            Return False
        End If

        Return True
    End Function

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Customer.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Home.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Admin.Show()
        Me.Hide()
    End Sub
End Class
