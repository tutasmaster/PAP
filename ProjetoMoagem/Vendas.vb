Public Class Vendas

    Structure VendaRegisto
        Public Item As ItemPicker.Item
        Public Quantity As Integer
    End Structure

    Dim Vendas_Registo As New List(Of VendaRegisto)

    Dim total As Integer

    Sub UpdateListBox()
        ListBox1.Items.Clear()
        For Each v In Vendas_Registo
            ListBox1.Items.Add(v.Item.Name & " - " & v.Quantity)
        Next
    End Sub

    Sub UpdateValue()

    End Sub

    Dim CurrentUser As New UserPicker.User
    Dim CurrentItem As New ItemPicker.Item

    Private Sub Vendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentUser = UserPicker.BadUser
        CurrentItem = ItemPicker.BadItem
    End Sub

    Sub UpdatePrice()
        Dim t As Integer

        For Each v In Vendas_Registo
            t += v.Item.Price * v.Quantity
        Next

        Label1.Text = "Total: " & CInt(t * 0.01).ToString("0.00€")
        total = CInt(t)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CurrentItem.ID = 0 Or NumericUpDown3.Value < 1 Then
            Return
        End If
        Dim v As VendaRegisto
        v.Item = CurrentItem
        v.Quantity = NumericUpDown3.Value
        Vendas_Registo.Add(v)
        UpdateListBox()
        UpdateValue()
        UpdatePrice()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim resultUser = UserPicker.Input()
        Button4.Text = resultUser.Name
        CurrentUser = resultUser
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim resultItem = ItemPicker.Input()
        Button5.Text = resultItem.Name
        CurrentItem = resultItem
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListBox1.SelectedIndex = -1 Then
            Return
        End If

        Vendas_Registo.RemoveAt(ListBox1.SelectedIndex)
        UpdateListBox()
        UpdateValue()
        UpdatePrice()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Not (CurrentUser.ID = UserPicker.BadUser.ID) And (ListBox1.Items.Count() > 0) Then
            DefaultReader.GetData("INSERT INTO tb_venda(ClienteID,Preco) VALUES(" & CurrentUser.ID & "," & total & ")")

            'LAST INSERT ID DOESNT WORK PROPERLY IF THERE ARE MULTIPLE CONNECTIONS
            Dim id = DefaultReader.GetData("SELECT LAST_INSERT_ID();")(0)(0)

            For Each v In Vendas_Registo
                DefaultReader.GetData("INSERT INTO tb_vendaprodutos VALUES(" & id & "," & v.Item.ID & "," & v.Quantity & ")")
            Next

            MsgBox("A venda foi registada com sucesso.")
        Else
            MsgBox("Não foi possível registar a venda.")

        End If



    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3.ValueChanged

    End Sub
End Class