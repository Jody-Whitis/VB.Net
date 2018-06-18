Imports System.IO


Module Module1

    Sub Main()
        Dim newfile As FileIO = New FileIO("ICTest.txt", "ICTestOutput.txt")
        Dim clientList As List(Of Recept)

        Try
            clientList = newfile.ReadFile()
            newfile.WriteFile(clientList)
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try



    End Sub

End Module
