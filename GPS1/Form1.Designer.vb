<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbPortName = New System.Windows.Forms.ComboBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.lbl_Lati = New System.Windows.Forms.Label()
        Me.lbl_Lon = New System.Windows.Forms.Label()
        Me.lbl_cTime = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pctPolar = New System.Windows.Forms.PictureBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.pctSN = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDistance = New System.Windows.Forms.Label()
        Me.lblNaviDeg = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctPolar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctSN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(604, 10)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 25)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Sポート検索"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbPortName
        '
        Me.cmbPortName.FormattingEnabled = True
        Me.cmbPortName.Location = New System.Drawing.Point(686, 14)
        Me.cmbPortName.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cmbPortName.Name = "cmbPortName"
        Me.cmbPortName.Size = New System.Drawing.Size(126, 20)
        Me.cmbPortName.TabIndex = 1
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 4800
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(88, 6)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(476, 19)
        Me.TextBox1.TabIndex = 3
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(9, 6)
        Me.Button4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(74, 26)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "受信開始"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'lbl_Lati
        '
        Me.lbl_Lati.AutoSize = True
        Me.lbl_Lati.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_Lati.Location = New System.Drawing.Point(9, 77)
        Me.lbl_Lati.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Lati.Name = "lbl_Lati"
        Me.lbl_Lati.Size = New System.Drawing.Size(52, 16)
        Me.lbl_Lati.TabIndex = 7
        Me.lbl_Lati.Text = "Label1"
        '
        'lbl_Lon
        '
        Me.lbl_Lon.AutoSize = True
        Me.lbl_Lon.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_Lon.Location = New System.Drawing.Point(9, 103)
        Me.lbl_Lon.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_Lon.Name = "lbl_Lon"
        Me.lbl_Lon.Size = New System.Drawing.Size(52, 16)
        Me.lbl_Lon.TabIndex = 8
        Me.lbl_Lon.Text = "Label1"
        '
        'lbl_cTime
        '
        Me.lbl_cTime.AutoSize = True
        Me.lbl_cTime.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbl_cTime.Location = New System.Drawing.Point(9, 126)
        Me.lbl_cTime.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_cTime.Name = "lbl_cTime"
        Me.lbl_cTime.Size = New System.Drawing.Size(52, 16)
        Me.lbl_cTime.TabIndex = 9
        Me.lbl_cTime.Text = "Label1"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(693, 126)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(40, 172)
        Me.ListBox1.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(188, 126)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(500, 500)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'pctPolar
        '
        Me.pctPolar.Location = New System.Drawing.Point(9, 350)
        Me.pctPolar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pctPolar.Name = "pctPolar"
        Me.pctPolar.Size = New System.Drawing.Size(165, 176)
        Me.pctPolar.TabIndex = 13
        Me.pctPolar.TabStop = False
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 12
        Me.ListBox2.Location = New System.Drawing.Point(736, 126)
        Me.ListBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(40, 172)
        Me.ListBox2.TabIndex = 14
        '
        'pctSN
        '
        Me.pctSN.Location = New System.Drawing.Point(9, 164)
        Me.pctSN.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pctSN.Name = "pctSN"
        Me.pctSN.Size = New System.Drawing.Size(165, 171)
        Me.pctSN.TabIndex = 15
        Me.pctSN.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(188, 77)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 42)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "目標地点設定"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblDistance)
        Me.GroupBox1.Controls.Add(Me.lblNaviDeg)
        Me.GroupBox1.Location = New System.Drawing.Point(308, 39)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(255, 82)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Navigation"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 24)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "距離"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 24)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "方位"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDistance
        '
        Me.lblDistance.AutoSize = True
        Me.lblDistance.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDistance.Location = New System.Drawing.Point(98, 50)
        Me.lblDistance.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDistance.Name = "lblDistance"
        Me.lblDistance.Size = New System.Drawing.Size(75, 24)
        Me.lblDistance.TabIndex = 22
        Me.lblDistance.Text = "Label1"
        Me.lblDistance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNaviDeg
        '
        Me.lblNaviDeg.AutoSize = True
        Me.lblNaviDeg.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNaviDeg.Location = New System.Drawing.Point(98, 26)
        Me.lblNaviDeg.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblNaviDeg.Name = "lblNaviDeg"
        Me.lblNaviDeg.Size = New System.Drawing.Size(75, 24)
        Me.lblNaviDeg.TabIndex = 21
        Me.lblNaviDeg.Text = "Label1"
        Me.lblNaviDeg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(190, 38)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 19)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Label3"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(106, 138)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(64, 16)
        Me.CheckBox1.TabIndex = 23
        Me.CheckBox1.Text = "回転ON"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1079, 637)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.pctSN)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.pctPolar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.lbl_cTime)
        Me.Controls.Add(Me.lbl_Lon)
        Me.Controls.Add(Me.lbl_Lati)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cmbPortName)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctPolar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctSN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents cmbPortName As ComboBox
    Friend WithEvents SerialPort1 As SerialPort
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents lbl_Lati As Label
    Friend WithEvents lbl_Lon As Label
    Friend WithEvents lbl_cTime As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pctPolar As PictureBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents pctSN As PictureBox
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDistance As Label
    Friend WithEvents lblNaviDeg As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Timer1 As Timer
End Class
