Imports System
Imports System.Data
Imports System.Data.OleDb

Public Class helper_en
    Private connectionString As String

    Function callto(ByVal calla As String)
        Process.Start("skype:" & calla & "?call")
    End Function



    Public Sub getdata()
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
        wherename = "ya_translate"
        str = "SELECT * FROM api_keys WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            TextBox1.Text = dr("value").ToString
        End While
        wherename = "ya_speechkit"
        str = "SELECT * FROM api_keys WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            TextBox2.Text = dr("value").ToString
        End While
        wherename = "wolfram_alpha"
        str = "SELECT * FROM api_keys WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            TextBox3.Text = dr("value").ToString
        End While
        wherename = "tel"
        str = "SELECT * FROM moderator_data WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            TextBox4.Text = dr("value").ToString
        End While
        myConnection.Close()
    End Sub

    Public Sub updatedata()
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
        wherename = "ya_translate"
        str = "DELETE * FROM api_keys WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [api_keys]([name] , [value]) VALUES('" & wherename & "', '" & TextBox1.Text & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        wherename = "ya_speechkit"
        str = "DELETE * FROM api_keys WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [api_keys]([name] , [value]) VALUES('" & wherename & "', '" & TextBox2.Text & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        wherename = "wolfram_alpha"
        str = "DELETE * FROM api_keys WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [api_keys]([name] , [value]) VALUES('" & wherename & "', '" & TextBox3.Text & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        wherename = "tel"
        str = "DELETE * FROM moderator_data WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [moderator_data]([name] , [value]) VALUES('" & wherename & "', '" & TextBox4.Text & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        myConnection.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call updatedata()
        Call getdata()
    End Sub







    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
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

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call getdata()
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
            Label1.ForeColor = Color.Teal
            Label3.ForeColor = Color.Teal
            Label4.ForeColor = Color.Teal
            Label5.ForeColor = Color.Teal
            Label9.ForeColor = Color.Teal
            Label2.ForeColor = Color.Teal
            Label7.ForeColor = Color.Teal
        ElseIf o = "2" Then
            Me.BackColor = Color.White

            Button1.ForeColor = Color.Black
            Label1.ForeColor = Color.Black
            Label3.ForeColor = Color.Black
            Label4.ForeColor = Color.Black
            Label5.ForeColor = Color.Black
            Label9.ForeColor = Color.Black
            Label2.ForeColor = Color.Black
            Label7.ForeColor = Color.Black
        ElseIf o = "3" Then
            Me.BackColor = Color.PowderBlue

            Button1.ForeColor = Color.Blue
            Label1.ForeColor = Color.Blue
            Label3.ForeColor = Color.Blue
            Label4.ForeColor = Color.Blue
            Label5.ForeColor = Color.Blue
            Label9.ForeColor = Color.Blue
            Label2.ForeColor = Color.Blue
            Label7.ForeColor = Color.Blue
        ElseIf o = "4" Then
            Me.BackColor = Color.BlanchedAlmond

            Button1.ForeColor = Color.Sienna
            Label1.ForeColor = Color.Sienna
            Label3.ForeColor = Color.Sienna
            Label4.ForeColor = Color.Sienna
            Label5.ForeColor = Color.Sienna
            Label9.ForeColor = Color.Sienna
            Label2.ForeColor = Color.Sienna
            Label7.ForeColor = Color.Sienna
        ElseIf o = "5" Then
            Me.BackColor = Color.DarkRed

            Button1.ForeColor = Color.Lime
            Label1.ForeColor = Color.Lime
            Label3.ForeColor = Color.Lime
            Label4.ForeColor = Color.Lime
            Label5.ForeColor = Color.Lime
            Label9.ForeColor = Color.Lime
            Label2.ForeColor = Color.Lime
            Label7.ForeColor = Color.Lime
        End If
    End Sub

    Private Sub PictureBox3_Click_1(sender As Object, e As EventArgs) Handles PictureBox3.Click
        menu_en.Show()
        Me.Hide()
    End Sub
End Class