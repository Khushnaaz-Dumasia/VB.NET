Imports System.Data.OleDb

Public Class Form1
    Dim connection As OleDbConnection
    Dim ds As DataSet
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New OleDbConnection("Data Source=localhost; Password=shweta_1920; User id=system; Provider =OraOLEDB.Oracle")
        fillDataGrid()
    End Sub

    Private Sub fillDataGrid()
        'to fill datagrid view
        ds = New DataSet
        Dim adp As New OleDbDataAdapter("Select * from inventory", connection)
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            connection.Open()
            Dim qry As New String("insert into inventory(iid,item_name,quantity,total_price,company_name,payment_date,delivery_date) values(?,?,?,?,?,TO_DATE(?,'DD-MM-YYYY'),TO_DATE(?,'DD-MM-YYYY'))")
            Dim command As New OleDbCommand(qry, connection)
            command.Parameters.AddWithValue("?", txt_id.Text)
            command.Parameters.AddWithValue("?", ComboBox1.SelectedItem)
            command.Parameters.AddWithValue("?", NumericUpDown1.Value)
            command.Parameters.AddWithValue("?", txt_price.Text)
            command.Parameters.AddWithValue("?", txt_company.Text)
            command.Parameters.AddWithValue("?", DateTimePicker1.Value.ToString("dd-MM-yyyy"))
            command.Parameters.AddWithValue("?", DateTimePicker2.Value.ToString("dd-MM-yyyy"))

            Dim res = command.ExecuteNonQuery()

            If (res >= 1) Then
                MsgBox("Data Inserted")
                fillDataGrid()
            End If
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result = MessageBox.Show("Are you sure you want to delete?", "Heads Up!", MessageBoxButtons.YesNo)
        If (result = DialogResult.No) Then
            Return
        End If
        Try
            connection.Open()
            Dim qry As New String("Delete from inventory where iid=?")
            Dim command As New OleDbCommand(qry, connection)
            command.Parameters.AddWithValue("?", txt_id.Text)

            Dim res = command.ExecuteNonQuery()

            If (res >= 1) Then
                MsgBox("Data Inserted")
                fillDataGrid()
            End If
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
