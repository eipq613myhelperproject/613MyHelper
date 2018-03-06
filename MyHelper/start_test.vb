Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.GC
Imports System.Net
Imports System.Xml
Imports System.Text
Imports System.String
Imports System.IO
Public Class start_test
    Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal process As IntPtr, ByVal minimumWorkingSetSize As Integer, ByVal maximumWorkingSetSize As Integer) As Integer
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim dr As OleDbDataReader
    Private Sub start_test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call apikeysdownload()
        Call setanjatel()
        provider = "Provider=Microsoft.JET.OLEDB.4.0;Data Source ="
        dataFile = "data/data.mdb" ' Change it to your Access Database location
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        Dim wherename = "first_time"
        Dim str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            str = dr("value").ToString
        End While
        If str = 0 Then
            lng_form.Show()
            Me.Close()
        Else
            wherename = "language"
            str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
            cmd = New OleDbCommand(str, myConnection)
            dr = cmd.ExecuteReader
            While dr.Read()
                str = dr("value").ToString
            End While
            If str = "ru" Then
                start_ru.Show()
                Me.Close()
            ElseIf str = "arm" Then
                start_hy.Show()
                Me.Close()
            ElseIf str = "en" Then
                start_en.Show()
                Me.Close()
            Else
                start_uk.Show()
                Me.Close()
            End If
        End If
        Timer2.Start()
    End Sub ''Առաջին անգամ լեզվի, մնացած դեպքում ծրագրի մենյուն բացող հատված
    Public Sub setanjatel()
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
        wherename = "timer"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            str = dr("value").ToString
        End While
        If (str <> "0" And str <> 0 And str <> "") Then
            Timer1.Enabled = True
            Timer1.Interval = Val(str) * 60000
            Timer1.Start()
        End If
        myConnection.Close()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MsgBox("ANJATEL KOMP@")
        'System.Diagnostics.Process.Start("shutdown", "-l")
        ''Timer1.Stop()
    End Sub '' Քոմփյութերը անջատող կոդ
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()
            If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
                Dim myProcesses As Process() = Process.GetProcessesByName("MyHelper")
                Dim myProcess As Process
                For Each myProcess In myProcesses
                    SetProcessWorkingSetSize(myProcess.Handle, -1, -1)
                Next myProcess
            End If
        Catch ex As Exception
        End Try
    End Sub '' Ծրագրի հիշողությունը մաքրող կոդ
    Function callto(ByVal calla As String)
        Process.Start("skype:" & calla & "?call")
    End Function ' Skype զանգ - պրոցեդուրա
    Public Sub callcalc()
        Dim calc As New System.Diagnostics.Process()
        calc = Process.Start("C:\Windows\system32\calc.exe", "")
    End Sub ' Հաշվիչի միացում
    Public Sub calllupa()
        Dim lupa As New System.Diagnostics.Process()
        lupa = Process.Start("C:\Windows\system32\magnify.exe", "")
    End Sub ' Խոշորացույցի միացում
    Public Sub callnotes()
        Dim snotes As New System.Diagnostics.Process()
        snotes = Process.Start("notes\ssn.exe", "")
    End Sub ' Նոթատետրի միացում
    Public Sub callkeyboard()
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
    End Sub ' Վիրտուալ ստեղնաշարի միացում
    Public Sub calltomoderator()
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
    End Sub '' Զանգել մոդերատորին
    Public Sub askload()
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
            ask_ru.Button1.ForeColor = Color.Teal
            ask_hy.Button1.ForeColor = Color.Teal
            ask_en.Button1.ForeColor = Color.Teal
            ask_uk.Button1.ForeColor = Color.Teal
        ElseIf o = "2" Then
            Me.BackColor = Color.White
            ask_ru.Button1.ForeColor = Color.Black
            ask_en.Button1.ForeColor = Color.Black
            ask_uk.Button1.ForeColor = Color.Black
            ask_hy.Button1.ForeColor = Color.Black
        ElseIf o = "3" Then
            Me.BackColor = Color.PowderBlue
            ask_ru.Button1.ForeColor = Color.Blue
            ask_uk.Button1.ForeColor = Color.Blue
            ask_en.Button1.ForeColor = Color.Blue
            ask_hy.Button1.ForeColor = Color.Blue
        ElseIf o = "4" Then
            Me.BackColor = Color.BlanchedAlmond
            ask_ru.Button1.ForeColor = Color.Sienna
            ask_en.Button1.ForeColor = Color.Sienna
            ask_uk.Button1.ForeColor = Color.Sienna
            ask_hy.Button1.ForeColor = Color.Sienna
        ElseIf o = "5" Then
            Me.BackColor = Color.DarkRed
            ask_ru.Button1.ForeColor = Color.Lime
            ask_uk.Button1.ForeColor = Color.Lime
            ask_en.Button1.ForeColor = Color.Lime
            ask_hy.Button1.ForeColor = Color.Lime
        End If
    End Sub  ''  Հարց-պատասխան համակարգի թեմայի կարգավորում
    Public Sub readload()
        Dim o As String = ""
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
        wherename = "background"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            o = dr("value").ToString
        End While
        If o = "1" Then
            Me.BackColor = Color.White
            read_ru.Button1.ForeColor = Color.Teal
            read_ru.Label1.ForeColor = Color.Teal
            read_en.Button1.ForeColor = Color.Teal
            read_en.Label1.ForeColor = Color.Teal
            read_uk.Button1.ForeColor = Color.Teal
            read_uk.Label1.ForeColor = Color.Teal
            read_hy.Button1.ForeColor = Color.Teal
            read_hy.Label1.ForeColor = Color.Teal
        ElseIf o = "2" Then
            Me.BackColor = Color.White
            read_ru.Button1.ForeColor = Color.Black
            read_ru.Label1.ForeColor = Color.Black
            read_uk.Button1.ForeColor = Color.Black
            read_uk.Label1.ForeColor = Color.Black
            read_en.Button1.ForeColor = Color.Black
            read_en.Label1.ForeColor = Color.Black
            read_hy.Button1.ForeColor = Color.Black
            read_hy.Label1.ForeColor = Color.Black
        ElseIf o = "3" Then
            Me.BackColor = Color.PowderBlue
            read_ru.Button1.ForeColor = Color.Blue
            read_ru.Label1.ForeColor = Color.Blue
            read_uk.Button1.ForeColor = Color.Blue
            read_uk.Label1.ForeColor = Color.Blue
            read_en.Button1.ForeColor = Color.Blue
            read_en.Label1.ForeColor = Color.Blue
            read_hy.Button1.ForeColor = Color.Blue
            read_hy.Label1.ForeColor = Color.Blue
        ElseIf o = "4" Then
            Me.BackColor = Color.BlanchedAlmond
            read_ru.Button1.ForeColor = Color.Sienna
            read_ru.Label1.ForeColor = Color.Sienna
            read_uk.Button1.ForeColor = Color.Sienna
            read_uk.Label1.ForeColor = Color.Sienna
            read_en.Button1.ForeColor = Color.Sienna
            read_en.Label1.ForeColor = Color.Sienna
            read_hy.Button1.ForeColor = Color.Sienna
            read_hy.Label1.ForeColor = Color.Sienna
        ElseIf o = "5" Then
            Me.BackColor = Color.DarkRed
            read_ru.Button1.ForeColor = Color.Lime
            read_ru.Label1.ForeColor = Color.Lime
            read_en.Button1.ForeColor = Color.Lime
            read_en.Label1.ForeColor = Color.Lime
            read_uk.Button1.ForeColor = Color.Lime
            read_uk.Label1.ForeColor = Color.Lime
            read_hy.Button1.ForeColor = Color.Lime
            read_hy.Label1.ForeColor = Color.Lime
        End If
        Dim q As String = ""
        myConnection = New OleDbConnection
        provider = "Provider=Microsoft.JET.OLEDB.4.0;Data Source ="
        dataFile = "data/data.mdb" ' Change it to your Access Database location
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()
        wherename = "jest"
        str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
        cmd = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        While dr.Read()
            q = dr("value").ToString
        End While
        While dr.Read()
            q = dr("value").ToString
        End While
        read_ru.PictureBox1.Visible = False
        read_uk.PictureBox1.Visible = False
        read_en.PictureBox1.Visible = False
        read_hy.PictureBox1.Visible = False
        If q = "true" Then
            read_ru.PictureBox1.Visible = True
            read_uk.PictureBox1.Visible = True
            read_en.PictureBox1.Visible = True
            read_hy.PictureBox1.Visible = True
        End If
    End Sub '' Կարդալ համակարգի թեմայի կարգավորում
    Public Sub menuload()
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
            menu_ru.Button2.ForeColor = Color.Teal
            menu_ru.Button1.ForeColor = Color.Teal
            menu_ru.Button4.ForeColor = Color.Teal
            menu_ru.Button9.ForeColor = Color.Teal
            menu_ru.Button10.ForeColor = Color.Teal
            menu_ru.Button5.ForeColor = Color.Teal
            menu_uk.Button2.ForeColor = Color.Teal
            menu_uk.Button1.ForeColor = Color.Teal
            menu_uk.Button4.ForeColor = Color.Teal
            menu_uk.Button9.ForeColor = Color.Teal
            menu_uk.Button10.ForeColor = Color.Teal
            menu_uk.Button5.ForeColor = Color.Teal
            menu_en.Button2.ForeColor = Color.Teal
            menu_en.Button1.ForeColor = Color.Teal
            menu_en.Button4.ForeColor = Color.Teal
            menu_en.Button9.ForeColor = Color.Teal
            menu_en.Button10.ForeColor = Color.Teal
            menu_en.Button5.ForeColor = Color.Teal
            menu_hy.Button2.ForeColor = Color.Teal
            menu_hy.Button1.ForeColor = Color.Teal
            menu_hy.Button4.ForeColor = Color.Teal
            menu_hy.Button9.ForeColor = Color.Teal
            menu_hy.Button10.ForeColor = Color.Teal
            menu_hy.Button5.ForeColor = Color.Teal
        ElseIf o = "2" Then
            menu_ru.BackColor = Color.White
            menu_ru.Button2.ForeColor = Color.Black
            menu_ru.Button1.ForeColor = Color.Black
            menu_ru.Button4.ForeColor = Color.Black
            menu_ru.Button9.ForeColor = Color.Black
            menu_ru.Button10.ForeColor = Color.Black
            menu_ru.Button5.ForeColor = Color.Black
            menu_en.BackColor = Color.White
            menu_en.Button2.ForeColor = Color.Black
            menu_en.Button1.ForeColor = Color.Black
            menu_en.Button4.ForeColor = Color.Black
            menu_en.Button9.ForeColor = Color.Black
            menu_en.Button10.ForeColor = Color.Black
            menu_en.Button5.ForeColor = Color.Black
            menu_uk.BackColor = Color.White
            menu_uk.Button2.ForeColor = Color.Black
            menu_uk.Button1.ForeColor = Color.Black
            menu_uk.Button4.ForeColor = Color.Black
            menu_uk.Button9.ForeColor = Color.Black
            menu_uk.Button10.ForeColor = Color.Black
            menu_uk.Button5.ForeColor = Color.Black
            menu_hy.BackColor = Color.White
            menu_hy.Button2.ForeColor = Color.Black
            menu_hy.Button1.ForeColor = Color.Black
            menu_hy.Button4.ForeColor = Color.Black
            menu_hy.Button9.ForeColor = Color.Black
            menu_hy.Button10.ForeColor = Color.Black
            menu_hy.Button5.ForeColor = Color.Black
        ElseIf o = "3" Then
            menu_ru.BackColor = Color.PowderBlue
            menu_ru.Button2.ForeColor = Color.Blue
            menu_ru.Button1.ForeColor = Color.Blue
            menu_ru.Button4.ForeColor = Color.Blue
            menu_ru.Button9.ForeColor = Color.Blue
            menu_ru.Button10.ForeColor = Color.Blue
            menu_ru.Button5.ForeColor = Color.Blue
            menu_uk.BackColor = Color.PowderBlue
            menu_uk.Button2.ForeColor = Color.Blue
            menu_uk.Button1.ForeColor = Color.Blue
            menu_uk.Button4.ForeColor = Color.Blue
            menu_uk.Button9.ForeColor = Color.Blue
            menu_uk.Button10.ForeColor = Color.Blue
            menu_uk.Button5.ForeColor = Color.Blue
            menu_en.BackColor = Color.PowderBlue
            menu_en.Button2.ForeColor = Color.Blue
            menu_en.Button1.ForeColor = Color.Blue
            menu_en.Button4.ForeColor = Color.Blue
            menu_en.Button9.ForeColor = Color.Blue
            menu_en.Button10.ForeColor = Color.Blue
            menu_en.Button5.ForeColor = Color.Blue
            menu_hy.BackColor = Color.PowderBlue
            menu_hy.Button2.ForeColor = Color.Blue
            menu_hy.Button1.ForeColor = Color.Blue
            menu_hy.Button4.ForeColor = Color.Blue
            menu_hy.Button9.ForeColor = Color.Blue
            menu_hy.Button10.ForeColor = Color.Blue
            menu_hy.Button5.ForeColor = Color.Blue
        ElseIf o = "4" Then
            menu_ru.BackColor = Color.BlanchedAlmond
            menu_ru.Button2.ForeColor = Color.Sienna
            menu_ru.Button1.ForeColor = Color.Sienna
            menu_ru.Button4.ForeColor = Color.Sienna
            menu_ru.Button9.ForeColor = Color.Sienna
            menu_ru.Button10.ForeColor = Color.Sienna
            menu_ru.Button5.ForeColor = Color.Sienna
            menu_en.BackColor = Color.BlanchedAlmond
            menu_en.Button2.ForeColor = Color.Sienna
            menu_en.Button1.ForeColor = Color.Sienna
            menu_en.Button4.ForeColor = Color.Sienna
            menu_en.Button9.ForeColor = Color.Sienna
            menu_en.Button10.ForeColor = Color.Sienna
            menu_en.Button5.ForeColor = Color.Sienna
            menu_uk.BackColor = Color.BlanchedAlmond
            menu_uk.Button2.ForeColor = Color.Sienna
            menu_uk.Button1.ForeColor = Color.Sienna
            menu_uk.Button4.ForeColor = Color.Sienna
            menu_uk.Button9.ForeColor = Color.Sienna
            menu_uk.Button10.ForeColor = Color.Sienna
            menu_uk.Button5.ForeColor = Color.Sienna
            menu_hy.BackColor = Color.BlanchedAlmond
            menu_hy.Button2.ForeColor = Color.Sienna
            menu_hy.Button1.ForeColor = Color.Sienna
            menu_hy.Button4.ForeColor = Color.Sienna
            menu_hy.Button9.ForeColor = Color.Sienna
            menu_hy.Button10.ForeColor = Color.Sienna
            menu_hy.Button5.ForeColor = Color.Sienna
        ElseIf o = "5" Then
            menu_ru.BackColor = Color.DarkRed
            menu_ru.Button2.ForeColor = Color.Lime
            menu_ru.Button1.ForeColor = Color.Lime
            menu_ru.Button4.ForeColor = Color.Lime
            menu_ru.Button9.ForeColor = Color.Lime
            menu_ru.Button10.ForeColor = Color.Lime
            menu_ru.Button5.ForeColor = Color.Lime
            menu_en.BackColor = Color.DarkRed
            menu_en.Button2.ForeColor = Color.Lime
            menu_en.Button1.ForeColor = Color.Lime
            menu_en.Button4.ForeColor = Color.Lime
            menu_en.Button9.ForeColor = Color.Lime
            menu_en.Button10.ForeColor = Color.Lime
            menu_en.Button5.ForeColor = Color.Lime
            menu_uk.BackColor = Color.DarkRed
            menu_uk.Button2.ForeColor = Color.Lime
            menu_uk.Button1.ForeColor = Color.Lime
            menu_uk.Button4.ForeColor = Color.Lime
            menu_uk.Button9.ForeColor = Color.Lime
            menu_uk.Button10.ForeColor = Color.Lime
            menu_uk.Button5.ForeColor = Color.Lime
            menu_hy.BackColor = Color.DarkRed
            menu_hy.Button2.ForeColor = Color.Lime
            menu_hy.Button1.ForeColor = Color.Lime
            menu_hy.Button4.ForeColor = Color.Lime
            menu_hy.Button9.ForeColor = Color.Lime
            menu_hy.Button10.ForeColor = Color.Lime
            menu_hy.Button5.ForeColor = Color.Lime
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
        menu_ru.PictureBox4.Visible = False
        menu_ru.PictureBox2.Visible = False
        menu_hy.PictureBox4.Visible = False
        menu_hy.PictureBox2.Visible = False
        menu_en.PictureBox4.Visible = False
        menu_en.PictureBox2.Visible = False
        menu_uk.PictureBox4.Visible = False
        menu_uk.PictureBox2.Visible = False
        If t = "true" Then
            menu_ru.PictureBox2.Visible = True
            menu_uk.PictureBox2.Visible = True
            menu_en.PictureBox2.Visible = True
            menu_hy.PictureBox2.Visible = True
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
            menu_ru.PictureBox4.Visible = True
            menu_uk.PictureBox4.Visible = True
            menu_en.PictureBox4.Visible = True
            menu_hy.PictureBox4.Visible = True
        End If
    End Sub '' Մենյուի թեմայի կարգավորում / անհրաժեշտ գործիքների ընտրում
    Function Makequery(ByVal query As String)
        Try
            Dim Request As HttpWebRequest = HttpWebRequest.Create(query)
            Request.Proxy = Nothing
            Request.UserAgent = "Test"
            Dim Response As HttpWebResponse = Request.GetResponse
            Dim ResponseStream As System.IO.Stream = Response.GetResponseStream
            Dim StreamReader As New System.IO.StreamReader(ResponseStream)
            Dim Data As String = StreamReader.ReadToEnd
            StreamReader.Close()
            Makequery = Data
        Catch ex As Exception
        End Try
    End Function
    Function Makequerya(ByVal query As String, ByVal user_text As String)
        Try
            Dim Request As HttpWebRequest = HttpWebRequest.Create(query)
            Request.Proxy = Nothing
            Request.UserAgent = "Test"
            Dim Response As HttpWebResponse = Request.GetResponse
            Dim ResponseStream As System.IO.Stream = Response.GetResponseStream
            Dim StreamReader As New System.IO.StreamReader(ResponseStream)
            Dim Data As String = StreamReader.ReadToEnd
            StreamReader.Close()
            Makequerya = Data
        Catch ex As Exception
            '   MsgBox(user_text)
            user_text = Makequery("http://iwebing.96.lt/api/world-it-planet-url-encode.php?a=" & user_text)
            Dim webAddress As String = "https://yandex.ru/search/?text=" & user_text
            'TextBox1.Text = webAddress
            ask_ru.WebBrowser1.Visible = True
            ask_en.WebBrowser1.Visible = True
            ask_hy.WebBrowser1.Visible = True
            ask_uk.WebBrowser1.Visible = True
            ask_ru.WebBrowser1.Navigate(webAddress)
            ask_en.WebBrowser1.Navigate(webAddress)
            ask_hy.WebBrowser1.Navigate(webAddress)
            ask_uk.WebBrowser1.Navigate(webAddress)
        End Try
    End Function
    Function replaceaaa(ByRef textaaa As String)
        Dim aaaaaa As String = textaaa
        For i = 1 To textaaa.Length - 1
            aaaaaa = textaaa.Replace(" ", "+")
        Next
        Return aaaaaa
    End Function
    Function getxmltagvalue(ByRef query, ByRef valuetext)
        Try
            Dim doc As XmlDocument = New XmlDocument()
            Dim xmlvalue As String
            xmlvalue = Makequery(query)
            doc.LoadXml(xmlvalue)
            Dim valuetexta As String = "//" & valuetext ' Translation/text
            Dim gettedtext As String = doc.SelectSingleNode(valuetexta).InnerText
            getxmltagvalue = gettedtext
        Catch ex As Exception


        End Try
    End Function
    Function getxmlattrvalue(ByVal query, ByVal attribute)
        Try
            Dim doc As XmlDocument = New XmlDocument()
            Dim xmlvalue As String
            xmlvalue = Me.Makequery(query)
            doc.LoadXml(xmlvalue)
            Dim root As XmlElement = doc.DocumentElement
            Dim lang As String
            If (root.HasAttribute(attribute)) Then
                lang = root.GetAttribute(attribute)
            Else : lang = "There is not found attribute"
            End If
            getxmlattrvalue = lang
        Catch ex As Exception
        End Try
    End Function
    Public Sub check_first()
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
        wherename = "first_time"
        str = "DELETE * FROM settings WHERE (name = '" & wherename & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        str = "INSERT INTO [settings]([name] , [value]) VALUES('" & wherename & "', '" & "1" & "')"
        cmd = New OleDbCommand(str, myConnection)
        cmd.ExecuteNonQuery()
    End Sub ' Արդյոք առաջին անգամ է ծրագիրը աշխատում այդ քոմփյութերում
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
            settings_ru.Label1.ForeColor = Color.Teal
            settings_ru.Label2.ForeColor = Color.Teal
            settings_ru.Label3.ForeColor = Color.Teal
            settings_ru.Label4.ForeColor = Color.Teal
            settings_ru.Label5.ForeColor = Color.Teal
            settings_ru.Label6.ForeColor = Color.Teal
            settings_ru.CheckBox1.ForeColor = Color.Teal
            settings_ru.CheckBox2.ForeColor = Color.Teal
            settings_ru.CheckBox3.ForeColor = Color.Teal
            settings_ru.Button6.ForeColor = Color.Teal
            settings_ru.Button8.ForeColor = Color.Teal
            settings_ru.Button10.ForeColor = Color.Teal
            settings_ru.Button11.ForeColor = Color.Teal
            settings_ru.Button12.ForeColor = Color.Teal
            settings_ru.Button9.ForeColor = Color.White
            settings_ru.Button7.ForeColor = Color.White
            settings_ru.Button9.BackColor = Color.Teal
            settings_ru.Button7.BackColor = Color.Teal
            settings_uk.Label1.ForeColor = Color.Teal
            settings_uk.Label2.ForeColor = Color.Teal
            settings_uk.Label3.ForeColor = Color.Teal
            settings_uk.Label4.ForeColor = Color.Teal
            settings_uk.Label5.ForeColor = Color.Teal
            settings_uk.Label6.ForeColor = Color.Teal
            settings_uk.CheckBox1.ForeColor = Color.Teal
            settings_uk.CheckBox2.ForeColor = Color.Teal
            settings_uk.CheckBox3.ForeColor = Color.Teal
            settings_uk.Button6.ForeColor = Color.Teal
            settings_uk.Button8.ForeColor = Color.Teal
            settings_uk.Button10.ForeColor = Color.Teal
            settings_uk.Button11.ForeColor = Color.Teal
            settings_uk.Button12.ForeColor = Color.Teal
            settings_uk.Button9.ForeColor = Color.White
            settings_uk.Button7.ForeColor = Color.White
            settings_uk.Button9.BackColor = Color.Teal
            settings_uk.Button7.BackColor = Color.Teal
            settings_en.Label1.ForeColor = Color.Teal
            settings_en.Label2.ForeColor = Color.Teal
            settings_en.Label3.ForeColor = Color.Teal
            settings_en.Label4.ForeColor = Color.Teal
            settings_en.Label5.ForeColor = Color.Teal
            settings_en.Label6.ForeColor = Color.Teal
            settings_en.CheckBox1.ForeColor = Color.Teal
            settings_en.CheckBox2.ForeColor = Color.Teal
            settings_en.CheckBox3.ForeColor = Color.Teal
            settings_en.Button6.ForeColor = Color.Teal
            settings_en.Button8.ForeColor = Color.Teal
            settings_en.Button10.ForeColor = Color.Teal
            settings_en.Button11.ForeColor = Color.Teal
            settings_en.Button12.ForeColor = Color.Teal
            settings_en.Button9.ForeColor = Color.White
            settings_en.Button7.ForeColor = Color.White
            settings_en.Button9.BackColor = Color.Teal
            settings_en.Button7.BackColor = Color.Teal
            settings_hy.Label1.ForeColor = Color.Teal
            settings_hy.Label2.ForeColor = Color.Teal
            settings_hy.Label3.ForeColor = Color.Teal
            settings_hy.Label4.ForeColor = Color.Teal
            settings_hy.Label5.ForeColor = Color.Teal
            settings_hy.Label6.ForeColor = Color.Teal
            settings_hy.CheckBox1.ForeColor = Color.Teal
            settings_hy.CheckBox2.ForeColor = Color.Teal
            settings_hy.CheckBox3.ForeColor = Color.Teal
            settings_hy.Button6.ForeColor = Color.Teal
            settings_hy.Button8.ForeColor = Color.Teal
            settings_hy.Button10.ForeColor = Color.Teal
            settings_hy.Button11.ForeColor = Color.Teal
            settings_hy.Button12.ForeColor = Color.Teal
            settings_hy.Button9.ForeColor = Color.White
            settings_hy.Button7.ForeColor = Color.White
            settings_hy.Button9.BackColor = Color.Teal
            settings_hy.Button7.BackColor = Color.Teal
        ElseIf o = "2" Then
            settings_ru.BackColor = Color.White
            settings_ru.Label1.ForeColor = Color.Black
            settings_ru.Label2.ForeColor = Color.Black
            settings_ru.Label3.ForeColor = Color.Black
            settings_ru.Label4.ForeColor = Color.Black
            settings_ru.Label5.ForeColor = Color.Black
            settings_ru.Label6.ForeColor = Color.Black
            settings_ru.CheckBox1.ForeColor = Color.Black
            settings_ru.CheckBox2.ForeColor = Color.Black
            settings_ru.CheckBox3.ForeColor = Color.Black
            settings_ru.Button6.ForeColor = Color.Black
            settings_ru.Button8.ForeColor = Color.Black
            settings_ru.Button10.ForeColor = Color.Black
            settings_ru.Button11.ForeColor = Color.Black
            settings_ru.Button12.ForeColor = Color.Black
            settings_ru.Button9.ForeColor = Color.White
            settings_ru.Button7.ForeColor = Color.White
            settings_ru.Button9.BackColor = Color.Black
            settings_ru.Button7.BackColor = Color.Black
            settings_uk.BackColor = Color.White
            settings_uk.Label1.ForeColor = Color.Black
            settings_uk.Label2.ForeColor = Color.Black
            settings_uk.Label3.ForeColor = Color.Black
            settings_uk.Label4.ForeColor = Color.Black
            settings_uk.Label5.ForeColor = Color.Black
            settings_uk.Label6.ForeColor = Color.Black
            settings_uk.CheckBox1.ForeColor = Color.Black
            settings_uk.CheckBox2.ForeColor = Color.Black
            settings_uk.CheckBox3.ForeColor = Color.Black
            settings_uk.Button6.ForeColor = Color.Black
            settings_uk.Button8.ForeColor = Color.Black
            settings_uk.Button10.ForeColor = Color.Black
            settings_uk.Button11.ForeColor = Color.Black
            settings_uk.Button12.ForeColor = Color.Black
            settings_uk.Button9.ForeColor = Color.White
            settings_uk.Button7.ForeColor = Color.White
            settings_uk.Button9.BackColor = Color.Black
            settings_uk.Button7.BackColor = Color.Black
            settings_en.BackColor = Color.White
            settings_en.Label1.ForeColor = Color.Black
            settings_en.Label2.ForeColor = Color.Black
            settings_en.Label3.ForeColor = Color.Black
            settings_en.Label4.ForeColor = Color.Black
            settings_en.Label5.ForeColor = Color.Black
            settings_en.Label6.ForeColor = Color.Black
            settings_en.CheckBox1.ForeColor = Color.Black
            settings_en.CheckBox2.ForeColor = Color.Black
            settings_en.CheckBox3.ForeColor = Color.Black
            settings_en.Button6.ForeColor = Color.Black
            settings_en.Button8.ForeColor = Color.Black
            settings_en.Button10.ForeColor = Color.Black
            settings_en.Button11.ForeColor = Color.Black
            settings_en.Button12.ForeColor = Color.Black
            settings_en.Button9.ForeColor = Color.White
            settings_en.Button7.ForeColor = Color.White
            settings_en.Button9.BackColor = Color.Black
            settings_en.Button7.BackColor = Color.Black
            settings_hy.BackColor = Color.White
            settings_hy.Label1.ForeColor = Color.Black
            settings_hy.Label2.ForeColor = Color.Black
            settings_hy.Label3.ForeColor = Color.Black
            settings_hy.Label4.ForeColor = Color.Black
            settings_hy.Label5.ForeColor = Color.Black
            settings_hy.Label6.ForeColor = Color.Black
            settings_hy.CheckBox1.ForeColor = Color.Black
            settings_hy.CheckBox2.ForeColor = Color.Black
            settings_hy.CheckBox3.ForeColor = Color.Black
            settings_hy.Button6.ForeColor = Color.Black
            settings_hy.Button8.ForeColor = Color.Black
            settings_hy.Button10.ForeColor = Color.Black
            settings_hy.Button11.ForeColor = Color.Black
            settings_hy.Button12.ForeColor = Color.Black
            settings_hy.Button9.ForeColor = Color.White
            settings_hy.Button7.ForeColor = Color.White
            settings_hy.Button9.BackColor = Color.Black
            settings_hy.Button7.BackColor = Color.Black
        ElseIf o = "3" Then
            settings_ru.BackColor = Color.PowderBlue
            settings_ru.Label1.ForeColor = Color.Blue
            settings_ru.Label2.ForeColor = Color.Blue
            settings_ru.Label3.ForeColor = Color.Blue
            settings_ru.Label4.ForeColor = Color.Blue
            settings_ru.Label5.ForeColor = Color.Blue
            settings_ru.Label6.ForeColor = Color.Blue
            settings_ru.CheckBox1.ForeColor = Color.Blue
            settings_ru.CheckBox2.ForeColor = Color.Blue
            settings_ru.CheckBox3.ForeColor = Color.Blue
            settings_ru.Button6.ForeColor = Color.Blue
            settings_ru.Button8.ForeColor = Color.Blue
            settings_ru.Button10.ForeColor = Color.Blue
            settings_ru.Button11.ForeColor = Color.Blue
            settings_ru.Button12.ForeColor = Color.Blue
            settings_ru.Button9.ForeColor = Color.PowderBlue
            settings_ru.Button7.ForeColor = Color.PowderBlue
            settings_ru.Button9.BackColor = Color.Blue
            settings_ru.Button7.BackColor = Color.Blue
            settings_hy.BackColor = Color.PowderBlue
            settings_hy.Label1.ForeColor = Color.Blue
            settings_hy.Label2.ForeColor = Color.Blue
            settings_hy.Label3.ForeColor = Color.Blue
            settings_hy.Label4.ForeColor = Color.Blue
            settings_hy.Label5.ForeColor = Color.Blue
            settings_hy.Label6.ForeColor = Color.Blue
            settings_hy.CheckBox1.ForeColor = Color.Blue
            settings_hy.CheckBox2.ForeColor = Color.Blue
            settings_hy.CheckBox3.ForeColor = Color.Blue
            settings_hy.Button6.ForeColor = Color.Blue
            settings_hy.Button8.ForeColor = Color.Blue
            settings_hy.Button10.ForeColor = Color.Blue
            settings_hy.Button11.ForeColor = Color.Blue
            settings_hy.Button12.ForeColor = Color.Blue
            settings_hy.Button9.ForeColor = Color.PowderBlue
            settings_hy.Button7.ForeColor = Color.PowderBlue
            settings_hy.Button9.BackColor = Color.Blue
            settings_hy.Button7.BackColor = Color.Blue
            settings_en.BackColor = Color.PowderBlue
            settings_en.Label1.ForeColor = Color.Blue
            settings_en.Label2.ForeColor = Color.Blue
            settings_en.Label3.ForeColor = Color.Blue
            settings_en.Label4.ForeColor = Color.Blue
            settings_en.Label5.ForeColor = Color.Blue
            settings_en.Label6.ForeColor = Color.Blue
            settings_en.CheckBox1.ForeColor = Color.Blue
            settings_en.CheckBox2.ForeColor = Color.Blue
            settings_en.CheckBox3.ForeColor = Color.Blue
            settings_en.Button6.ForeColor = Color.Blue
            settings_en.Button8.ForeColor = Color.Blue
            settings_en.Button10.ForeColor = Color.Blue
            settings_en.Button11.ForeColor = Color.Blue
            settings_en.Button12.ForeColor = Color.Blue
            settings_en.Button9.ForeColor = Color.PowderBlue
            settings_en.Button7.ForeColor = Color.PowderBlue
            settings_en.Button9.BackColor = Color.Blue
            settings_en.Button7.BackColor = Color.Blue
            settings_uk.BackColor = Color.PowderBlue
            settings_uk.Label1.ForeColor = Color.Blue
            settings_uk.Label2.ForeColor = Color.Blue
            settings_uk.Label3.ForeColor = Color.Blue
            settings_uk.Label4.ForeColor = Color.Blue
            settings_uk.Label5.ForeColor = Color.Blue
            settings_uk.Label6.ForeColor = Color.Blue
            settings_uk.CheckBox1.ForeColor = Color.Blue
            settings_uk.CheckBox2.ForeColor = Color.Blue
            settings_uk.CheckBox3.ForeColor = Color.Blue
            settings_uk.Button6.ForeColor = Color.Blue
            settings_uk.Button8.ForeColor = Color.Blue
            settings_uk.Button10.ForeColor = Color.Blue
            settings_uk.Button11.ForeColor = Color.Blue
            settings_uk.Button12.ForeColor = Color.Blue
            settings_uk.Button9.ForeColor = Color.PowderBlue
            settings_uk.Button7.ForeColor = Color.PowderBlue
            settings_uk.Button9.BackColor = Color.Blue
            settings_uk.Button7.BackColor = Color.Blue
        ElseIf o = "4" Then
            settings_ru.BackColor = Color.BlanchedAlmond
            settings_ru.Label1.ForeColor = Color.Sienna
            settings_ru.Label2.ForeColor = Color.Sienna
            settings_ru.Label3.ForeColor = Color.Sienna
            settings_ru.Label4.ForeColor = Color.Sienna
            settings_ru.Label5.ForeColor = Color.Sienna
            settings_ru.Label6.ForeColor = Color.Sienna
            settings_ru.CheckBox1.ForeColor = Color.Sienna
            settings_ru.CheckBox2.ForeColor = Color.Sienna
            settings_ru.CheckBox3.ForeColor = Color.Sienna
            settings_ru.Button6.ForeColor = Color.Sienna
            settings_ru.Button8.ForeColor = Color.Sienna
            settings_ru.Button10.ForeColor = Color.Sienna
            settings_ru.Button11.ForeColor = Color.Sienna
            settings_ru.Button12.ForeColor = Color.Sienna
            settings_ru.Button9.ForeColor = Color.BlanchedAlmond
            settings_ru.Button7.ForeColor = Color.BlanchedAlmond
            settings_ru.Button9.BackColor = Color.Sienna
            settings_ru.Button7.BackColor = Color.Sienna
            settings_uk.BackColor = Color.BlanchedAlmond
            settings_uk.Label1.ForeColor = Color.Sienna
            settings_uk.Label2.ForeColor = Color.Sienna
            settings_uk.Label3.ForeColor = Color.Sienna
            settings_uk.Label4.ForeColor = Color.Sienna
            settings_uk.Label5.ForeColor = Color.Sienna
            settings_uk.Label6.ForeColor = Color.Sienna
            settings_uk.CheckBox1.ForeColor = Color.Sienna
            settings_uk.CheckBox2.ForeColor = Color.Sienna
            settings_uk.CheckBox3.ForeColor = Color.Sienna
            settings_uk.Button6.ForeColor = Color.Sienna
            settings_uk.Button8.ForeColor = Color.Sienna
            settings_uk.Button10.ForeColor = Color.Sienna
            settings_uk.Button11.ForeColor = Color.Sienna
            settings_uk.Button12.ForeColor = Color.Sienna
            settings_uk.Button9.ForeColor = Color.BlanchedAlmond
            settings_uk.Button7.ForeColor = Color.BlanchedAlmond
            settings_uk.Button9.BackColor = Color.Sienna
            settings_uk.Button7.BackColor = Color.Sienna
            settings_en.BackColor = Color.BlanchedAlmond
            settings_en.Label1.ForeColor = Color.Sienna
            settings_en.Label2.ForeColor = Color.Sienna
            settings_en.Label3.ForeColor = Color.Sienna
            settings_en.Label4.ForeColor = Color.Sienna
            settings_en.Label5.ForeColor = Color.Sienna
            settings_en.Label6.ForeColor = Color.Sienna
            settings_en.CheckBox1.ForeColor = Color.Sienna
            settings_en.CheckBox2.ForeColor = Color.Sienna
            settings_en.CheckBox3.ForeColor = Color.Sienna
            settings_en.Button6.ForeColor = Color.Sienna
            settings_en.Button8.ForeColor = Color.Sienna
            settings_en.Button10.ForeColor = Color.Sienna
            settings_en.Button11.ForeColor = Color.Sienna
            settings_en.Button12.ForeColor = Color.Sienna
            settings_en.Button9.ForeColor = Color.BlanchedAlmond
            settings_en.Button7.ForeColor = Color.BlanchedAlmond
            settings_en.Button9.BackColor = Color.Sienna
            settings_en.Button7.BackColor = Color.Sienna
            settings_hy.BackColor = Color.BlanchedAlmond
            settings_hy.Label1.ForeColor = Color.Sienna
            settings_hy.Label2.ForeColor = Color.Sienna
            settings_hy.Label3.ForeColor = Color.Sienna
            settings_hy.Label4.ForeColor = Color.Sienna
            settings_hy.Label5.ForeColor = Color.Sienna
            settings_hy.Label6.ForeColor = Color.Sienna
            settings_hy.CheckBox1.ForeColor = Color.Sienna
            settings_hy.CheckBox2.ForeColor = Color.Sienna
            settings_hy.CheckBox3.ForeColor = Color.Sienna
            settings_hy.Button6.ForeColor = Color.Sienna
            settings_hy.Button8.ForeColor = Color.Sienna
            settings_hy.Button10.ForeColor = Color.Sienna
            settings_hy.Button11.ForeColor = Color.Sienna
            settings_hy.Button12.ForeColor = Color.Sienna
            settings_hy.Button9.ForeColor = Color.BlanchedAlmond
            settings_hy.Button7.ForeColor = Color.BlanchedAlmond
            settings_hy.Button9.BackColor = Color.Sienna
            settings_hy.Button7.BackColor = Color.Sienna
        ElseIf o = "5" Then
            settings_ru.BackColor = Color.DarkRed
            settings_ru.Label1.ForeColor = Color.Lime
            settings_ru.Label2.ForeColor = Color.Lime
            settings_ru.Label3.ForeColor = Color.Lime
            settings_ru.Label4.ForeColor = Color.Lime
            settings_ru.Label5.ForeColor = Color.Lime
            settings_ru.Label6.ForeColor = Color.Lime
            settings_ru.CheckBox1.ForeColor = Color.Lime
            settings_ru.CheckBox2.ForeColor = Color.Lime
            settings_ru.CheckBox3.ForeColor = Color.Lime
            settings_ru.Button6.ForeColor = Color.Lime
            settings_ru.Button8.ForeColor = Color.Lime
            settings_ru.Button10.ForeColor = Color.Lime
            settings_ru.Button11.ForeColor = Color.Lime
            settings_ru.Button12.ForeColor = Color.Lime
            settings_ru.Button9.ForeColor = Color.DarkRed
            settings_ru.Button7.ForeColor = Color.DarkRed
            settings_ru.Button9.BackColor = Color.Lime
            settings_ru.Button7.BackColor = Color.Lime
            settings_hy.BackColor = Color.DarkRed
            settings_hy.Label1.ForeColor = Color.Lime
            settings_hy.Label2.ForeColor = Color.Lime
            settings_hy.Label3.ForeColor = Color.Lime
            settings_hy.Label4.ForeColor = Color.Lime
            settings_hy.Label5.ForeColor = Color.Lime
            settings_hy.Label6.ForeColor = Color.Lime
            settings_hy.CheckBox1.ForeColor = Color.Lime
            settings_hy.CheckBox2.ForeColor = Color.Lime
            settings_hy.CheckBox3.ForeColor = Color.Lime
            settings_hy.Button6.ForeColor = Color.Lime
            settings_hy.Button8.ForeColor = Color.Lime
            settings_hy.Button10.ForeColor = Color.Lime
            settings_hy.Button11.ForeColor = Color.Lime
            settings_hy.Button12.ForeColor = Color.Lime
            settings_hy.Button9.ForeColor = Color.DarkRed
            settings_hy.Button7.ForeColor = Color.DarkRed
            settings_hy.Button9.BackColor = Color.Lime
            settings_hy.Button7.BackColor = Color.Lime
            settings_en.BackColor = Color.DarkRed
            settings_en.Label1.ForeColor = Color.Lime
            settings_en.Label2.ForeColor = Color.Lime
            settings_en.Label3.ForeColor = Color.Lime
            settings_en.Label4.ForeColor = Color.Lime
            settings_en.Label5.ForeColor = Color.Lime
            settings_en.Label6.ForeColor = Color.Lime
            settings_en.CheckBox1.ForeColor = Color.Lime
            settings_en.CheckBox2.ForeColor = Color.Lime
            settings_en.CheckBox3.ForeColor = Color.Lime
            settings_en.Button6.ForeColor = Color.Lime
            settings_en.Button8.ForeColor = Color.Lime
            settings_en.Button10.ForeColor = Color.Lime
            settings_en.Button11.ForeColor = Color.Lime
            settings_en.Button12.ForeColor = Color.Lime
            settings_en.Button9.ForeColor = Color.DarkRed
            settings_en.Button7.ForeColor = Color.DarkRed
            settings_en.Button9.BackColor = Color.Lime
            settings_en.Button7.BackColor = Color.Lime
            settings_uk.BackColor = Color.DarkRed
            settings_uk.Label1.ForeColor = Color.Lime
            settings_uk.Label2.ForeColor = Color.Lime
            settings_uk.Label3.ForeColor = Color.Lime
            settings_uk.Label4.ForeColor = Color.Lime
            settings_uk.Label5.ForeColor = Color.Lime
            settings_uk.Label6.ForeColor = Color.Lime
            settings_uk.CheckBox1.ForeColor = Color.Lime
            settings_uk.CheckBox2.ForeColor = Color.Lime
            settings_uk.CheckBox3.ForeColor = Color.Lime
            settings_uk.Button6.ForeColor = Color.Lime
            settings_uk.Button8.ForeColor = Color.Lime
            settings_uk.Button10.ForeColor = Color.Lime
            settings_uk.Button11.ForeColor = Color.Lime
            settings_uk.Button12.ForeColor = Color.Lime
            settings_uk.Button9.ForeColor = Color.DarkRed
            settings_uk.Button7.ForeColor = Color.DarkRed
            settings_uk.Button9.BackColor = Color.Lime
            settings_uk.Button7.BackColor = Color.Lime
        End If
        settings_ru.Refresh()
        settings_en.Refresh()
        settings_uk.Refresh()
        settings_hy.Refresh()
    End Sub ' Թեմայի կարգավորում
    Public Sub start_load()
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
        myConnection.Close()
        If o = "1" Then
            start_ru.BackColor = Color.White
            start_ru.Label1.ForeColor = Color.Teal
            start_ru.Button1.ForeColor = Color.Teal
            start_en.BackColor = Color.White
            start_en.Label1.ForeColor = Color.Teal
            start_en.Button1.ForeColor = Color.Teal
            start_uk.BackColor = Color.White
            start_uk.Label1.ForeColor = Color.Teal
            start_uk.Button1.ForeColor = Color.Teal
            start_hy.BackColor = Color.White
            start_hy.Label1.ForeColor = Color.Teal
            start_hy.Button1.ForeColor = Color.Teal
        ElseIf o = "2" Then
            Me.BackColor = Color.White
            start_ru.Label1.ForeColor = Color.Black
            start_ru.Button1.ForeColor = Color.Black
            start_en.Label1.ForeColor = Color.Black
            start_en.Button1.ForeColor = Color.Black
            start_uk.Label1.ForeColor = Color.Black
            start_uk.Button1.ForeColor = Color.Black
            start_hy.Label1.ForeColor = Color.Black
            start_hy.Button1.ForeColor = Color.Black
        ElseIf o = "3" Then
            start_ru.BackColor = Color.PowderBlue
            start_ru.Label1.ForeColor = Color.Blue
            start_ru.Button1.ForeColor = Color.Blue
            start_en.BackColor = Color.PowderBlue
            start_en.Label1.ForeColor = Color.Blue
            start_en.Button1.ForeColor = Color.Blue
            start_uk.BackColor = Color.PowderBlue
            start_uk.Label1.ForeColor = Color.Blue
            start_uk.Button1.ForeColor = Color.Blue
            start_hy.BackColor = Color.PowderBlue
            start_hy.Label1.ForeColor = Color.Blue
            start_hy.Button1.ForeColor = Color.Blue
        ElseIf o = "4" Then
            start_ru.BackColor = Color.BlanchedAlmond
            start_ru.Label1.ForeColor = Color.Sienna
            start_ru.Button1.ForeColor = Color.Sienna
            start_hy.BackColor = Color.BlanchedAlmond
            start_hy.Label1.ForeColor = Color.Sienna
            start_hy.Button1.ForeColor = Color.Sienna
            start_uk.BackColor = Color.BlanchedAlmond
            start_uk.Label1.ForeColor = Color.Sienna
            start_uk.Button1.ForeColor = Color.Sienna
            start_en.BackColor = Color.BlanchedAlmond
            start_en.Label1.ForeColor = Color.Sienna
            start_en.Button1.ForeColor = Color.Sienna
        ElseIf o = "5" Then
            start_ru.BackColor = Color.DarkRed
            start_ru.Label1.ForeColor = Color.Lime
            start_ru.Button1.ForeColor = Color.Lime
            start_en.BackColor = Color.DarkRed
            start_en.Label1.ForeColor = Color.Lime
            start_en.Button1.ForeColor = Color.Lime
            start_uk.BackColor = Color.DarkRed
            start_uk.Label1.ForeColor = Color.Lime
            start_uk.Button1.ForeColor = Color.Lime
            start_hy.BackColor = Color.DarkRed
            start_hy.Label1.ForeColor = Color.Lime
            start_hy.Button1.ForeColor = Color.Lime
        End If
    End Sub  ' Գունային համադրության ընտրում
    Public Sub apikeysdownload()
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
        str = "SELECT * FROM settings WHERE (name = '" & "server" & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim ezo As String = ""
        Dim server As String = ""
        While dr.Read()
            server = dr("value").ToString
        End While
        Dim sitelink As String = server & "api/system/wolfram_alpha.php"
        ezo = Me.Makequery(sitelink)
        Dim wherename As String = "wolfram_alpha"
        Try
            str = "DELETE * FROM api_keys WHERE (name = '" & wherename & " ')"
            cmd = New OleDbCommand(str, myConnection)
            dr = cmd.ExecuteReader
            str = "INSERT INTO [api_keys]([name] , [value]) VALUES('" & wherename & "', '" & ezo & "')"
            cmd = New OleDbCommand(str, myConnection)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        sitelink = server & "api/system/ya_speechkit.php"
        ezo = Me.Makequery(sitelink)
        wherename = "ya_speechkit"
        Try
            str = "DELETE * FROM api_keys WHERE (name = '" & wherename & " ')"
            cmd = New OleDbCommand(str, myConnection)
            dr = cmd.ExecuteReader
            str = "INSERT INTO [api_keys]([name] , [value]) VALUES('" & wherename & "', '" & ezo & "')"
            cmd = New OleDbCommand(str, myConnection)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        sitelink = server & "api/system/ya_translate.php"
        ezo = Me.Makequery(sitelink)
        wherename = "ya_translate"
        Try
            str = "DELETE * FROM api_keys WHERE (name = '" & wherename & " ')"
            cmd = New OleDbCommand(str, myConnection)
            dr = cmd.ExecuteReader
            str = "INSERT INTO [api_keys]([name] , [value]) VALUES('" & wherename & "', '" & ezo & "')"
            cmd = New OleDbCommand(str, myConnection)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

    End Sub



    Public Function getserver()
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
        str = "SELECT * FROM settings WHERE (name = '" & "server" & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim server As String = ""
        While dr.Read()
            server = dr("value").ToString
        End While
        myConnection.Close()
        Return server
    End Function
    Public Function get_translate_key()
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
        str = "SELECT * FROM api_keys WHERE (name = '" & "ya_translate" & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim server As String = ""
        While dr.Read()
            server = dr("value").ToString
        End While
        myConnection.Close()
        server = "https://translate.yandex.net/api/v1.5/tr/detect?key=" & server & "&text="
        Return server
    End Function
    Public Function get_speechkit_key()
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
        str = "SELECT * FROM api_keys WHERE (name = '" & "ya_speechkit" & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim server As String = ""
        While dr.Read()
            server = dr("value").ToString
        End While
        myConnection.Close()
        server = "https://tts.voicetech.yandex.net/generate?key=" & server & "&emotion=good&text="
        Return server
    End Function
    Public Function getwolframkey()
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
        str = "SELECT * FROM api_keys WHERE (name = '" & "wolfram_alpha" & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim server As String = ""
        While dr.Read()
            server = dr("value").ToString
        End While
        myConnection.Close()
        server = "http://api.wolframalpha.com/v1/result?appid=" & server & "&i="
        Return server
    End Function

    Public Function gettranslationkey()
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
        str = "SELECT * FROM api_keys WHERE (name = '" & "ya_translate" & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim server As String = ""
        While dr.Read()
            server = dr("value").ToString
        End While
        myConnection.Close()
        server = "https://translate.yandex.net/api/v1.5/tr/translate?key=" & server & "&lang=en&text="




        Return server
    End Function


    Public Function trans_key()
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
        str = "SELECT * FROM api_keys WHERE (name = '" & "ya_translate" & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim server As String = ""
        While dr.Read()
            server = dr("value").ToString
        End While
        Return server
    End Function


    Public Function speech_key()
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
        str = "SELECT * FROM api_keys WHERE (name = '" & "ya_speechkit" & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim server As String = ""
        While dr.Read()
            server = dr("value").ToString
        End While
        Return server
    End Function




End Class