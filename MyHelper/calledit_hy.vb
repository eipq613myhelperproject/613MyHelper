Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class calledit_hy
    Private connectionString As String

    Function callto(ByVal calla As String)
        Process.Start("skype:" & calla & "?call")
    End Function
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        call_hy.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
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

        str = "SELECT * FROM moderator_data WHERE (name = '" & "tel" & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim ezo As String
        While dr.Read()
            ezo = dr("value").ToString
        End While
        callto(ezo)
    End Sub

    Private Sub calledit_hy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            Button1.ForeColor = Color.Teal
            Button2.ForeColor = Color.Teal
            Label1.ForeColor = Color.Teal
            Label2.ForeColor = Color.Teal
            Label3.ForeColor = Color.Teal
            Label4.ForeColor = Color.Teal


        ElseIf o = "2" Then
            Me.BackColor = Color.White
            Button1.ForeColor = Color.Black
            Button2.ForeColor = Color.Black
            Label1.ForeColor = Color.Black
            Label2.ForeColor = Color.Black
            Label3.ForeColor = Color.Black
            Label4.ForeColor = Color.Black
        ElseIf o = "3" Then
            Me.BackColor = Color.PowderBlue

            Button1.ForeColor = Color.Blue
            Button2.ForeColor = Color.Blue
            Label1.ForeColor = Color.Blue
            Label2.ForeColor = Color.Blue
            Label3.ForeColor = Color.Blue
            Label4.ForeColor = Color.Blue
        ElseIf o = "4" Then
            Me.BackColor = Color.BlanchedAlmond

            Button1.ForeColor = Color.Sienna
            Button2.ForeColor = Color.Sienna
            Label1.ForeColor = Color.Sienna
            Label2.ForeColor = Color.Sienna
            Label3.ForeColor = Color.Sienna
            Label4.ForeColor = Color.Sienna
        ElseIf o = "5" Then
            Me.BackColor = Color.DarkRed

            Button1.ForeColor = Color.Lime
            Button2.ForeColor = Color.Lime
            Label1.ForeColor = Color.Lime
            Label2.ForeColor = Color.Lime
            Label3.ForeColor = Color.Lime
            Label4.ForeColor = Color.Lime
        End If
    End Sub
End Class