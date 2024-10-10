Public Class CategoryBusiness
    Private categoryData As New CategoryData()

    Public Function ListCategories() As DataTable
        Return categoryData.ListCategories()
    End Function
End Class
