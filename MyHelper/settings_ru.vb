
Imports System
Imports System.Data
Imports System.Data.OleDb

Public Class settings_ru


    Public Sub backgr()
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
            Label2.ForeColor = Color.Teal
            Label3.ForeColor = Color.Teal
            Label4.ForeColor = Color.Teal
            Label5.ForeColor = Color.Teal
            Label6.ForeColor = Color.Teal
            CheckBox1.ForeColor = Color.Teal
            CheckBox2.ForeColor = Color.Teal
            CheckBox3.ForeColor = Color.Teal
            Button6.ForeColor = Color.Teal
            Button8.ForeColor = Color.Teal
            Button10.ForeColor = Color.Teal
            Button11.ForeColor = Color.Teal
            Button12.ForeColor = Color.Teal
            Button9.ForeColor = Color.White
            Button7.ForeColor = Color.White
            Button9.BackColor = Color.Teal
            Button7.BackColor = Color.Teal


        ElseIf o = "2" Then
            Me.BackColor = Color.White
            Label1.ForeColor = Color.Black
            Label2.ForeColor = Color.Black
            Label3.ForeColor = Color.Black
            Label4.ForeColor = Color.Black
            Label5.ForeColor = Color.Black
            Label6.ForeColor = Color.Black
            CheckBox1.ForeColor = Color.Black
            CheckBox2.ForeColor = Color.Black
            CheckBox3.ForeColor = Color.Black
            Button6.ForeColor = Color.Black
            Button8.ForeColor = Color.Black
            Button10.ForeColor = Color.Black
            Button11.ForeColor = Color.Black
            Button12.ForeColor = Color.Black
            Button9.ForeColor = Color.White
            Button7.ForeColor = Color.White
            Button9.BackColor = Color.Black
            Button7.BackColor = Color.Black
        ElseIf o = "3" Then
            Me.BackColor = Color.PowderBlue
            Label1.ForeColor = Color.Blue
            Label2.ForeColor = Color.Blue
            Label3.ForeColor = Color.Blue
            Label4.ForeColor = Color.Blue
            Label5.ForeColor = Color.Blue
            Label6.ForeColor = Color.Blue
            CheckBox1.ForeColor = Color.Blue
            CheckBox2.ForeColor = Color.Blue
            CheckBox3.ForeColor = Color.Blue
            Button6.ForeColor = Color.Blue
            Button8.ForeColor = Color.Blue
            Button10.ForeColor = Color.Blue
            Button11.ForeColor = Color.Blue
            Button12.ForeColor = Color.Blue
            Button9.ForeColor = Color.PowderBlue
            Button7.ForeColor = Color.PowderBlue
            Button9.BackColor = Color.Blue
            Button7.BackColor = Color.Blue
        ElseIf o = "4" Then
            Me.BackColor = Color.BlanchedAlmond
            Label1.ForeColor = Color.Sienna
            Label2.ForeColor = Color.Sienna
            Label3.ForeColor = Color.Sienna
            Label4.ForeColor = Color.Sienna
            Label5.ForeColor = Color.Sienna
            Label6.ForeColor = Color.Sienna
            CheckBox1.ForeColor = Color.Sienna
            CheckBox2.ForeColor = Color.Sienna
            CheckBox3.ForeColor = Color.Sienna
            Button6.ForeColor = Color.Sienna
            Button8.ForeColor = Color.Sienna
            Button10.ForeColor = Color.Sienna
            Button11.ForeColor = Color.Sienna
            Button12.ForeColor = Color.Sienna
            Button9.ForeColor = Color.BlanchedAlmond
            Button7.ForeColor = Color.BlanchedAlmond
            Button9.BackColor = Color.Sienna
            Button7.BackColor = Color.Sienna
        ElseIf o = "5" Then
            Me.BackColor = Color.DarkRed
            Label1.ForeColor = Color.Lime
            Label2.ForeColor = Color.Lime
            Label3.ForeColor = Color.Lime
            Label4.ForeColor = Color.Lime
            Label5.ForeColor = Color.Lime
            Label6.ForeColor = Color.Lime
            CheckBox1.ForeColor = Color.Lime
            CheckBox2.ForeColor = Color.Lime
            CheckBox3.ForeColor = Color.Lime
            Button6.ForeColor = Color.Lime
            Button8.ForeColor = Color.Lime
            Button10.ForeColor = Color.Lime
            Button11.ForeColor = Color.Lime
            Button12.ForeColor = Color.Lime
            Button9.ForeColor = Color.DarkRed
            Button7.ForeColor = Color.DarkRed
            Button9.BackColor = Color.Lime
            Button7.BackColor = Color.Lime

        End If
        Me.Refresh()
    End Sub
    Public Sub check_first()
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
        wherename = "first_time"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & "1" & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
    End Sub

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
        wherename = "magnifier"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            CheckBox1.Checked = dr("value").ToString
        End While
        wherename = "jest"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            CheckBox3.Checked = dr("value").ToString
        End While

        wherename = "keyboard"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            CheckBox2.Checked = dr("value").ToString
        End While

        wherename = "timer"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            ComboBox1.Text = dr("value").ToString
        End While
        wherename = "alarm1"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            TextBox2.Text = dr("value").ToString
        End While
        wherename = "alarm2"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            TextBox3.Text = dr("value").ToString
        End While

        wherename = "alarm3"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            TextBox4.Text = dr("value").ToString
        End While
        wherename = "alarm4"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            TextBox5.Text = dr("value").ToString
        End While
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Call check_first()
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

        Application.Exit()
        Process.Start(Application.ExecutablePath)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Call check_first()
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

        Application.Exit()
        Process.Start(Application.ExecutablePath)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Call check_first()
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
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & "arm" & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()

        Application.Exit()
        Process.Start(Application.ExecutablePath)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call check_first()
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
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & "ukr" & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()

        Application.Exit()
        Process.Start(Application.ExecutablePath)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call check_first()

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
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & "1" & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        Call backgr()
        Me.Refresh()

        Application.Exit()
        Process.Start(Application.ExecutablePath)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call check_first()
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
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & "2" & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        Call backgr()
        Me.Refresh()

        Application.Exit()
        Process.Start(Application.ExecutablePath)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call check_first()
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
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & "3" & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        Call backgr()
        Me.Refresh()

        Application.Exit()
        Process.Start(Application.ExecutablePath)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call check_first()
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
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & "4" & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        Call backgr()
        Me.Refresh()

        Application.Exit()
        Process.Start(Application.ExecutablePath)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Call check_first()
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
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & "5" & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        Call backgr()

        Application.Exit()
        Process.Start(Application.ExecutablePath)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Call start_test.FlushMemory()
        Call start_test.setanjatel()
        start_ru.Timer1.Start()
        start_ru.Timer2.Start()
        start_ru.Timer3.Start()
        start_ru.Timer4.Start()
        Call check_first()
        Call updatedata()
        Call getdata()

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

        wherename = "magnifier"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim k As String = ""
        If CheckBox1.Checked = False Then
            k = "false"
        Else
            k = "true"
        End If
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & k & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()



        wherename = "keyboard"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim t As String = ""
        If CheckBox2.Checked = False Then
            t = "false"
        Else
            t = "true"
        End If
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & t & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()



        wherename = "jest"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim s As String = ""
        If CheckBox3.Checked = False Then
            s = "false"
        Else
            s = "true"
        End If
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & s & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()






        wherename = "timer"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader

        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & Val(ComboBox1.Text) & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()


        wherename = "alarm1"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & (TextBox2.Text) & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()

        wherename = "alarm2"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & (TextBox3.Text) & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()

        wherename = "alarm3"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & (TextBox4.Text) & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()

        wherename = "alarm4"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & (TextBox5.Text) & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()





    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim o As String = ""
        Call getdata()
        Call backgr()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        menu_ru.Show()
        Me.Close()
    End Sub


End Class