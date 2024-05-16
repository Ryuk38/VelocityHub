<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payment
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        Label1 = New Label()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        DateTimePicker1 = New DateTimePicker()
        TextBox3 = New TextBox()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Teal
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(2, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1223, 101)
        Panel1.TabIndex = 15
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(497, 24)
        Label1.Name = "Label1"
        Label1.Size = New Size(164, 50)
        Label1.TabIndex = 0
        Label1.Text = "Payment"
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(358, 463)
        Button3.Name = "Button3"
        Button3.Size = New Size(76, 29)
        Button3.TabIndex = 28
        Button3.Text = "Cancel"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(191, 463)
        Button2.Name = "Button2"
        Button2.Size = New Size(76, 29)
        Button2.TabIndex = 27
        Button2.Text = "Reset"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(43, 463)
        Button1.Name = "Button1"
        Button1.Size = New Size(76, 29)
        Button1.TabIndex = 26
        Button1.Text = "Book"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(229, 365)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(182, 27)
        DateTimePicker1.TabIndex = 24
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(229, 300)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(179, 27)
        TextBox3.TabIndex = 23
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(229, 248)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(179, 27)
        TextBox2.TabIndex = 22
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(229, 196)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(179, 27)
        TextBox1.TabIndex = 21
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(74, 361)
        Label5.Name = "Label5"
        Label5.Size = New Size(68, 31)
        Label5.TabIndex = 19
        Label5.Text = " Date"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(74, 300)
        Label4.Name = "Label4"
        Label4.Size = New Size(96, 31)
        Label4.TabIndex = 18
        Label4.Text = "Amount"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(74, 196)
        Label3.Name = "Label3"
        Label3.Size = New Size(124, 31)
        Label3.TabIndex = 17
        Label3.Text = "PaymentID"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(74, 248)
        Label2.Name = "Label2"
        Label2.Size = New Size(117, 31)
        Label2.TabIndex = 16
        Label2.Text = "BookingId"
        ' 
        ' Payment
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1222, 753)
        Controls.Add(Panel1)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(DateTimePicker1)
        Controls.Add(TextBox3)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Name = "Payment"
        Text = "Payment"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
