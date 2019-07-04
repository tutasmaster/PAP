Public Class Listagem_de_Produtos
    Dim IDList As New List(Of String)

    Sub UpdateList()
        DefaultReader.FillListBox(ListBox1, "tb_items", "Nome", False)
        DefaultReader.FillList(IDList, "tb_items", "ID", False)
    End Sub

    Private Sub Listagem_de_Produtos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateList()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        UpdateDetails()
    End Sub

    Sub UpdateDetails()
        Dim result = DefaultReader.GetData("SELECT * FROM TB_ITEMS")

        Label1.Text = "Nome: " & result(ListBox1.SelectedIndex)(1)
        Label2.Text = "Peso: " & (CInt(result(ListBox1.SelectedIndex)(3))) & "g"
        Label4.Text = "Preço: " & (CInt(result(ListBox1.SelectedIndex)(4)) / 100).ToString("0.00€")
        TextBox1.Text = result(ListBox1.SelectedIndex)(2)

    End Sub
End Class