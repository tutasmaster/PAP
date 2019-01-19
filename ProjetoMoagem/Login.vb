Public Class Login
    Private Sub TB_Username_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Username.KeyDown
        If e.KeyCode = Keys.Enter Then
            TB_Password.Select()
        End If
    End Sub

    Sub Login()
        Dim result = DefaultReader.GetData(
        "SELECT * FROM TB_LOGIN WHERE 
        USERNAME='" & TB_Username.Text & "' AND 
        PASSWORD='" & TB_Password.Text & "'"
        )

        If result.Count() > 0 Then
            MsgBox("The user exists in the database")
            FormMenu.Show()
            Me.Hide()
        Else
            MsgBox("The user doesn't exist in the database")
        End If
    End Sub

    Private Sub TB_Password_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Password.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login()
            TB_Username.Select()
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultReader.PrepareConnection("db_moagem")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Login()
    End Sub
End Class
