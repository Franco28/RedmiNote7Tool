
'(C) 2019 Franco 28
'Basic Tool for Mi 8 Lite.  

Imports System.IO

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Visual
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
            Try
                Dim Xcel() As Process = Process.GetProcessesByName("adb" & "fastboot")
                For Each Process As Process In Xcel
                    Process.Kill()
                Next
            Catch ex As Exception
            End Try
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Visual))
        Me.unlockbootlaoderlabel = New System.Windows.Forms.Label()
        Me.TaskBar = New System.Windows.Forms.ToolStrip()
        Me.TaskBarDropdownFolders = New System.Windows.Forms.ToolStripDropDownButton()
        Me.AdbFastbootFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MiFlashFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MiUnlockFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaskBarDropdownDownload = New System.Windows.Forms.ToolStripDropDownButton()
        Me.DownloadLatestMIUIFastbootImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadLatestMIUIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFolderXiaomiGlobalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XiaomiGlobalPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadLatestMIUIByXiaomieuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFolderXiaomieuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XiaomieuPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadMiFlash2018ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadMiUnlockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaskBarDropdownHardRecovery = New System.Windows.Forms.ToolStripDropDownButton()
        Me.EnterEDLModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropFastboot = New System.Windows.Forms.ToolStripDropDownButton()
        Me.FlashFirmwareBetaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFlashToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Help = New System.Windows.Forms.ToolStripButton()
        Me.Refresh = New System.Windows.Forms.ToolStripButton()
        Me.UninstallTool = New System.Windows.Forms.ToolStripButton()
        Me.recoverylabel = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.flashtwrp = New System.Windows.Forms.Button()
        Me.boottwrp = New System.Windows.Forms.Button()
        Me.LockBootloader = New System.Windows.Forms.Button()
        Me.MiBanner = New System.Windows.Forms.PictureBox()
        Me.unlockbootloader = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TaskBar.SuspendLayout()
        CType(Me.MiBanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'unlockbootlaoderlabel
        '
        Me.unlockbootlaoderlabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.unlockbootlaoderlabel, "unlockbootlaoderlabel")
        Me.unlockbootlaoderlabel.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.unlockbootlaoderlabel.Name = "unlockbootlaoderlabel"
        '
        'TaskBar
        '
        Me.TaskBar.BackColor = System.Drawing.Color.Gainsboro
        Me.TaskBar.BackgroundImage = Global.RedmiNote7Tool.My.Resources.Resources.banner
        resources.ApplyResources(Me.TaskBar, "TaskBar")
        Me.TaskBar.GripMargin = New System.Windows.Forms.Padding(4)
        Me.TaskBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TaskBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TaskBarDropdownFolders, Me.TaskBarDropdownDownload, Me.TaskBarDropdownHardRecovery, Me.ToolStripDropFastboot, Me.Help, Me.Refresh, Me.UninstallTool})
        Me.TaskBar.Name = "TaskBar"
        Me.TaskBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        '
        'TaskBarDropdownFolders
        '
        Me.TaskBarDropdownFolders.BackColor = System.Drawing.Color.Transparent
        Me.TaskBarDropdownFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TaskBarDropdownFolders.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdbFastbootFolderToolStripMenuItem, Me.MiFlashFolderToolStripMenuItem, Me.MiUnlockFolderToolStripMenuItem})
        Me.TaskBarDropdownFolders.ForeColor = System.Drawing.Color.WhiteSmoke
        resources.ApplyResources(Me.TaskBarDropdownFolders, "TaskBarDropdownFolders")
        Me.TaskBarDropdownFolders.Name = "TaskBarDropdownFolders"
        Me.TaskBarDropdownFolders.Padding = New System.Windows.Forms.Padding(5)
        '
        'AdbFastbootFolderToolStripMenuItem
        '
        Me.AdbFastbootFolderToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.AdbFastbootFolderToolStripMenuItem, "AdbFastbootFolderToolStripMenuItem")
        Me.AdbFastbootFolderToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.AdbFastbootFolderToolStripMenuItem.Name = "AdbFastbootFolderToolStripMenuItem"
        '
        'MiFlashFolderToolStripMenuItem
        '
        Me.MiFlashFolderToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.MiFlashFolderToolStripMenuItem, "MiFlashFolderToolStripMenuItem")
        Me.MiFlashFolderToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.MiFlashFolderToolStripMenuItem.Name = "MiFlashFolderToolStripMenuItem"
        '
        'MiUnlockFolderToolStripMenuItem
        '
        Me.MiUnlockFolderToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.MiUnlockFolderToolStripMenuItem, "MiUnlockFolderToolStripMenuItem")
        Me.MiUnlockFolderToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.MiUnlockFolderToolStripMenuItem.Name = "MiUnlockFolderToolStripMenuItem"
        '
        'TaskBarDropdownDownload
        '
        Me.TaskBarDropdownDownload.BackColor = System.Drawing.Color.Transparent
        Me.TaskBarDropdownDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TaskBarDropdownDownload.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DownloadLatestMIUIFastbootImageToolStripMenuItem, Me.DownloadLatestMIUIToolStripMenuItem, Me.DownloadLatestMIUIByXiaomieuToolStripMenuItem, Me.DownloadMiFlash2018ToolStripMenuItem, Me.DownloadMiUnlockToolStripMenuItem})
        Me.TaskBarDropdownDownload.ForeColor = System.Drawing.Color.DimGray
        resources.ApplyResources(Me.TaskBarDropdownDownload, "TaskBarDropdownDownload")
        Me.TaskBarDropdownDownload.Name = "TaskBarDropdownDownload"
        Me.TaskBarDropdownDownload.Padding = New System.Windows.Forms.Padding(5)
        '
        'DownloadLatestMIUIFastbootImageToolStripMenuItem
        '
        Me.DownloadLatestMIUIFastbootImageToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.DownloadLatestMIUIFastbootImageToolStripMenuItem, "DownloadLatestMIUIFastbootImageToolStripMenuItem")
        Me.DownloadLatestMIUIFastbootImageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.DownloadLatestMIUIFastbootImageToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.DownloadLatestMIUIFastbootImageToolStripMenuItem.Name = "DownloadLatestMIUIFastbootImageToolStripMenuItem"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        Me.ToolStripMenuItem2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        '
        'DownloadLatestMIUIToolStripMenuItem
        '
        Me.DownloadLatestMIUIToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.DownloadLatestMIUIToolStripMenuItem, "DownloadLatestMIUIToolStripMenuItem")
        Me.DownloadLatestMIUIToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenFolderXiaomiGlobalToolStripMenuItem, Me.XiaomiGlobalPageToolStripMenuItem})
        Me.DownloadLatestMIUIToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.DownloadLatestMIUIToolStripMenuItem.Name = "DownloadLatestMIUIToolStripMenuItem"
        '
        'OpenFolderXiaomiGlobalToolStripMenuItem
        '
        Me.OpenFolderXiaomiGlobalToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.OpenFolderXiaomiGlobalToolStripMenuItem, "OpenFolderXiaomiGlobalToolStripMenuItem")
        Me.OpenFolderXiaomiGlobalToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.OpenFolderXiaomiGlobalToolStripMenuItem.Name = "OpenFolderXiaomiGlobalToolStripMenuItem"
        '
        'XiaomiGlobalPageToolStripMenuItem
        '
        Me.XiaomiGlobalPageToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.XiaomiGlobalPageToolStripMenuItem, "XiaomiGlobalPageToolStripMenuItem")
        Me.XiaomiGlobalPageToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.XiaomiGlobalPageToolStripMenuItem.Name = "XiaomiGlobalPageToolStripMenuItem"
        '
        'DownloadLatestMIUIByXiaomieuToolStripMenuItem
        '
        Me.DownloadLatestMIUIByXiaomieuToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.DownloadLatestMIUIByXiaomieuToolStripMenuItem, "DownloadLatestMIUIByXiaomieuToolStripMenuItem")
        Me.DownloadLatestMIUIByXiaomieuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenFolderXiaomieuToolStripMenuItem, Me.XiaomieuPageToolStripMenuItem})
        Me.DownloadLatestMIUIByXiaomieuToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.DownloadLatestMIUIByXiaomieuToolStripMenuItem.Name = "DownloadLatestMIUIByXiaomieuToolStripMenuItem"
        '
        'OpenFolderXiaomieuToolStripMenuItem
        '
        Me.OpenFolderXiaomieuToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.OpenFolderXiaomieuToolStripMenuItem, "OpenFolderXiaomieuToolStripMenuItem")
        Me.OpenFolderXiaomieuToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.OpenFolderXiaomieuToolStripMenuItem.Name = "OpenFolderXiaomieuToolStripMenuItem"
        '
        'XiaomieuPageToolStripMenuItem
        '
        Me.XiaomieuPageToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.XiaomieuPageToolStripMenuItem, "XiaomieuPageToolStripMenuItem")
        Me.XiaomieuPageToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.XiaomieuPageToolStripMenuItem.Name = "XiaomieuPageToolStripMenuItem"
        '
        'DownloadMiFlash2018ToolStripMenuItem
        '
        Me.DownloadMiFlash2018ToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.DownloadMiFlash2018ToolStripMenuItem, "DownloadMiFlash2018ToolStripMenuItem")
        Me.DownloadMiFlash2018ToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.DownloadMiFlash2018ToolStripMenuItem.Name = "DownloadMiFlash2018ToolStripMenuItem"
        '
        'DownloadMiUnlockToolStripMenuItem
        '
        Me.DownloadMiUnlockToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.DownloadMiUnlockToolStripMenuItem, "DownloadMiUnlockToolStripMenuItem")
        Me.DownloadMiUnlockToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.DownloadMiUnlockToolStripMenuItem.Name = "DownloadMiUnlockToolStripMenuItem"
        '
        'TaskBarDropdownHardRecovery
        '
        Me.TaskBarDropdownHardRecovery.BackColor = System.Drawing.Color.Transparent
        Me.TaskBarDropdownHardRecovery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TaskBarDropdownHardRecovery.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnterEDLModeToolStripMenuItem})
        Me.TaskBarDropdownHardRecovery.ForeColor = System.Drawing.Color.DimGray
        resources.ApplyResources(Me.TaskBarDropdownHardRecovery, "TaskBarDropdownHardRecovery")
        Me.TaskBarDropdownHardRecovery.Name = "TaskBarDropdownHardRecovery"
        Me.TaskBarDropdownHardRecovery.Padding = New System.Windows.Forms.Padding(0, 0, 20, 0)
        '
        'EnterEDLModeToolStripMenuItem
        '
        Me.EnterEDLModeToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.EnterEDLModeToolStripMenuItem.BackgroundImage = Global.RedmiNote7Tool.My.Resources.Resources.banner
        resources.ApplyResources(Me.EnterEDLModeToolStripMenuItem, "EnterEDLModeToolStripMenuItem")
        Me.EnterEDLModeToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.EnterEDLModeToolStripMenuItem.Name = "EnterEDLModeToolStripMenuItem"
        '
        'ToolStripDropFastboot
        '
        Me.ToolStripDropFastboot.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripDropFastboot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropFastboot.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FlashFirmwareBetaToolStripMenuItem, Me.OpenFlashToolStripMenuItem})
        Me.ToolStripDropFastboot.ForeColor = System.Drawing.Color.DimGray
        resources.ApplyResources(Me.ToolStripDropFastboot, "ToolStripDropFastboot")
        Me.ToolStripDropFastboot.Name = "ToolStripDropFastboot"
        Me.ToolStripDropFastboot.Padding = New System.Windows.Forms.Padding(5)
        '
        'FlashFirmwareBetaToolStripMenuItem
        '
        Me.FlashFirmwareBetaToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.FlashFirmwareBetaToolStripMenuItem, "FlashFirmwareBetaToolStripMenuItem")
        Me.FlashFirmwareBetaToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.FlashFirmwareBetaToolStripMenuItem.Name = "FlashFirmwareBetaToolStripMenuItem"
        '
        'OpenFlashToolStripMenuItem
        '
        Me.OpenFlashToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.OpenFlashToolStripMenuItem, "OpenFlashToolStripMenuItem")
        Me.OpenFlashToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.OpenFlashToolStripMenuItem.Name = "OpenFlashToolStripMenuItem"
        '
        'Help
        '
        Me.Help.BackColor = System.Drawing.Color.Transparent
        Me.Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.Help, "Help")
        Me.Help.Margin = New System.Windows.Forms.Padding(300, 0, 0, 0)
        Me.Help.Name = "Help"
        Me.Help.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        '
        'Refresh
        '
        Me.Refresh.BackColor = System.Drawing.Color.Transparent
        Me.Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Refresh.ForeColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Refresh, "Refresh")
        Me.Refresh.Margin = New System.Windows.Forms.Padding(-85, 1, 0, 2)
        Me.Refresh.Name = "Refresh"
        '
        'UninstallTool
        '
        Me.UninstallTool.BackColor = System.Drawing.Color.Transparent
        Me.UninstallTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.UninstallTool, "UninstallTool")
        Me.UninstallTool.Margin = New System.Windows.Forms.Padding(90, 0, 0, 0)
        Me.UninstallTool.Name = "UninstallTool"
        '
        'recoverylabel
        '
        Me.recoverylabel.BackColor = System.Drawing.Color.DimGray
        Me.recoverylabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.recoverylabel, "recoverylabel")
        Me.recoverylabel.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.recoverylabel.Name = "recoverylabel"
        '
        'TextBox1
        '
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.BackColor = System.Drawing.Color.DimGray
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        '
        'LinkLabel1
        '
        resources.ApplyResources(Me.LinkLabel1, "LinkLabel1")
        Me.LinkLabel1.BackColor = System.Drawing.Color.DimGray
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Yellow
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.TabStop = True
        '
        'ComboBox1
        '
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.Name = "ComboBox1"
        '
        'TextBox2
        '
        resources.ApplyResources(Me.TextBox2, "TextBox2")
        Me.TextBox2.BackColor = System.Drawing.Color.DimGray
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        '
        'flashtwrp
        '
        Me.flashtwrp.BackColor = System.Drawing.Color.LightGray
        Me.flashtwrp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.flashtwrp.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.flashtwrp.FlatAppearance.BorderSize = 0
        Me.flashtwrp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.flashtwrp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.flashtwrp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.flashtwrp, "flashtwrp")
        Me.flashtwrp.Name = "flashtwrp"
        Me.flashtwrp.UseVisualStyleBackColor = False
        '
        'boottwrp
        '
        Me.boottwrp.BackColor = System.Drawing.Color.LightGray
        Me.boottwrp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.boottwrp.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.boottwrp.FlatAppearance.BorderSize = 0
        Me.boottwrp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.boottwrp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.boottwrp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.boottwrp, "boottwrp")
        Me.boottwrp.Name = "boottwrp"
        Me.boottwrp.UseVisualStyleBackColor = False
        '
        'LockBootloader
        '
        Me.LockBootloader.BackColor = System.Drawing.Color.LightGray
        Me.LockBootloader.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LockBootloader.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.LockBootloader.FlatAppearance.BorderSize = 0
        Me.LockBootloader.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.LockBootloader.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.LockBootloader.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.LockBootloader, "LockBootloader")
        Me.LockBootloader.Name = "LockBootloader"
        Me.LockBootloader.UseVisualStyleBackColor = False
        '
        'MiBanner
        '
        Me.MiBanner.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.MiBanner, "MiBanner")
        Me.MiBanner.Name = "MiBanner"
        Me.MiBanner.TabStop = False
        '
        'unlockbootloader
        '
        Me.unlockbootloader.BackColor = System.Drawing.Color.LightGray
        Me.unlockbootloader.Cursor = System.Windows.Forms.Cursors.Hand
        Me.unlockbootloader.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.unlockbootloader.FlatAppearance.BorderSize = 0
        Me.unlockbootloader.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.unlockbootloader.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.unlockbootloader.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.unlockbootloader, "unlockbootloader")
        Me.unlockbootloader.Name = "unlockbootloader"
        Me.unlockbootloader.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DimGray
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Name = "Label3"
        '
        'Visual
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.DimGray
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TaskBar)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.flashtwrp)
        Me.Controls.Add(Me.boottwrp)
        Me.Controls.Add(Me.unlockbootlaoderlabel)
        Me.Controls.Add(Me.recoverylabel)
        Me.Controls.Add(Me.LockBootloader)
        Me.Controls.Add(Me.MiBanner)
        Me.Controls.Add(Me.unlockbootloader)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.Name = "Visual"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TaskBar.ResumeLayout(False)
        Me.TaskBar.PerformLayout()
        CType(Me.MiBanner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents recoverylabel As Label
    Friend WithEvents boottwrp As Button
    Friend WithEvents flashtwrp As Button
    Friend WithEvents TaskBarDropdownDownload As ToolStripDropDownButton
    Friend WithEvents DownloadLatestMIUIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TaskBar As ToolStrip
    Friend WithEvents TaskBarDropdownFolders As ToolStripDropDownButton
    Friend WithEvents AdbFastbootFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents unlockbootlaoderlabel As Label
    Friend WithEvents unlockbootloader As Button
    Friend WithEvents MiBanner As PictureBox
    Friend WithEvents LockBootloader As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TaskBarDropdownHardRecovery As ToolStripDropDownButton
    Friend WithEvents EnterEDLModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents DownloadLatestMIUIByXiaomieuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XiaomieuPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFolderXiaomieuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFolderXiaomiGlobalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XiaomiGlobalPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadLatestMIUIFastbootImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripDropFastboot As ToolStripDropDownButton
    Friend WithEvents FlashFirmwareBetaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Help As ToolStripButton
    Friend WithEvents OpenFlashToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadMiFlash2018ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MiFlashFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DownloadMiUnlockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MiUnlockFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents UninstallTool As ToolStripButton
    Friend WithEvents Refresh As ToolStripButton
End Class
