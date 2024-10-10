Public Class ProductListForm
    Private Sub ProductListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()
        AddButtonColumns()
    End Sub

    Private Sub LoadProducts()
        Dim productBusiness As New ProductBusiness()
        Dim productsTable As DataTable = productBusiness.ListProducts()

        ' Agregar una nueva columna para mostrar el estado como texto
        productsTable.Columns.Add("StatusText", GetType(String))

        ' Llenar la nueva columna con "Activo" o "Inactivo"
        For Each row As DataRow In productsTable.Rows
            If CBool(row("Status")) Then
                row("StatusText") = "Activo"
            Else
                row("StatusText") = "Inactivo"
            End If
        Next

        dataGridViewProducts.DataSource = productsTable

        '' Ajustar el tamaño de las columnas
        'dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Ocultar la columna original de Status si no es necesaria
        dataGridViewProducts.Columns("Status").Visible = False

        ' Renombrar la nueva columna a Status
        dataGridViewProducts.Columns("StatusText").HeaderText = "Status"
    End Sub


    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim createForm As New ProductForm()
        createForm.ShowDialog()
        LoadProducts() ' Recargar la lista después de crear un producto
    End Sub

    Private Sub AddButtonColumns()
        Dim editButton As New DataGridViewButtonColumn()
        editButton.Name = "EditButton"
        editButton.HeaderText = "Editar"
        editButton.Text = "Editar"
        editButton.UseColumnTextForButtonValue = True
        dataGridViewProducts.Columns.Add(editButton)

        Dim deleteButton As New DataGridViewButtonColumn()
        deleteButton.Name = "DeleteButton"
        deleteButton.HeaderText = "Eliminar"
        deleteButton.Text = "Eliminar"
        deleteButton.UseColumnTextForButtonValue = True
        dataGridViewProducts.Columns.Add(deleteButton)
    End Sub

    Private Sub dataGridViewProducts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridViewProducts.CellContentClick
        If e.RowIndex < 0 Then Return ' Ignorar encabezados

        If e.ColumnIndex = dataGridViewProducts.Columns("EditButton").Index Then
            ' Editar
            Dim productId As Integer = CType(dataGridViewProducts.Rows(e.RowIndex).Cells("Id").Value, Integer)
            Dim editForm As New ProductForm(productId, True) ' Suponiendo que pasas el ID y un flag de edición
            editForm.ShowDialog()
            LoadProducts() ' Recargar la lista después de editar
        ElseIf e.ColumnIndex = dataGridViewProducts.Columns("DeleteButton").Index Then
            ' Eliminar
            Dim productId As Integer = CType(dataGridViewProducts.Rows(e.RowIndex).Cells("Id").Value, Integer)
            If MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?", "Eliminar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim productBusiness As New ProductBusiness()
                If productBusiness.DeleteProduct(productId) Then
                    MessageBox.Show("Producto eliminado con éxito.")
                    LoadProducts() ' Recargar la lista después de eliminar
                Else
                    MessageBox.Show("Error al eliminar el producto.")
                End If
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim productBusiness As New ProductBusiness()
        Dim searchTerm As String = txtSearch.Text.Trim()
        Dim productsTable As DataTable = productBusiness.ListProducts(searchTerm)
        dataGridViewProducts.DataSource = productsTable
    End Sub


End Class
