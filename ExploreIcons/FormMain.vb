Public Class FormMain
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler TextBoxFolder.TextChanged, Sub() LoadFiles(TextBoxFolder.Text)
        AddHandler ButtonSelectFolder.Click, Sub()
                                                 Using dlg As New FolderBrowserDialog()
                                                     dlg.Description = "Select Folder"
                                                     dlg.SelectedPath = TextBoxFolder.Text
                                                     If dlg.ShowDialog(Me) = DialogResult.OK Then
                                                         TextBoxFolder.Text = dlg.SelectedPath
                                                     End If
                                                 End Using
                                             End Sub
        AddHandler ListViewFiles.SelectedIndexChanged, Sub() UpdateIcons()
        AddHandler TrackBarIconsSize.MouseUp, Sub() UpdateIcons()
        AddHandler TrackBarIconsSize.ValueChanged, Sub() LabelIconSize.Text = $"{TrackBarIconsSize.Value}x{TrackBarIconsSize.Value}"

        TextBoxFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.System)
    End Sub

    Private Sub UpdateIcons()
        If ListViewFiles.SelectedItems.Count = 0 Then
            LoadIcons("")
        Else
            LoadIcons(ListViewFiles.SelectedItems(0).Tag)
        End If
    End Sub

    Private Sub LoadIcons(fileName As String)
        ListViewIcons.Items.Clear()
        ImageListIcons.Images.Clear()

        ImageListIcons.ImageSize = New Size(TrackBarIconsSize.Value, TrackBarIconsSize.Value)

        If Not IO.File.Exists(fileName) Then Exit Sub

        ListViewIcons.BeginUpdate()

        Dim k As Integer
        For Each icon As Icon In Native.GetIconsFromFile(fileName, False)
            ImageListIcons.Images.Add(k.ToString(), icon)
            ListViewIcons.Items.Add("", k.ToString())
            k += 1
        Next

        ListViewIcons.EndUpdate()
    End Sub

    Private Sub LoadFiles(folder As String)
        ListViewIcons.Items.Clear()
        ImageListFileIcons.Images.Clear()

        With ListViewFiles
            .BeginUpdate()

            .Items.Clear()

            Dim di As New IO.DirectoryInfo(folder)
            If di.Exists Then
                Dim k As Integer
                For Each file As IO.FileInfo In di.GetFiles()
                    ImageListFileIcons.Images.Add(k.ToString(), Native.GetIconsFromFile(file.FullName, True, True)(0))
                    .Items.Add(file.Name, k.ToString()).Tag = file.FullName
                    k += 1
                Next
            End If

            .AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

            .EndUpdate()
        End With
    End Sub
End Class
