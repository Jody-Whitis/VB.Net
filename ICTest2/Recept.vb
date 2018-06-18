Public Class Recept

    Public billNumber As String
    Public billType As String
    Public billName As String
    Public address1 As String
    Public address2 As String
    Public city As String
    Public state As String
    Public zipCode As String
    Public town As String
    Public propType As String
    Public propertyID As String
    Public billInfo As String
    Public altParcel As String
    Public billed As String
    Public adjustments As String
    Public abate As String
    Public pmts As String
    Public interestPaid As String
    Public interestDue As String
    Public dueNow As String



    Public Sub PrintClient()
        Console.WriteLine(billNumber + " " + billType + " " + billName + " " + dueNow)
    End Sub
End Class
