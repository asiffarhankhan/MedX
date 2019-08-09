Imports System.Data.OleDb

Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CheckBox1.Checked = False Then
            MsgBox("Please Agree to the Terms & Condition")
        ElseIf CheckBox1.Checked = True Then
            Dim connection As OleDbConnection = New OleDbConnection
            connection.ConnectionString = My.Settings.logindbc
            connection.Open()
            Dim updatequery As OleDbCommand = New OleDbCommand("INSERT INTO LoginTable (name1,name2,mobile,age,sex) VALUES(@name1,@name2,@num,@age,@sex)", connection)
            ComboBox1.Text = ""
            updatequery.Parameters.Add("@name1", OleDbType.VarChar).Value = TextBox1.Text
            updatequery.Parameters.Add("@name2", OleDbType.VarChar).Value = TextBox2.Text
            updatequery.Parameters.Add("@num", OleDbType.Numeric).Value = TextBox3.Text
            updatequery.Parameters.Add("@age", OleDbType.Numeric).Value = TextBox4.Text
            updatequery.Parameters.Add("@sex", OleDbType.VarChar).Value = ComboBox1.Text
            updatequery.ExecuteNonQuery()
            ComboBox1.Text = ""
            Me.Hide()
            Form3.Show()
            connection.Close()
        End If

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cur As Icon
        cur = (My.Resources.icons8_cursor_filled_50)
        Me.Cursor = New Cursor(cur.Handle)
    End Sub
End Class