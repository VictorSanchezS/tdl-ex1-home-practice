<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        btnTestConnection = New Button()
        dataGridViewProducts = New DataGridView()
        btnLoadProducts = New Button()
        MenuStrip1 = New MenuStrip()
        ProductosToolStripMenuItem = New ToolStripMenuItem()
        CType(dataGridViewProducts, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnTestConnection
        ' 
        btnTestConnection.Location = New Point(39, 56)
        btnTestConnection.Name = "btnTestConnection"
        btnTestConnection.Size = New Size(123, 29)
        btnTestConnection.TabIndex = 0
        btnTestConnection.Text = "ConexionTest"
        btnTestConnection.UseVisualStyleBackColor = True
        ' 
        ' dataGridViewProducts
        ' 
        dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridViewProducts.Location = New Point(39, 138)
        dataGridViewProducts.Name = "dataGridViewProducts"
        dataGridViewProducts.RowHeadersWidth = 51
        dataGridViewProducts.Size = New Size(300, 188)
        dataGridViewProducts.TabIndex = 1
        ' 
        ' btnLoadProducts
        ' 
        btnLoadProducts.Location = New Point(195, 56)
        btnLoadProducts.Name = "btnLoadProducts"
        btnLoadProducts.Size = New Size(94, 29)
        btnLoadProducts.TabIndex = 2
        btnLoadProducts.Text = "Listar"
        btnLoadProducts.UseVisualStyleBackColor = True
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {ProductosToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(800, 28)
        MenuStrip1.TabIndex = 3
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ProductosToolStripMenuItem
        ' 
        ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        ProductosToolStripMenuItem.Size = New Size(89, 24)
        ProductosToolStripMenuItem.Text = "Productos"
        ' 
        ' Main
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnLoadProducts)
        Controls.Add(dataGridViewProducts)
        Controls.Add(btnTestConnection)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "Main"
        Text = "Main"
        CType(dataGridViewProducts, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnTestConnection As Button
    Friend WithEvents dataGridViewProducts As DataGridView
    Friend WithEvents btnLoadProducts As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
End Class
