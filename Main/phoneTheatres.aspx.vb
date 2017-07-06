Imports System.Drawing
Imports System.Data


Partial Class Main_phoneTheatres

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone


    
    Sub MenuSpacer(p_tbl As Table, p_size As Integer)
        Dim rowItem As TableRow = New TableRow
        Dim c1 As TableCell = New TableCell
        c1.Height = Unit.Pixel(p_size)
        rowItem.Cells.Add(c1)
        p_tbl.Rows.Add(rowItem)

    End Sub


    Sub BuildHeading()
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim strTextSpacer As String = ""
        Dim blnCss As Boolean

        rowItem = New TableRow
        'rowItem.CssClass = "GRID_HEADING"

        c1 = New TableCell
        c1.Width = Unit.Pixel(100)
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = "Location Name"
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(50)
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = "Location #"
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(125)
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = "Phone"
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(50)
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = "Speed Dial"
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(125)
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = "Fax Phone"
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(125)
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = "Recording Phone"
        rowItem.Cells.Add(c1)

        tblPhone.Rows.Add(rowItem)

    End Sub


    Sub BuildList(m_login As String, m_circuit As String)
        Dim ds As DataSet = PhoneSys.GetTheatrePhones(m_circuit)
        Dim dt As DataTable = ds.Tables(0)
        Dim i As Int32 = 0
        Dim blnCss As Boolean = True

        BuildHeading()
        MenuSpacer(tblPhone, 5)


        ' ***  POPULATE LEFT COLUMN
        Do While i <= dt.Rows.Count - 1

            Dim rowItem As TableRow
            Dim c1 As TableCell
            Dim strTextSpacer As String = ""

            rowItem = New TableRow
            'If blnCss Then
            rowItem.CssClass = "GRID_DATA"
            'Else
            'rowItem.CssClass = "GRID_DATA_ALT2"
            'End If

            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Left
            c1.Text = dt.Rows(i).Item("LOC_NAME").ToString
            rowItem.Cells.Add(c1)

            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.Text = "<a href='phoneTheatreDetail.aspx?unit=" & dt.Rows(i).Item("LOC_NUMBER") & "'>" & dt.Rows(i).Item("LOC_NUMBER").ToString & "</a>"
            rowItem.Cells.Add(c1)

            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.Text = dt.Rows(i).Item("phone").ToString
            rowItem.Cells.Add(c1)

            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.Text = dt.Rows(i).Item("SpeedDial").ToString
            rowItem.Cells.Add(c1)

            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.Text = dt.Rows(i).Item("FaxPhone").ToString
            rowItem.Cells.Add(c1)

            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.Text = dt.Rows(i).Item("RecordingPhone").ToString
            rowItem.Cells.Add(c1)

            tblPhone.Rows.Add(rowItem)

            MenuSpacer(tblPhone, 2)

            blnCss = Not blnCss
            i = i + 1

        Loop

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
               Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
        If String.IsNullOrEmpty(strLogin) Then
            strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
        End If

        Dim strCircuit As String = Request.Params("circuit")

        Select Case strCircuit
            Case "US"
                lblTitle.Text = "<h2>US Theatre Numbers</h2>"
            Case "140"
                lblTitle.Text = "<h2>UK Theatre Numbers</h2>"
            Case "303"
                lblTitle.Text = "<h2>Argentina Theatre Numbers</h2>"
            Case "304"
                lblTitle.Text = "<h2>Brazil Theatre Numbers</h2>"
            Case "DI"
                lblTitle.Text = "<h2>Drive-In Numbers</h2>"
            Case "FLEA"
                lblTitle.Text = "<h2>Flea Market Numbers</h2>"
            Case Else
                lblTitle.Text = "<h2>Theatre Numbers</h2>"
        End Select

        If Not Page.IsPostBack Then
            BuildList(strLogin, strCircuit)

        End If


    End Sub


End Class
