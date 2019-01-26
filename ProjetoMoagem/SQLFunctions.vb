Imports MySql.Data.MySqlClient

Public Class SQLComboBox
    Inherits ComboBox

    Public Pairs As New List(Of Object)
    Public Sub New()

    End Sub

    Public Sub AddItem(str As String, Optional pair As String = "")
        Items.Add(str)
        Pairs.Add(pair)
    End Sub

    Public Sub Clear()
        Items.Clear()
        Pairs.Clear()
    End Sub

    Public Sub RemovePairAt(ByVal index)
        Items.RemoveAt(index)
        Pairs.RemoveAt(index)
    End Sub

    Public Sub RemoveCurrentPair()
        Items.RemoveAt(SelectedIndex)
        Pairs.RemoveAt(SelectedIndex)
    End Sub

    Public Function GetPairAt(ByVal index) As Object
        Dim str As Object() = Pairs.Item(index)
        Return str
    End Function

    Public Function GetCurrentPair() As Object
        Dim str As Object() = Pairs.Item(SelectedIndex)
        Return str
    End Function

    Public Function GetValueAt(ByVal index) As Object
        Dim str As Object() = Items.Item(index)
        Return str
    End Function

    Public Function GetCurrentValue() As Object
        Dim str As Object() = Items.Item(SelectedIndex)
        Return str
    End Function
End Class

Module SQLFunctions


    Class SQLReader
        Dim connection As New MySqlConnection
        Dim dataReader As MySqlDataReader
        Public adapter As MySqlDataAdapter
        Public isPrepared As Boolean = False


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

        Public Sub GetDataToSource(query As String, ByRef dataTable As DataTable, Optional warn As Boolean = True)
            Dim list As New List(Of List(Of String))
            dataTable.Clear()
            Try
                adapter = New MySqlDataAdapter(query, connection)
                adapter.Fill(dataTable)

            Catch e As Exception
                If warn Then
                    MsgBox(e.Message)
                    MsgBox("Command: " & vbNewLine & query)
                End If
            Finally
            End Try
        End Sub

        Public Sub GetDataToSource(query As String, ByRef dataGrid As DataGridView, Optional warn As Boolean = True)
            Dim list As New List(Of List(Of String))
            Dim dt As New DataTable
            Try
                adapter = New MySqlDataAdapter(query, connection)
                adapter.Fill(dt)
                dataGrid.DataSource = dt

            Catch e As Exception
                If warn Then
                    MsgBox(e.Message)
                    MsgBox("Command: " & vbNewLine & query)
                End If
            Finally
            End Try
        End Sub

        Public Sub FillComboBox(box As ComboBox, table As String, field As String, Optional clear As Boolean = True)
            If clear Then
                box.Items.Clear()
            End If

            Dim dat = GetData("SELECT DISTINCT " & field & " FROM " & table)
            For Each row In dat
                box.Items.Add(row(0))
            Next
            box.SelectedIndex = 0
        End Sub

        Public Sub FillSQLComboBox(box As SQLComboBox, table As String, display As String, pair As String, Optional clear As Boolean = True)
            If clear Then
                box.Items.Clear()
            End If

            Dim dat = GetData("SELECT DISTINCT " & display & "," & pair & " FROM " & table)
            For Each row In dat
                box.AddItem(row(0), row(1))
            Next

            box.SelectedIndex = 0
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
