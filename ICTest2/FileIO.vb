Imports System.IO
Imports Microsoft.VisualBasic.FileIO



Public Class FileIO
    Private input As String
    Private output As String

    Public Sub New()

    End Sub

    Public Sub New(ByVal i As String)
        input = i
    End Sub

    Public Sub New(ByVal i As String, ByVal o As String)
        input = i
        output = o
    End Sub


    Public Property _Input() As String
        Get
            Return input
        End Get
        Set(ByVal value As String)
            input = value
        End Set
    End Property


    Public Property _Output() As String
        Get
            Return output
        End Get
        Set(ByVal value As String)
            output = value
        End Set
    End Property



    Public Function ReadFile() As List(Of Recept)
        Dim s As String

        Dim fields As String()
        Dim clientList = New List(Of Recept)


        Try

            Using inputs As TextFieldParser = New TextFieldParser(input)

                s = inputs.ReadLine()

                inputs.TextFieldType = FieldType.Delimited
                inputs.SetDelimiters(",")
                inputs.HasFieldsEnclosedInQuotes = True


                While Not inputs.EndOfData
                    fields = inputs.ReadFields()
                    Dim client As Recept = New Recept()
                    Try
#Region "Client's Properties"

                        client.billNumber = fields(0)
                        client.billType = fields(1)
                        client.billName = fields(2)
                        client.address1 = fields(3)
                        client.address2 = fields(4)
                        client.city = fields(5)
                        client.state = fields(6)
                        client.zipCode = fields(7)
                        client.town = fields(8)
                        client.propType = fields(9)
                        client.propertyID = fields(10)
                        client.billInfo = fields(11)
                        client.altParcel = fields(12)
                        client.billed = fields(13)
                        client.adjustments = fields(14)
                        client.abate = fields(15)
                        client.pmts = fields(16)
                        client.interestPaid = fields(17)
                        client.interestDue = fields(18)
                        client.dueNow = fields(19)
#End Region

                    Catch ex As Exception
                        fields = inputs.ReadFields()
                    Finally
                        clientList.Add(client)

                    End Try


                End While

                For Each currentField In clientList
#Region "Clients on console"
                    Console.WriteLine(currentField.billNumber + currentField.propType + currentField.propertyID + "|" +
                        currentField.billName + "|" + currentField.address1 + "|" + currentField.city + "|" +
                         currentField.state + "|" + currentField.zipCode + "|" + currentField.billed _
                         + "|" + currentField.dueNow)
#End Region

                Next


            End Using


        Catch ex As Exception
            Console.WriteLine(ex)

        End Try

        Return clientList

    End Function


    Public Sub WriteFile(ByVal outClient As List(Of Recept))
        Dim invoiceDate As Date = Today

        Dim totalDue As Double
        Dim recordCount As Int32

        For Each client In outClient
            Try
                totalDue += CDbl(client.dueNow)

            Catch ex As InvalidCastException
                totalDue += CDbl(client.dueNow.Remove(client.dueNow.Length - 1, 1))

            Catch ex As NullReferenceException
                totalDue += 0

            End Try
            recordCount += 1
        Next

        Try
            Using fw As StreamWriter = New StreamWriter(output)


                fw.WriteLine(invoiceDate + "|" + recordCount.ToString() + "|" + totalDue.ToString("c"))

                For Each client In outClient
#Region "Write Client's properties"
                    fw.WriteLine(client.billNumber + client.propType + client.propertyID + "|" +
                        client.billName + "|" + client.address1 + "|" + client.city + "|" +
                         client.state + "|" + client.zipCode + "|" + client.billed _
                         + "|" + client.dueNow + "|" + invoiceDate.ToString())
#End Region

                Next




            End Using

        Catch ex As Exception
            Console.WriteLine(ex)
        End Try


    End Sub

End Class
