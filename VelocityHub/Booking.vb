Imports MySql.Data.MySqlClient

Public Class Booking
    Dim connectionString As String = "Server=localhost;Database=velocityhub;Uid=root;Pwd=pass;"

    Private Sub Booking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataIntoDataGridView()
    End Sub

    Private Sub LoadDataIntoDataGridView()
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT bookingid, bikeid, customerid, rentaldate, returndate FROM booking"
            Using cmd As New MySqlCommand(query, connection)
                Using adapter As New MySqlDataAdapter(cmd)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    DataGridView1.DataSource = dataTable
                End Using
            End Using
        End Using
    End Sub

    Private Function ValidateInputs() As Boolean
        ' Check if mandatory fields are filled
        If String.IsNullOrEmpty(TextBox1.Text) OrElse String.IsNullOrEmpty(TextBox2.Text) OrElse String.IsNullOrEmpty(TextBox3.Text) Then
            MessageBox.Show("Please enter all required details.")
            Return False
        End If

        ' Check if the rental date is not later than the return date
        If DateTimePicker2.Value < DateTimePicker1.Value Then
            MessageBox.Show("Rental date cannot be later than return date.")
            Return False
        End If

        ' Check if the bike is already booked for the selected dates
        If IsBikeAlreadyBooked(TextBox2.Text, DateTimePicker1.Value.Date, DateTimePicker2.Value.Date) Then
            MessageBox.Show("This bike is already booked for the selected dates.")
            Return False
        End If
        ' Check if the bike is available in the bike table
        If Not IsBikeAvailable(TextBox2.Text) Then
            MessageBox.Show("This bike is not available for booking.")
            Return False
        End If

        Return True

       
    End Function


    Private Function IsBikeAlreadyBooked(bikeID As String, startDate As Date, endDate As Date) As Boolean
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT COUNT(*) FROM booking WHERE bikeid = @BikeID AND " &
                              "((rentaldate BETWEEN @StartDate AND @EndDate) OR (returndate BETWEEN @StartDate AND @EndDate))"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@BikeID", bikeID)
                cmd.Parameters.AddWithValue("@StartDate", startDate)
                cmd.Parameters.AddWithValue("@EndDate", endDate)

                Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                Return result > 0
            End Using
        End Using
    End Function


    Private Function IsBikeAvailable(bikeID As String) As Boolean
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT available FROM bike WHERE bikeid = @BikeID"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@BikeID", bikeID)

                Dim result As String = Convert.ToString(cmd.ExecuteScalar())

                ' Check if the bike is available
                Return String.Equals(result, "yes", StringComparison.OrdinalIgnoreCase)
            End Using
        End Using
    End Function


    Private Sub InsertData()
        Try
            If ValidateInputs() Then
                ' Additional checks passed, proceed with the booking
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()


                    Dim query As String = "INSERT INTO booking (bookingid, bikeid, customerid, rentaldate, returndate) VALUES (@BookingID, @BikeID, @CustomerID, @RentalDate, @ReturnDate)"
                        Using cmd As New MySqlCommand(query, connection)
                            cmd.Parameters.AddWithValue("@BookingID", TextBox1.Text)
                            cmd.Parameters.AddWithValue("@BikeID", TextBox2.Text)
                            cmd.Parameters.AddWithValue("@CustomerID", TextBox3.Text)
                            cmd.Parameters.AddWithValue("@RentalDate", DateTimePicker1.Value.Date)
                            cmd.Parameters.AddWithValue("@ReturnDate", DateTimePicker2.Value.Date)

                            cmd.ExecuteNonQuery()
                            MessageBox.Show("Booking successful!")

                            ' Redirect to Payment page
                            Dim paymentForm As New Payment()
                            paymentForm.FillPaymentDetails(TextBox1.Text) ' Pass the BookingID to Payment form
                            paymentForm.Show()
                            Me.Hide()
                        End Using

                End Using

                LoadDataIntoDataGridView()
                ResetFields()
            End If

        Catch ex As Exception
            MessageBox.Show("Error booking: " & ex.Message)
        End Try
    End Sub



    Private Sub CancelBooking()
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedBookingID As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("bookingid").Value)

            Try
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' Get bike ID and dates for the selected booking
                    Dim bikeID As String = DataGridView1.SelectedRows(0).Cells("bikeid").Value.ToString()

                    ' Delete booking record
                    Dim query As String = "DELETE FROM booking WHERE bookingid = @BookingID"
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@BookingID", selectedBookingID)

                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Booking canceled successfully!")


                    End Using
                End Using

                LoadDataIntoDataGridView()
                ResetFields()

            Catch ex As Exception
                MessageBox.Show("Error canceling booking: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please select a booking to cancel.")
        End If
    End Sub

    Private Sub ResetFields()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            TextBox1.Text = DataGridView1.SelectedRows(0).Cells("bookingid").Value.ToString()
            TextBox2.Text = DataGridView1.SelectedRows(0).Cells("bikeid").Value.ToString()
            TextBox3.Text = DataGridView1.SelectedRows(0).Cells("customerid").Value.ToString() ' Change to "customerid"
            DateTimePicker1.Value = Convert.ToDateTime(DataGridView1.SelectedRows(0).Cells("rentaldate").Value)
            DateTimePicker2.Value = Convert.ToDateTime(DataGridView1.SelectedRows(0).Cells("returndate").Value)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InsertData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ResetFields()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CancelBooking()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Home.Show()
        Me.Hide()
    End Sub
End Class
