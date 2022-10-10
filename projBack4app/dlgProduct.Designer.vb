<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgProduct
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
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.cbxUom = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtItemnum = New System.Windows.Forms.TextBox()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.txtStdWeight = New System.Windows.Forms.TextBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.txtDesc2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtObjectId = New System.Windows.Forms.TextBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("PMingLiU", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 264)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 21)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "Item price:"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(73, 22)
        Me.lblTitle.TabIndex = 46
        Me.lblTitle.Text = "Product"
        '
        'cbxUom
        '
        Me.cbxUom.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.cbxUom.FormattingEnabled = True
        Me.cbxUom.Location = New System.Drawing.Point(208, 175)
        Me.cbxUom.Name = "cbxUom"
        Me.cbxUom.Size = New System.Drawing.Size(220, 29)
        Me.cbxUom.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("PMingLiU", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(190, 21)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Item Standard Weight:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 21)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Unit of Measure:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("PMingLiU", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 21)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Item Number:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 21)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Item Description:"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("PMingLiU", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSave.Location = New System.Drawing.Point(459, 231)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(123, 59)
        Me.btnSave.TabIndex = 34
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtItemnum
        '
        Me.txtItemnum.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.txtItemnum.Location = New System.Drawing.Point(208, 46)
        Me.txtItemnum.Name = "txtItemnum"
        Me.txtItemnum.Size = New System.Drawing.Size(124, 33)
        Me.txtItemnum.TabIndex = 50
        '
        'txtDesc
        '
        Me.txtDesc.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.txtDesc.Location = New System.Drawing.Point(208, 89)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(374, 33)
        Me.txtDesc.TabIndex = 51
        '
        'txtStdWeight
        '
        Me.txtStdWeight.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.txtStdWeight.Location = New System.Drawing.Point(208, 214)
        Me.txtStdWeight.Name = "txtStdWeight"
        Me.txtStdWeight.Size = New System.Drawing.Size(124, 33)
        Me.txtStdWeight.TabIndex = 52
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.txtPrice.Location = New System.Drawing.Point(208, 257)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(124, 33)
        Me.txtPrice.TabIndex = 53
        '
        'txtDesc2
        '
        Me.txtDesc2.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.txtDesc2.Location = New System.Drawing.Point(208, 132)
        Me.txtDesc2.Name = "txtDesc2"
        Me.txtDesc2.Size = New System.Drawing.Size(374, 33)
        Me.txtDesc2.TabIndex = 55
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("PMingLiU", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 21)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Item Description 2:"
        '
        'txtObjectId
        '
        Me.txtObjectId.Enabled = False
        Me.txtObjectId.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.txtObjectId.Location = New System.Drawing.Point(405, 10)
        Me.txtObjectId.Name = "txtObjectId"
        Me.txtObjectId.Size = New System.Drawing.Size(217, 33)
        Me.txtObjectId.TabIndex = 56
        '
        'dlgProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 311)
        Me.Controls.Add(Me.txtObjectId)
        Me.Controls.Add(Me.txtDesc2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.txtStdWeight)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.txtItemnum)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.cbxUom)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "dlgProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dlgProduct"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Label8 As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents cbxUom As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents txtDesc As TextBox
    Friend WithEvents txtItemnum As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtStdWeight As TextBox
    Friend WithEvents txtDesc2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtObjectId As TextBox
End Class
