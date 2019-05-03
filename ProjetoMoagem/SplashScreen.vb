Public Class SplashScreen
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Login.Show()
        Me.Hide()
    End Sub
End Class