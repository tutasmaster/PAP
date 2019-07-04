Public Class Registo_de_Clientes
    Private Sub Registo_de_Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Db_moagemDataSet.tb_clientes' table. You can move, or remove it, as needed.
        Me.Tb_clientesTableAdapter.Fill(Me.Db_moagemDataSet.tb_clientes)

    End Sub
End Class