Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class call_hy
    Private connectionString As String
    Function callto(ByVal calla As String)
        Process.Start("skype:" & calla & "?call")
    End Function
    Private Sub call_hy_Load(sender As Object, e As EventArgs) Handles MyBase.Load


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




        Dim cmd


        str = "SELECT * FROM call1"
        cmd = New OleDbCommand(str, myConnection)
        Dim dr1 = cmd.ExecuteReader


        Dim o As String = ""

        myConnection = New OleDbConnection

        provider = "Provider=Microsoft.JET.OLEDB.4.0;Data Source ="
        dataFile = "data/data.mdb" ' Change it to your Access Database location
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()

        Dim wherename As String
        wherename = "background"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            o = dr("value").ToString
        End While
        If o = "1" Then
            Me.BackColor = Color.White

            Button1.ForeColor = Color.Teal
            Label1.ForeColor = Color.Teal

        ElseIf o = "2" Then
            Me.BackColor = Color.White

            Button1.ForeColor = Color.Black
            Label1.ForeColor = Color.Black
        ElseIf o = "3" Then
            Me.BackColor = Color.PowderBlue

            Button1.ForeColor = Color.Blue
            Label1.ForeColor = Color.Blue
        ElseIf o = "4" Then
            Me.BackColor = Color.BlanchedAlmond

            Button1.ForeColor = Color.Sienna
            Label1.ForeColor = Color.Sienna
        ElseIf o = "5" Then
            Me.BackColor = Color.DarkRed

            Button1.ForeColor = Color.Lime
            Label1.ForeColor = Color.Lime
        End If


        Dim i As Integer = 1
        Dim b, k, a
        b = 1 : k = 1 : a = 0


        While dr1.Read()


            Dim Btn As New Button

            Btn.Size = New Size(150, 40)
            If a < 5 Then
                Btn.Location = New Point(80, k * 50)
                Btn.Tag = a
                Btn.Text = dr1("name")
                Btn.Name = dr1("login")
                k += 1
            Else
                Btn.Location = New Point(300, b * 50)
                b += 1
                Btn.Tag = a
                Btn.Text = dr1("name")
                Btn.Name = dr1("login")
            End If


            Me.Controls.Add(Btn)
            If o = "1" Then
                Btn.ForeColor = Color.Teal
            ElseIf o = "2" Then
                Btn.ForeColor = Color.Black
            ElseIf o = "3" Then
                Btn.ForeColor = Color.Blue
            ElseIf o = "4" Then
                Btn.ForeColor = Color.Sienna
            ElseIf o = "5" Then
                Btn.ForeColor = Color.Lime
            End If
            Btn.FlatStyle = FlatStyle.Flat
            Btn.Font = New Font("Microsoft Sans Serif", 16.0, FontStyle.Bold)
            AddHandler Btn.Click, AddressOf Me.btns_Click
            a += 1
        End While
    End Sub









    Private Sub btns_Click(sender As Object, e As System.EventArgs)

        Dim currButton As Button = CType(sender, Button)
        Select Case currButton.Tag
            Case "0"
                Process.Start("skype:" & currButton.Name & "?call")
            Case "1"
                Process.Start("skype:" & currButton.Name & "?call")
            Case "2"
                Process.Start("skype:" & currButton.Name & "?call")
            Case "3"
                Process.Start("skype:" & currButton.Name & "?call")
            Case "4"
                Process.Start("skype:" & currButton.Name & "?call")
            Case "5"
                Process.Start("skype:" & currButton.Name & "?call")
            Case "6"
                Process.Start("skype:" & currButton.Name & "?call")
            Case "7"
                Process.Start("skype:" & currButton.Name & "?call")
            Case "8"
                Process.Start("skype:" & currButton.Name & "?call")
            Case "9"
                Process.Start("skype:" & currButton.Name & "?call")
        End Select
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)
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

    Private Sub PictureBox5_Click_1(sender As Object, e As EventArgs) Handles PictureBox5.Click
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

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        menu_hy.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        calledit_hy.Show()
        Me.Close()
    End Sub
End Class