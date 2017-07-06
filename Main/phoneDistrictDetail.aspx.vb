Imports System.Drawing
Imports System.Data


Partial Class Main_phoneDistrictDetail

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone


    Sub ShowCAData(ByVal p_ca As String)
        Dim i As Integer
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim strCADetail As String = ""
        Dim currentCM As CityManager
        Dim currentCA As CityArea
        Dim strDOAddress As String = ""
        Dim strHomeAddress As String = ""


        ' ***  RETRIEVE CURRENT CITY AREA/MANAGER
        currentCA = PhoneSys.SelectCityAreaData(p_ca)
        currentCM = PhoneSys.SelectCityMgrData(p_ca)

        If Not currentCM Is Nothing Then
            With currentCM

                ' ***  SHOW DO/CITY AREA OFFICE INFORMATION
                ' ***  PARSE TOGETHER  STREET ADDRESS
                strDOAddress = .Address1
                If Len(.Address2) > 0 Then strDOAddress = strDOAddress + "<BR>" & .Address2
                strDOAddress = strDOAddress + "<BR>" & .City & ",  " & .State & "   " & .Postal

                ' ***  CITY AREA MANAGER
                rowItem = New TableRow
                rowItem.CssClass = "DATA_LABEL"
                c1 = New TableCell
                c1.ColumnSpan = 2
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "<a href='phoneEmpDetail.aspx?id=" & .ID & "'>" & .FirstName & " " & .LastName & "  -- City Manager</a>"
                rowItem.Cells.Add(c1)
                tblCA.Rows.Add(rowItem)

                rowItem = New TableRow
                rowItem.CssClass = "DATA_LABEL"
                c1 = New TableCell
                c1.ColumnSpan = 2
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "City Area Office"
                rowItem.Cells.Add(c1)
                tblCA.Rows.Add(rowItem)

                ' ***  CITY AREA OFFICE ADDRESS
                rowItem = New TableRow
                rowItem.CssClass = "DATA"
                c1 = New TableCell
                c1.ColumnSpan = 2
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = strDOAddress
                rowItem.Cells.Add(c1)
                tblCA.Rows.Add(rowItem)

                ' ***  CITY AREA PHONE
                rowItem = New TableRow
                rowItem.CssClass = "DATA"
                c1 = New TableCell
                c1.Width = Unit.Pixel(50)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Office :"
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(250)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = .Phone & " (#" & .OfficeSpeedDial & ")"
                rowItem.Cells.Add(c1)
                tblCA.Rows.Add(rowItem)

                ' ***  CITY AREA FAX
                rowItem = New TableRow
                rowItem.CssClass = "DATA"
                c1 = New TableCell
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Fax :"
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = .FaxNumber
                rowItem.Cells.Add(c1)
                tblCA.Rows.Add(rowItem)

                ' ***  CITY AREA EMAIL
                rowItem = New TableRow
                rowItem.CssClass = "DATA"
                c1 = New TableCell
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Email :"
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = currentCA.CAEmail
                rowItem.Cells.Add(c1)
                tblCA.Rows.Add(rowItem)


                 ' *** SHOW CITY MANAGER HOME INFORMATION
                ' ***  PARSE TOGETHER HOME ADDRESS
                strHomeAddress = .HomeAdd1
                If Len(.HomeAdd2) > 0 Then strHomeAddress = strHomeAddress + "<BR>" & .HomeAdd2
                strHomeAddress = strHomeAddress + "<BR>" & .HomeCity & ",  " & .HomeState & "   " & .HomePostal

                rowItem = New TableRow
                rowItem.CssClass = "DATA_LABEL"
                c1 = New TableCell
                c1.ColumnSpan = 2
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "&nbsp;"
                rowItem.Cells.Add(c1)
                tblCM.Rows.Add(rowItem)

                rowItem = New TableRow
                rowItem.CssClass = "DATA_LABEL"
                c1 = New TableCell
                c1.ColumnSpan = 2
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Personal Information"
                rowItem.Cells.Add(c1)
                tblCM.Rows.Add(rowItem)

                ' ***  CITY MANAGER HOME ADDRESS
                rowItem = New TableRow
                rowItem.CssClass = "DATA"
                c1 = New TableCell
                c1.ColumnSpan = 2
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = strHomeAddress
                rowItem.Cells.Add(c1)
                tblCM.Rows.Add(rowItem)

                ' ***  CITY MANAGER PHONE
                rowItem = New TableRow
                rowItem.CssClass = "DATA"
                c1 = New TableCell
                c1.Width = Unit.Pixel(50)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Home :"
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(250)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = .HomePhone
                rowItem.Cells.Add(c1)
                tblCM.Rows.Add(rowItem)

                ' ***  CITY MANAGER MOBILE
                rowItem = New TableRow
                rowItem.CssClass = "DATA"
                c1 = New TableCell
                c1.Width = Unit.Pixel(50)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Mobile :"
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(250)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = .Mobile
                rowItem.Cells.Add(c1)
                tblCM.Rows.Add(rowItem)

                ' ***  CITY AREA EMAIL
                rowItem = New TableRow
                rowItem.CssClass = "DATA"
                c1 = New TableCell
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Email :"
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = .Email
                rowItem.Cells.Add(c1)
                tblCM.Rows.Add(rowItem)

            End With

        End If



    End Sub


    Sub ShowTheatreData(ByVal p_ca As String)
        Dim i As Integer
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim strTheatreDetail As String = ""
        Dim ds As DataSet
        Dim dt As DataTable
        Dim currentTheatre As Theatre
        Dim dsEmp As DataSet
        Dim dtEmp As DataTable
        Dim x As Integer
        Dim strEmpData As String = ""
        Dim strAddress As String = ""
        Dim strMailing As String = ""


        ds = PhoneSys.GetTheatresByDistrict(p_ca)
        dt = ds.Tables(0)


        ' ***  ADD THEATRE HEADER ROW
        rowItem = New TableRow
        c1 = New TableCell
        c1.ColumnSpan = 2
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.VerticalAlign = VerticalAlign.Top
        c1.Text = "<h2>City Area Locations</h2>"
        rowItem.Cells.Add(c1)
        tblTheatres.Rows.Add(rowItem)

        ' ***  ADD BLANK ROW
        rowItem = New TableRow
        c1 = New TableCell
        c1.ColumnSpan = 2
        c1.Height = Unit.Pixel(20)
        c1.Text = " "
        rowItem.Cells.Add(c1)
        tblTheatres.Rows.Add(rowItem)


        Do While i <= dt.Rows.Count - 1

            currentTheatre = PhoneSys.SelectTheatreData(dt.Rows(i).Item("RELOC#"))


            ' ***  ADD THEATRE HEADER ROW
            rowItem = New TableRow
            rowItem.CssClass = "REPORT_HEADER"
            c1 = New TableCell
            c1.ColumnSpan = 2
            c1.HorizontalAlign = HorizontalAlign.Left
            c1.VerticalAlign = VerticalAlign.Top
            c1.Text = "<a href='phoneTheatreDetail.aspx?unit=" & currentTheatre.UnitNo & "'>" & currentTheatre.UnitName & "  (" & currentTheatre.UnitNo & ") </a>"
            c1.CssClass = "REPORT_HEADER"
            rowItem.Cells.Add(c1)
            tblTheatres.Rows.Add(rowItem)


            ' ***  ADD THEATRE INFORMATION ROW
            rowItem = New TableRow
            rowItem.CssClass = "DATA"

            With currentTheatre
                ' ***  PARSE TOGETHER STREET ADDRESS
                strAddress = .Address1
                If Len(.Address2) > 0 Then strAddress = strAddress + "<BR>" & .Address2
                strAddress = strAddress + "<BR>" & .City & ",  " & .State & "   " & .Postal

                ' ***  PARSE TOGETHER MAILING ADDRESS
                strMailing = .MailingAdd1
                If Len(.MailingAdd2) > 0 Then strMailing = strMailing + "<BR>" & .MailingAdd2
                strMailing = strMailing + "<BR>" & .MailingCity & ",  " & .MailingState & "   " & .MailingPostal

                strTheatreDetail = "<TABLE WIDTH='100%' BORDER=0 ALIGN='RIGHT' CELLPADDING=0 CELLSPACING=0>"
                strTheatreDetail = strTheatreDetail & "<TR><TD>&nbsp;</TD><TD CLASS='data' VALIGN=top>Address :</TD><TD CLASS='data'>" & strAddress & "</TD></TR>"
                strTheatreDetail = strTheatreDetail & "<TR><TD>&nbsp;</TD><TD CLASS='data' VALIGN=top>Mailing Address :</TD><TD CLASS='data'>" & strMailing & "</TD></TR>"
                strTheatreDetail = strTheatreDetail & "<TR><TD>&nbsp;</TD><TD CLASS='data'>Phone :</TD><TD CLASS='data'>" & .Phone & "</TD></TR>"
                strTheatreDetail = strTheatreDetail & "<TR><TD>&nbsp;</TD><TD CLASS='data'>Speed Dial :</TD><TD CLASS='data'>(#" & .SpeedDial & ")</TD></TR>"
                strTheatreDetail = strTheatreDetail & "<TR><TD>&nbsp;</TD><TD CLASS='data'>Fax :</TD><TD CLASS='data'>" & .FaxNumber & "</TD></TR>"
                strTheatreDetail = strTheatreDetail & "<TR><TD>&nbsp;</TD><TD CLASS='data'>Recording Phone :</TD><TD CLASS='data'>" & .RecordingNumber & "</TD></TR>"
                strTheatreDetail = strTheatreDetail & "<TR><TD>&nbsp;</TD><TD CLASS='data'>Recording Speed Dial :</TD><TD CLASS='data'>(#" & .RecSpeedDial & ")</TD></TR>"
                'strTheatreDetail = strTheatreDetail & "<TR><TD>&nbsp;</TD><TD CLASS='data' VALIGN=top>Company Name and #:</TD><TD CLASS='data'>" & .CompanyNum & " - " & .CompanyName & "</TD></TR>"
                'strTheatreDetail = strTheatreDetail & "<TR><TD>&nbsp;</TD><TD CLASS='data'>EIN :</TD><TD CLASS='data'>" & .EIN & "</TD></TR>"
                strTheatreDetail = strTheatreDetail & "<TR><TD WIDTH=20>&nbsp;</TD><TD WIDTH=130>&nbsp;</TD><TD></TD></TR>"
                strTheatreDetail = strTheatreDetail & "</TABLE>"

            End With

            c1 = New TableCell
            c1.Width = Unit.Pixel(350)
            c1.HorizontalAlign = HorizontalAlign.Left
            c1.VerticalAlign = VerticalAlign.Top
            c1.Text = strTheatreDetail
            c1.CssClass = "data"
            rowItem.Cells.Add(c1)


            ' *** THEATRE EMPLOYEES
            dsEmp = PhoneSys.GetTheatrePersonnel(currentTheatre.UnitNo)
            dtEmp = dsEmp.Tables(0)

            x = 0
            strEmpData = "<TABLE WIDTH='100%' BORDER=0>"

            Do While x <= dtEmp.Rows.Count - 1
                strEmpData = strEmpData & "<TR CLASS='data'>"
                strEmpData = strEmpData & "<TD WIDTH='175'>" & dtEmp.Rows(x).Item("JobDescription") & " :</TD>"
                strEmpData = strEmpData & "<TD><a href='phoneEmpDetail.aspx?id=" & dtEmp.Rows(x).Item("empautonum") & "'>" & dtEmp.Rows(x).Item("emp_name") & "</a></TD>"
                strEmpData = strEmpData & "</TR>"

                x = x + 1

            Loop
            strEmpData = strEmpData & "</TABLE>"

            c1 = New TableCell
            c1.Width = Unit.Pixel(350)
            c1.HorizontalAlign = HorizontalAlign.Left
            c1.VerticalAlign = VerticalAlign.Top
            c1.Text = strEmpData
            c1.CssClass = "data"
            rowItem.Cells.Add(c1)

            '*** ADD ROW TO TABLE ***
            tblTheatres.Rows.Add(rowItem)


            ' ***  ADD BLANK ROW
            rowItem = New TableRow
            c1 = New TableCell
            c1.ColumnSpan = 2
            c1.Height = Unit.Pixel(20)
            c1.Text = " "
            rowItem.Cells.Add(c1)
            tblTheatres.Rows.Add(rowItem)


            ' ***  MOVE TO NEXT ROW
            i += 1
            strEmpData = ""
            strAddress = ""
            strMailing = ""

        Loop


        ' ***  ADD FOOTER ROW
        rowItem = New TableRow
        c1 = New TableCell
        c1.ColumnSpan = 2
        c1.Text = "<hr width='100%'>"
        rowItem.Cells.Add(c1)
        tblTheatres.Rows.Add(rowItem)


    End Sub


    Sub BuildCABox(ByVal p_ca As String)
        Dim ds As DataSet = PhoneSys.GetDistrictList()
        With ddlCA
            .DataTextField = "REDISNAME"
            .DataValueField = "REDISTRICT"
            .DataSource = ds
            .DataBind()
            .CssClass = "DATA_LABEL"
        End With

        ' ***  SELECT DISTRICT/CA IN LIST
        If Len(p_ca) > 0 Then ddlCA.SelectedValue = p_ca

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim strDistrict As String = Request.Params("district")
        If Len(strDistrict) = 0 Then strDistrict = 100

        If Not Page.IsPostBack Then
            BuildCABox(strDistrict)
        Else
            lblMessage.Text = " "
        End If


        Try
            ShowCAData(ddlCA.SelectedValue)
            ShowTheatreData(ddlCA.SelectedValue)

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

    End Sub

End Class
