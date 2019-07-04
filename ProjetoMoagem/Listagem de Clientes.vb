Public Class Listagem_de_Clientes

    Dim idList As New List(Of Integer)

    Private Sub Listagem_de_Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateTable()
        UpdateListBox()


    End Sub

    Sub UpdateListBox()

        ListBox1.Items.Clear()
        idList.Clear()

        Dim str = "SELECT ID, Name FROM tb_clientes"
        Dim result = DefaultReader.GetData(str)

        For Each r In result
            idList.Add(r(0))
            ListBox1.Items.Add(r(1))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim treatedNumber = MaskedTextBox1.Text.Replace("-", "")

        Dim command As String = "INSERT INTO tb_clientes 
        (Name,Phone,Email,Address)
        VALUES('" & TextBox1.Text & "','" & treatedNumber & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
        DefaultReader.GetData(command)

        UpdateTable()
        UpdateListBox()
        MsgBox("O utilizador foi criado com sucesso!")
    End Sub

    Sub UpdateTable()
        Me.Tb_clientesTableAdapter.ClearBeforeFill = True
        Me.Tb_clientesTableAdapter.Fill(Me.Db_moagemDataSet.tb_clientes)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim treatedNumber = MaskedTextBox1.Text.Replace("-", "")

        Dim command As String = "UPDATE tb_clientes 
        SET Name='" & TextBox1.Text & "', Phone='" & treatedNumber & "', Email='" & TextBox2.Text & "', Address='" & TextBox3.Text & "'
        WHERE ID=" & idList(ListBox1.SelectedIndex) & ""
        DefaultReader.GetData(command)

        UpdateTable()
        UpdateListBox()
        MsgBox("O utilizador foi atualizado com sucesso!")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim str = "DELETE FROM tb_clientes WHERE ID=" & idList(ListBox1.SelectedIndex)
        DefaultReader.GetData(str)
        MsgBox("O utilizador foi eliminado com sucesso!")
        UpdateListBox()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim str = "SELECT * FROm tb_clientes WHERE ID=" & idList(ListBox1.SelectedIndex)
        Dim r = DefaultReader.GetData(str)
        TextBox1.Text = r(0)(1)
            MaskedTextBox1.Text = r(0)(2)
            TextBox2.Text = r(0)(3)
            TextBox3.Text = r(0)(4)
    End Sub
End Class