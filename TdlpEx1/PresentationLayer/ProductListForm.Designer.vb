<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductListForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        dataGridViewProducts = New DataGridView()
        txtSearch = New TextBox()
        btnSearch = New Button()
        btnCreate = New Button()
        CType(dataGridViewProducts, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dataGridViewProducts
        ' 
        dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridViewProducts.Location = New Point(33, 161)
        dataGridViewProducts.Name = "dataGridViewProducts"
        dataGridViewProducts.RowHeadersWidth = 51
        dataGridViewProducts.Size = New Size(969, 188)
        dataGridViewProducts.TabIndex = 0
        ' 
        ' txtSearch
        ' 
        txtSearch.Location = New Point(33, 110)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(398, 27)
        txtSearch.TabIndex = 1
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(458, 110)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(94, 29)
        btnSearch.TabIndex = 2
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' btnCreate
        ' 
        btnCreate.Location = New Point(908, 108)
        btnCreate.Name = "btnCreate"
        btnCreate.Size = New Size(94, 29)
        btnCreate.TabIndex = 3
        btnCreate.Text = "Create"
        btnCreate.UseVisualStyleBackColor = True
        ' 
        ' ProductListForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1035, 450)
        Controls.Add(btnCreate)
        Controls.Add(btnSearch)
        Controls.Add(txtSearch)
        Controls.Add(dataGridViewProducts)
        Name = "ProductListForm"
        Text = "ProductListForm"
        CType(dataGridViewProducts, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dataGridViewProducts As DataGridView
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnCreate As Button
End Class
