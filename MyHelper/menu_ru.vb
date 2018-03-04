Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class menu_ru
    Private connectionString As String
    Function callto(ByVal calla As String)
        Process.Start("skype:" & calla & "?call")
    End Function
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim calc As New System.Diagnostics.Process()
        calc = Process.Start("C:\Windows\system32\calc.exe", "")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim lupa As New System.Diagnostics.Process()
        lupa = Process.Start("C:\Windows\system32\magnify.exe", "")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim snotes As New System.Diagnostics.Process()
        snotes = Process.Start("notes\ssn.exe", "")

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click


        Try
            Dim key As New System.Diagnostics.Process()
            key = Process.Start("C:\Windows\system32\osk.exe", "")
        Catch

            Dim old As Long
            If Environment.Is64BitOperatingSystem Then
                If Wow64DisableWow64FsRedirection(old) Then
                    Process.Start(osk)
                    Wow64EnableWow64FsRedirection(old)
                End If
            Else
                Process.Start(osk)
            End If
        End Try
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        read_ru.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ask_ru.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        call_ru.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        settings_ru.Show()
        Me.Hide()
    End Sub

    Private Sub menu_ru_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Button2.ForeColor = Color.Teal
            Button1.ForeColor = Color.Teal
            Button3.ForeColor = Color.Teal
            Button4.ForeColor = Color.Teal
            Button9.ForeColor = Color.Teal
            Button10.ForeColor = Color.Teal
            Button5.ForeColor = Color.Teal

        ElseIf o = "2" Then
            Me.BackColor = Color.White
            Button2.ForeColor = Color.Black
            Button1.ForeColor = Color.Black
            Button3.ForeColor = Color.Black
            Button4.ForeColor = Color.Black
            Button9.ForeColor = Color.Black
            Button10.ForeColor = Color.Black
            Button5.ForeColor = Color.Black
        ElseIf o = "3" Then
            Me.BackColor = Color.PowderBlue
            Button2.ForeColor = Color.Blue
            Button1.ForeColor = Color.Blue
            Button3.ForeColor = Color.Blue
            Button4.ForeColor = Color.Blue
            Button9.ForeColor = Color.Blue
            Button10.ForeColor = Color.Blue
            Button5.ForeColor = Color.Blue
        ElseIf o = "4" Then
            Me.BackColor = Color.BlanchedAlmond
            Button2.ForeColor = Color.Sienna
            Button1.ForeColor = Color.Sienna
            Button3.ForeColor = Color.Sienna
            Button4.ForeColor = Color.Sienna
            Button9.ForeColor = Color.Sienna
            Button10.ForeColor = Color.Sienna
            Button5.ForeColor = Color.Sienna
        ElseIf o = "5" Then
            Me.BackColor = Color.DarkRed
            Button2.ForeColor = Color.Lime
            Button1.ForeColor = Color.Lime
            Button3.ForeColor = Color.Lime
            Button4.ForeColor = Color.Lime
            Button9.ForeColor = Color.Lime
            Button10.ForeColor = Color.Lime
            Button5.ForeColor = Color.Lime
        End If
        myConnection = New OleDbConnection
        Dim t As String = ""
        provider = "Provider=Microsoft.JET.OLEDB.4.0;Data Source ="
        dataFile = "data/data.mdb" ' Change it to your Access Database location
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()

        wherename = "magnifier"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            t = dr("value").ToString
        End While
        PictureBox4.Visible = False
        PictureBox2.Visible = False
        If t = "true" Then
            PictureBox2.Visible = True
        End If
        myConnection = New OleDbConnection
        Dim r As String = ""
        provider = "Provider=Microsoft.JET.OLEDB.4.0;Data Source ="
        dataFile = "data/data.mdb" ' Change it to your Access Database location
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()

        wherename = "keyboard"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            r = dr("value").ToString
        End While
        If r = "true" Then
            PictureBox4.Visible = True
        End If
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        settings_ru.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        helper_ru.Show()
        Me.Hide()
    End Sub
End Class