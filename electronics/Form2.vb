Imports System.Data.OleDb

Public Class Form2
    Dim con As OleDbConnection
    Dim ds As DataSet

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New OleDbConnection("Data Source=localhost; Password=khushnaaz; User id=system; Provider=ORAOLEDB.Oracle")
        filldatagrid()
        filldatagrid1()
    End Sub

    Private Sub filldatagrid()
        ds = New DataSet
        Dim adp As New OleDbDataAdapter("select * from shopping", con)
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub insert_btn_Click(sender As Object, e As EventArgs) Handles insert_btn.Click
        Try
            con.Open()
            Dim qry As String
            qry = "insert into shopping values(?,?,?,?)"
            Dim cmd As OleDbCommand
            cmd = New OleDbCommand(qry, con)

            cmd.Parameters.AddWithValue("?", i_id.SelectedItem(0))
            cmd.Parameters.AddWithValue("?", i_name.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("?", NumericUpDown1.Value)
            cmd.Parameters.AddWithValue("?", i_color.SelectedItem.ToString)

            Dim res = cmd.ExecuteNonQuery()
            con.Close()

            If res >= 1 Then
                MsgBox("Data Inserted!")
                filldatagrid()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Update_btn_Click(sender As Object, e As EventArgs) Handles Update_btn.Click
        Try
            con.Open()
            Dim qry As String
            qry = "update shopping set i_name=?, stock=?, color=? where i_id=?"
            Dim cmd As OleDbCommand
            cmd = New OleDbCommand(qry, con)

            cmd.Parameters.AddWithValue("?", i_name.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("?", NumericUpDown1.Value)
            cmd.Parameters.AddWithValue("?", i_color.SelectedItem.ToString)
            cmd.Parameters.AddWithValue("?", i_id.SelectedItem)

            Dim res = cmd.ExecuteNonQuery()
            con.Close()

            If res >= 1 Then
                MsgBox("Updated Successfully!")
                filldatagrid()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub delete_btn_Click(sender As Object, e As EventArgs) Handles delete_btn.Click
        Try
            con.Open()
            Dim qry As String
            qry = "delete from shopping where i_id=?"
            Dim cmd As OleDbCommand
            cmd = New OleDbCommand(qry, con)

            cmd.Parameters.AddWithValue("?", i_id.SelectedItem(0))

            Dim res = cmd.ExecuteNonQuery()
            con.Close()

            If res >= 1 Then
                MsgBox("Data Deleted")
                filldatagrid()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 AndAlso DataGridView1.Focused Then
            Try
                i_id.SelectedItem = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
                i_name.SelectedItem = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                NumericUpDown1.Value = DataGridView1.SelectedRows(0).Cells(2).Value.ToString
                i_color.SelectedItem = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Insert_bill_Click(sender As Object, e As EventArgs) Handles Insert_bill.Click
        Try
            con.Open()
            Dim qry As String
            qry = "insert into billing values (?,?,TO_DATE(?,'DD-MM-YYYY'),?,?)"
            Dim cmd As OleDbCommand
            cmd = New OleDbCommand(qry, con)

            cmd.Parameters.AddWithValue("?", TextBox1.Text)
            cmd.Parameters.AddWithValue("?", TextBox2.Text)
            cmd.Parameters.AddWithValue("?", DateTimePicker1.Value.ToString("dd-MM-yyyy"))
            cmd.Parameters.AddWithValue("?", NumericUpDown2.Value)
            cmd.Parameters.AddWithValue("?", TextBox3.Text)

            Dim res = cmd.ExecuteNonQuery()
            con.Close()

            If res >= 1 Then
                MsgBox("Data Inserted")
                filldatagrid1()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub filldatagrid1()
        ds = New DataSet
        Dim adp As New OleDbDataAdapter("select * from billing", con)
        adp.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
    End Sub

    Private Sub Update_bill_Click(sender As Object, e As EventArgs) Handles Update_bill.Click
        Try
            con.Open()
            Dim qry As String
            qry = "update billing set i_id=?, b_date=TO_DATE(?, 'DD-MM-YYYY'), no_of_items=?, price=? where b_id=?"
            Dim cmd As OleDbCommand
            cmd = New OleDbCommand(qry, con)

            cmd.Parameters.AddWithValue("?", TextBox2.Text)
            cmd.Parameters.AddWithValue("?", DateTimePicker1.Value.ToString("dd-MM-yyyy"))
            cmd.Parameters.AddWithValue("?", NumericUpDown2.Value)
            cmd.Parameters.AddWithValue("?", TextBox3.Text)
            cmd.Parameters.AddWithValue("?", TextBox1.Text)

            Dim res = cmd.ExecuteNonQuery()
            con.Close()

            If res >= 1 Then
                MsgBox("Data Updated")
                filldatagrid1()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub delete_bill_Click(sender As Object, e As EventArgs) Handles delete_bill.Click
        Try
            con.Open()
            Dim qry As String
            qry = "delete from billing where b_id=?"
            Dim cmd As OleDbCommand
            cmd = New OleDbCommand(qry, con)

            cmd.Parameters.AddWithValue("?", TextBox1.Text)

            Dim res = cmd.ExecuteNonQuery()
            con.Close()

            If res >= 1 Then
                MsgBox("Data Deleted")
                filldatagrid1()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged
        If DataGridView2.SelectedRows.Count > 0 AndAlso DataGridView2.Focused Then
            Try
                TextBox1.Text = DataGridView2.SelectedRows(0).Cells(0).Value.ToString
                TextBox2.Text = DataGridView2.SelectedRows(0).Cells(1).Value.ToString
                DateTimePicker1.Value = DataGridView2.SelectedRows(0).Cells(2).Value.ToString
                NumericUpDown2.Value = DataGridView2.SelectedRows(0).Cells(3).Value.ToString
                TextBox3.Text = DataGridView2.SelectedRows(0).Cells(4).Value.ToString
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class