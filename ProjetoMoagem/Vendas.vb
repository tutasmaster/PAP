Public Class Vendas
    Private Sub Vendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultReader.FillComboBox(ComboBox1, "tb_items", "Nome")
    End Sub
End Class