Public Class Listagem_de_Vendas
    Private Sub Listagem_de_Vendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data = DefaultReader.GetData("SELECT * FROM tb_venda")
        ListBox1.Items.Clear()

    End Sub
End Class