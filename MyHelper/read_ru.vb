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
    Function callto(ByVal calla As String)
        Process.Start("skype:" & calla & "?call")
    End Function
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
    Function getxmlattrvalue(ByVal query, ByVal attribute)
        Try
            Dim doc As XmlDocument = New XmlDocument()
            Dim xmlvalue As String
            xmlvalue = Makequery(query)
            doc.LoadXml(xmlvalue)
            Dim root As XmlElement = doc.DocumentElement
            Dim lang As String
            If (root.HasAttribute(attribute)) Then
                lang = root.GetAttribute(attribute)
            Else
                lang = "There is not found attribute"
            End If
            getxmlattrvalue = lang
        Catch ex As Exception

        End Try

    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim user_text As String, text_user As String
        user_text = TextBox1.Text
        Dim textforchecklang As String
        If user_text.Length > 200 Then
            textforchecklang = user_text.Substring(20)
        Else : textforchecklang = user_text
        End If
        textforchecklang = "https://translate.yandex.net/api/v1.5/tr/detect?key=trnsl.1.1.20171215T141314Z.7e2b64cbfaa80409.452ed95d1799a5cc4054fb5ecf82a422669c1a09&text=" & textforchecklang
        If getxmlattrvalue(textforchecklang, "code") <> 200 Then
            MsgBox("Error . API key was wrong or disactivated by yandex")
        Else
            Dim language As String
            language = getxmlattrvalue(textforchecklang, "lang")
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
                user_text = Makequery("http://iwebing.96.lt/api/world-it-planet-url-encode.php?a=" & user_text)
                text_user = "https://tts.voicetech.yandex.net/generate?key=c6a0ef6d-8f9e-4379-9001-408fee63f93c&emotion=good&text=" & user_text & "&lang=" & language 'user_text     479c36c0-5034-48a3-b837-0f57b54e44a6
                'TextBox1.Text = text_user
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




















    End Sub



    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

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

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        menu_ru.Show()
        Me.Close()
    End Sub

    Private Sub read_ru_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        PictureBox1.Visible = False
        If q = "true" Then
            PictureBox1.Visible = True
        End If
    End Sub
End Class