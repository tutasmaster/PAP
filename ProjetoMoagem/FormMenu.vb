Public Class FormMenu
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Listagem_de_Clientes.Show()
    End Sub

    Private Sub Menu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FormMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripStatusLabel1.Text = "Logado como: " & Permissions.name
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Produtos.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Vendas.Show()
    End Sub
End Class