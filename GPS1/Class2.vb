Public Class Navigator

    Private TrackX As Double
    Private TrackY As Double
    Private sCurX As Double
    Private sCurY As Double
    Private pnt As Integer

    Public WriteOnly Property CurX() As Double
        Set(value As Double)
            sCurX = value
        End Set
    End Property

    Public WriteOnly Property CurY() As Double
        Set(value As Double)
            sCurY = value
        End Set
    End Property




End Class
