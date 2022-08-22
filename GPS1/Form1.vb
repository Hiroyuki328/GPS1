Imports System.Math

Public Class Form1

    Dim sr As New System.IO.StreamReader("Sample_NMEA.log", System.Text.Encoding.GetEncoding("shift_jis"))
    Dim cnt As Integer

    Dim GP As GPstat
    Dim SV() As satellite
    Dim listSV As New List(Of satellite)
    Dim listView As New List(Of String)
    Dim listFix As New List(Of String)
    Dim rcnt As Integer
    Dim dt1() As DataTable
    Dim MapBmp As Bitmap = My.Resources.Map
    Dim PolarBmp As Bitmap
    Dim SnBmp As Bitmap
    Dim TrackX, TrackY As Double()
    Dim TrackPnt As Integer
    Dim TgtOn_flg As Boolean = False : Dim NaviOn_flg As Boolean = False
    Dim NaviValid_flg As Boolean = False
    Dim TgtSchng_flg As Boolean = False
    Dim TrimBmp As Bitmap : Dim TrimX As Integer : Dim TrimY As Integer
    Dim TgtX, TgtY As Double
    Dim PortOpen_flg As Boolean = False
    Dim deg As Double
    Dim MapRotateOn_flg As Boolean = False

    Const realx0 As Double = 143.928303
    Const realy0 As Double = 43.83238
    Const realxl As Double = 0.001187
    Const realyl As Double = 0.000854

    Delegate Sub DataDelegate(ByVal sdata As String)
    Delegate Sub GraDelegate(ByVal vlist As List(Of String))

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.SV = New satellite(60) {}
        PolarBmp = New Bitmap(pctPolar.Width, pctPolar.Height)
        SnBmp = New Bitmap(pctSN.Width, pctSN.Height)
        TrackX = New Double(5) {}
        TrackY = New Double(5) {} : TrackPnt = 0

        Dim i As Integer
        For i = 0 To SV.Length - 1
            Me.SV(i) = New satellite
        Next
        rcnt = 0

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click       'シリアルポート列挙

        Dim PortList As String() = SerialPort.GetPortNames()
        cmbPortName.Items.Clear()

        For Each PortName As String In PortList
            cmbPortName.Items.Add(PortName)
        Next PortName

    End Sub


    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        'シリアルデータ受信
        Dim ReceivedData As String = " "
        Try
            ReceivedData = SerialPort1.ReadLine     'データ受信
        Catch ex As Exception
            ReceivedData = ex.Message
        End Try

        Dim dele As New DataDelegate(AddressOf PrintData)
        Me.Invoke(dele, ReceivedData)

        Call Analyze(ReceivedData)

    End Sub

    Private Sub PrintData(ByVal sdata As String)
        TextBox1.Text = sdata
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click       '接続ボタン

        If PortOpen_flg = False Then
            Try
                'If SerialPort1.IsOpen = True Then   'ポートオープン済み
                '    MessageBox.Show(" ", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub
                'End If
                'SerialPort1.PortName = "COM3"       'オープンするポート名
                'SerialPort1.Open()                  'ポートオープン        

                'SerialPort1.DiscardInBuffer()
                'SerialPort1.RtsEnable = True        'RTSをON
                TextBox1.Enabled = True
                GP = New GPstat

                PortOpen_flg = True
                Button4.Text = "切断"

                Timer1.Enabled = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            'If SerialPort1.IsOpen = True Then       'ポートオープン済み
            'SerialPort1.Close()                 'ポートクローズ
            PortOpen_flg = False
                Button4.Text = "受信開始"
                Timer1.Enabled = False
            'End If
        End If

    End Sub

    Private Sub Analyze(ByVal ReceiveData As String)    'メッセージ解析

        Dim Data() As String
        Dim dmr As String() = {",", "*"}
        Data = ReceiveData.Split(dmr, System.StringSplitOptions.None)
        Dim GPcmd As String = Data(0)
        Dim i As Integer
        Dim dele1 As New DataDelegate(AddressOf lblnew)
        Dim dele2 As New GraDelegate(AddressOf PolarDraw)

        Select Case GPcmd
            Case "$GPRMC"
                GP.Ctime = Data(1)
                GP.DVflag = Data(2)
                GP.Lati = Data(3)
                GP.LaDir = Data(4)
                GP.Lon = Data(5)
                GP.LonDir = Data(6)
                GP.Speed = Data(7)
                GP.Heading = Data(8)
                GP.Gdate = Data(9)
                Me.Invoke(dele1, " ")
            Case "$GPGGA"
                GP.Ctime = Data(1)
                GP.Lati = Data(2)
                GP.LaDir = Data(3)
                GP.Lon = Data(4)
                GP.LonDir = Data(5)
                GP.NumFix = Data(7)
                GP.Alt = Data(9)
                Me.Invoke(dele1, " ")
            Case "$GPGSA"
                listFix.Clear()
                For i = 3 To 14
                    If Data(i) <> "" Then listFix.Add(Data(i))
                Next
                For Each satID As String In listFix
                    Dim id As Integer = Integer.Parse(satID)
                Next
            Case "$GPGSV"
                If Data(2) = "1" Then
                    listView.Clear()    'メッセージ番号"1"の時、捕捉リストクリア
                End If
                Dim satID As String
                Dim sID As Integer
                Dim d1, d2, d3, d4 As String
                Dim n As Integer = (Data.Length - 4) / 4
                For i = 1 To n
                    d1 = Data(i * 4) : d2 = Data(i * 4 + 1) : d3 = Data(i * 4 + 2) : d4 = Data(i * 4 + 3)

                    If d1 <> "" Then
                        satID = d1 : sID = CInt(satID)
                        SV(sID).Ed = If(d2 <> "", Integer.Parse(d2), 0)
                        SV(sID).Az = If(d3 <> "", Integer.Parse(d3), 0)
                        SV(sID).SN = If(d4 <> "", Integer.Parse(d4), 0)
                        listView.Add(satID)
                    Else
                        Exit For
                    End If
                Next
                If Data(1) = Data(2) Then   '最終メッセージ番号の時、グラフ更新
                    Me.Invoke(dele2, listView)
                End If
        End Select
    End Sub

    Public Sub lblnew(ByVal sdata As String)    '緯度経度、時間の表示更新

        Dim dmss As String = GP.Lati
        Dim d As String = dmss.Substring(0, 2)
        Dim m As String = dmss.Substring(2, 2)
        Dim mm As String = dmss.Substring(2, 7)
        Dim b As Double = (CDbl(mm) - CDbl(m)) * 60
        Dim sb As String = b.ToString("00.00")
        lbl_Lati.Text = String.Format("{0}˚ {1}' {2}""", d, m, sb)
        Dim lati_val As Double = d + CDbl(mm) / 60

        dmss = GP.Lon
        d = dmss.Substring(0, 3)
        m = dmss.Substring(3, 2)
        mm = dmss.Substring(3, 7)
        b = (CDbl(mm) - CDbl(m)) * 60
        sb = b.ToString("00.00")
        lbl_Lon.Text = String.Format("{0}˚ {1}' {2}""", d, m, sb)
        Dim lon_val As Double = d + CDbl(mm) / 60

        '進行方向角度
        Dim dx As Double = lon_val - TrackX(TrackPnt)
        Dim dy As Double = lati_val - TrackY(TrackPnt)

        If Math.Sqrt(dx ^ 2 + dy ^ 2) > 0.00001 Then
            deg = NaviDeg(dx, dy * 0.724, 0, 1)     '最新移動ベクトルと真北との角度
            Label3.Text = Format(deg, "###.#0")
        End If

        Call MapDraw(lon_val, lati_val, deg)

        If TgtOn_flg = True Then
            Call Navi(lon_val, lati_val)
        End If

        dmss = GP.Ctime
        d = dmss.Substring(0, 2)
        m = dmss.Substring(2, 2)
        Dim s1 As String = dmss.Substring(4, 2)
        lbl_cTime.Text = String.Format("{0}:{1}:{2}", d, m, s1)

    End Sub

    Private Sub MapDraw(gx As Double, gy As Double, sita As Double)     'マップ画像更新

        Dim g As Graphics = Graphics.FromImage(MapBmp)
        Dim pen As New Pen(Color.Black, 1)
        Dim x As Integer
        Dim y As Integer

        Dim pw As Integer = 8
        Dim ofs As Integer = Int(pw / 2)

        x = (gx - realx0) / realxl * 500
        y = -(gy - realy0) / realyl * 500
        g.FillEllipse(Brushes.Yellow, x - ofs, y - ofs, pw, pw)
        g.DrawEllipse(pen, x - ofs, y - ofs, pw, pw)

        If CheckBox1.Checked = True Then
            Dim TempBmp As Bitmap = New Bitmap(500, 500)
            sita = sita * PI / 180
            Dim cx1 As Integer = (-250) * Cos(sita) - (-250) * Sin(sita) + 250
            Dim cy1 As Integer = (-250) * Sin(sita) + (-250) * Cos(sita) + 250
            Dim cx2 As Integer = (250) * Cos(sita) - (-250) * Sin(sita) + 250
            Dim cy2 As Integer = (250) * Sin(sita) + (-250) * Cos(sita) + 250
            Dim cx3 As Integer = (-250) * Cos(sita) - (250) * Sin(sita) + 250
            Dim cy3 As Integer = (-250) * Sin(sita) + (250) * Cos(sita) + 250

            Dim g2 As Graphics = Graphics.FromImage(TempBmp)
            Dim destinationPoints() As Point
            destinationPoints = New Point() {New Point(cx1, cy1),
                            New Point(cx2, cy2),
                            New Point(cx3, cy3)}
            g2.DrawImage(MapBmp, destinationPoints)
            g2.Dispose()
            PictureBox1.Image = TempBmp
        Else
            PictureBox1.Image = MapBmp
        End If

        pen.Dispose()
        g.Dispose()

        Dim dl As Double = Math.Sqrt((TrackX(TrackPnt) - gx) ^ 2 + (TrackY(TrackPnt) - gy) ^ 2)
        If dl > 0.00001 Then
            TrackPnt += 1
            If TrackPnt > 5 Then TrackPnt = 0
            TrackX(TrackPnt) = gx : TrackY(TrackPnt) = gy
            rcnt = rcnt + 1
            NaviValid_flg = True
        Else
            If dl < 0.0000001 Then
                NaviValid_flg = False
            End If
        End If

    End Sub

    Private Sub PolarDraw(ByVal vlist As List(Of String))   '天空図更新

        Dim g As Graphics = Graphics.FromImage(PolarBmp)
        Dim pen As New Pen(Color.Black, 1)
        Dim objFont = New Font("ＭＳ Ｐゴシック", 10)
        Dim x As Integer
        Dim y As Integer
        Dim x0 As Single = pctPolar.Width / 2
        Dim y0 As Single = pctPolar.Height / 2
        pctPolar.Image = PolarBmp

        g.FillRectangle(Brushes.Gainsboro, 0, 0, pctPolar.Width - 1, pctPolar.Height - 1)
        g.DrawRectangle(pen, 0, 0, pctPolar.Width - 1, pctPolar.Height - 1)
        g.DrawLine(pen, 0, y0, pctPolar.Width, y0)
        g.DrawLine(pen, x0, 0, x0, pctPolar.Height)
        g.DrawEllipse(pen, x0 - 90, y0 - 90, 180, 180)
        g.DrawEllipse(pen, x0 - 45, y0 - 45, 90, 90)
        g.DrawString("N", objFont, Brushes.Navy, x0, 2)

        Dim ofx As Integer = pctPolar.Width / 2
        Dim ofy As Integer = pctPolar.Height / 2
        Dim pw As Integer = 8
        Dim ofs As Integer = Int(pw / 2)

        Dim Az As Double = 0
        Dim Ed As Double = 90
        Dim satID As String
        Dim fixID As String

        ListBox1.Items.Clear()

        For Each satID In listView
            Dim sID As Integer = Integer.Parse(satID)
            Dim IDSN As String = String.Format("{0} {1}", satID, SV(sID).SN.ToString)
            ListBox1.Items.Add(IDSN)

            Ed = SV(sID).Ed
            Az = SV(sID).Az

            x = (90 - Ed) * Math.Sin(Az * Math.PI / 180)
            y = (90 - Ed) * Math.Cos(Az * Math.PI / 180)

            If listFix.Contains(satID) = True Then
                g.FillRectangle(Brushes.Red, x + ofx - ofs, -y + ofy - ofs, pw, pw)
                g.DrawString(satID, objFont, Brushes.Red, x + ofx, -y + ofy)
            Else
                g.FillRectangle(Brushes.Green, x + ofx - ofs, -y + ofy - ofs, pw, pw)
                g.DrawString(satID, objFont, Brushes.Green, x + ofx, -y + ofy)
            End If
        Next

        ListBox2.Items.Clear()
        For Each fixID In listFix
            ListBox2.Items.Add(fixID)
        Next
        Call SnDraw()

        pen.Dispose()
        g.Dispose()
        objFont.Dispose()

    End Sub

    Private Sub SnDraw()                'SN比グラフ更新

        Dim g As Graphics = Graphics.FromImage(SnBmp)
        Dim pen As New Pen(Color.Black, 1)
        Dim objFont = New Font("ＭＳ Ｐゴシック", 9)
        Dim x As Integer
        Dim y As Integer
        Dim barX0 As Integer = pctSN.Width * 0.1
        Dim barLen As Integer = pctSN.Width - barX0
        Dim barWth As Integer = (pctSN.Height - 6) / listView.Count
        If barWth > 20 Then barWth = 20

        pctSN.Image = SnBmp

        g.FillRectangle(Brushes.Gainsboro, 0, 0, pctSN.Width - 1, pctSN.Height - 1)
        g.DrawRectangle(pen, 0, 0, pctSN.Width - 1, pctSN.Height - 1)
        g.DrawLine(pen, barX0, 0, barX0, pctSN.Height)

        Dim cnt As Integer = 0
        For Each satID As String In listView
            Dim sID As Integer = Integer.Parse(satID)
            Dim SN As Integer = SV(sID).SN

            x = barLen / 100 * SN
            y = cnt * barWth
            g.DrawString(satID, objFont, Brushes.Black, 2, y + 0)
            If listFix.Contains(satID) = True Then
                g.FillRectangle(Brushes.OrangeRed, barX0, y + 0, x, barWth)
            Else
                g.FillRectangle(Brushes.ForestGreen, barX0, y + 0, x, barWth)
            End If

            g.DrawRectangle(pen, barX0, y + 0, x, barWth)

                cnt += 1
        Next
        pen.Dispose()
        g.Dispose()
    End Sub

    Private Sub Navi(gx As Double, gy As Double)

        Dim x As Double() = New Double(5) {}
        Dim y As Double() = New Double(5) {}
        Dim i As Integer
        Dim pnt As Integer = TrackPnt

        For i = 5 To 1 Step -1
            x(i) = TrackX(pnt) : y(i) = TrackY(pnt)
            pnt -= 1
            If pnt < 1 Then pnt = 5
        Next

        Dim moveX As Double = x(5) - x(4)
        Dim moveY As Double = y(5) - y(4)
        Dim toX As Double = TgtX - x(5)
        Dim toY As Double = TgtY - y(5)
        'Dim moveX As Double = gx - x(4)
        'Dim moveY As Double = gy - y(4)
        'Dim toX As Double = TgtX - gx
        'Dim toY As Double = TgtY - gy

        Dim disx_g As Double = 93 / realxl * toX
        Dim disy_g As Double = 93 / realyl * toY

        Dim distance_m As Double = Math.Sqrt(disx_g ^ 2 + disy_g ^ 2)

        If rcnt > 2 Then
            Dim deg As Double = NaviDeg(moveX, moveY, toX, toY)

            If NaviValid_flg = True Then
                lblNaviDeg.Text = deg.ToString("####.0" + " °")
                lblDistance.Text = distance_m.ToString("####.0" + "m")
            Else
                'lblNaviDeg.Text = ""
            End If
        End If
    End Sub

    Private Function NaviDeg(x1 As Double, y1 As Double, x2 As Double, y2 As Double) As Double

        Dim xy As Double = x1 * x2 + y1 * y2    '内積
        Dim S As Double = x1 * y2 - y1 * x2     '方向　右回り-、左回り+
        Dim sign As Integer = Math.Sign(S)

        Dim l1 As Double = Math.Sqrt(x1 ^ 2 + y1 ^ 2)
        Dim l2 As Double = Math.Sqrt(x2 ^ 2 + y2 ^ 2)

        Dim a As Double = xy / l1 / l2
        Dim deg As Double = Math.Acos(a) * 180 / Math.PI

        Return deg * -sign     '右回りを＋とする

    End Function


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TgtOn_flg = False Then
            TgtSchng_flg = True
            Button2.Enabled = False
            MapRotateOn_flg = False
            CheckBox1.Checked = False
        Else
            TgtOn_flg = False
            Button2.Text = "目標設定"

            Dim g As Graphics = Graphics.FromImage(MapBmp)
            g.DrawImage(TrimBmp, TrimX, TrimY)                  '元画像を上書きしてマーカーを消す
        End If

    End Sub

    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        If TgtSchng_flg = False Then Exit Sub
        Me.Cursor = Cursors.Cross
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If sr.Peek() > -1 Then ' And cnt < 10 Then
            Dim sData As String
            sData = sr.ReadLine()
            TextBox1.Text = sData
            cnt = cnt + 1
            'Console.WriteLine("{0} ,{1}", cnt, sData)

            If TextBox1.Text.Length = 0 Then                '送信データが無ければエラー
                MessageBox.Show(" ", "文字列入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub                '処理を抜ける
            End If

            Try
                'SerialPort1.WriteLine(TextBox1.Text)    '送信バッファにデータ書き込み

                'シリアルデータ受信
                Dim ReceivedData As String = " "
                ReceivedData = sData     'データ受信

                'Dim dele As New DataDelegate(AddressOf PrintData)
                'Me.Invoke(dele, ReceivedData)

                Call Analyze(ReceivedData)


            Catch ex As Exception           '例外処理            
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            sr.Close()
            sr.Dispose()
            Timer1.Enabled = False
            cnt = 0
            MessageBox.Show("送信完了しました。")
            'Button3.Enabled = True
            Button2.Enabled = True
        End If
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        If TgtSchng_flg = False Then Exit Sub

        TgtSchng_flg = False
        TgtOn_flg = True
        Button2.Text = "目標解除" : Button2.Enabled = True
        Me.Cursor = Cursors.Default
        Dim g As Graphics = Graphics.FromImage(MapBmp)

        Dim srcRect = New Rectangle(e.X - 5, e.Y - 5, 11, 11)   'マーカーを置く前に元を切り抜いておく
        TrimBmp = MapBmp.Clone(srcRect, MapBmp.PixelFormat)
        TrimX = e.X - 5 : TrimY = e.Y - 5

        g.DrawEllipse(Pens.DeepPink, e.X - 5, e.Y - 5, 10, 10)  'マーカー配置
        TgtX = e.X / 500 * realxl + realx0
        TgtY = -e.Y / 500 * realyl + realy0
    End Sub
End Class
