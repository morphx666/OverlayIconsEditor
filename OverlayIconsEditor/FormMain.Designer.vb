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
        Me.ListViewOverlayIcons = New OverlayIconsEditor.ListViewDoubleBuffer()
        Me.ColumnHeaderName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageListFilesIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.ButtonUp = New System.Windows.Forms.Button()
        Me.ButtonDown = New System.Windows.Forms.Button()
        Me.ButtonApply = New System.Windows.Forms.Button()
        Me.ImageListIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'ListViewOverlayIcons
        '
        Me.ListViewOverlayIcons.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewOverlayIcons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListViewOverlayIcons.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderName, Me.ColumnHeaderDescription})
        Me.ListViewOverlayIcons.FullRowSelect = True
        Me.ListViewOverlayIcons.GridLines = True
        Me.ListViewOverlayIcons.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewOverlayIcons.HideSelection = False
        Me.ListViewOverlayIcons.LabelWrap = False
        Me.ListViewOverlayIcons.LargeImageList = Me.ImageListFilesIcons
        Me.ListViewOverlayIcons.Location = New System.Drawing.Point(12, 12)
        Me.ListViewOverlayIcons.Name = "ListViewOverlayIcons"
        Me.ListViewOverlayIcons.ShowGroups = False
        Me.ListViewOverlayIcons.Size = New System.Drawing.Size(581, 427)
        Me.ListViewOverlayIcons.SmallImageList = Me.ImageListFilesIcons
        Me.ListViewOverlayIcons.TabIndex = 0
        Me.ListViewOverlayIcons.UseCompatibleStateImageBehavior = False
        Me.ListViewOverlayIcons.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderName
        '
        Me.ColumnHeaderName.Text = "Overlay Icon Name"
        '
        'ColumnHeaderDescription
        '
        Me.ColumnHeaderDescription.Text = "Description"
        '
        'ImageListFilesIcons
        '
        Me.ImageListFilesIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.ImageListFilesIcons.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListFilesIcons.TransparentColor = System.Drawing.Color.Transparent
        '
        'ButtonUp
        '
        Me.ButtonUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonUp.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonUp.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonUp.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.ButtonUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonUp.Image = Global.OverlayIconsEditor.My.Resources.Resources.Icon_Up
        Me.ButtonUp.Location = New System.Drawing.Point(599, 12)
        Me.ButtonUp.Name = "ButtonUp"
        Me.ButtonUp.Size = New System.Drawing.Size(51, 50)
        Me.ButtonUp.TabIndex = 1
        Me.ButtonUp.UseVisualStyleBackColor = True
        '
        'ButtonDown
        '
        Me.ButtonDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDown.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonDown.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonDown.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.ButtonDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDown.Image = Global.OverlayIconsEditor.My.Resources.Resources.Icon_Down
        Me.ButtonDown.Location = New System.Drawing.Point(599, 68)
        Me.ButtonDown.Name = "ButtonDown"
        Me.ButtonDown.Size = New System.Drawing.Size(51, 50)
        Me.ButtonDown.TabIndex = 1
        Me.ButtonDown.UseVisualStyleBackColor = True
        '
        'ButtonApply
        '
        Me.ButtonApply.Location = New System.Drawing.Point(599, 408)
        Me.ButtonApply.Name = "ButtonApply"
        Me.ButtonApply.Size = New System.Drawing.Size(75, 31)
        Me.ButtonApply.TabIndex = 2
        Me.ButtonApply.Text = "Apply"
        Me.ButtonApply.UseVisualStyleBackColor = True
        '
        'ImageListIcons
        '
        Me.ImageListIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.ImageListIcons.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageListIcons.TransparentColor = System.Drawing.Color.Transparent
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 451)
        Me.Controls.Add(Me.ButtonApply)
        Me.Controls.Add(Me.ButtonDown)
        Me.Controls.Add(Me.ButtonUp)
        Me.Controls.Add(Me.ListViewOverlayIcons)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Overlay Icons Editor"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListViewOverlayIcons As ListViewDoubleBuffer
    Friend WithEvents ColumnHeaderName As ColumnHeader
    Friend WithEvents ImageListFilesIcons As ImageList
    Friend WithEvents ColumnHeaderDescription As ColumnHeader
    Friend WithEvents ButtonUp As Button
    Friend WithEvents ButtonDown As Button
    Friend WithEvents ButtonApply As Button
    Friend WithEvents ImageListIcons As ImageList
End Class
