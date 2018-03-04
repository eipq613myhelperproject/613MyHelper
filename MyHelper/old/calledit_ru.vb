Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class calledit_ru
    Private connectionString As String
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        call_ru.Show()
        Me.Close()
    End Sub ' վերադառնալ նախորդ էջ
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim provider As String
        Dim dataFile As String
        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dr As OleDbDataReader
        provider = "Provider=Microsoft.JET.OLEDB.4.0;Data Source ="
        dataFile = "data/data.mdb"
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        Dim str As String
        Dim wherename As String
        wherename = TextBox1.Text
        Try
            str = "DELETE * FROM call1 WHERE (name = '" & wherename & " ')"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            dr = cmd.ExecuteReader
        Catch ex As Exception
            MsgBox("error")
        End Try
    End Sub ' ջնջել կոնտակտ
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
        wherename = TextBox1.Text
        Try
            str = "INSERT INTO [call1]([name] , [login]) VALUES('" & TextBox2.Text & "', '" & TextBox3.Text & "')"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            cmd = New OleDbCommand(str, myConnection)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("error")
        End Try
    End Sub ' Ավելացնել կոնտակտ
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        start_test.calltomoderator()
    End Sub ' Զանգել մոդերատորին
    Private Sub calledit_ru_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    End Sub   'թեմայի կարգավորումներ
End Class