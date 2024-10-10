Imports System.Data.SqlClient

Public Class DatabaseConnection
    Private ReadOnly connectionString As String = "Data Source=LAPTOP-PAHPU2LO;Initial Catalog=tdlp_ex1;Integrated Security=True"


    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function
End Class
