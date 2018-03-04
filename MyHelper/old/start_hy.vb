Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class start_ru
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        menu_ru.Show()
        Me.Hide()
    End Sub ' Գլխավոր մենյուի ընտրում
    Private Sub start_ru_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        start_test.start_load()
        Timer1.Start()
        Timer2.Start()
        Timer3.Start()
        Timer4.Start()
    End Sub '' Ֆոռմի միացում՝ անհրաժեշտ պրոցեդուրաների կանչում
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
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
            wherename = "alarm1"
            str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            dr = cmd.ExecuteReader
            While dr.Read()
                str = dr("value").ToString
            End While
            Dim d = Now.ToShortTimeString
            If d = str Then
                alarm_ru.Show()
                Timer1.Stop()
            End If
            myConnection.Close()
        Catch ex As Exception
        End Try
    End Sub   '' Առաջին դեղերի ժամի մասին հիշեցում
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
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
            wherename = "alarm2"
            str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            dr = cmd.ExecuteReader
            While dr.Read()
                str = dr("value").ToString
            End While
            Dim d = Now.ToShortTimeString
            If d = str Then
                alarm_ru.Show()
                Timer2.Stop()
            End If
        Catch ex As Exception
        End Try
    End Sub  '' Երկրորդ դեղերի ժամի  մասին հիշեցում
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Try
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
            wherename = "alarm3"
            str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            dr = cmd.ExecuteReader
            While dr.Read()
                str = dr("value").ToString
            End While
            myConnection.Close()
            Dim d = Now.ToShortTimeString
            If d = str Then
                alarm_ru.Show()
                Timer3.Stop()
            End If
        Catch ex As Exception
        End Try
    End Sub  '' Երրորդ դեղերի ժամի մասին հիշեցում
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Try
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
            wherename = "alarm4"
            str = "SELECT * FROM settings WHERE (name = '" & wherename & " ')"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            dr = cmd.ExecuteReader
            While dr.Read()
                str = dr("value").ToString
            End While
            myConnection.Close()
            Dim d = Now.ToShortTimeString
            If d = str Then
                alarm_ru.Show()
                Timer4.Stop()
            End If
        Catch ex As Exception
        End Try
    End Sub  '' Չորրորդ դեղերի ժամի մասին հիշեցում
End Class