Imports System.Data.SqlClient

Public Class CategoryData
    Private dbConnection As New DatabaseConnection()

    Public Function ListCategories() As DataTable
        Dim categoriesTable As New DataTable()

        Using connection As SqlConnection = dbConnection.GetConnection()
            Dim query As String = "SELECT Id, Name FROM categories"
            Using command As SqlCommand = New SqlCommand(query, connection)
                connection.Open()
                Using reader As SqlDataReader = command.ExecuteReader()
                    categoriesTable.Load(reader)
                End Using
            End Using
        End Using

        Return categoriesTable
    End Function
End Class

