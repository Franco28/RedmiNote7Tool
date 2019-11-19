
'(C) 2019 Franco28
'Basic Tool for Redmi Note 7 .  

Imports System.IO

Public Class Visual

    Public Function GetDirectorySize(path As String) As Long
        Dim files() As String = Directory.GetFiles(path, "*", SearchOption.AllDirectories)
        Dim size As Long = 0
        For Each file As String In files
            Dim info As New FileInfo(file)
            size += info.Length
        Next
        size *= 0.00000095367432
        Return size
    End Function

    Public Function CPUShow()
        Dim cpu As PerformanceCounter

        cpu = New PerformanceCounter("Processor", "% Processor Time", "_Total")

        System.Threading.Thread.Sleep(1000)

        Label1.Text = "CPU Usage: " & cpu.NextValue() & " %"

        System.Threading.Thread.Sleep(1000)
    End Function


    Private Sub unlockbootloader_Click(sender As Object, e As EventArgs) Handles unlockbootloader.Click

        Dim paths() As String = IO.Directory.GetFiles("C:\adb\MIUnlock", "miflash_unlock.exe")
        If paths.Length > 0 Then 'if at least one file is found do something

            Try
                Dim proc As New System.Diagnostics.Process()
                proc = Process.Start("C:\adb\MIUnlock\miflash_unlock.exe", "")
            Catch
                MsgBox("Mi Unlock Closed...", CType(MessageBoxIcon.Warning, MsgBoxStyle))
            End Try

        Else
            MsgBox("Error on loading Mi Unlock, seems to be missing...", CType(MessageBoxIcon.Warning, MsgBoxStyle))
        End If

        If ("Chrome.exe" Is Nothing) Then
            BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://c.mi.com/thread-1857937-1-1.html")
        Else
            BrowserCheck.StartBrowser("Chrome.exe", "https://c.mi.com/thread-1857937-1-1.html")
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        If ("Chrome.exe" Is Nothing) Then
            BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://github.com/Franco28?tab=repositories")
        Else
            BrowserCheck.StartBrowser("Chrome.exe", "https://github.com/Franco28?tab=repositories")
        End If

    End Sub

    Private Sub AdbFastbootFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdbFastbootFolderToolStripMenuItem.Click
        Dim Proc As String = "Explorer.exe"
        Dim Args As String =
        ControlChars.Quote &
        IO.Path.Combine("C:\", "adb") &
        ControlChars.Quote
        Process.Start(Proc, Args)
    End Sub

    Private Sub MiFlashFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MiFlashFolderToolStripMenuItem.Click

        Try
            Dim Proc As String = "Explorer.exe"
            Dim Args As String =
            ControlChars.Quote &
            IO.Path.Combine("C:\", "adb\MI") &
            ControlChars.Quote
            Process.Start(Proc, Args)
        Catch
            MsgBox("Error in opening folder...", CType(MessageBoxIcon.Warning, MsgBoxStyle))
        End Try

    End Sub

    Private Sub MiUnlockFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MiUnlockFolderToolStripMenuItem.Click

        Try
            Dim Proc As String = "Explorer.exe"
            Dim Args As String =
            ControlChars.Quote &
            IO.Path.Combine("C:\", "adb\MIUnlock") &
            ControlChars.Quote
            Process.Start(Proc, Args)
        Catch
            MsgBox("Error in opening folder...", CType(MessageBoxIcon.Warning, MsgBoxStyle))
        End Try

    End Sub

    Private Sub OpenFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFolderXiaomiGlobalToolStripMenuItem.Click

        Dim Proc As String = "Explorer.exe"
        Dim Args As String =
        ControlChars.Quote &
        IO.Path.Combine("C:\", "adb\.settings\xiaomiglobal") &
        ControlChars.Quote
        Process.Start(Proc, Args)

    End Sub

    Private Sub DownloadLatestMIUIByXiaomieuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadLatestMIUIByXiaomieuToolStripMenuItem.Click

        Dim result = MessageBox.Show("Do you want to download Xiaomi eu ROM?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then

            'Do nothing :)

        ElseIf result = DialogResult.Yes Then

            Dim paths() As String = IO.Directory.GetFiles("C:\adb\.settings\xiaomieu\", "*.zip")
            If paths.Length > 0 Then 'if at least one file is found do something

                Dim infoReader As System.IO.FileInfo
                infoReader = My.Computer.FileSystem.GetFileInfo("C:\adb\.settings\xiaomieu\xiaomi.eu_multi_MI8LITE_9.11.14_v11-9.zip")

                If infoReader.Length < 1610612736 Then
                    MsgBox("File is corrupted \: , downloading again!", CType(MessageBoxIcon.Warning, MsgBoxStyle))
                    Dim miuieudownload = New DownloadMIUIeu()
                    miuieudownload.Show()
                Else
                    Dim Proc As String = "Explorer.exe"
                    Dim Args As String =
                    ControlChars.Quote &
                    IO.Path.Combine("C:\", "adb\.settings\xiaomieu") &
                    ControlChars.Quote
                    Process.Start(Proc, Args)
                End If
            Else

                Try
                    If My.Computer.Network.Ping("www.google.com") Then
                        Dim miuieudownload = New DownloadMIUIeu()
                        miuieudownload.Show()
                    End If
                Catch ex As Exception
                    MsgBox("ERROR: Can´t connect to the server to download MIUI by Xiaomi.eu!", CType(MessageBoxIcon.Warning, MsgBoxStyle))
                    System.Windows.Forms.Application.Restart()
                End Try

            End If

        End If

    End Sub

    Private Sub DownloadMiFlash2018ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadMiFlash2018ToolStripMenuItem.Click

        Try
            If My.Computer.Network.Ping("www.google.com") Then
                Dim miflash = New DownloadMIFlash()
                miflash.Show()
            End If
        Catch ex As Exception
            MsgBox("ERROR: Can´t connect to the server to download Mi Flash!", CType(MessageBoxIcon.Warning, MsgBoxStyle))
            System.Windows.Forms.Application.Restart()
        End Try

    End Sub

    Private Sub DownloadMiUnlockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadMiUnlockToolStripMenuItem.Click

        Try
            If My.Computer.Network.Ping("www.google.com") Then
                Dim miunlock = New DownloadMIUnlock()
                miunlock.Show()
            End If
        Catch ex As Exception
            MsgBox("ERROR: Can´t connect to the server to download Mi Unlock!", CType(MessageBoxIcon.Warning, MsgBoxStyle))
            System.Windows.Forms.Application.Restart()
        End Try

    End Sub

    Private Sub XiaomieuPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XiaomieuPageToolStripMenuItem.Click

        If ("Chrome.exe" Is Nothing) Then
            BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://xiaomi.eu/community")
        Else
            BrowserCheck.StartBrowser("Chrome.exe", "https://xiaomi.eu/community")
        End If

    End Sub

    Private Sub XiaomiGlobalPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XiaomiGlobalPageToolStripMenuItem.Click

        If ("Chrome.exe" Is Nothing) Then
            BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://c.mi.com/index.php")
        Else
            BrowserCheck.StartBrowser("Chrome.exe", "https://c.mi.com/index.php")
        End If

    End Sub

    Private Sub ToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        Dim Proc As String = "Explorer.exe"
        Dim Args As String =
        ControlChars.Quote &
        IO.Path.Combine("C:\", "adb\.settings\xiaomiglobalfastboot") &
        ControlChars.Quote
        Process.Start(Proc, Args)

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        If ("Chrome.exe" Is Nothing) Then
            BrowserCheck.StartBrowser("MicrosoftEdge.exe", "https://c.mi.com/global/forum-1932-1.html")
        Else
            BrowserCheck.StartBrowser("Chrome.exe", "https://c.mi.com/global/forum-1932-1.html")
        End If

    End Sub

    Private Sub DownloadLatestMIUIFastbootImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadLatestMIUIFastbootImageToolStripMenuItem.Click

        Dim result = MessageBox.Show("Do you want to download Global Fastboot MIUI Firmware?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then

            'Do nothing :)

        ElseIf result = DialogResult.Yes Then

            Dim paths() As String = IO.Directory.GetFiles("C:\adb\.settings\xiaomiglobalfastboot\", "*.tgz")
            If paths.Length > 0 Then 'if at least one file is found do something

                Dim infoReader As System.IO.FileInfo
                infoReader = My.Computer.FileSystem.GetFileInfo("C:\adb\.settings\xiaomiglobalfastboot\lavender_global_images_V10.3.10.0.PFGMIXM_20190816.0000.00_9.0_global_8cf943bb70.tgz")

                If infoReader.Length < 3006477107.2 Then
                    MsgBox("File is corrupted \: , downloading again!", CType(MessageBoxIcon.Warning, MsgBoxStyle))
                    Dim miuiglobal = New DownloadMIUI()
                    miuiglobal.Show()
                Else
                    Dim Proc As String = "Explorer.exe"
                    Dim Args As String =
                    ControlChars.Quote &
                    IO.Path.Combine("C:\", "adb\.settings\xiaomiglobalfastboot") &
                    ControlChars.Quote
                    Process.Start(Proc, Args)
                End If
            Else

                Try
                    If My.Computer.Network.Ping("www.google.com") Then
                        Dim miuiglobaldownload = New DownloadMIUI()
                        miuiglobaldownload.Show()
                    End If
                Catch ex As Exception
                    MsgBox("ERROR: Can´t connect to the server to download MIUI Global Fastboot Firmware!", CType(MessageBoxIcon.Warning, MsgBoxStyle))
                    System.Windows.Forms.Application.Restart()
                End Try

            End If

        End If

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenFolderXiaomieuToolStripMenuItem.Click

        Dim Proc As String = "Explorer.exe"
        Dim Args As String =
        ControlChars.Quote &
        IO.Path.Combine("C:\", "adb\.settings\xiaomieu") &
        ControlChars.Quote
        Process.Start(Proc, Args)

    End Sub

    Private Sub DownloadLatestMIUIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadLatestMIUIToolStripMenuItem.Click

        Dim result = MessageBox.Show("Do you want to download Global MIUI Recovery ROM?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then

            'Do nothing :)

        ElseIf result = DialogResult.Yes Then

            Dim paths() As String = IO.Directory.GetFiles("C:\adb\.settings\xiaomiglobal\", "*.zip")
            If paths.Length > 0 Then 'if at least one file is found do something

                Dim infoReader As System.IO.FileInfo
                infoReader = My.Computer.FileSystem.GetFileInfo("C:\adb\.settings\xiaomiglobal\miui_LAVENDERGlobal_V10.3.10.0.PFGMIXM_730eb0aa6e_9.0.zip")

                If infoReader.Length < 1932735283.2 Then
                    MsgBox("File is corrupted \: , downloading again!", CType(MessageBoxIcon.Warning, MsgBoxStyle))
                    Dim miuiglobal = New DownloadMIUI()
                    miuiglobal.Show()
                Else
                    Dim Proc As String = "Explorer.exe"
                    Dim Args As String =
                    ControlChars.Quote &
                    IO.Path.Combine("C:\", "adb\.settings\xiaomiglobal") &
                    ControlChars.Quote
                    Process.Start(Proc, Args)
                End If
            Else

                Try
                    If My.Computer.Network.Ping("www.google.com") Then
                        Dim miuiglobaldownload = New DownloadMIUI()
                        miuiglobaldownload.Show()
                    End If
                Catch ex As Exception
                    MsgBox("ERROR: Can´t connect to the server to download MIUI Global!", CType(MessageBoxIcon.Warning, MsgBoxStyle))
                    System.Windows.Forms.Application.Restart()
                End Try

            End If

        End If

    End Sub

    Private Sub FlashFastbootGlobalFirmwareToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim result = MessageBox.Show("Do you want to Flash platina_global_images_V10.3.5.0.PDTMIXM_20190820.0000.00_9.0_global?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then

            'Do nothing :)

        ElseIf result = DialogResult.Yes Then

            If (Not System.IO.Directory.Exists("C:\adb\.settings\xiaomiglobalfastboot")) Then
                System.IO.Directory.CreateDirectory("C:\adb\.settings\xiaomiglobalfastboot")
            End If


            Dim paths() As String = IO.Directory.GetFiles("C:\adb\.settings\xiaomiglobalfastboot\", "*.tgz")
            If paths.Length > 0 Then 'if at least one file is found do something

                Dim infoReader As System.IO.FileInfo
                infoReader = My.Computer.FileSystem.GetFileInfo("C:\adb\.settings\xiaomiglobalfastboot\platina_global_images_V10.3.5.0.PDTMIXM_20190820.0000.00_9.0_global_d63472d18d.tgz")

                If infoReader.Length < 1825361100.8 Then
                    MsgBox("File is corrupted \: , downloading again!", CType(MessageBoxIcon.Warning, MsgBoxStyle))
                    Dim miuiglobalfastboot = New DownloadMIUIFastboot()
                    miuiglobalfastboot.Show()
                Else
                    Dim miuiglobalflash = New Flash()
                    miuiglobalflash.Show()
                End If
            Else

                Try
                    If My.Computer.Network.Ping("www.google.com") Then
                        Dim miuiglobalfastboot = New DownloadMIUIFastboot()
                        miuiglobalfastboot.Show()
                    End If
                Catch ex As Exception
                    MsgBox("ERROR: Can´t connect to the server to download MIUI Global!", CType(MessageBoxIcon.Warning, MsgBoxStyle))
                    System.Windows.Forms.Application.Restart()
                End Try

            End If

        End If

    End Sub

    Private Sub EnterEDLModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnterEDLModeToolStripMenuItem.Click

        Dim result = MessageBox.Show("Are you sure that you wan to enter to EDL mode? This can´t be undone!", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then

            If Shell("""C:\adb\fastboot_edl.exe""reboot-edl " & TextBox1.ToString, AppWinStyle.NormalFocus, True, 30000) = CInt(True) Then
                TextBox2.Text += "Folder: C:\adb "

                Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

                TextBox1.Text = "Please connect your device in fastboot mode... "

                Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

                TextBox1.Text = "Entering to EDL Mode..."

                Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

            Else
                MsgBox("EDL canceled...", CType(MessageBoxIcon.Warning, MsgBoxStyle))
            End If

        End If

    End Sub

    Private Sub boottwrp_Click(sender As Object, e As EventArgs) Handles boottwrp.Click

        Dim paths() As String = IO.Directory.GetFiles("C:\adb\.settings\TWRP", "*.img")
        If paths.Length > 0 Then 'if at least one file is found do something

            If Shell("""C:\adb\fastboot.exe"" boot recovery.img " & TextBox1.ToString, AppWinStyle.NormalFocus, True, 30000) = CInt(True) Then
                TextBox2.Text += "Folder: C:\adb\.settings\TWRP "

                Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

                TextBox1.Text = "Please connect your device in fastboot mode... "

                Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

                TextBox1.Text = "Booting TWRP OrangeFox..."

                Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

                MsgBox("Now if you want to keep all working on this Recovery flash this OrangeFox-R10.0_2-Stable-lavender, this will keep flashed this Recovery permanent!...", CType(MessageBoxIcon.Warning, MsgBoxStyle))

                Dim Proc As String = "Explorer.exe"
                Dim Args As String =
                ControlChars.Quote &
                IO.Path.Combine("C:\", "adb\.settings\TWRP") &
                ControlChars.Quote
                Process.Start(Proc, Args)

            Else
                MsgBox("Booting TWRP OrangeFox Canceled...", CType(MessageBoxIcon.Warning, MsgBoxStyle))
            End If

            Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

        Else

            Try
                If My.Computer.Network.Ping("www.google.com") Then
                    MsgBox("Can´t find TWRP OrangeFox image...", CType(MessageBoxIcon.Warning, MsgBoxStyle))
                    Dim twrpdownload = New DownloadTWRP()
                    twrpdownload.Show()
                End If
            Catch ex As Exception
                MsgBox("ERROR: Can´t connect to the server to download TWRP OrangeFox!", CType(MessageBoxIcon.Warning, MsgBoxStyle))
                System.Windows.Forms.Application.Restart()
            End Try
        End If

    End Sub

    Private Sub flashtwrp_Click(sender As Object, e As EventArgs) Handles flashtwrp.Click

        Dim paths() As String = IO.Directory.GetFiles("C:\adb\.settings\TWRP", "*.img")
        If paths.Length > 0 Then 'if at least one file is found do something

            If Shell("""C:\adb\fastboot.exe"" flash recovery recovery.img " & TextBox1.ToString, AppWinStyle.NormalFocus, True, 30000) = CInt(True) Then
                TextBox2.Text += "Folder: C:\adb\.settings\TWRP "

                Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

                TextBox1.Text = "Please connect your device in fastboot mode... "

                Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

                TextBox1.Text = "Flashing TWRP OrangeFox..."

                Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

                MsgBox("Now if you want to keep all working on this Recovery flash this OrangeFox-R10.0_2-Stable-lavender, this will keep flashed this Recovery permanent!...", CType(MessageBoxIcon.Warning, MsgBoxStyle))

                Dim Proc As String = "Explorer.exe"
                Dim Args As String =
                ControlChars.Quote &
                IO.Path.Combine("C:\", "adb\.settings\TWRP") &
                ControlChars.Quote
                Process.Start(Proc, Args)

            Else
                MsgBox("Flash TWRP OrangeFox Canceled...", CType(MessageBoxIcon.Warning, MsgBoxStyle))
            End If

            Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

        Else

            Try
                If My.Computer.Network.Ping("www.google.com") Then
                    MsgBox("Can´t find TWRP OrangeFox image...", CType(MessageBoxIcon.Warning, MsgBoxStyle))
                    Dim twrpdownload = New DownloadTWRP()
                    twrpdownload.Show()
                End If
            Catch ex As Exception
                MsgBox("ERROR: Can´t connect to the server to download TWRP OrangeFox!", CType(MessageBoxIcon.Warning, MsgBoxStyle))
                System.Windows.Forms.Application.Restart()
            End Try
        End If

    End Sub

    Private Sub LockBootloader_Click(sender As Object, e As EventArgs) Handles LockBootloader.Click

        Dim result = MessageBox.Show("Do you want to Lock the bootloader? This will erase all your data!", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then

            If Shell("""C:\adb\fastboot.exe"" oem lock " & TextBox1.ToString, AppWinStyle.NormalFocus, True, 30000) = True Then
                TextBox2.Text += "Folder: C:\adb "

                Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

                TextBox1.Text = "Please connect your device in fastboot mode... "

                Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

                TextBox1.Text = "Locking bootloader..."

                Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

            Else
                MsgBox("Lock Bootloader canceled...", MessageBoxIcon.Warning)
            End If

            Threading.Thread.Sleep(500) ' 500 milliseconds = 0.5 seconds

        End If

    End Sub

    Private Sub Visual_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        Dim dir As New IO.DirectoryInfo("C:\adb")

        If dir.Exists Then

            ChDir("C:\adb")

        Else

            If (Not System.IO.Directory.Exists("C:\adb")) Then
                System.IO.Directory.CreateDirectory("C:\adb")
            End If

        End If

        If Not Directory.Exists("C:\adb\.settings") Then
            Directory.CreateDirectory("C:\adb\.settings")
        End If

        Try
            If My.Computer.Network.Ping("www.google.com") Then
                If Not Directory.Exists("C:\adb") Then
                    Directory.CreateDirectory("C:\adb")
                Else
                    If Not File.Exists("C:\adb\.settings\bannermiui.jpg") Then
                        Dim img As Image = My.Resources.banner
                    End If
                    If Not File.Exists("C:\adb\adb.exe") Then
                        MyBase.Dispose(Disposing)
                        Dim downloadadb = New DownloadAdbFastboot()
                        downloadadb.Show()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR: Can´t connect to the server to download files!", CType(MessageBoxIcon.Warning, MsgBoxStyle))
            System.Windows.Forms.Application.Restart()
        End Try

        If Not Directory.Exists("C:\adb\.settings\TWRP") Then
            Directory.CreateDirectory("C:\adb\.settings\TWRP")
        End If

        If Not Directory.Exists("C:\adb\MI") Then
            Directory.CreateDirectory("C:\adb\MI")
        End If

        If Not Directory.Exists("C:\adb\MIUnlock") Then
            Directory.CreateDirectory("C:\adb\MIUnlock")
        End If

        TextBox2.Text = "Remember to always Backup your efs and persist folders!"

        Label3.Text = "User: " & Environment.UserName

        CPUShow()

        Label2.Text = "Folder Size: C:\adb " & GetDirectorySize("C:\adb") & " MB"

    End Sub

    Private Sub FlashFirmwareBetaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlashFirmwareBetaToolStripMenuItem.Click

        Dim paths() As String = IO.Directory.GetFiles("C:\adb\MI", "XiaoMiFlash.exe")
        If paths.Length > 0 Then 'if at least one file is found do something

            Try
                Dim proc As New System.Diagnostics.Process()
                proc = Process.Start("C:\adb\MI\XiaoMiFlash.exe", "")
            Catch
                MsgBox("XiaoMiFlash Closed...", CType(MessageBoxIcon.Warning, MsgBoxStyle))
            End Try

        Else
            MsgBox("Error on loading XiaoMiFlash, seems to be missing...", CType(MessageBoxIcon.Warning, MsgBoxStyle))
        End If

    End Sub

    Private Sub Help_Click(sender As Object, e As EventArgs) Handles Help.Click

        Dim help = New Help()
        help.Show()

    End Sub

    Private Sub UninstallTool_Click(sender As Object, e As EventArgs) Handles UninstallTool.Click

        Dim result = MessageBox.Show("Do you want to Remove all files? " & GetDirectorySize("C:\adb") & " MB", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then

            'Do nothing :)

        ElseIf result = DialogResult.Yes Then

            Try
                ChDir("C:\")
                Dim root As String = "C:\adb"
                'If directory does not exist, don't even try
                If Directory.Exists(root) Then
                    Me.Controls.Clear() 'removes all the controls on the form
                    Directory.Delete(root, True)
                    MsgBox("All files removed! " & " See you " & Environment.UserName, MessageBoxIcon.Warning)
                    MyBase.Dispose(Disposing)
                End If

            Catch ex As Exception
                MsgBox("The process failed: {0} " & ex.Message, MessageBoxIcon.Error)
                Me.Controls.Clear() 'removes all the controls on the form
                MyBase.Refresh()
            End Try

        End If

    End Sub

    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        Visual_Load(e, e)
        MyBase.Refresh()
    End Sub

    Private Sub OpenFlashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFlashToolStripMenuItem.Click

        Dim testflash = New Flash()
        testflash.Show()

    End Sub

    Dim savedCursor As Windows.Forms.Cursor
    Private sender As Object

    Private Sub TaskBarDropdownFolders_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TaskBarDropdownFolders.MouseEnter
        If savedCursor Is Nothing Then
            savedCursor = Me.Cursor
            Me.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub TaskBarDropdownFolders_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TaskBarDropdownFolders.MouseLeave
        Me.Cursor = savedCursor
        savedCursor = Nothing
    End Sub

    Private Sub ToolStripDropFastboot_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripDropFastboot.MouseEnter
        If savedCursor Is Nothing Then
            savedCursor = Me.Cursor
            Me.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub ToolStripDropFastboot_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripDropFastboot.MouseLeave
        Me.Cursor = savedCursor
        savedCursor = Nothing
    End Sub

    Private Sub TaskBarDropdownHardRecovery_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TaskBarDropdownHardRecovery.MouseEnter
        If savedCursor Is Nothing Then
            savedCursor = Me.Cursor
            Me.Cursor = Cursors.Hand
        End If
    End Sub
    Private Sub TaskBarDropdownHardRecovery_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TaskBarDropdownHardRecovery.MouseLeave
        Me.Cursor = savedCursor
        savedCursor = Nothing
    End Sub

    Private Sub TaskBarDropdownDownload_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TaskBarDropdownDownload.MouseEnter, TaskBarDropdownHardRecovery.MouseEnter
        If savedCursor Is Nothing Then
            savedCursor = Me.Cursor
            Me.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub TaskBarDropdownDownload_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TaskBarDropdownDownload.MouseLeave
        Me.Cursor = savedCursor
        savedCursor = Nothing
    End Sub

    Private Sub Help_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Help.MouseEnter
        If savedCursor Is Nothing Then
            savedCursor = Me.Cursor
            Me.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub Help_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Help.MouseLeave
        Me.Cursor = savedCursor
        savedCursor = Nothing
    End Sub

    Private Sub UninstallTool_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles UninstallTool.MouseEnter
        If savedCursor Is Nothing Then
            savedCursor = Me.Cursor
            Me.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub UninstallTool_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UninstallTool.MouseLeave
        Me.Cursor = savedCursor
        savedCursor = Nothing
    End Sub

    Private Sub Refresh_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Refresh.MouseEnter
        If savedCursor Is Nothing Then
            savedCursor = Me.Cursor
            Me.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub Refresh_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Refresh.MouseLeave
        Me.Cursor = savedCursor
        savedCursor = Nothing
    End Sub

End Class