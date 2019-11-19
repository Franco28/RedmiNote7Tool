Imports System.IO.Compression
Imports System.Net

Public Class DownloadMIUnlock


    Private WithEvents WClient As New WebClient
    Private DlStage As Integer
    Private FileName As String = "miflash_unlock-en-3.5.1108.44.zip"
    Private LastCount As Integer = 0

    Private Sub DownloadMIUnlock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        Dim paths() As String = IO.Directory.GetFiles("C:\adb\MI", "*.zip")
        If paths.Length > 0 Then 'if at least one file is found do something
            Dim infoReader As System.IO.FileInfo
            infoReader = My.Computer.FileSystem.GetFileInfo("C:\adb\MI\MiFlash20181115.zip")

            If infoReader.Length > 48000000 Then

                Dim zipPath As String = "C:\adb\MIUnlock\miflash_unlock-en-3.5.1108.44.zip"
                Dim extractPath As String = "C:\adb\MIUnlock\"

                ZipFile.ExtractToDirectory(zipPath, extractPath)

                Dim FileToDelete As String

                FileToDelete = "C:\adb\MIUnlock\miflash_unlock-en-3.5.1108.44.zip"

                If System.IO.File.Exists(FileToDelete) = True Then

                    System.IO.File.Delete(FileToDelete)

                End If

                MsgBox("Mi MIUnlock installed in C:\adb\MIUlock", MessageBoxIcon.Information)

                Dim visual = New Visual()
                visual.Show()
                MyBase.Dispose(Disposing)

            Else

                Try
                    If My.Computer.Network.Ping("www.google.com") Then
                        MsgBox("File is corrupted \: , downloading again!", MessageBoxIcon.Warning)
                        TextBox1.Text = "Starting download... Please wait"
                        WClient.DownloadFileAsync(New Uri("https://bitbucket.org/Franco28/flashtool-motorola-moto-g5-g5plus/downloads/miflash_unlock-en-3.5.1108.44.zip"), "C:\adb\MIUnlock\miflash_unlock-en-3.5.1108.44.zip")
                    End If
                Catch ex As Exception
                    MsgBox("ERROR: Can´t connect to the server to download Mi Unlock!", MessageBoxIcon.Warning)
                    System.Windows.Forms.Application.Restart()
                End Try

            End If

        Else

            Try
                If My.Computer.Network.Ping("www.google.com") Then
                    TextBox1.Text = "Starting download... Please wait"
                    WClient.DownloadFileAsync(New Uri("https://bitbucket.org/Franco28/flashtool-motorola-moto-g5-g5plus/downloads/miflash_unlock-en-3.5.1108.44.zip"), "C:\adb\MIUnlock\miflash_unlock-en-3.5.1108.44.zip")
                End If
            Catch ex As Exception
                MsgBox("ERROR: Can´t connect to the server to download Mi Unlock!", MessageBoxIcon.Warning)
                System.Windows.Forms.Application.Restart()
            End Try

        End If

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

        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo("C:\adb\MIUnlock\miflash_unlock-en-3.5.1108.44.zip")

        If infoReader.Length < 48000000 Then

            MsgBox("File is corrupted \: , downloading again!", MessageBoxIcon.Warning)
            Dim miunlock = New DownloadMIUnlock()
            miunlock.Show()
            MyBase.Dispose(Disposing)

        Else

            Dim zipPath As String = "C:\adb\MIUnlock\miflash_unlock-en-3.5.1108.44.zip"
            Dim extractPath As String = "C:\adb\MIUnlock\"

            ZipFile.ExtractToDirectory(zipPath, extractPath)

            Dim FileToDelete As String

            FileToDelete = "C:\adb\MIUnlock\miflash_unlock-en-3.5.1108.44.zip"

            If System.IO.File.Exists(FileToDelete) = True Then

                System.IO.File.Delete(FileToDelete)

            End If

            MsgBox("Mi Flash installed in C:\adb\MIUnlock\", MessageBoxIcon.Information)

            Dim visual = New Visual()
            visual.Show()
            MyBase.Dispose(Disposing)

        End If

    End Sub

    Private Sub DownloadMIUnlock_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

        System.Windows.Forms.Application.Restart()

    End Sub

End Class