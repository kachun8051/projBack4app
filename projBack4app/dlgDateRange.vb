Public Class dlgDateRange

    Private m_startingDt, m_endingDt As Date

    Public ReadOnly Property startingDt() As Date
        Get
            'Dim m_startingDt As Date = dtpFrom.Value
            Return New Date(m_startingDt.Year, m_startingDt.Month, m_startingDt.Day, 0, 0, 0)
        End Get
    End Property

    Public ReadOnly Property endingDt() As Date
        Get
            'Dim m_endingdt As Date = dtpTo.Value
            Return New Date(m_endingdt.Year, m_endingdt.Month, m_endingdt.Day, 0, 0, 0)
        End Get
    End Property

    Public Function getRangeInString() As String
        If isTwoDatesSame(m_startingDt, m_endingDt) Then
            Return m_startingDt.Year & "/" &
                m_startingDt.Month.ToString.PadLeft(2, "0") & "/" &
                m_startingDt.Day.ToString.PadLeft(2, "0") & " (Daily)"
        End If
        Dim dt_1 As String = m_startingDt.Year & "/" &
                m_startingDt.Month.ToString.PadLeft(2, "0") & "/" &
                m_startingDt.Day.ToString.PadLeft(2, "0")
        Dim dt_2 As String = m_endingDt.Year & "/" &
                m_endingDt.Month.ToString.PadLeft(2, "0") & "/" &
                m_endingDt.Day.ToString.PadLeft(2, "0")
        If isTwoDatesAWeek(m_startingDt, m_endingDt) Then
            Return "From " & dt_1 & " To " & dt_2 & " (Weekly)"
        End If
        If isTwoDatesAMonth(m_startingDt, m_endingDt) Then
            Return "From " & dt_1 & " To " & dt_2 & " (Monthly)"
        End If
        Return "From " & dt_1 & " To " & dt_2
    End Function

    Private Sub dlgDateRange_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim lstPeriod As List(Of String) = New List(Of String)({"Period...", "Monthly", "Weekly", "Daily"})
        For Each str As String In lstPeriod
            cbxPeriod.Items.Add(str)
        Next
        cbxPeriod.SelectedIndex = 0
    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If m_startingDt <= m_endingDt Then
            Me.DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub cbxPeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPeriod.SelectedIndexChanged
        Dim dt As Date = dtpFrom.Value
        Select Case cbxPeriod.SelectedIndex
            Case 1 ' Monthly
                dtpFrom.Value = modCommon.FirstDayOfMonth(dt)
                dtpTo.Value = modCommon.LastDayOfMonth(dt)
            Case 2 ' Weekly
                dtpFrom.Value = modCommon.FirstDayOfWeek(dt)
                dtpTo.Value = modCommon.LastDayOfWeek(dt)
            Case 3 ' Daily
                dtpFrom.Value = dt
                dtpTo.Value = dt
        End Select
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        m_endingDt = dtpTo.Value
        Diagnostics.Debug.WriteLine("endingDt: " & dtpTo.Value)
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        m_startingDt = dtpFrom.Value
        Diagnostics.Debug.WriteLine("startingDt: " & dtpFrom.Value)
    End Sub

    Private Function isTwoDatesSame(dt1 As DateTime, dt2 As DateTime) As Boolean
        If dt1.Day <> dt2.Day Then
            Return False
        End If
        If dt1.Month <> dt2.Month Then
            Return False
        End If
        If dt1.Year <> dt2.Year Then
            Return False
        End If
        Return True
    End Function

    Private Function isTwoDatesAMonth(dt1 As DateTime, dt2 As DateTime) As Boolean
        Dim date_1 As DateTime = New DateTime(dt1.Year, dt1.Month, dt1.Day, 0, 0, 0)
        Dim date_2 As DateTime = New DateTime(dt2.Year, dt2.Month, dt2.Day, 0, 0, 0)
        If date_1.AddMonths(1).AddDays(-1) = date_2 Then
            Return True
        End If
        Return False
    End Function

    Private Function isTwoDatesAWeek(dt1 As DateTime, dt2 As DateTime) As Boolean
        Dim date_1 As DateTime = New DateTime(dt1.Year, dt1.Month, dt1.Day, 0, 0, 0)
        Dim date_2 As DateTime = New DateTime(dt2.Year, dt2.Month, dt2.Day, 0, 0, 0)
        If date_1.AddDays(6) = date_2 Then
            Return True
        End If
        Return False
    End Function

End Class