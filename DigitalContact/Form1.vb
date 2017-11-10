Public Class Form1
    Private Sub ContactsTableBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles ContactsTableBindingNavigatorSaveItem.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ContactTableDataSet.ContactsTable' table. You can move, or remove it, as needed.
        Me.ContactsTableTableAdapter.Fill(Me.ContactTableDataSet.ContactsTable)
        If ComboBox1.Text = Nothing Then
            Try
                ContactsTableBindingSource.AddNew()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FirstNameTextBox.Text = Nothing Then
            FirstNameTextBox.Text = "Unknown"
        End If
        If LastNameTextBox.Text = Nothing Then
            LastNameTextBox.Text = "Unknown"
        End If
        If AddressTextBox.Text = Nothing Then
            AddressTextBox.Text = "Unknow"
        End If
        If PhoneNumberTextBox.Text = Nothing Then
            PhoneNumberTextBox.Text = "Unknown"
        End If
        If Email_AddressTextBox.Text = Nothing Then
            Email_AddressTextBox.Text = "Unkown"
        End If
        Try
            Me.Validate()
            Me.ContactsTableBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.ContactTableDataSet)
            MessageBox.Show("Contact has been saved", "Information", MessageBoxButtons.OK)
            ContactsTableBindingSource.AddNew()
            FirstNameTextBox.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ContactsTableBindingSource.AddNew()
            FirstNameTextBox.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Select Case MsgBox("Are you sure you want to Delete the current contact?", MsgBoxStyle.YesNo, "ARE YOU SURE?")
            Case MsgBoxResult.Yes
                Try
                    ContactsTableBindingSource.RemoveCurrent()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Case MsgBoxResult.No
                ''nothing
        End Select
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            ContactsTableBindingSource.MovePrevious()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            ContactsTableBindingSource.MoveNext()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
