Imports System.Data.OleDb

Public Class Form1
    Dim con As OleDbConnection
    Dim ds As DataSet

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con = New OleDbConnection("Data Source=localhost;Password=khushnaaz;User id=system;Provider=ORAOLEDB.Oracle")
        filldatagrid()
        filldatagrid1()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            con.Open()
            Dim qry As String
            qry = "insert into toy values(?,?,?,?,?)"
            Dim command As OleDbCommand
            command = New OleDbCommand(qry, con)

            Dim ageCategory As Integer
            If RadioButton1.Checked Then
                ageCategory = 1
            ElseIf RadioButton2.Checked Then
                ageCategory = 2
            ElseIf RadioButton3.Checked Then
                ageCategory = 3
            End If

            command.Parameters.AddWithValue("?", ComboBox1.SelectedItem(0))
            command.Parameters.AddWithValue("?", ComboBox2.SelectedItem.ToString)
            command.Parameters.AddWithValue("?", ageCategory)
            command.Parameters.AddWithValue("?", NumericUpDown1.Value)
            command.Parameters.AddWithValue("?", TextBox1.Text)

            Dim res = command.ExecuteNonQuery()
            con.Close()

            If res >= 1 Then
                MsgBox("Data Inserted")
                filldatagrid()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub filldatagrid()
        ds = New DataSet
        Dim adp As New OleDbDataAdapter("select * from toy", con)
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            con.Open()
            Dim qry As String
            qry = "update toy set t_name=?, age_categoary=?, quantity=?, price_per_toy=? where t_id=?"
            Dim command As New OleDbCommand(qry, con)

            Dim ageCategory As Integer
            If RadioButton1.Checked Then
                ageCategory = 1
            ElseIf RadioButton2.Checked Then
                ageCategory = 2
            ElseIf RadioButton3.Checked Then
                ageCategory = 3
            End If


            command.Parameters.AddWithValue("?", ComboBox2.SelectedItem.ToString)
            command.Parameters.AddWithValue("?", ageCategory)
            command.Parameters.AddWithValue("?", NumericUpDown1.Value)
            command.Parameters.AddWithValue("?", TextBox1.Text)
            command.Parameters.AddWithValue("?", ComboBox1.SelectedItem)


            Dim res = command.ExecuteNonQuery()
            con.Close()

            If res >= 1 Then
                MsgBox("Updated successfully!")
                filldatagrid()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            con.Open()
            Dim qry As String
            qry = "delete from toy where t_id=?"
            Dim command As New OleDbCommand(qry, con)

            command.Parameters.AddWithValue("?", ComboBox1.SelectedItem(0))

            Dim res = command.ExecuteNonQuery()
            con.Close()

            If res >= 1 Then
                MsgBox("Deleted successfully!")
                filldatagrid()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 AndAlso DataGridView1.Focused Then
            Try
                ComboBox1.SelectedItem = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
                ComboBox2.SelectedItem = DataGridView1.SelectedRows(0).Cells(1).Value.ToString

                Dim ageCategory As Integer = CInt(DataGridView1.SelectedRows(0).Cells(2).Value)

                'Set the appropriate radio button based on the age category
                If ageCategory = 1 Then
                    RadioButton1.Checked = True
                ElseIf ageCategory = 2 Then
                    RadioButton2.Checked = True
                ElseIf ageCategory = 3 Then
                    RadioButton3.Checked = True
                End If

                NumericUpDown1.Value = CDec(DataGridView1.SelectedRows(0).Cells(3).Value.ToString)
                TextBox1.Text = DataGridView1.SelectedRows(0).Cells(4).Value.ToString


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
        con = New OleDbConnection("Data Source=localhost;Password=khushnaaz;User id=system;Provider=ORAOLEDB.Oracle")
        filldatagrid1()
    End Sub

    Private Sub filldatagrid1()
        ds = New DataSet
        Dim adp As New OleDbDataAdapter("select * from bill", con)
        adp.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            con.Open()
            Dim qry As String
            qry = "insert into bill values(?,?,TO_DATE(?,'DD-MM-YYYY'),?,?,?,?,?)"
            Dim command As OleDbCommand
            command = New OleDbCommand(qry, con)

            command.Parameters.AddWithValue("?", ComboBox3.SelectedItem)
            command.Parameters.AddWithValue("?", CInt(txt_id.Text))
            command.Parameters.AddWithValue("?", DateTimePicker1.Value.ToString("dd-MM-yyyy"))
            command.Parameters.AddWithValue("?", txt_name.Text)
            command.Parameters.AddWithValue("?", NumericUpDown2.Value)
            command.Parameters.AddWithValue("?", txt_price.Text)
            command.Parameters.AddWithValue("?", txt_discount.Text)
            command.Parameters.AddWithValue("?", txt_total_price.Text)

            Dim res = command.ExecuteNonQuery()
            con.Close()

            If res >= 1 Then
                MsgBox("Data Inserted")
                filldatagrid1()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            con.Open()
            Dim qry As String
            qry = "update bill set t_id=?, b_date=TO_DATE(?,'DD-MM-YYYY'), c_name=?, quantity1=?, price=?, discount=?, total_amount=? where b_id=?"
            Dim command As New OleDbCommand(qry, con)

            command.Parameters.AddWithValue("?", ComboBox3.SelectedItem)
            command.Parameters.AddWithValue("?", DateTimePicker1.Value.ToString("dd-MM-yyyy"))
            command.Parameters.AddWithValue("?", txt_name.Text)
            command.Parameters.AddWithValue("?", NumericUpDown2.Value)
            command.Parameters.AddWithValue("?", txt_price.Text)
            command.Parameters.AddWithValue("?", txt_discount.Text)
            command.Parameters.AddWithValue("?", txt_total_price.Text)
            command.Parameters.AddWithValue("?", txt_id.Text)


            Dim res = command.ExecuteNonQuery()
            con.Close()

            If res >= 1 Then
                MsgBox("Updated successfully!")
                filldatagrid1()
                con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            con.Open()
            Dim qry As String
            qry = "delete from bill where b_id=?"
            Dim command As New OleDbCommand(qry, con)

            command.Parameters.AddWithValue("?", txt_id.Text)

            Dim res = command.ExecuteNonQuery()
            con.Close()

            If res >= 1 Then
                MsgBox("Deleted successfully!")
                filldatagrid1()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
    End Sub

    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged
        If DataGridView2.SelectedRows.Count > 0 AndAlso DataGridView2.Focused Then
            Try
                ComboBox3.SelectedItem = DataGridView2.SelectedRows(0).Cells(0).Value.ToString
                txt_id.Text = DataGridView2.SelectedRows(0).Cells(1).Value.ToString
                DateTimePicker1.Value = DataGridView2.SelectedRows(0).Cells(2).Value.ToString
                txt_name.Text = DataGridView2.SelectedRows(0).Cells(3).Value.ToString
                NumericUpDown2.Value = DataGridView2.SelectedRows(0).Cells(4).Value.ToString
                txt_price.Text = DataGridView2.SelectedRows(0).Cells(5).Value.ToString
                txt_discount.Text = DataGridView2.SelectedRows(0).Cells(6).Value.ToString
                txt_total_price.Text = DataGridView2.SelectedRows(0).Cells(7).Value.ToString

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class

