Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Label1.ForeColor = ColorDialog1.Color
            Label1.Text = "HELLO KHUSHNAAZ"
        End If
    End Sub
End Class
