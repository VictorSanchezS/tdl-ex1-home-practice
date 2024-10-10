Public Class ProductBusiness
    Private productData As New ProductData()

    ' Método para listar productos
    Public Function ListProducts(Optional searchTerm As String = "") As DataTable
        Return productData.ListProducts(searchTerm)
    End Function


    Public Function AddProduct(name As String, description As String, price As Decimal, categoryId As Integer, status As Boolean) As Boolean
        ' Validaciones opcionales
        If String.IsNullOrWhiteSpace(name) OrElse price < 0 Then
            Throw New ArgumentException("El nombre y el precio son obligatorios.")
        End If

        Return productData.AddProduct(name, description, price, categoryId, status)
    End Function

    'Funcion para editar un producto
    Public Function UpdateProduct(id As Integer, name As String, description As String, price As Decimal, categoryId As Integer, status As Boolean) As Boolean
        ' Validaciones opcionales
        If String.IsNullOrWhiteSpace(name) OrElse price < 0 Then
            Throw New ArgumentException("El nombre y el precio son obligatorios.")
        End If

        Return productData.UpdateProduct(id, name, description, price, categoryId, status)
    End Function

    'Funcion para eliminar un producto
    Public Function DeleteProduct(id As Integer) As Boolean
        Dim productData As New ProductData()
        Return productData.DeleteProduct(id)
    End Function

    'Funcion para obtenter un producto
    Public Function GetProductById(id As Integer) As Product
        Dim productData As New ProductData()
        Return productData.GetProductById(id)
    End Function



End Class
