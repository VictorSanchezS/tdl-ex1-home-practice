Public Class ProductForm
    Private isEdit As Boolean = False
    Private productId As Integer

    ' Constructor para crear
    Public Sub New(Optional id As Integer = 0, Optional edit As Boolean = False)
        InitializeComponent()
        productId = id
        isEdit = edit
    End Sub

    Private Sub ProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories() ' Cargar categorías primero
        If isEdit Then
            LoadProductDetails() ' Luego cargar los detalles del producto
        End If
    End Sub


    Private Sub LoadProductDetails()
        Dim productBusiness As New ProductBusiness()
        Dim product = productBusiness.GetProductById(productId)

        If product IsNot Nothing Then
            txtName.Text = product.Name
            txtDescription.Text = product.Description
            txtPrice.Text = product.Price.ToString("F2")
            chkStatus.Checked = product.Status

            ' Asegúrate de que el ComboBox esté cargado antes de establecer el SelectedValue
            If cmbCategory.DataSource IsNot Nothing Then
                cmbCategory.SelectedValue = product.CategoryId
            End If
        Else
            MessageBox.Show("Producto no encontrado.")
        End If
    End Sub

    Private Sub LoadCategories()
        Dim categoryBusiness As New CategoryBusiness()
        Dim categoriesTable As DataTable = categoryBusiness.ListCategories()
        cmbCategory.DataSource = categoriesTable
        cmbCategory.DisplayMember = "Name" ' Campo que se muestra en el ComboBox
        cmbCategory.ValueMember = "Id"      ' Valor que se usa internamente
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim productBusiness As New ProductBusiness()
        Dim success As Boolean

        Try
            If Not String.IsNullOrWhiteSpace(txtName.Text) AndAlso
           Decimal.TryParse(txtPrice.Text, Nothing) Then

                If isEdit Then
                    ' Editar producto
                    success = productBusiness.UpdateProduct(productId, txtName.Text, txtDescription.Text, Decimal.Parse(txtPrice.Text), CType(cmbCategory.SelectedValue, Integer), chkStatus.Checked)
                Else
                    ' Crear nuevo producto
                    success = productBusiness.AddProduct(txtName.Text, txtDescription.Text, Decimal.Parse(txtPrice.Text), CType(cmbCategory.SelectedValue, Integer), chkStatus.Checked)
                End If

                If success Then
                    MessageBox.Show("Producto guardado con éxito.")
                    Me.Close()
                Else
                    MessageBox.Show("Error al guardar el producto.")
                End If
            Else
                MessageBox.Show("Por favor, completa todos los campos obligatorios.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
