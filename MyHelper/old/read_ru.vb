Imports System
Imports System.Net
Imports System.Xml
Imports System.Text
Imports System.String
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Public Class read_ru
    Private connectionString As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim user_text As String, text_user As String
        user_text = TextBox1.Text
        Dim textforchecklang As String
        If user_text.Length > 200 Then
            textforchecklang = user_text.Substring(20)
        Else : textforchecklang = user_text
        End If
        textforchecklang = "https://translate.yandex.net/api/v1.5/tr/detect?key=trnsl.1.1.20171215T141314Z.7e2b64cbfaa80409.452ed95d1799a5cc4054fb5ecf82a422669c1a09&text=" & textforchecklang
        If start_test.getxmlattrvalue(textforchecklang, "code") <> 200 Then
            MsgBox("Error : No internet connection , server disabled. If you think it is wrong, contact to MyHelper's support")
        Else
            Dim language As String
            language = start_test.getxmlattrvalue(textforchecklang, "lang")
            If language <> "en" And language <> "ru" And language <> "uk" Then
                MsgBox("Извените, , система работает только русский, английский, украинский языки")
            Else
                If language = "en" Then
                    language = "en-US"
                End If
                If language = "ru" Then
                    language = "ru-RU"
                End If
                If language = "uk" Then
                    language = "uk-UK"
                End If
                user_text = start_test.Makequery("http://iwebing.96.lt/api/world-it-planet-url-encode.php?a=" & user_text)
                text_user = "https://tts.voicetech.yandex.net/generate?key=c6a0ef6d-8f9e-4379-9001-408fee63f93c&emotion=good&text=" & user_text & "&lang=" & language 'user_text     479c36c0-5034-48a3-b837-0f57b54e44a6
                AxWindowsMediaPlayer1.URL = text_user
            End If
        End If
        Dim a As String = TextBox1.Text & " " & " "
        For i = 0 To a.Length - 1
            Dim c As String = a.Substring(i, 1)
            Dim myFilePath As String = ("rus\" & c & ".gif")
            If c = " " Then
                PictureBox1.ImageLocation = ("rus\s.png")
                Threading.Thread.Sleep(500)
            End If
            If File.Exists(myFilePath) Then
                PictureBox1.ImageLocation = ("rus\" & c & ".gif")
                Threading.Thread.Sleep(500)
            Else
                Dim g As Graphics = PictureBox1.CreateGraphics()
                PictureBox1.Image = Nothing
                g.DrawString(c, New Font("Arial", 100), Brushes.Black, 30, 30)
                Threading.Thread.Sleep(500)
            End If
            Application.DoEvents()
        Next
    End Sub   '' Կատարվում է հարցումը և պատասխանի ստացումը
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)
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
        str = "SELECT * FROM moderator_data WHERE (name = '" & "tel" & " ')"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        dr = cmd.ExecuteReader
        Dim ezo As String
        While dr.Read()
            ezo = dr("value").ToString
        End While
        start_test.callto(ezo)
    End Sub '' Զանգել օգնողին
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        menu_ru.Show()
        Me.Close()
    End Sub '' Վերադարձ դեպի մենյու
    Private Sub read_ru_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call start_test.readload()
    End Sub  '' Գույների, անհրաժեշտ գործիքների ընտրում
End Class