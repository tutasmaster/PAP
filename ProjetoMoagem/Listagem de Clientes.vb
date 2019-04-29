Public Class Listagem_de_Clientes
    Private Sub Listagem_de_Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateTable()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim treatedNumber = MaskedTextBox1.Text.Replace("-", "")

        Dim command As String = "INSERT INTO tb_clientes 
        (Name,Phone,Email,Address)
        VALUES('" & TextBox1.Text & "','" & treatedNumber & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
        DefaultReader.GetData(command)

        UpdateTable()
    End Sub

    Sub UpdateTable()
        Me.Tb_clientesTableAdapter.ClearBeforeFill = True
        Me.Tb_clientesTableAdapter.Fill(Me.Db_moagemDataSet.tb_clientes)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim treatedNumber = MaskedTextBox1.Text.Replace("-", "")

        Dim command As String = "UPDATE tb_clientes 
        SET Name='" & TextBox1.Text & "', Phone='" & treatedNumber & "', Email='" & TextBox2.Text & "', Address='" & TextBox3.Text & "'
        WHERE ID=" & NumericUpDown1.Value & ""
        DefaultReader.GetData(command)

        UpdateTable()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class