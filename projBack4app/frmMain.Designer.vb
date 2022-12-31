<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvProduct = New System.Windows.Forms.DataGridView()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnRecordRefresh = New System.Windows.Forms.Button()
        Me.btnRecordDelete = New System.Windows.Forms.Button()
        Me.dtpProduction = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvProductionRecord = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnReportGroupBy = New System.Windows.Forms.Button()
        Me.lblDateRange = New System.Windows.Forms.Label()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.btnRangeSearch = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvRangeRecords = New System.Windows.Forms.DataGridView()
        CType(Me.dgvProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvProductionRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvRangeRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(7, 462)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(135, 59)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "btnAdd"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgvProduct
        '
        Me.dgvProduct.AllowUserToAddRows = False
        Me.dgvProduct.AllowUserToDeleteRows = False
        Me.dgvProduct.AllowUserToOrderColumns = True
        Me.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProduct.Location = New System.Drawing.Point(5, 5)
        Me.dgvProduct.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvProduct.Name = "dgvProduct"
        Me.dgvProduct.ReadOnly = True
        Me.dgvProduct.RowHeadersWidth = 51
        Me.dgvProduct.RowTemplate.Height = 27
        Me.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProduct.Size = New System.Drawing.Size(1188, 451)
        Me.dgvProduct.TabIndex = 1
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(149, 462)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(135, 59)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "btnRefresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("PMingLiU", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1208, 565)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvProduct)
        Me.TabPage1.Controls.Add(Me.btnRefresh)
        Me.TabPage1.Controls.Add(Me.btnAdd)
        Me.TabPage1.Location = New System.Drawing.Point(4, 33)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Size = New System.Drawing.Size(1200, 528)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnSearch)
        Me.TabPage2.Controls.Add(Me.btnRecordRefresh)
        Me.TabPage2.Controls.Add(Me.btnRecordDelete)
        Me.TabPage2.Controls.Add(Me.dtpProduction)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.dgvProductionRecord)
        Me.TabPage2.Location = New System.Drawing.Point(4, 33)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Size = New System.Drawing.Size(1200, 528)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(401, 8)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(95, 32)
        Me.btnSearch.TabIndex = 7
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnRecordRefresh
        '
        Me.btnRecordRefresh.Location = New System.Drawing.Point(149, 462)
        Me.btnRecordRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRecordRefresh.Name = "btnRecordRefresh"
        Me.btnRecordRefresh.Size = New System.Drawing.Size(135, 59)
        Me.btnRecordRefresh.TabIndex = 6
        Me.btnRecordRefresh.Text = "btnRecordRefresh"
        Me.btnRecordRefresh.UseVisualStyleBackColor = True
        '
        'btnRecordDelete
        '
        Me.btnRecordDelete.Location = New System.Drawing.Point(7, 462)
        Me.btnRecordDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRecordDelete.Name = "btnRecordDelete"
        Me.btnRecordDelete.Size = New System.Drawing.Size(135, 59)
        Me.btnRecordDelete.TabIndex = 5
        Me.btnRecordDelete.Text = "btnRecordDelete"
        Me.btnRecordDelete.UseVisualStyleBackColor = True
        '
        'dtpProduction
        '
        Me.dtpProduction.Location = New System.Drawing.Point(195, 8)
        Me.dtpProduction.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpProduction.Name = "dtpProduction"
        Me.dtpProduction.Size = New System.Drawing.Size(200, 35)
        Me.dtpProduction.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Production Date:"
        '
        'dgvProductionRecord
        '
        Me.dgvProductionRecord.AllowUserToAddRows = False
        Me.dgvProductionRecord.AllowUserToDeleteRows = False
        Me.dgvProductionRecord.AllowUserToOrderColumns = True
        Me.dgvProductionRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductionRecord.Location = New System.Drawing.Point(5, 50)
        Me.dgvProductionRecord.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvProductionRecord.Name = "dgvProductionRecord"
        Me.dgvProductionRecord.ReadOnly = True
        Me.dgvProductionRecord.RowHeadersWidth = 51
        Me.dgvProductionRecord.RowTemplate.Height = 27
        Me.dgvProductionRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductionRecord.Size = New System.Drawing.Size(1188, 406)
        Me.dgvProductionRecord.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnReportGroupBy)
        Me.TabPage3.Controls.Add(Me.lblDateRange)
        Me.TabPage3.Controls.Add(Me.btnReport)
        Me.TabPage3.Controls.Add(Me.btnRangeSearch)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.dgvRangeRecords)
        Me.TabPage3.Location = New System.Drawing.Point(4, 33)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage3.Size = New System.Drawing.Size(1200, 528)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnReportGroupBy
        '
        Me.btnReportGroupBy.Location = New System.Drawing.Point(855, 13)
        Me.btnReportGroupBy.Name = "btnReportGroupBy"
        Me.btnReportGroupBy.Size = New System.Drawing.Size(183, 45)
        Me.btnReportGroupBy.TabIndex = 18
        Me.btnReportGroupBy.Text = "Report Groupby"
        Me.btnReportGroupBy.UseVisualStyleBackColor = True
        '
        'lblDateRange
        '
        Me.lblDateRange.AutoSize = True
        Me.lblDateRange.Location = New System.Drawing.Point(244, 18)
        Me.lblDateRange.Name = "lblDateRange"
        Me.lblDateRange.Size = New System.Drawing.Size(0, 23)
        Me.lblDateRange.TabIndex = 17
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(740, 14)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(109, 44)
        Me.btnReport.TabIndex = 16
        Me.btnReport.Text = "Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'btnRangeSearch
        '
        Me.btnRangeSearch.Location = New System.Drawing.Point(1044, 12)
        Me.btnRangeSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRangeSearch.Name = "btnRangeSearch"
        Me.btnRangeSearch.Size = New System.Drawing.Size(132, 46)
        Me.btnRangeSearch.TabIndex = 11
        Me.btnRangeSearch.Text = "Search ..."
        Me.btnRangeSearch.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(222, 23)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Production Date Range:"
        '
        'dgvRangeRecords
        '
        Me.dgvRangeRecords.AllowUserToAddRows = False
        Me.dgvRangeRecords.AllowUserToDeleteRows = False
        Me.dgvRangeRecords.AllowUserToOrderColumns = True
        Me.dgvRangeRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRangeRecords.Location = New System.Drawing.Point(7, 63)
        Me.dgvRangeRecords.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvRangeRecords.Name = "dgvRangeRecords"
        Me.dgvRangeRecords.ReadOnly = True
        Me.dgvRangeRecords.RowHeadersWidth = 51
        Me.dgvRangeRecords.RowTemplate.Height = 27
        Me.dgvRangeRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRangeRecords.Size = New System.Drawing.Size(1188, 460)
        Me.dgvRangeRecords.TabIndex = 8
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1232, 602)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.dgvProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvProductionRecord, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgvRangeRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAdd As Button
    Friend WithEvents dgvProduct As DataGridView
    Friend WithEvents btnRefresh As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnRecordRefresh As Button
    Friend WithEvents btnRecordDelete As Button
    Friend WithEvents dtpProduction As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvProductionRecord As DataGridView
    Friend WithEvents btnSearch As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btnRangeSearch As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvRangeRecords As DataGridView
    Friend WithEvents btnReport As Button
    Friend WithEvents lblDateRange As Label
    Friend WithEvents btnReportGroupBy As Button
End Class
