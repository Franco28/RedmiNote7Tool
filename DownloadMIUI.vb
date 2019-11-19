
Imports System.Net

Public Class DownloadMIUI

    Private WithEvents WClient As New WebClient
    Private DlStage As Integer
    Private FileName As String = "miui_LAVENDERGlobal_V10.3.10.0.PFGMIXM_730eb0aa6e_9.0.zip"
    Private LastCount As Integer = 0

    Private Sub DownloadMIUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        If (Not System.IO.Directory.Exists("C:\adb\.settings\xiaomiglobal")) Then
            System.IO.Directory.CreateDirectory("C:\adb\.settings\xiaomiglobal")
        End If

        Try
            If My.Computer.Network.Ping("www.google.com") Then
                TextBox1.Text = "Starting download... Please wait"
                WClient.DownloadFileAsync(New Uri("http://bigota.d.miui.com/V10.3.10.0.PFGMIXM/miui_LAVENDERGlobal_V10.3.10.0.PFGMIXM_730eb0aa6e_9.0.zip"), "C:\adb\.settings\xiaomiglobal\miui_LAVENDERGlobal_V10.3.10.0.PFGMIXM_730eb0aa6e_9.0.zip")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Can´t connect to the server to download MIUI Global!", MessageBoxIcon.Warning)
            System.Windows.Forms.Application.Restart()
        End Try

    End Sub

    Private Sub wClient_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WClient.DownloadProgressChanged

        ProgressBar1.Value = e.ProgressPercentage

        If e.ProgressPercentage > LastCount Then
            TextBox1.Text = FileName & "... " & LastCount.ToString & " % Completed"
            LastCount += 1
        End If

    End Sub

    Private Sub wClient_DownloadComplete(ByVal sender As Object, ByVal e As EventArgs) Handles WClient.DownloadFileCompleted

        TextBox1.Text = FileName & "... " & "100 % Complete"

        LastCount = 0

        Dim visual = New Visual()

        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo("C:\adb\.settings\xiaomiglobal\miui_LAVENDERGlobal_V10.3.10.0.PFGMIXM_730eb0aa6e_9.0.zip")

        If infoReader.Length < 1932735283.2 Then
            MsgBox("File is corrupted \: , downloading again!", MessageBoxIcon.Warning)
            Dim miuiglobal = New DownloadMIUI()
            miuiglobal.Show()
            MyBase.Dispose(Disposing)
        Else
            Dim Proc As String = "Explorer.exe"
            Dim Args As String =
            ControlChars.Quote &
            IO.Path.Combine("C:\", "adb\.settings\xiaomiglobal") &
            ControlChars.Quote
            Process.Start(Proc, Args)

            visual.Show()
            MyBase.Dispose(Disposing)
        End If

    End Sub

    Private Sub DownloadMIUI_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

        System.Windows.Forms.Application.Restart()

    End Sub

End Class