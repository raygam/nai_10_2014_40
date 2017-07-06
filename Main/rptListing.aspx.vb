Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Net.Mail


Partial Class Main_rptListing

    Inherits System.Web.UI.Page



    Function CalcCurrentUSUK() As String
        Return "(" & CalcBeginUSUK() & " - " & CalcEndUSUK() & ")"
    End Function


    Function CalcCurrentSA() As String
        Return "(" & CalcBeginSA() & " - " & CalcEndSA() & ")"
    End Function


    Function CalcCurrentAKS() As String
        Return "(" & CalcBeginSA() & " - " & CalcEndSA() & ")"
    End Function


    Function CalcCurrentAdd() As String
        Return "(" & CalcBeginAdd() & " - " & CalcEndAdd() & ")"
    End Function


    Function CalcArchiveUSUK() As String
        Return "(Prior to " & CalcBeginUSUK() & ")"
    End Function


    Function CalcArchiveSA() As String
        Return "(Prior to " & CalcBeginSA() & ")"
    End Function


    Function CalcArchiveAKS() As String
        Return "(Prior to " & CalcBeginSA() & ")"
    End Function


    Function CalcArchiveAdd() As String
        Return "(Prior to " & CalcBeginAdd() & ")"
    End Function


    Function CalcBeginUSUK() As String
        Dim x As Integer
        Dim y As Integer
        x = DatePart(DateInterval.Weekday, DateValue(Now()))
        Select Case x
            Case 1
                y = 4
            Case 2
                y = 3
            Case 3
                y = 2
            Case 4
                y = 1
            Case 5
                y = 0
            Case 6
                y = 6
            Case 7
                y = 5
        End Select
        Return DateAdd("d", -6, DateAdd(DateInterval.Day, y, DateValue(Now()))).ToString("MM/dd/yyyy")
    End Function


    Function CalcEndUSUK() As String
        Dim x As Integer
        Dim y As Integer
        x = DatePart(DateInterval.Weekday, DateValue(Now()))
        Select Case x
            Case 1
                y = 4
            Case 2
                y = 3
            Case 3
                y = 2
            Case 4
                y = 1
            Case 5
                y = 0
            Case 6
                y = 6
            Case 7
                y = 5
        End Select
        Return DateAdd(DateInterval.Day, y, DateValue(Now())).ToString("MM/dd/yyyy")
    End Function


    Function CalcBeginSA() As String
        Dim x As Integer
        Dim y As Integer
        x = DatePart(DateInterval.Weekday, DateValue(Now()))
        Select Case x
            Case 1
                y = 3
            Case 2
                y = 2
            Case 3
                y = 1
            Case 4
                y = 0
            Case 5
                y = 6
            Case 6
                y = 5
            Case 7
                y = 4
        End Select
        Return DateAdd(DateInterval.Day, -6, DateAdd(DateInterval.Day, y, DateValue(Now()))).ToString("MM/dd/yyyy")
    End Function


    Function CalcEndSA() As String
        Dim x As Integer
        Dim y As Integer
        x = DatePart(DateInterval.Weekday, DateValue(Now()))
        Select Case x
            Case 1
                y = 3
            Case 2
                y = 2
            Case 3
                y = 1
            Case 4
                y = 0
            Case 5
                y = 6
            Case 6
                y = 5
            Case 7
                y = 4
        End Select
        Return DateAdd(DateInterval.Day, y, DateValue(Now())).ToString("MM/dd/yyyy")
    End Function


    Function CalcBeginAdd() As Date
        Return DateAdd(DateInterval.Day, -7, CalcEndAdd())
    End Function


    Function CalcEndAdd() As Date
        Dim datValue As Date
        Dim x As Integer
        x = DatePart(DateInterval.Weekday, DateValue(Now()))
        Select Case x
            Case 1
                datValue = CalcEndUSUK()
            Case 2
                datValue = CalcEndUSUK()
            Case 3
                datValue = CalcEndUSUK()
            Case 4
                datValue = CalcEndUSUK()
            Case 5
                datValue = CalcEndSA()
            Case 6
                datValue = CalcEndUSUK()
            Case 7
                datValue = CalcEndUSUK()
            Case Else
                datValue = DateValue(Now())
        End Select

        Return datValue
    End Function


    Function GetCurrentCircuitDesc(p_circuit As String) As String
        Dim strDesc As String = ""

        Select Case p_circuit
            Case "USA"
                strDesc = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a HREF='rptListing.aspx?circuit=USA&time=1'><b>US Circuit   &nbsp;&nbsp;<font SIZE='1'>" & CalcCurrentUSUK() & "</font></b></a>"
            Case "UK"
                strDesc = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a HREF='rptListing.aspx?circuit=UK&time=1'><b>UK Circuit   &nbsp;&nbsp;<font SIZE='1'>" & CalcCurrentUSUK() & "</font></b></a>"
            Case "SA"
                strDesc = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a HREF='rptListing.aspx?circuit=SA&time=1''><b>South American Circuit    &nbsp;&nbsp;<font SIZE='1'>" & CalcCurrentSA() & "</font></b></a>"
            Case "ABZ"
                strDesc = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a HREF='rptListing.aspx?circuit=ABZ&time=1''><b>Brazil Circuit    &nbsp;&nbsp;<font SIZE='1'>" & CalcCurrentUSUK() & "</font></b></a>"
            Case "GROSS"
                strDesc = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a HREF='rptListing.aspx?circuit=GROSS&time=1''><b>Gross Sheets (All Circuits)   &nbsp;&nbsp;<font SIZE='1'>" & CalcCurrentAdd() & "</font></b></a>"
            Case Else
                strDesc = ""
        End Select

        Return strDesc

    End Function


    Function GetArchiveCircuitDesc(p_circuit As String) As String
        Dim strDesc As String = ""

        Select Case p_circuit
            Case "USA"
                strDesc = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a HREF='rptListing.aspx?circuit=USA&time=2'><b>US Circuit   &nbsp;&nbsp;<font SIZE='1'>" & CalcArchiveUSUK() & "</font></b></a>"
            Case "UK"
                strDesc = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a HREF='rptListing.aspx?circuit=UK&time=2'><b>UK Circuit   &nbsp;&nbsp;<font SIZE='1'>" & CalcArchiveUSUK() & "</font></b></a>"
            Case "SA"
                strDesc = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a HREF='rptListing.aspx?circuit=SA&time=2''><b>South American Circuit    &nbsp;&nbsp;<font SIZE='1'>" & CalcArchiveSA() & "</font></b></a>"
            Case "ABZ"
                strDesc = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a HREF='rptListing.aspx?circuit=ABZ&time=2''><b>Brazil Circuit    &nbsp;&nbsp;<font SIZE='1'>" & CalcArchiveUSUK() & "</font></b></a>"
            Case "GROSS"
                strDesc = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a HREF='rptListing.aspx?circuit=GROSS&time=2''><b>Gross Sheets (All Circuits)   &nbsp;&nbsp;<font SIZE='1'>" & CalcArchiveAdd() & "</font></b></a>"
            Case "AKS"
                strDesc = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a HREF='rptListing.aspx?circuit=AKS&time=2'><b>Russian Circuit   &nbsp;&nbsp;<font SIZE='1'>" & CalcArchiveAKS() & "</font></b></a>"
            Case "MHC"
                strDesc = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a HREF='rptListing.aspx?circuit=MHC&time=2'><b>UK Hoyts Circuit   &nbsp;&nbsp;<font SIZE='1'>" & CalcArchiveUSUK() & "</font></b></a>"
            Case Else
                strDesc = ""
        End Select

        Return strDesc

    End Function


    Function getData(p_circuit As String, p_TimeFlag As String) As String
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim strReportList As String = ""
        Dim sql1, sql2, sql3, sql4 As String
        Dim strSQL As String = ""
        Dim fileURL As String = ""

        sql1 = "SELECT *  FROM rpt_file_data "
        sql2 = ""
        sql3 = " AND ReportGroup = '" & p_circuit & "'"
        sql4 = " ORDER BY End_Date DESC "


        Select Case p_circuit
            Case "USA"
                If p_TimeFlag = 1 Then
                    sql2 = "WHERE End_Date BETWEEN '" & CalcBeginUSUK() & "' AND '" & CalcEndUSUK() & "'"
                Else
                    sql2 = "WHERE End_Date BETWEEN '1/1/2012' AND '" & CalcBeginUSUK() & "'"
                    'sql2 = "WHERE End_Date < '" & CalcBeginUSUK() & "'"
                End If

            Case "UK"
                If p_TimeFlag = 1 Then
                    sql2 = "WHERE End_Date BETWEEN '" & CalcBeginUSUK() & "' AND '" & CalcEndUSUK() & "'"
                Else
                    sql2 = "WHERE End_Date BETWEEN '1/1/2012' AND '" & CalcBeginUSUK() & "'"
                    'sql2 = "WHERE End_Date < '" & CalcBeginUSUK() & "'"
                End If

            Case "MHC"
                If p_TimeFlag = 1 Then
                    sql2 = "WHERE End_Date BETWEEN '" & CalcBeginUSUK() & "' AND '" & CalcEndUSUK() & "'"
                Else
                    sql2 = "WHERE End_Date < '" & CalcBeginUSUK() & "'"
                End If

            Case "SA"
                If p_TimeFlag = 1 Then
                    sql2 = "WHERE End_Date BETWEEN '" & CalcBeginSA() & "' AND '" & CalcEndSA() & "'"
                Else
                    sql2 = "WHERE End_Date BETWEEN '1/1/2012' AND '" & CalcBeginSA() & "'"
                    'sql2 = "WHERE End_Date < '" & CalcBeginSA() & "'"
                End If
                sql3 = " AND ReportGroup IN ( 'Chilean', 'Argentine', 'SA' ) "

            Case "AKS"
                If p_TimeFlag = 1 Then
                    sql2 = "WHERE End_Date BETWEEN '" & CalcBeginSA() & "' AND '" & CalcEndSA() & "'"
                Else
                    sql2 = "WHERE End_Date < '" & CalcBeginSA() & "'"
                End If

            Case "ABZ"
                If p_TimeFlag = 1 Then
                    sql2 = "WHERE End_Date BETWEEN '" & CalcBeginUSUK() & "' AND '" & CalcEndUSUK() & "'"
                Else
                    sql2 = "WHERE End_Date BETWEEN '1/1/2012' AND '" & CalcBeginUSUK() & "'"
                    'sql2 = "WHERE End_Date < '" & CalcBeginUSUK() & "'"
                End If
                sql3 = " AND ReportGroup = 'Brazil' "

            Case "GROSS"
                If p_TimeFlag = 1 Then
                    sql2 = "WHERE End_Date BETWEEN '" & CalcBeginAdd() & "' AND '" & CalcEndAdd() & "'"
                Else
                    sql2 = "WHERE End_Date BETWEEN '1/1/2012' AND '" & CalcBeginAdd() & "'"
                    'sql2 = "WHERE End_Date < '" & CalcBeginAdd() & "'"
                End If
                sql3 = " AND ReportGroup = 'Miscellaneous' "

            Case Else
                sql3 = " WHERE ReportGroup = '" & p_circuit & "'"

        End Select

        strSQL = sql1 & sql2 & sql3 & sql4

        Dim cmd As New SqlCommand(strSQL, cn)
        With cmd
            .CommandType = CommandType.Text
            .Connection = cn
        End With
        cn.Open()
        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        While rdr.Read()
            fileURL = rdr("web_url")
            strReportList = strReportList & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
            'strReportList = strReportList & "- <A HREF='' onClick=" & Chr(34) & "return OpenWindow('" & fileURL & "');" & Chr(34) & " onMouseOver=" & Chr(34) & "window.status='" & fileURL & "';return true;" & Chr(34) & " onMouseOut=" & Chr(34) & "window.status='';return true;" & Chr(34) & ">" & rdr("rpt_desc") & "  <b>" & rdr("End_Date") & "</b></a><br/>"
            strReportList = strReportList & "- <A HREF='" & fileURL & "' TARGET='_new'>" & rdr("rpt_desc") & "  <b>" & rdr("End_Date") & "</b></a><br/>"

        End While

        rdr.Close()

        Return strReportList

    End Function


    Sub GetReportList(strFlag As String, p_circuit As String, p_time As String)
        'Dim dt As DataTable = ds.Tables(0)
        Dim i As Int32 = 0
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim blnCss As Boolean = True
        Dim circuitArray(6) As String
        Dim circuit As Int32 = 0
        Dim archiveArray(8) As String
        Dim archive As Int32 = 0

        ' ***  LOAD CIRCUIT ARRAY
        circuitArray(0) = "USA"
        circuitArray(1) = "UK"
        circuitArray(2) = "SA"
        circuitArray(3) = "ABZ"
        circuitArray(4) = "GROSS"
        circuitArray(5) = ""


        ' ***   CURRENT PLAY WEEK REPORTS
        rowItem = New TableRow
        rowItem.CssClass = "GRID_HEADER"
        c1 = New TableCell
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = "<a HREF='rptListing.aspx?OpenFlg=43'><b><li>Current Play Week</li></b></a>"
        rowItem.Cells.Add(c1)
        rptTable.Rows.Add(rowItem)

        circuit = 0
        Do Until circuitArray(circuit) = ""

            rowItem = New TableRow
            rowItem.CssClass = "GRID_HEADER"
            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Left
            c1.Text = GetCurrentCircuitDesc(circuitArray(circuit))
            rowItem.Cells.Add(c1)
            rptTable.Rows.Add(rowItem)

            ' ***  SHOW REPORTS
            If p_circuit = circuitArray(circuit) And p_time = 1 Then
                rowItem = New TableRow
                rowItem.CssClass = "GRID_HEADER"
                c1 = New TableCell
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = getData(circuitArray(circuit), 1)
                rowItem.Cells.Add(c1)
                rptTable.Rows.Add(rowItem)
            End If

            circuit = circuit + 1

        Loop

        rowItem = New TableRow
        rowItem.CssClass = "GRID_HEADER"
        c1 = New TableCell
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = "&nbsp;"
        rowItem.Cells.Add(c1)
        rptTable.Rows.Add(rowItem)



        ' ***  LOAD ARCHIVE ARRAY
        archiveArray(0) = "USA"
        archiveArray(1) = "UK"
        archiveArray(2) = "MHC"
        archiveArray(3) = "SA"
        archiveArray(4) = "AKS"
        archiveArray(5) = "ABZ"
        archiveArray(6) = "GROSS"
        archiveArray(7) = ""


        ' ***       ARCHIVE REPORTS
        rowItem = New TableRow
        rowItem.CssClass = "GRID_HEADER"
        c1 = New TableCell
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = "<a HREF='rptListing.aspx?OpenFlg=44'><b><li>Archive Reports</li></b></a>"
        rowItem.Cells.Add(c1)
        rptTable.Rows.Add(rowItem)

        archive = 0
        Do Until archiveArray(archive) = ""

            rowItem = New TableRow
            rowItem.CssClass = "GRID_HEADER"
            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Left
            c1.Text = GetArchiveCircuitDesc(archiveArray(archive))
            rowItem.Cells.Add(c1)
            rptTable.Rows.Add(rowItem)

            ' ***  SHOW REPORTS
            If p_circuit = archiveArray(archive) And p_time = 2 Then
                rowItem = New TableRow
                rowItem.CssClass = "GRID_HEADER"
                c1 = New TableCell
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = getData(archiveArray(archive), 2)
                rowItem.Cells.Add(c1)
                rptTable.Rows.Add(rowItem)
            End If

            archive = archive + 1

        Loop

        rowItem = New TableRow
        rowItem.CssClass = "GRID_HEADER"
        c1 = New TableCell
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = "&nbsp;"
        rowItem.Cells.Add(c1)
        rptTable.Rows.Add(rowItem)

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        GetReportList(Request.Params("OpenFlg"), Request.Params("circuit"), Request.Params("time"))

    End Sub

End Class
