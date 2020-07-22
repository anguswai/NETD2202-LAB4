Option Strict On

' Name: Angus Wai (100719558)
' Date: 2020-07-21
' Description: Car inventory application for Lab 4

Public Class Car
    Private Count As Integer = 0
    Private IdentificationNumber, Year As Integer
    Private Make, Model As String
    Private Price As Decimal
    Private NewStatus As Boolean

    ' Default constructor
    ' Increment Count and Update IdentificationNumber (not working)
    Private Sub New()
        Count += 1
        IdentificationNumber += 1
    End Sub

    ' Parametrized constructor
    Public Sub New(make As String, model As String, year As Integer, price As Decimal, newStatus As Boolean)
        ' Call the default constructor
        Me.New()

        ' Parameters representing the car's Make, Model, Year, Price and NewStatus
        Me.Make = make
        Me.Model = model
        Me.Year = year
        Me.Price = price
        Me.NewStatus = newStatus
    End Sub

    ' String representing the car object's data
    Public Function GetCarData() As String
        Return CStr(IdentificationNumber)
    End Function
End Class