Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class menu_ru
    Private connectionString As String
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Call start_test.callcalc()
    End Sub '' Հաշվիչի միացում
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Call start_test.calllupa()
    End Sub  ' Խոշորացույցի միացում
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Call start_test.callnotes()
    End Sub  '' Նոթատերտրի միացում
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Call start_test.callkeyboard()
    End Sub  ' Էկրանային ստեղնաշարի միացում
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
        start_test.callto(ezo)
    End Sub  ' Զանգել մոդերատորին
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        read_ru.Show()
        Me.Close()
    End Sub  ' Կարդալ տեքստ
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ask_ru.Show()
        Me.Close()
    End Sub  ' Հարցնել
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        call_ru.Show()
        Me.Close()
    End Sub  ' Զանգել
    Private Sub menu_ru_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        start_test.menuload()
    End Sub  ' Անհրաժեշտ թեմաների, գործիքների ընտրում
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        settings_ru.Show()
        Me.Hide()
    End Sub   ' Կարգավորումներ
End Class