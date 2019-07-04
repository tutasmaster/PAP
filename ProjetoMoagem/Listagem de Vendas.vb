Public Class Listagem_de_Vendas

    Structure Venda
        Public ID As Integer
        Public CID As Integer
        Public Price As String
        Public ClientName As String
    End Structure

    Dim vendaList As New List(Of Venda)

    Sub UpdateList()

        Dim result = DefaultReader.GetData("SELECT * FROM tb_venda")

        vendaList.Clear()

        For Each r In result
            Dim v As New Venda
            v.ID = r(0)
            v.CID = r(1)
            v.Price = (r(2) * 0.01).ToString("0.00€")
            v.ClientName = DefaultReader.GetData("SELECT Name FROM tb_clientes WHERE ID=" & v.CID)(0)(0)
            vendaList.Add(v)
        Next

        ListBox1.Items.Clear()
        For Each v In vendaList
            ListBox1.Items.Add(v.ClientName & " - " & v.Price)
        Next
    End Sub

    Private Sub Listagem_de_Vendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateList()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex <> -1 Then
            ListBox2.Items.Clear()
            Dim cur = vendaList.Item(ListBox1.SelectedIndex)

            Dim result = DefaultReader.GetData("SELECT * FROM tb_vendaprodutos WHERE ID=" & cur.ID)
            For Each r In result
                Dim result1 = DefaultReader.GetData("SELECT * FROM tb_items WHERE ID=" & r(1))
                ListBox2.Items.Add(result1(0)(1) & " - Quantidade: " & r(2))
            Next

        End If
    End Sub
End Class