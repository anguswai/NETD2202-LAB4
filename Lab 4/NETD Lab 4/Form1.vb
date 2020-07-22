Option Strict On

' Name: Angus Wai (100719558)
' Date: 2020-07-21
' Description: Car inventory application for Lab 4

Public Class frmCarInventory
    Dim editMode As Boolean = False
    Dim currentlySelectedIndex As Integer = -1
    Dim cars As New List(Of Car)

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        lblOutput.Text = String.Empty
        If Validation(cbMake, txtModel, nudYear, txtPrice) Then
            ' Validation successful
            If editMode Then
                ' editMode not implemented due to time constraint

                lblOutput.Text = "Updated car"
            Else
                ' Create new car

                Dim car As Car = New Car(cbMake.Text, txtModel.Text, CInt(nudYear.Value), CInt(txtPrice.Text), ckNew.Checked)
                Dim id As String = car.GetCarData()

                ' Create a new car with its info
                Dim item As New ListViewItem
                item.Checked = ckNew.Checked
                item.SubItems.Add(id)
                item.SubItems.Add(cbMake.Text)
                item.SubItems.Add(txtModel.Text)
                item.SubItems.Add(nudYear.Text)
                item.SubItems.Add(txtPrice.Text)

                ' Add the car to the listview
                lvCarList.Items.Add(item)

                ' Reset the form
                ResetForm()

                lblOutput.Text = "Added new car"
            End If
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ResetForm()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    ' ListSelectedIndexChanged not implemented due to time constraint
    Private Sub ListSelectedIndexChanged(sender As Object, e As EventArgs) Handles lvCarList.SelectedIndexChanged
        If (Not lvCarList.FocusedItem Is Nothing) Then

        End If
    End Sub

    ' Resets the form to the default format
    Private Sub ResetForm()
        lvCarList.SelectedItems.Clear()
        cbMake.SelectedIndex = -1
        txtModel.Text = String.Empty
        nudYear.Value = 2020
        txtPrice.Text = String.Empty
        ckNew.Checked = False
    End Sub

    ' Validates user input
    Function Validation(make As ComboBox, model As TextBox, year As NumericUpDown, price As TextBox) As Boolean
        Dim isValid As Boolean = True

        ' If make is not selected
        If make.SelectedIndex = -1 Then
            lblOutput.Text = "Make must be selected from the list" & Environment.NewLine
            isValid = False
        End If

        ' If model is empty
        If model.Text = String.Empty Then
            lblOutput.Text &= "Model can't be empty" & Environment.NewLine
            isValid = False
        End If

        ' If year is somehow not in range
        If year.Value < 1920 Or nudYear.Value > 2020 Then
            isValid = False
            lblOutput.Text &= "Year must be between 1920 and 2020" & Environment.NewLine
        End If

        ' If price is empty
        If price.Text = String.Empty Then
            lblOutput.Text &= "Price can't be empty" & Environment.NewLine
            isValid = False
        ElseIf Not IsNumeric(price.Text) Then ' If price is not a number
            lblOutput.Text &= "Price must be a real number" & Environment.NewLine
            isValid = False
        ElseIf CDbl(price.Text) < 0 Then ' If price is less than 0
            lblOutput.Text &= "Price must be greater than or equal to 0"
            isValid = False
        End If

        Return isValid
    End Function
End Class
