Imports MySql.Data.MySqlClient

Public Class Customer

    Dim connectionString As String = "Server=localhost;Database=velocityhub;Uid=root;Pwd=pass;"

    Private Sub Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataIntoDataGridView()
    End Sub

    Private Sub LoadDataIntoDataGridView()
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT * FROM customer"
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

                    Dim query As String = "INSERT INTO customer (CustomerID, Name, Phone_No, Address, Aadhar_No) VALUES (@CustomerID, @Name, @PhoneNo, @Address, @AadharNo)"
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@CustomerID", TextBox1.Text)
                        cmd.Parameters.AddWithValue("@Name", TextBox2.Text)
                        cmd.Parameters.AddWithValue("@PhoneNo", TextBox5.Text)
                        cmd.Parameters.AddWithValue("@Address", TextBox3.Text)
                        cmd.Parameters.AddWithValue("@AadharNo", TextBox4.Text)

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

                    Dim query As String = "UPDATE customer SET Name = @Name, Phone_No = @PhoneNo, Address = @Address, Aadhar_No = @AadharNo WHERE CustomerID = @CustomerID"
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@CustomerID", TextBox1.Text)
                        cmd.Parameters.AddWithValue("@Name", TextBox2.Text)
                        cmd.Parameters.AddWithValue("@PhoneNo", TextBox5.Text)
                        cmd.Parameters.AddWithValue("@Address", TextBox3.Text)
                        cmd.Parameters.AddWithValue("@AadharNo", TextBox4.Text)

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
            Dim selectedCustomerID As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("CustomerID").Value)

            Try
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim query As String = "DELETE FROM customer WHERE CustomerID = @CustomerID"
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@CustomerID", selectedCustomerID)

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
            TextBox1.Text = DataGridView1.SelectedRows(0).Cells("CustomerID").Value.ToString()
            TextBox2.Text = DataGridView1.SelectedRows(0).Cells("Name").Value.ToString()
            TextBox3.Text = DataGridView1.SelectedRows(0).Cells("Address").Value.ToString()
            TextBox4.Text = DataGridView1.SelectedRows(0).Cells("Aadhar_No").Value.ToString()
            TextBox5.Text = DataGridView1.SelectedRows(0).Cells("Phone_No").Value.ToString()
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

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Allow only numeric input for CustomerID
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("Please enter numeric values for Customer ID.")
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        ' Allow only numeric input for AadharNo
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("Please enter numeric values for Aadhar number.")
        ElseIf TextBox5.Text.Length >= 12 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("Phone number cannot exceed 12 digits.")
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        ' Allow only numeric input for PhoneNo
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("Please enter numeric values for Phone number.")
        ElseIf TextBox5.Text.Length >= 10 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("Phone number cannot exceed 10 digits.")
        End If
    End Sub

    ' Additional validation or checks can be added based on your specific requirements

    Private Function ValidateInputs() As Boolean
        ' Perform any additional validation here if needed
        ' For example, check if mandatory fields are filled
        If String.IsNullOrEmpty(TextBox1.Text) OrElse String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Please enter all the fields correctly.")
            Return False
        End If

        Return True
    End Function

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Admin.Show()
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
