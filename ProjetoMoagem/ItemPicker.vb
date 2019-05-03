Public Class ItemPicker

    Structure Item
        Public Sub New(i As Integer)
            ID = i
        End Sub
        Public Sub New(i As Integer, n As String)
            ID = i
            Name = n
        End Sub

        Public ID As Integer
        Public Name As String
        Public Description As String
        Public Weight As Integer
        Public Price As Integer
    End Structure

    Dim ItemList As New List(Of Item)

    Public BadItem As New Item(-1, "Produto Inválido")

    Public Function Input() As Item
        Dim resultCode = ShowDialog()

        If resultCode = DialogResult.OK Then
            If ListBox1.SelectedIndex < 0 Then
                Return BadItem
            Else
                Return ItemList(ListBox1.SelectedIndex)
            End If
        End If

        Return BadItem
    End Function

    Sub UpdateUserList()
        ItemList.Clear()

        Dim result = DefaultReader.GetData("SELECT * FROM tb_items")
        For Each row In result
            Dim i As New Item
            i.ID = row(0)
            i.Name = row(1)
            i.Description = row(2)
            i.Weight = row(3)
            i.Price = row(4)
            ItemList.Add(i)
        Next
    End Sub

    Sub UpdateListBox()
        ListBox1.Items.Clear()
        For Each i In ItemList
            ListBox1.Items.Add(i.Name)
        Next
    End Sub

    Public Sub UpdateGUI()
        If ListBox1.SelectedIndex = -1 Then
            Label1.Text = "ID: " & BadItem.ID
            Label2.Text = "Nome: " & BadItem.Name
            Return
        End If
        Label1.Text = "ID: " & ItemList(ListBox1.SelectedIndex).ID
        Label2.Text = "Nome: " & ItemList(ListBox1.SelectedIndex).Name
        TextBox1.Text = ItemList(ListBox1.SelectedIndex).Description
        Label3.Text = "Peso: " & ItemList(ListBox1.SelectedIndex).Weight
        Label4.Text = "Preço: " & ItemList(ListBox1.SelectedIndex).Price
    End Sub

    Private Sub ItemPicker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateUserList()
        UpdateListBox()
        UpdateGUI()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        UpdateGUI()
    End Sub
End Class