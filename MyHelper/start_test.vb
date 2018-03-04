Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.GC
Public Class start_test
    Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal process As IntPtr, ByVal minimumWorkingSetSize As Integer, ByVal maximumWorkingSetSize As Integer) As Integer
    Public Sub FlushMemory()
        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()
            If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
                Dim myProcesses As Process() = Process.GetProcessesByName("MyhHelper")
                Dim myProcess As Process
                'Dim ProcessInfo As Process
                For Each myProcess In myProcesses
                    SetProcessWorkingSetSize(myProcess.Handle, -1, -1)
                Next myProcess
            End If
        Catch ex As Exception
        End Try
    End Sub
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim dr As OleDbDataReader
    Private Sub start_test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    End Sub
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
        Call FlushMemory()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MsgBox("ANJATEL KOMP@")
        'System.Diagnostics.Process.Start("shutdown", "-l")
        ''Timer1.Stop()
        Call FlushMemory()
    End Sub








End Class