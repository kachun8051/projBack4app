<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgDateRange
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
        Me.cbxPeriod = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbxPeriod
        '
        Me.cbxPeriod.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbxPeriod.FormattingEnabled = True
        Me.cbxPeriod.Location = New System.Drawing.Point(76, 163)
        Me.cbxPeriod.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxPeriod.Name = "cbxPeriod"
        Me.cbxPeriod.Size = New System.Drawing.Size(191, 28)
        Me.cbxPeriod.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 24)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 24)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "From"
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpTo.Location = New System.Drawing.Point(76, 108)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(191, 31)
        Me.dtpTo.TabIndex = 18
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dtpFrom.Location = New System.Drawing.Point(76, 61)
        Me.dtpFrom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(191, 31)
        Me.dtpFrom.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 28)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Production Date Range:"
        '
        'btnOk
        '
        Me.btnOk.Font = New System.Drawing.Font("Calibri", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(128, 217)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(138, 49)
        Me.btnOk.TabIndex = 22
        Me.btnOk.Text = "Confirm"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'dlgDateRange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 285)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.cbxPeriod)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.Label2)
        Me.Name = "dlgDateRange"
        Me.Text = "dlgDateRange"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbxPeriod As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents btnOk As Button
End Class
