Imports MySql.Data.MySqlClient

Public Class Payment

    Dim connectionString As String = "Server=localhost;Database=velocityhub;Uid=root;Pwd=pass;"

    ' Method to fill payment details based on the booking ID
    Public Sub FillPaymentDetails(bookingID As String)
        ' Implement logic to fetch booking details and set TextBoxes on this form
        ' Example:
        TextBox2.Text = bookingID
        DateTimePicker1.Value = DateTime.Now
    End Sub

    ' Method to save payment data to the payment table
    Private Sub SavePaymentData()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "INSERT INTO payment (PaymentID, BookingID, Amount, PaymentDate) VALUES (@PaymentID, @BookingID, @Amount, @PaymentDate)"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@PaymentID", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@BookingID", TextBox2.Text)
                    cmd.Parameters.AddWithValue("@Amount", TextBox3.Text)
                    cmd.Parameters.AddWithValue("@PaymentDate", DateTimePicker1.Value.Date)

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Payment successful!")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving payment data: " & ex.Message)
        End Try
    End Sub

    ' Additional methods and event handlers as needed
End Class

