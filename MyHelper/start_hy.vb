Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class start_hy
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        menu_hy.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        settings_hy.Show()
        Me.Hide()
    End Sub

    Private Sub start_hy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim o As String = ""
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
        wherename = "background"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            o = dr("value").ToString
        End While
        If o = "1" Then
            Me.BackColor = Color.White
            Label1.ForeColor = Color.Teal
            Button1.ForeColor = Color.Teal
        ElseIf o = "2" Then
            Me.BackColor = Color.White
            Label1.ForeColor = Color.Black
            Button1.ForeColor = Color.Black
        ElseIf o = "3" Then
            Me.BackColor = Color.PowderBlue
            Label1.ForeColor = Color.Blue
            Button1.ForeColor = Color.Blue
        ElseIf o = "4" Then
            Me.BackColor = Color.BlanchedAlmond
            Label1.ForeColor = Color.Sienna
            Button1.ForeColor = Color.Sienna
        ElseIf o = "5" Then
            Me.BackColor = Color.DarkRed
            Label1.ForeColor = Color.Lime
            Button1.ForeColor = Color.Lime
        End If
    End Sub
End Class