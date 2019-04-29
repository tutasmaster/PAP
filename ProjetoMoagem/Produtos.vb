Public Class Produtos
    Dim IDList As New List(Of String)

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs)
        Try
            ListBox1.SelectedIndex = IDList.IndexOf(NumericUpDown1.Value)
            UpdateDetails()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        UpdateDetails()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Produtos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateList()
    End Sub

    Sub UpdateDetails()
        Dim result = DefaultReader.GetData("SELECT * FROM TB_ITEMS")

        TextBox2.Text = result(ListBox1.SelectedIndex)(1)
        TextBox1.Text = result(ListBox1.SelectedIndex)(2)
        NumericUpDown1.Value = result(ListBox1.SelectedIndex)(3)
        NumericUpDown2.Value = result(ListBox1.SelectedIndex)(4) / 100

        ChangePicture(My.Application.Info.DirectoryPath & "/DATA/" & IDList(ListBox1.SelectedIndex) & ".png")
    End Sub

    Sub ChangePicture(ByRef path As String)
        Try
            PictureBox1.BackgroundImage = Image.FromFile(path)
        Catch ex As Exception

        End Try


    End Sub

    Sub UpdateList()
        DefaultReader.FillListBox(ListBox1, "tb_items", "Nome", False)
        DefaultReader.FillList(IDList, "tb_items", "ID", False)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DefaultReader.GetData("DELETE FROM tb_items WHERE ID=" & IDList(ListBox1.SelectedIndex))
        UpdateList()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DefaultReader.GetData("UPDATE tb_items SET Nome='" & TextBox2.Text & "',Descricao='" & TextBox1.Text & "', Peso=" & NumericUpDown1.Value & ", Preco=" & (NumericUpDown2.Value * 100).ToString().Replace(",", ".") & " WHERE ID=" & IDList(ListBox1.SelectedIndex))
        UpdateList()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DefaultReader.GetData("INSERT INTO tb_items(Nome,Descricao,Peso,Preco) VALUES('" &
                              TextBox2.Text & "','" &
                              TextBox1.Text & "'," &
                              NumericUpDown1.Value & "," &
                              (NumericUpDown2.Value * 100).ToString().Replace(",", ".") &
       ")")
        UpdateList()
    End Sub
End Class