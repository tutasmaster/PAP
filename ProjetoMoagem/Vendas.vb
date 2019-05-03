Public Class Vendas

    Structure VendaRegisto
        Public Item As ItemPicker.Item
        Public Quantity As Integer
    End Structure

    Dim Vendas_Registo As New List(Of VendaRegisto)

    Sub UpdateListBox()
        ListBox1.Items.Clear()
        For Each v In Vendas_Registo
            ListBox1.Items.Add(v.Item.Name & " - " & v.Quantity)
        Next
    End Sub

    Dim CurrentUser As New UserPicker.User
    Dim CurrentItem As New ItemPicker.Item

    Private Sub Vendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentUser = UserPicker.BadUser
        CurrentItem = ItemPicker.BadItem
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

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub
End Class