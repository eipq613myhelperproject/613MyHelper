Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class lng_form
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim provider As String
        Dim dataFile As String
        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dr As OleDbDataReader
        provider = "Provider=Microsoft.JET.OLEDB.4.0;Data Source ="
        dataFile = "data/data.mdb" ' Change it to your Access Database location
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        Dim str As String
        Dim wherename As String
        wherename = "language"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & "ru" & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        settings_ru.Show()
        Me.Close()
    End Sub '' Ռուսերեն ընտրություն
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim provider As String
        Dim dataFile As String
        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dr As OleDbDataReader
        provider = "Provider=Microsoft.JET.OLEDB.4.0;Data Source ="
        dataFile = "data/data.mdb" ' Change it to your Access Database location
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        Dim str As String
        Dim wherename As String
        wherename = "language"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & "uk" & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        settings_uk.Show()
        Me.Close()
    End Sub '' ՈՒկրաիներեն ընտրություն
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim provider As String
        Dim dataFile As String
        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dr As OleDbDataReader
        provider = "Provider=Microsoft.JET.OLEDB.4.0;Data Source ="
        dataFile = "data/data.mdb" ' Change it to your Access Database location
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        Dim str As String
        Dim wherename As String
        wherename = "language"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & "en" & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        settings_en.Show()
        Me.Close()
    End Sub  '' Անգլերեն ընտրություն
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim provider As String
        Dim dataFile As String
        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dr As OleDbDataReader
        provider = "Provider=Microsoft.JET.OLEDB.4.0;Data Source ="
        dataFile = "data/data.mdb" ' Change it to your Access Database location
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        Dim str As String
        Dim wherename As String
        wherename = "language"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & "hy" & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        settings_hy.Show()
        Me.Close()
    End Sub  '' Հայերեն ընտրություն
End Class
