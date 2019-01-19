Public Class FormMenu
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Listagem_de_Clientes.Show()
    End Sub

    Private Sub Menu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
End Class