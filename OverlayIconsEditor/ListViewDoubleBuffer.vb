Public Class ListViewDoubleBuffer
    Inherits ListView

    Public Sub New()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    End Sub
End Class
