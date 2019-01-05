Imports MySql.Data.MySqlClient

Module SQLFunctions
    Class SQLReader
        Dim connection As New MySqlConnection
        Dim dataReader As MySqlDataReader
        Public adapter As MySqlDataAdapter
        Public isPrepared As Boolean = False
        Public dt As New DataTable
        Public ds As New DataSet

        Public Sub PrepareConnection(database As String,
                                     Optional server As String = "localhost",
                                     Optional Uid As String = "root",
                                     Optional Pwd As String = "")
            connection.ConnectionString = "Server=" & server & ";DataBase=" & database & ";Uid=" & Uid & ";Pwd=" & Pwd
            isPrepared = True

        End Sub

        Public Function GetData(query As String, Optional warn As Boolean = True) As List(Of List(Of String))
            Dim list As New List(Of List(Of String))

            Try
                connection.Open()
                Dim cmd As MySqlCommand = New MySqlCommand(query, connection)
                dataReader = cmd.ExecuteReader()
                While dataReader.Read()
                    Dim item As New List(Of String)
                    Dim i As Integer
                    For i = 0 To dataReader.FieldCount - 1
                        item.Add(dataReader(i).ToString)
                    Next
                    list.Add(item)
                End While
            Catch e As Exception
                If warn Then
                    MsgBox(e.Message)
                    MsgBox("Command: " & vbNewLine & query)
                End If
            Finally
                connection.Close()
            End Try

            Return list
        End Function

        Public Sub GetDataToSource(query As String, ByRef bindingSource As BindingSource, Optional warn As Boolean = True)
            Dim list As New List(Of List(Of String))
            dt.Clear()
            Try
                adapter = New MySqlDataAdapter(query, connection)
                adapter.Fill(dt)
                bindingSource.DataSource = dt

            Catch e As Exception
                If warn Then
                    MsgBox(e.Message)
                    MsgBox("Command: " & vbNewLine & query)
                End If
            Finally
            End Try
        End Sub

    End Class

    Public Function DateToSQL(dat As Date) As String
        Return dat.ToString("yyyy-MM-dd HH:mm:ss.fff")
    End Function

    Public Function GetItemString(combo As ComboBox) As String
        Return combo.Items(combo.SelectedIndex).ToString
    End Function

    Public DefaultReader As New SQLReader
End Module
