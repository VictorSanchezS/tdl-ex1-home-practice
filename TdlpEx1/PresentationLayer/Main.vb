Imports System.Data.SqlClient

Public Class Main
    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        Dim dbConnection As New DatabaseConnection()

        Try
            Using connection As SqlConnection = dbConnection.GetConnection()
                connection.Open()
                MessageBox.Show("Conexión exitosa a la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al conectar a la base de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLoadProducts_Click(sender As Object, e As EventArgs) Handles btnLoadProducts.Click
        Dim productData As New ProductData()
        Dim productsTable As DataTable = productData.ListProducts()
        dataGridViewProducts.DataSource = productsTable
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim productListForm As New ProductListForm()
        productListForm.ShowDialog()
    End Sub
End Class