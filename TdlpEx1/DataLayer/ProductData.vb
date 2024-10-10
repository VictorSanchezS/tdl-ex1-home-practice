Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient

Public Class ProductData
    Private ReadOnly dbConnection As DatabaseConnection = New DatabaseConnection()

    ' Método para listar productos
    Public Function ListProducts(Optional searchTerm As String = "") As DataTable
        Dim dt As New DataTable()
        Dim query As String = "SELECT p.Id, p.Name, p.Description, p.Price, p.CreationDate, p.Status, c.Name AS CategoryName " &
                          "FROM Products p LEFT JOIN Categories c ON p.CategoryId = c.Id"

        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            query += " WHERE p.Name LIKE @SearchTerm"
        End If

        Using connection As SqlConnection = dbConnection.GetConnection()
            Using command As New SqlCommand(query, connection)
                If Not String.IsNullOrWhiteSpace(searchTerm) Then
                    command.Parameters.AddWithValue("@SearchTerm", "%" & searchTerm & "%")
                End If

                connection.Open()
                Dim adapter As New SqlDataAdapter(command)
                adapter.Fill(dt)
            End Using
        End Using

        Return dt
    End Function


    'Metodo para crear un producto
    Public Function AddProduct(name As String, description As String, price As Decimal, categoryId As Integer, status As Boolean) As Boolean
        Using connection As SqlConnection = dbConnection.GetConnection()
            Dim query As String = "INSERT INTO Products (Name, Description, Price, CategoryId, Status) VALUES (@Name, @Description, @Price, @CategoryId, @Status)" ' Cambiado a "Products"
            Using command As SqlCommand = New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Name", name)
                command.Parameters.AddWithValue("@Description", description)
                command.Parameters.AddWithValue("@Price", price)
                command.Parameters.AddWithValue("@CategoryId", categoryId)
                command.Parameters.AddWithValue("@Status", status)

                connection.Open()
                Return command.ExecuteNonQuery() > 0 ' Retorna True si se insertó al menos una fila
            End Using
        End Using
    End Function

    'Funcion para editar un producto
    Public Function UpdateProduct(id As Integer, name As String, description As String, price As Decimal, categoryId As Integer, status As Boolean) As Boolean
        Using connection As SqlConnection = dbConnection.GetConnection()
            Dim query As String = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, CategoryId = @CategoryId, Status = @Status WHERE Id = @Id"
            Using command As SqlCommand = New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", id)
                command.Parameters.AddWithValue("@Name", name)
                command.Parameters.AddWithValue("@Description", description)
                command.Parameters.AddWithValue("@Price", price)
                command.Parameters.AddWithValue("@CategoryId", categoryId)
                command.Parameters.AddWithValue("@Status", status)

                connection.Open()
                Return command.ExecuteNonQuery() > 0 ' Retorna True si se actualizó al menos una fila
            End Using
        End Using
    End Function

    'Funcion para eliminar un producto
    Public Function DeleteProduct(id As Integer) As Boolean
        Using connection As SqlConnection = dbConnection.GetConnection()
            Dim query As String = "DELETE FROM Products WHERE Id = @Id"
            Using command As SqlCommand = New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", id)

                connection.Open()
                Return command.ExecuteNonQuery() > 0 ' Retorna True si se eliminó al menos una fila
            End Using
        End Using
    End Function

    'Funcion para obtener un producto
    Public Function GetProductById(id As Integer) As Product
        Dim product As Product = Nothing

        Using connection As SqlConnection = dbConnection.GetConnection()
            Dim query As String = "SELECT Id, Name, Description, Price, CategoryId, Status FROM Products WHERE Id = @Id"
            Using command As SqlCommand = New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Id", id)

                connection.Open()
                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        product = New Product() With {
                        .Id = reader.GetInt32(0),
                        .Name = reader.GetString(1),
                        .Description = reader.GetString(2),
                        .Price = reader.GetDecimal(3),
                        .CategoryId = reader.GetInt32(4),
                        .Status = reader.GetBoolean(5)
                    }
                    End If
                End Using
            End Using
        End Using

        Return product
    End Function


End Class
