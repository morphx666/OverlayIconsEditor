<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxFolder = New System.Windows.Forms.TextBox()
        Me.ButtonSelectFolder = New System.Windows.Forms.Button()
        Me.ListViewFiles = New System.Windows.Forms.ListView()
        Me.ColumnHeaderFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageListFileIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.ListViewIcons = New System.Windows.Forms.ListView()
        Me.ImageListIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.TrackBarIconsSize = New System.Windows.Forms.TrackBar()
        Me.LabelIconSize = New System.Windows.Forms.Label()
        CType(Me.TrackBarIconsSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folder"
        '
        'TextBoxFolder
        '
        Me.TextBoxFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxFolder.Location = New System.Drawing.Point(63, 12)
        Me.TextBoxFolder.Name = "TextBoxFolder"
        Me.TextBoxFolder.Size = New System.Drawing.Size(869, 25)
        Me.TextBoxFolder.TabIndex = 1
        '
        'ButtonSelectFolder
        '
        Me.ButtonSelectFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSelectFolder.Location = New System.Drawing.Point(938, 13)
        Me.ButtonSelectFolder.Name = "ButtonSelectFolder"
        Me.ButtonSelectFolder.Size = New System.Drawing.Size(29, 23)
        Me.ButtonSelectFolder.TabIndex = 2
        Me.ButtonSelectFolder.Text = "..."
        Me.ButtonSelectFolder.UseVisualStyleBackColor = True
        '
        'ListViewFiles
        '
        Me.ListViewFiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderFileName})
        Me.ListViewFiles.FullRowSelect = True
        Me.ListViewFiles.GridLines = True
        Me.ListViewFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewFiles.HideSelection = False
        Me.ListViewFiles.LabelWrap = False
        Me.ListViewFiles.Location = New System.Drawing.Point(63, 43)
        Me.ListViewFiles.MultiSelect = False
        Me.ListViewFiles.Name = "ListViewFiles"
        Me.ListViewFiles.ShowGroups = False
        Me.ListViewFiles.Size = New System.Drawing.Size(350, 525)
        Me.ListViewFiles.SmallImageList = Me.ImageListFileIcons
        Me.ListViewFiles.TabIndex = 3
        Me.ListViewFiles.UseCompatibleStateImageBehavior = False
        Me.ListViewFiles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderFileName
        '
        Me.ColumnHeaderFileName.Text = "File Name"
        '
        'ImageListFileIcons
        '
        Me.ImageListFileIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageListFileIcons.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListFileIcons.TransparentColor = System.Drawing.Color.Transparent
        '
        'ListViewIcons
        '
        Me.ListViewIcons.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewIcons.LargeImageList = Me.ImageListIcons
        Me.ListViewIcons.Location = New System.Drawing.Point(419, 43)
        Me.ListViewIcons.Name = "ListViewIcons"
        Me.ListViewIcons.Size = New System.Drawing.Size(548, 477)
        Me.ListViewIcons.SmallImageList = Me.ImageListIcons
        Me.ListViewIcons.TabIndex = 4
        Me.ListViewIcons.UseCompatibleStateImageBehavior = False
        '
        'ImageListIcons
        '
        Me.ImageListIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageListIcons.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageListIcons.TransparentColor = System.Drawing.Color.Transparent
        '
        'TrackBarIconsSize
        '
        Me.TrackBarIconsSize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBarIconsSize.LargeChange = 16
        Me.TrackBarIconsSize.Location = New System.Drawing.Point(419, 526)
        Me.TrackBarIconsSize.Maximum = 256
        Me.TrackBarIconsSize.Minimum = 16
        Me.TrackBarIconsSize.Name = "TrackBarIconsSize"
        Me.TrackBarIconsSize.Size = New System.Drawing.Size(486, 45)
        Me.TrackBarIconsSize.SmallChange = 8
        Me.TrackBarIconsSize.TabIndex = 5
        Me.TrackBarIconsSize.TickFrequency = 8
        Me.TrackBarIconsSize.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.TrackBarIconsSize.Value = 32
        '
        'LabelIconSize
        '
        Me.LabelIconSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelIconSize.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelIconSize.Location = New System.Drawing.Point(911, 541)
        Me.LabelIconSize.Name = "LabelIconSize"
        Me.LabelIconSize.Size = New System.Drawing.Size(56, 15)
        Me.LabelIconSize.TabIndex = 6
        Me.LabelIconSize.Text = "32x32"
        Me.LabelIconSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 580)
        Me.Controls.Add(Me.LabelIconSize)
        Me.Controls.Add(Me.TrackBarIconsSize)
        Me.Controls.Add(Me.ListViewIcons)
        Me.Controls.Add(Me.ListViewFiles)
        Me.Controls.Add(Me.ButtonSelectFolder)
        Me.Controls.Add(Me.TextBoxFolder)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Explore Icons"
        CType(Me.TrackBarIconsSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxFolder As TextBox
    Friend WithEvents ButtonSelectFolder As Button
    Friend WithEvents ListViewFiles As ListView
    Friend WithEvents ColumnHeaderFileName As ColumnHeader
    Friend WithEvents ListViewIcons As ListView
    Friend WithEvents ImageListIcons As ImageList
    Friend WithEvents ImageListFileIcons As ImageList
    Friend WithEvents TrackBarIconsSize As TrackBar
    Friend WithEvents LabelIconSize As Label
End Class
