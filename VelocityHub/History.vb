Imports MySql.Data.MySqlClient

Public Class history
    Dim connectionString As String = "Server=localhost;Database=velocityhub;Uid=root;Pwd=pass;"
    Dim connection As MySqlConnection

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the MySqlConnection with the connection string
        connection = New MySqlConnection(connectionString)

        ' Populate the DataGridView with all data initially (optional)
        RefreshDataGridView()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Get the Booking ID from TextBox1
        Dim bookingId As Integer
        If Integer.TryParse(TextBox1.Text, bookingId) Then
            ' Execute a query to retrieve the data based on the Booking ID
            Dim query As String = $"SELECT * FROM booking WHERE BookingID = {bookingId};"
            Dim adapter As New MySqlDataAdapter(query, connection)
            Dim dataTable As New DataTable()

            ' Open the connection
            connection.Open()

            ' Fill the DataTable with the results
            adapter.Fill(dataTable)

            ' Close the connection
            connection.Close()

            If dataTable.Rows.Count > 0 Then
                ' Display the results in the DataGridView
                DataGridView1.DataSource = dataTable
            Else
                MessageBox.Show("Booking not found in the database.")
            End If
        Else
            MessageBox.Show("Invalid Booking ID. Please enter a valid integer.")
        End If
    End Sub

    Private Sub RefreshDataGridView()
        ' Execute a query to retrieve all data from the booking table
        Dim query As String = "SELECT * FROM booking;"
        Dim adapter As New MySqlDataAdapter(query, connection)
        Dim dataTable As New DataTable()

        ' Open the connection
        connection.Open()

        ' Fill the DataTable with the results
        adapter.Fill(dataTable)

        ' Close the connection
        connection.Close()

        ' Display the results in the DataGridView
        DataGridView1.DataSource = dataTable
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Reset the TextBox and refresh the DataGridView
        TextBox1.Text = ""
        RefreshDataGridView()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Allow only numeric input and backspace
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("Please enter numeric values only.")
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Home.Show()
        Me.Hide()
    End Sub
End Class
