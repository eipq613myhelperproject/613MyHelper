Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class settings_en
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
        wherename = "server"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            TextBox1.Text = dr("value").ToString
        End While
        wherename = "tel"
        str = "SELECT * FROM moderator_data WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            TextBox6.Text = dr("value").ToString
        End While
    End Sub  ' Անհրաժեշտ կարգավորումների արժեքների ստացում, ցուցադրում
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
        wherename = "server"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & (TextBox1.Text) & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
        wherename = "tel"
        str = "DELETE * FROM moderator_data WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [moderator_data]([name] , [value]) VALUES('" & wherename & "', '" & (TextBox6.Text) & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
    End Sub   ' Պահպանել - պրոցեդուրա
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Call start_test.check_first()
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
    End Sub  ' Լեզվի փոփոխում դեպի ռուսերեն
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Call start_test.check_first()
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
    End Sub ' Լեզվի փոփոխու դեպի անգլերեն
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Call start_test.check_first()
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
    End Sub  ' Լեզվի փոփոխում դեպի հայերեն
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call start_test.check_first()
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
    End Sub   ' Լեզվի փոփոխում դեպի ուկրաիներեն
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call start_test.check_first()
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
        Call start_test.backgr()
        Me.Refresh()
        Application.Exit()
        Process.Start(Application.ExecutablePath)
    End Sub   ' Թեմայի փոփոխում՝ փիրուզագույն - սպիտակ
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call start_test.check_first()
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
        Call start_test.backgr()
        Me.Refresh()
        Application.Exit()
        Process.Start(Application.ExecutablePath)
    End Sub   ' Թեմայի փոփոխում ՝ սև-սպիտակ
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call start_test.check_first()
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
        Call start_test.backgr()
        Me.Refresh()
        Application.Exit()
        Process.Start(Application.ExecutablePath)
    End Sub   ' Թեմայի փոփոխում՝ կապույտ - բաց կապույտի վրա
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call start_test.check_first()
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
        Call start_test.backgr()
        Me.Refresh()
        Application.Exit()
        Process.Start(Application.ExecutablePath)
    End Sub    ' Թեմայի փոփոխում՝ մուգ և բաց շականակագույն
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Call start_test.check_first()
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
        Call start_test.backgr()
        Application.Exit()
        Process.Start(Application.ExecutablePath)
    End Sub  '' Թեմայի փոփոխում՝ մուգ շականակագույն և կանաչ
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Call start_test.setanjatel()
        start_en.Timer1.Start()
        start_en.Timer2.Start()
        start_en.Timer3.Start()
        start_en.Timer4.Start()
        Call start_test.check_first()
        Call updatedata()
        Call getdata()
    End Sub  '' Պահպանել
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim o As String = ""
        Call getdata()
        Call start_test.backgr()
    End Sub    ' Ֆոռմի միացում - անհրաժեշտ պրոցեդուրաների կանչում
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        menu_en.Show()
        Me.Close()
    End Sub  ' Ետ վերադարձ
End Class