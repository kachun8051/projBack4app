<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvProduct = New System.Windows.Forms.DataGridView()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemnum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemStdWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemuom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemprice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(13, 460)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(135, 59)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Button1"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgvProduct
        '
        Me.dgvProduct.AllowUserToAddRows = False
        Me.dgvProduct.AllowUserToDeleteRows = False
        Me.dgvProduct.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProduct.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProduct.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colItemnum, Me.colItemname, Me.colItemStdWeight, Me.colItemuom, Me.colItemprice})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProduct.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProduct.Location = New System.Drawing.Point(15, 15)
        Me.dgvProduct.Name = "dgvProduct"
        Me.dgvProduct.ReadOnly = True
        Me.dgvProduct.RowHeadersWidth = 51
        Me.dgvProduct.RowTemplate.Height = 27
        Me.dgvProduct.Size = New System.Drawing.Size(1030, 440)
        Me.dgvProduct.TabIndex = 1
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(192, 460)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(135, 59)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "Button2"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'colId
        '
        Me.colId.DataPropertyName = "id"
        Me.colId.HeaderText = "Id"
        Me.colId.MinimumWidth = 6
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        '
        'colItemnum
        '
        Me.colItemnum.DataPropertyName = "itemnum"
        Me.colItemnum.HeaderText = "Item No."
        Me.colItemnum.MinimumWidth = 6
        Me.colItemnum.Name = "colItemnum"
        Me.colItemnum.ReadOnly = True
        Me.colItemnum.Width = 125
        '
        'colItemname
        '
        Me.colItemname.DataPropertyName = "itemname"
        Me.colItemname.HeaderText = "Item Name"
        Me.colItemname.MinimumWidth = 6
        Me.colItemname.Name = "colItemname"
        Me.colItemname.ReadOnly = True
        Me.colItemname.Width = 300
        '
        'colItemStdWeight
        '
        Me.colItemStdWeight.DataPropertyName = "standardweight"
        Me.colItemStdWeight.HeaderText = "Standard weight"
        Me.colItemStdWeight.MinimumWidth = 6
        Me.colItemStdWeight.Name = "colItemStdWeight"
        Me.colItemStdWeight.ReadOnly = True
        Me.colItemStdWeight.Width = 200
        '
        'colItemuom
        '
        Me.colItemuom.DataPropertyName = "uom"
        Me.colItemuom.HeaderText = "Unit"
        Me.colItemuom.MinimumWidth = 6
        Me.colItemuom.Name = "colItemuom"
        Me.colItemuom.ReadOnly = True
        Me.colItemuom.Width = 125
        '
        'colItemprice
        '
        Me.colItemprice.DataPropertyName = "price"
        Me.colItemprice.HeaderText = "Unit Price"
        Me.colItemprice.MinimumWidth = 6
        Me.colItemprice.Name = "colItemprice"
        Me.colItemprice.ReadOnly = True
        Me.colItemprice.Width = 125
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 562)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.dgvProduct)
        Me.Controls.Add(Me.btnAdd)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dgvProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAdd As Button
    Friend WithEvents dgvProduct As DataGridView
    Friend WithEvents btnRefresh As Button
    Friend WithEvents colId As DataGridViewTextBoxColumn
    Friend WithEvents colItemnum As DataGridViewTextBoxColumn
    Friend WithEvents colItemname As DataGridViewTextBoxColumn
    Friend WithEvents colItemStdWeight As DataGridViewTextBoxColumn
    Friend WithEvents colItemuom As DataGridViewTextBoxColumn
    Friend WithEvents colItemprice As DataGridViewTextBoxColumn
End Class
