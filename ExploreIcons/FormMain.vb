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
        AddHandler TrackBarIconsSize.KeyUp, Sub() UpdateIcons()
        AddHandler TrackBarIconsSize.ValueChanged, Sub() LabelIconSize.Text = $"{TrackBarIconsSize.Value}x{TrackBarIconsSize.Value}"

        'TextBoxFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.System)
        TextBoxFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Windows)
    End Sub

    Private Sub UpdateIcons()
        If ListViewFiles.SelectedItems.Count = 0 Then
            LoadIcons("")
        Else
            LoadIcons(ListViewFiles.SelectedItems(0).Tag)
        End If
    End Sub

    Private Sub LoadIcons(fileName As String)
        ImageListIconsInFile.Images.Clear()
        ListViewIcons.Items.Clear()

        ImageListIconsInFile.ImageSize = New Size(TrackBarIconsSize.Value, TrackBarIconsSize.Value)

        If Not IO.File.Exists(fileName) Then Exit Sub

        Dim sw As New Stopwatch()
        sw.Start()
        ListViewIcons.BeginUpdate()

        ' Using keys instead of indexes is about 4 times slower!
        'Dim key As String
        Dim iconIndex As Integer = 0
        For Each icon As Icon In Native.GetIconsFromFile(fileName, False)
            'key = $"|{icon.Handle}"
            'ImageListIconsInFile.Images.Add(key, icon)
            'ListViewIcons.Items.Add("", key)
            ImageListIconsInFile.Images.Add(icon)
            ListViewIcons.Items.Add("", iconIndex)
            iconIndex += 1
        Next

        ListViewIcons.EndUpdate()
        sw.Stop()
        Console.WriteLine($"{NameOf(LoadIcons)}: {sw.ElapsedMilliseconds:N0}")
    End Sub

    Private Sub LoadFiles(folder As String)
        ImageListIconsInFile.Images.Clear()
        ListViewIcons.Items.Clear()

        With ListViewFiles
            .BeginUpdate()

            .Items.Clear()

            Dim di As New IO.DirectoryInfo(folder)
            If di.Exists Then
                ImageListFilesIcons.Images.Clear()

                Dim sw As New Stopwatch()
                sw.Start()

                Dim key As String
                For Each file As IO.FileInfo In di.GetFiles().OrderBy(Function(f) f.Name).ThenBy(Function(f) f.Extension)
                    key = file.Extension.ToLower()
                    If Not ImageListFilesIcons.Images.ContainsKey(key) Then
                        key = If(IsExe(file.FullName), $"&{file.Name}", key)
                        If Not ImageListFilesIcons.Images.ContainsKey(key) Then ImageListFilesIcons.Images.Add(key, Native.GetIconsFromFile(file.FullName, True, True)(0))
                    End If
                    With .Items.Add(file.Name, key)
                        .SubItems.Add($"{Native.CountIconsInFile(file.FullName):N0}")
                        .Tag = file.FullName
                    End With
                Next

                sw.Stop()
                Console.WriteLine($"{NameOf(LoadFiles)}: {sw.ElapsedMilliseconds:N0}")
            End If

            .AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Items(0).EnsureVisible()
            End If

            .EndUpdate()
        End With
    End Sub

    Private Function IsExe(fileName As String) As Boolean
        Try
            Dim b(2 - 1) As Char
            Using fs As New IO.StreamReader(fileName)
                fs.ReadBlock(b, 0, 2)
                Return b(0) = "M" AndAlso b(1) = "Z"
            End Using
        Catch ex As Exception
            Return True ' Assume it is...
        End Try
    End Function
End Class
