Imports System.Data.OleDb
Public Class Form1
    Dim dr As OleDbDataReader
    Public ame As String

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Login.Click
        Dim myconnection As OleDbConnection = New OleDbConnection
        myconnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\LoginDB.accdb"
        myconnection.Open()
        Dim cmd As OleDbCommand = New OleDbCommand("Select * from LoginTable where Username = '" & TextBox1.Text & "' AND Password = '" & TextBox2.Text & "'", myconnection)

        dr = cmd.ExecuteReader
        If (dr.Read = True) Then
            ame = dr(1)

            Form10.Show()
            TextBox1.Text = ""
            TextBox2.Text = ""
        Else
            Form11.Show()

        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus

        TextBox1.Text = ""
    End Sub


    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        TextBox2.Text = ""
        TextBox2.PasswordChar = "•"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cur As Icon
        cur = (My.Resources.icons8_cursor_filled_50)
        Me.Cursor = New Cursor(cur.Handle)
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Hide()
        Form9.Show()
    End Sub
End Class

