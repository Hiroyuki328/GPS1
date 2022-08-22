Public Class Class1

End Class

Public Structure satellite

    Private sPRN As String
    Private sEd As Integer
    Private sAz As Integer
    Private sSN As Integer

    Public Property PRN() As String
        Get
            Return sPRN
        End Get
        Set(value As String)
            sPRN = value
        End Set
    End Property
    Public Property Ed() As Integer
        Get
            Return sEd
        End Get
        Set(value As Integer)
            sEd = value
        End Set
    End Property
    Public Property Az() As Integer
        Get
            Return sAz
        End Get
        Set(value As Integer)
            sAz = value
        End Set
    End Property
    Public Property SN() As Integer
        Get
            Return sSN
        End Get
        Set(value As Integer)
            sSN = value
        End Set
    End Property

End Structure

Public Structure GPstat

    Private gCtime As String
    Private gDVflag As String
    Private gLati As String
    Private gLaDir As String
    Private gLon As String
    Private gLonDir As String
    Private gSpeed As String
    Private gHeading As String
    Private gGdate As String
    Private gNumView As Integer
    Private gNumFix As Integer
    Private gAlt As String

    Public Property Ctime() As String
        Get
            Return gCtime
        End Get
        Set(value As String)
            gCtime = value
        End Set
    End Property
    Public Property DVflag() As String
        Get
            Return gDVflag
        End Get
        Set(value As String)
            gDVflag = value
        End Set
    End Property
    Public Property Lati() As String
        Get
            Return gLati
        End Get
        Set(value As String)
            gLati = value
        End Set
    End Property
    Public Property LaDir() As String
        Get
            Return gLaDir
        End Get
        Set(value As String)
            gLaDir = value
        End Set
    End Property
    Public Property Lon() As String
        Get
            Return gLon
        End Get
        Set(value As String)
            gLon = value
        End Set
    End Property
    Public Property LonDir() As String
        Get
            Return gLonDir
        End Get
        Set(value As String)
            gLonDir = value
        End Set
    End Property
    Public Property Speed() As String
        Get
            Return gSpeed
        End Get
        Set(value As String)
            gSpeed = value
        End Set
    End Property
    Public Property Heading() As String
        Get
            Return gHeading
        End Get
        Set(value As String)
            gHeading = value
        End Set
    End Property
    Public Property Gdate() As String
        Get
            Return gGdate
        End Get
        Set(value As String)
            gGdate = value
        End Set
    End Property
    Public Property NumView() As String
        Get
            Return gNumView
        End Get
        Set(value As String)
            gNumView = value
        End Set
    End Property
    Public Property NumFix() As String
        Get
            Return gNumFix
        End Get
        Set(value As String)
            gNumFix = value
        End Set
    End Property
    Public Property Alt() As String
        Get
            Return gAlt
        End Get
        Set(value As String)
            gAlt = value
        End Set
    End Property

End Structure