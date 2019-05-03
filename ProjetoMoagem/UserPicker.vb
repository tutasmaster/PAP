Public Class UserPicker
    Structure User
        Public Sub New(i As Integer)
            ID = i
        End Sub
        Public Sub New(i As Integer, n As String)
            ID = i
            Name = n
        End Sub

        Public ID As Integer
        Public Name As String
        Public Phone As String
        Public Email As String
        Public Address As String
    End Structure

    Public BadUser As New User(-1, "Utilizador Inválido")

    Dim UserList As New List(Of User)

    Public Sub UpdateGUI()
        If ListBox1.SelectedIndex = -1 Then
            Label1.Text = "ID: " & BadUser.ID
            Label2.Text = "Nome: " & BadUser.Name
            Label3.Text = "Telefone: " & BadUser.Phone
            Label4.Text = "Email: " & BadUser.Email
            Label5.Text = "Address: " & BadUser.Address
            Return
        End If
        Label1.Text = "ID: " & UserList(ListBox1.SelectedIndex).ID
        Label2.Text = "Nome: " & UserList(ListBox1.SelectedIndex).Name
        Label3.Text = "Telefone: " & UserList(ListBox1.SelectedIndex).Phone
        Label4.Text = "Email: " & UserList(ListBox1.SelectedIndex).Email
        Label5.Text = "Address: " & UserList(ListBox1.SelectedIndex).Address
    End Sub

    Public Function Input() As User
        Dim resultCode = ShowDialog()

        If resultCode = DialogResult.OK Then
            If ListBox1.SelectedIndex < 0 Then
                Return BadUser
            Else
                Return UserList(ListBox1.SelectedIndex)
            End If
        End If

        Return BadUser
    End Function

    Sub UpdateUserList()
        UserList.Clear()

        Dim result = DefaultReader.GetData("SELECT * FROM tb_clientes")
        For Each row In result
            Dim u As New User
            u.ID = row(0)
            u.Name = row(1)
            u.Phone = row(2)
            u.Email = row(3)
            u.Address = row(4)
            UserList.Add(u)
        Next
    End Sub

    Sub UpdateListBox()
        ListBox1.Items.Clear()
        For Each u In UserList
            ListBox1.Items.Add(u.Name)
        Next
    End Sub

    Private Sub UserPicker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateUserList()
        UpdateListBox()
        UpdateGUI()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        UpdateGUI()
    End Sub
End Class