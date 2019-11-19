
Imports System.IO.Compression
Imports System.Net

Public Class DownloadMIUIFastboot

    Private WithEvents WClient As New WebClient
    Private DlStage As Integer
    Private FileName As String = "lavender_global_images_V10.3.10.0.PFGMIXM_20190816.0000.00_9.0_global_8cf943bb70.tgz"
    Private LastCount As Integer = 0

    Private Sub DownloadMIUIFastboot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        If (Not System.IO.Directory.Exists("C:\adb\.settings\xiaomiglobalfastboot")) Then
            System.IO.Directory.CreateDirectory("C:\adb\.settings\xiaomiglobalfastboot")
        End If

        Try
            If My.Computer.Network.Ping("www.google.com") Then
                TextBox1.Text = "Starting download... Please wait"
                WClient.DownloadFileAsync(New Uri("http://bigota.d.miui.com/V10.3.10.0.PFGMIXM/lavender_global_images_V10.3.10.0.PFGMIXM_20190816.0000.00_9.0_global_8cf943bb70.tgz"), "C:\adb\.settings\xiaomiglobalfastboot\lavender_global_images_V10.3.10.0.PFGMIXM_20190816.0000.00_9.0_global_8cf943bb70.tgz")
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
        infoReader = My.Computer.FileSystem.GetFileInfo("C:\adb\.settings\xiaomiglobalfastboot\lavender_global_images_V10.3.10.0.PFGMIXM_20190816.0000.00_9.0_global_8cf943bb70.tgz")

        If infoReader.Length < 3006477107.2 Then
            MsgBox("File is corrupted \: , downloading again!", MessageBoxIcon.Warning)
            Dim miuiglobal = New DownloadMIUI()
            miuiglobal.Show()
            MyBase.Dispose(Disposing)
        Else
            Dim zipPath As String = "C:\adb\.settings\xiaomiglobalfastboot\lavender_global_images_V10.3.10.0.PFGMIXM_20190816.0000.00_9.0_global_8cf943bb70.tgz"
            Dim extractPath As String = "C:\adb\.settings\xiaomiglobalfastboot"

            ZipFile.ExtractToDirectory(zipPath, extractPath)

            Dim FileToDelete As String

            FileToDelete = "C:\adb\.settings\xiaomiglobalfastboot\lavender_global_images_V10.3.10.0.PFGMIXM_20190816.0000.00_9.0_global_8cf943bb70.tgz"

            If System.IO.File.Exists(FileToDelete) = True Then

                System.IO.File.Delete(FileToDelete)

            End If

            FileIO.FileSystem.RenameDirectory("C:\adb\.settings\xiaomiglobalfastboot\lavender_global_images_V10.3.10.0.PFGMIXM_20190816.0000.00_9.0_global_8cf943bb70", "MI")

            Dim Proc As String = "Explorer.exe"
            Dim Args As String =
            ControlChars.Quote &
            IO.Path.Combine("C:\", "adb\.settings\xiaomiglobalfastboot") &
            ControlChars.Quote
            Process.Start(Proc, Args)

            visual.Show()
            MyBase.Dispose(Disposing)
        End If

    End Sub

    Private Sub DownloadMIUIFastboot_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

        System.Windows.Forms.Application.Restart()

    End Sub

End Class