Imports System.Data.OleDb

Public Class Form1
    Dim con As OleDbConnection


    Private Sub Login_btn_Click(sender As Object, e As EventArgs) Handles Login_btn.Click
        Dim cmd As New OleDbCommand("select * from login where username='" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'", con)
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            MsgBox("Welcome")
            dr.Close()
            Form2.Show()
        Else
            MsgBox("Invalid Username and Password")
            TextBox1.Clear()
            TextBox2.Clear()
        End If

        dr.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New OleDbConnection("Data Source = localhost; Password=khushnaaz; User id = system; Provider=ORAOLEDB.Oracle")
        con.Open()
    End Sub
End Class
