<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.dgvXls = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDL = New System.Windows.Forms.DataGridView()
        Me.ColFileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFileIze = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblMins = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblDLcount = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblCLientDateAndTime = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.tabSettings = New System.Windows.Forms.TabPage()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDestUpload = New System.Windows.Forms.TextBox()
        Me.txtLimitUpload = New System.Windows.Forms.NumericUpDown()
        Me.txtSrcUpload = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDLdest = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDLmin = New System.Windows.Forms.NumericUpDown()
        Me.txtLimitDownload = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnTestConnect = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbConnectionType = New System.Windows.Forms.ComboBox()
        Me.txtHostkey = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.NumericUpDown()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDLSrc = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TimerCheckingForDownloadInterval = New System.Windows.Forms.Timer(Me.components)
        Me.timerDLexecutorXLSfiles = New System.Windows.Forms.Timer(Me.components)
        Me.timerDLfinisheDownloadCheckerXLSfiles = New System.Windows.Forms.Timer(Me.components)
        Me.TimerExecutorForZipFiles = New System.Windows.Forms.Timer(Me.components)
        Me.blinkTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtAdjustTimeBy = New System.Windows.Forms.NumericUpDown()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvXls, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSettings.SuspendLayout()
        CType(Me.txtLimitUpload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDLmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLimitDownload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdjustTimeBy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.tabSettings)
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.LinkLabel1)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.RichTextBox1)
        Me.TabPage1.Controls.Add(Me.dgvXls)
        Me.TabPage1.Controls.Add(Me.dgvDL)
        Me.TabPage1.Controls.Add(Me.lblMins)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.lblDLcount)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.lblCLientDateAndTime)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.btnStop)
        Me.TabPage1.Controls.Add(Me.btnStart)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        resources.ApplyResources(Me.LinkLabel1, "LinkLabel1")
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.Name = "LinkLabel1"
        '
        'Button3
        '
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.Name = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        resources.ApplyResources(Me.RichTextBox1, "RichTextBox1")
        Me.RichTextBox1.Name = "RichTextBox1"
        '
        'dgvXls
        '
        Me.dgvXls.AllowUserToAddRows = False
        Me.dgvXls.AllowUserToDeleteRows = False
        Me.dgvXls.AllowUserToResizeColumns = False
        Me.dgvXls.AllowUserToResizeRows = False
        Me.dgvXls.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvXls.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvXls.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvXls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvXls.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        resources.ApplyResources(Me.dgvXls, "dgvXls")
        Me.dgvXls.MultiSelect = False
        Me.dgvXls.Name = "dgvXls"
        Me.dgvXls.ReadOnly = True
        Me.dgvXls.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvXls.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvXls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.Frozen = True
        resources.ApplyResources(Me.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1")
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        resources.ApplyResources(Me.DataGridViewTextBoxColumn2, "DataGridViewTextBoxColumn2")
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.DataGridViewTextBoxColumn3, "DataGridViewTextBoxColumn3")
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        resources.ApplyResources(Me.DataGridViewTextBoxColumn4, "DataGridViewTextBoxColumn4")
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dgvDL
        '
        Me.dgvDL.AllowUserToAddRows = False
        Me.dgvDL.AllowUserToDeleteRows = False
        Me.dgvDL.AllowUserToResizeColumns = False
        Me.dgvDL.AllowUserToResizeRows = False
        Me.dgvDL.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvDL.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColFileName, Me.colFileIze, Me.colFullPath, Me.colStat})
        resources.ApplyResources(Me.dgvDL, "dgvDL")
        Me.dgvDL.MultiSelect = False
        Me.dgvDL.Name = "dgvDL"
        Me.dgvDL.ReadOnly = True
        Me.dgvDL.RowHeadersVisible = False
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDL.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvDL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'ColFileName
        '
        resources.ApplyResources(Me.ColFileName, "ColFileName")
        Me.ColFileName.Name = "ColFileName"
        Me.ColFileName.ReadOnly = True
        Me.ColFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colFileIze
        '
        resources.ApplyResources(Me.colFileIze, "colFileIze")
        Me.colFileIze.Name = "colFileIze"
        Me.colFileIze.ReadOnly = True
        Me.colFileIze.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colFullPath
        '
        Me.colFullPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        resources.ApplyResources(Me.colFullPath, "colFullPath")
        Me.colFullPath.Name = "colFullPath"
        Me.colFullPath.ReadOnly = True
        Me.colFullPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colStat
        '
        resources.ApplyResources(Me.colStat, "colStat")
        Me.colStat.Name = "colStat"
        Me.colStat.ReadOnly = True
        Me.colStat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'lblMins
        '
        resources.ApplyResources(Me.lblMins, "lblMins")
        Me.lblMins.BackColor = System.Drawing.Color.DarkOrange
        Me.lblMins.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMins.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblMins.Name = "lblMins"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Name = "Label16"
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.BackColor = System.Drawing.Color.Linen
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Name = "Label22"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.BackColor = System.Drawing.Color.Linen
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label18.Name = "Label18"
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.BackColor = System.Drawing.Color.Linen
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label21.Name = "Label21"
        '
        'lblDLcount
        '
        resources.ApplyResources(Me.lblDLcount, "lblDLcount")
        Me.lblDLcount.BackColor = System.Drawing.Color.Linen
        Me.lblDLcount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDLcount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDLcount.Name = "lblDLcount"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Maroon
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Name = "Label19"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Maroon
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Name = "Label17"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Name = "Label15"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label20.Name = "Label20"
        '
        'lblCLientDateAndTime
        '
        Me.lblCLientDateAndTime.BackColor = System.Drawing.Color.Linen
        Me.lblCLientDateAndTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.lblCLientDateAndTime, "lblCLientDateAndTime")
        Me.lblCLientDateAndTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCLientDateAndTime.Name = "lblCLientDateAndTime"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.RoyalBlue
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.ForeColor = System.Drawing.Color.Yellow
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.RoyalBlue
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.ForeColor = System.Drawing.Color.Yellow
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnStop
        '
        Me.btnStop.BackColor = System.Drawing.Color.Maroon
        resources.ApplyResources(Me.btnStop, "btnStop")
        Me.btnStop.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnStop.Name = "btnStop"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.DarkGreen
        resources.ApplyResources(Me.btnStart, "btnStart")
        Me.btnStart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnStart.Name = "btnStart"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.Label23)
        Me.tabSettings.Controls.Add(Me.txtAdjustTimeBy)
        Me.tabSettings.Controls.Add(Me.Label24)
        Me.tabSettings.Controls.Add(Me.Label14)
        Me.tabSettings.Controls.Add(Me.Label13)
        Me.tabSettings.Controls.Add(Me.txtDestUpload)
        Me.tabSettings.Controls.Add(Me.txtLimitUpload)
        Me.tabSettings.Controls.Add(Me.txtSrcUpload)
        Me.tabSettings.Controls.Add(Me.Label3)
        Me.tabSettings.Controls.Add(Me.Label8)
        Me.tabSettings.Controls.Add(Me.Label5)
        Me.tabSettings.Controls.Add(Me.Label1)
        Me.tabSettings.Controls.Add(Me.txtDLdest)
        Me.tabSettings.Controls.Add(Me.Label9)
        Me.tabSettings.Controls.Add(Me.Label7)
        Me.tabSettings.Controls.Add(Me.txtDLmin)
        Me.tabSettings.Controls.Add(Me.txtLimitDownload)
        Me.tabSettings.Controls.Add(Me.Label6)
        Me.tabSettings.Controls.Add(Me.btnSave)
        Me.tabSettings.Controls.Add(Me.btnTestConnect)
        Me.tabSettings.Controls.Add(Me.Label4)
        Me.tabSettings.Controls.Add(Me.cmbConnectionType)
        Me.tabSettings.Controls.Add(Me.txtHostkey)
        Me.tabSettings.Controls.Add(Me.txtPort)
        Me.tabSettings.Controls.Add(Me.txtPassword)
        Me.tabSettings.Controls.Add(Me.txtUsername)
        Me.tabSettings.Controls.Add(Me.txtHost)
        Me.tabSettings.Controls.Add(Me.Label11)
        Me.tabSettings.Controls.Add(Me.Label10)
        Me.tabSettings.Controls.Add(Me.Label2)
        Me.tabSettings.Controls.Add(Me.txtDLSrc)
        Me.tabSettings.Controls.Add(Me.Label12)
        resources.ApplyResources(Me.tabSettings, "tabSettings")
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.UseVisualStyleBackColor = True
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Name = "Label14"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Name = "Label13"
        '
        'txtDestUpload
        '
        resources.ApplyResources(Me.txtDestUpload, "txtDestUpload")
        Me.txtDestUpload.Name = "txtDestUpload"
        Me.txtDestUpload.ReadOnly = True
        '
        'txtLimitUpload
        '
        resources.ApplyResources(Me.txtLimitUpload, "txtLimitUpload")
        Me.txtLimitUpload.Name = "txtLimitUpload"
        '
        'txtSrcUpload
        '
        resources.ApplyResources(Me.txtSrcUpload, "txtSrcUpload")
        Me.txtSrcUpload.Name = "txtSrcUpload"
        Me.txtSrcUpload.ReadOnly = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Name = "Label3"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Name = "Label8"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Name = "Label5"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtDLdest
        '
        Me.txtDLdest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtDLdest, "txtDLdest")
        Me.txtDLdest.Name = "txtDLdest"
        Me.txtDLdest.ReadOnly = True
        Me.txtDLdest.Tag = "Double Click"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Name = "Label9"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Name = "Label7"
        '
        'txtDLmin
        '
        Me.txtDLmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtDLmin, "txtDLmin")
        Me.txtDLmin.Name = "txtDLmin"
        '
        'txtLimitDownload
        '
        Me.txtLimitDownload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtLimitDownload, "txtLimitDownload")
        Me.txtLimitDownload.Name = "txtLimitDownload"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Name = "Label6"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkGreen
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Name = "btnSave"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnTestConnect
        '
        Me.btnTestConnect.BackColor = System.Drawing.Color.DarkGoldenrod
        resources.ApplyResources(Me.btnTestConnect, "btnTestConnect")
        Me.btnTestConnect.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnTestConnect.Name = "btnTestConnect"
        Me.btnTestConnect.UseVisualStyleBackColor = False
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Name = "Label4"
        '
        'cmbConnectionType
        '
        Me.cmbConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbConnectionType, "cmbConnectionType")
        Me.cmbConnectionType.FormattingEnabled = True
        Me.cmbConnectionType.Items.AddRange(New Object() {resources.GetString("cmbConnectionType.Items"), resources.GetString("cmbConnectionType.Items1")})
        Me.cmbConnectionType.Name = "cmbConnectionType"
        '
        'txtHostkey
        '
        Me.txtHostkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtHostkey, "txtHostkey")
        Me.txtHostkey.Name = "txtHostkey"
        Me.txtHostkey.Tag = "Host Key required"
        '
        'txtPort
        '
        Me.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtPort, "txtPort")
        Me.txtPort.Maximum = New Decimal(New Integer() {32500, 0, 0, 0})
        Me.txtPort.Name = "txtPort"
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtPassword, "txtPassword")
        Me.txtPassword.Name = "txtPassword"
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtUsername, "txtUsername")
        Me.txtUsername.Name = "txtUsername"
        '
        'txtHost
        '
        Me.txtHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtHost, "txtHost")
        Me.txtHost.Name = "txtHost"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Name = "Label11"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Name = "Label10"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Name = "Label2"
        '
        'txtDLSrc
        '
        Me.txtDLSrc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtDLSrc, "txtDLSrc")
        Me.txtDLSrc.Name = "txtDLSrc"
        Me.txtDLSrc.ReadOnly = True
        Me.txtDLSrc.Tag = "Double click"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Name = "Label12"
        '
        'TimerCheckingForDownloadInterval
        '
        Me.TimerCheckingForDownloadInterval.Interval = 1000
        '
        'timerDLexecutorXLSfiles
        '
        '
        'timerDLfinisheDownloadCheckerXLSfiles
        '
        '
        'TimerExecutorForZipFiles
        '
        '
        'blinkTimer
        '
        Me.blinkTimer.Interval = 800
        '
        'Label23
        '
        resources.ApplyResources(Me.Label23, "Label23")
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label23.Name = "Label23"
        '
        'txtAdjustTimeBy
        '
        Me.txtAdjustTimeBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtAdjustTimeBy, "txtAdjustTimeBy")
        Me.txtAdjustTimeBy.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.txtAdjustTimeBy.Minimum = New Decimal(New Integer() {24, 0, 0, -2147483648})
        Me.txtAdjustTimeBy.Name = "txtAdjustTimeBy"
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label24.Name = "Label24"
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvXls, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSettings.ResumeLayout(False)
        Me.tabSettings.PerformLayout()
        CType(Me.txtLimitUpload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDLmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLimitDownload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdjustTimeBy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents tabSettings As TabPage
    Friend WithEvents txtDLdest As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtLimitDownload As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnTestConnect As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbConnectionType As ComboBox
    Friend WithEvents txtHostkey As TextBox
    Friend WithEvents txtPort As NumericUpDown
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtHost As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDestUpload As TextBox
    Friend WithEvents txtDLSrc As TextBox
    Friend WithEvents txtLimitUpload As NumericUpDown
    Friend WithEvents txtSrcUpload As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtDLmin As NumericUpDown
    Friend WithEvents btnStop As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents lblCLientDateAndTime As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblMins As Label
    Friend WithEvents lblDLcount As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TimerCheckingForDownloadInterval As Timer
    Friend WithEvents dgvXls As DataGridView
    Friend WithEvents dgvDL As DataGridView
    Friend WithEvents ColFileName As DataGridViewTextBoxColumn
    Friend WithEvents colFileIze As DataGridViewTextBoxColumn
    Friend WithEvents colFullPath As DataGridViewTextBoxColumn
    Friend WithEvents colStat As DataGridViewTextBoxColumn
    Friend WithEvents Label19 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents timerDLexecutorXLSfiles As Timer
    Friend WithEvents timerDLfinisheDownloadCheckerXLSfiles As Timer
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents TimerExecutorForZipFiles As Timer
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents blinkTimer As Timer
    Friend WithEvents Label23 As Label
    Friend WithEvents txtAdjustTimeBy As NumericUpDown
    Friend WithEvents Label24 As Label
End Class
