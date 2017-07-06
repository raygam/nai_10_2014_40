Imports System.Drawing
Imports System.Data

Partial Class Main_phoneDeptList

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


    Sub BuildList(m_login As String, m_dept As String)

        Dim ds As DataSet = PhoneSys.GetPhoneDept(m_dept)
        Dim dt As DataTable = ds.Tables(0)
        Dim i As Int32 = 0

        Do While i <= dt.Rows.Count - 1

            Dim rowItem As TableRow
            Dim c1 As TableCell
            Dim strTextSpacer As String = ""
            Dim strOffice As String = ""
            Dim strHome As String = ""

            ' ***  EMPLOYEE NAME ROW
            rowItem = New TableRow
            rowItem.CssClass = "GRID_HEADER"
            rowItem.BackColor = Color.FromName("White")
            c1 = New TableCell
            c1.ColumnSpan = 2
            c1.HorizontalAlign = HorizontalAlign.Left
            c1.Text = "<a href='phoneEmpDetail.aspx?id=" & dt.Rows(i).Item("empAutonum").ToString & "'>" & dt.Rows(i).Item("empFirstName").ToString & " " & dt.Rows(i).Item("emplastName").ToString & "</a>"
            rowItem.Cells.Add(c1)
            tblDept.Rows.Add(rowItem)

            ' ***  DISPLAY OFFICE INFORMATION
            ' ***  TITLE ROW
            rowItem = New TableRow
            rowItem.CssClass = "GRID_HEADER"
            rowItem.BackColor = Color.FromName("White")
            c1 = New TableCell
            c1.ColumnSpan = 2
            c1.HorizontalAlign = HorizontalAlign.Left
            c1.Text = dt.Rows(i).Item("empTitle").ToString
            rowItem.Cells.Add(c1)
            tblDept.Rows.Add(rowItem)

            ' ***  ADD SPACING
            MenuSpacer(tblDept, 5)

            ' ***  OFFICE ADDRESS
            If Len(Trim(dt.Rows(i).Item("HomeAddressLine1").ToString)) > 0 Then

                ' ***  PARSE TOGETHER FIELDS
                strOffice = dt.Rows(i).Item("HomeAddressLine1").ToString

                If Len(Trim(dt.Rows(i).Item("HomeAddressLine2").ToString)) > 0 Then
                    strOffice = strOffice & "<br>" & dt.Rows(i).Item("HomeAddressLine2").ToString
                End If
                If Len(Trim(dt.Rows(i).Item("City").ToString)) > 0 Then
                    strOffice = strOffice & "<br>" & dt.Rows(i).Item("City").ToString & ", " & _
                            dt.Rows(i).Item("State").ToString & "  " & dt.Rows(i).Item("PostalCode").ToString
                End If

                rowItem = New TableRow
                rowItem.CssClass = "GRID_DATA"
                rowItem.BackColor = Color.FromName("White")
                c1 = New TableCell
                c1.Width = Unit.Pixel(150)
                c1.VerticalAlign = VerticalAlign.Top
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Office Address : "
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(300)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = strOffice
                rowItem.Cells.Add(c1)

                tblDept.Rows.Add(rowItem)

            End If

            If Len(Trim(dt.Rows(i).Item("OfficePhone").ToString)) > 0 Then
                rowItem = New TableRow
                rowItem.CssClass = "GRID_DATA"
                rowItem.BackColor = Color.FromName("White")
                c1 = New TableCell
                c1.Width = Unit.Pixel(150)
                c1.VerticalAlign = VerticalAlign.Top
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Office Phone : "
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(300)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = dt.Rows(i).Item("OfficePhone").ToString
                rowItem.Cells.Add(c1)

                tblDept.Rows.Add(rowItem)

            End If

            If Len(Trim(dt.Rows(i).Item("OfficeFax").ToString)) > 0 Then
                rowItem = New TableRow
                rowItem.CssClass = "GRID_DATA"
                rowItem.BackColor = Color.FromName("White")
                c1 = New TableCell
                c1.Width = Unit.Pixel(150)
                c1.VerticalAlign = VerticalAlign.Top
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Office Fax : "
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(300)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = dt.Rows(i).Item("OfficeFax").ToString
                rowItem.Cells.Add(c1)

                tblDept.Rows.Add(rowItem)

            End If

            ' ***  HOME ADDRESS
            If Len(Trim(dt.Rows(i).Item("HomeLine1").ToString)) > 0 Then

                ' ***  PARSE TOGETHER FIELDS
                strHome = dt.Rows(i).Item("HomeLine1").ToString

                If Len(Trim(dt.Rows(i).Item("HomeLine2").ToString)) > 0 Then
                    strHome = strHome & "<br>" & dt.Rows(i).Item("HomeLine2").ToString
                End If
                If Len(Trim(dt.Rows(i).Item("HomeCity").ToString)) > 0 Then
                    strHome = strHome & "<br>" & dt.Rows(i).Item("HomeCity").ToString & ", " & _
                            dt.Rows(i).Item("HomeState").ToString & "  " & dt.Rows(i).Item("HomePostal").ToString
                End If

                rowItem = New TableRow
                rowItem.CssClass = "GRID_DATA"
                rowItem.BackColor = Color.FromName("White")
                c1 = New TableCell
                c1.Width = Unit.Pixel(150)
                c1.VerticalAlign = VerticalAlign.Top
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Home Address : "
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(300)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = strHome
                rowItem.Cells.Add(c1)

                tblDept.Rows.Add(rowItem)

            End If

            If Len(Trim(dt.Rows(i).Item("HomePhone").ToString)) > 0 Then
                rowItem = New TableRow
                rowItem.CssClass = "GRID_DATA"
                rowItem.BackColor = Color.FromName("White")
                c1 = New TableCell
                c1.Width = Unit.Pixel(150)
                c1.VerticalAlign = VerticalAlign.Top
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Home Phone : "
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(300)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = dt.Rows(i).Item("HomePhone").ToString
                rowItem.Cells.Add(c1)

                tblDept.Rows.Add(rowItem)

            End If

            If Len(Trim(dt.Rows(i).Item("HomeCellPhone").ToString)) > 0 Then
                rowItem = New TableRow
                rowItem.CssClass = "GRID_DATA"
                rowItem.BackColor = Color.FromName("White")
                c1 = New TableCell
                c1.Width = Unit.Pixel(150)
                c1.VerticalAlign = VerticalAlign.Top
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Home Cell Phone : "
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(300)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = dt.Rows(i).Item("HomeCellPhone").ToString
                rowItem.Cells.Add(c1)

                tblDept.Rows.Add(rowItem)

            End If

            If Len(Trim(dt.Rows(i).Item("HomeFax").ToString)) > 0 Then
                rowItem = New TableRow
                rowItem.CssClass = "GRID_DATA"
                rowItem.BackColor = Color.FromName("White")
                c1 = New TableCell
                c1.Width = Unit.Pixel(150)
                c1.VerticalAlign = VerticalAlign.Top
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Home Fax : "
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(300)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = dt.Rows(i).Item("HomeFax").ToString
                rowItem.Cells.Add(c1)

                tblDept.Rows.Add(rowItem)

            End If

            If Len(Trim(dt.Rows(i).Item("EmailAddress").ToString)) > 0 Then
                rowItem = New TableRow
                rowItem.CssClass = "GRID_DATA"
                rowItem.BackColor = Color.FromName("White")
                c1 = New TableCell
                c1.Width = Unit.Pixel(150)
                c1.VerticalAlign = VerticalAlign.Top
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Email Address : "
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(300)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "<a href='mailto:" & dt.Rows(i).Item("EmailAddress").ToString & "'>" & dt.Rows(i).Item("EmailAddress").ToString & "</a>"
                rowItem.Cells.Add(c1)

                tblDept.Rows.Add(rowItem)

            End If

            If Len(Trim(dt.Rows(i).Item("Pager").ToString)) > 0 Then
                rowItem = New TableRow
                rowItem.CssClass = "GRID_DATA"
                rowItem.BackColor = Color.FromName("White")
                c1 = New TableCell
                c1.Width = Unit.Pixel(150)
                c1.VerticalAlign = VerticalAlign.Top
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Pager : "
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(300)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = dt.Rows(i).Item("Pager").ToString
                rowItem.Cells.Add(c1)

                tblDept.Rows.Add(rowItem)

            End If

            If Len(Trim(dt.Rows(i).Item("PagerPin").ToString)) > 0 Then
                rowItem = New TableRow
                rowItem.CssClass = "GRID_DATA"
                rowItem.BackColor = Color.FromName("White")
                c1 = New TableCell
                c1.Width = Unit.Pixel(150)
                c1.VerticalAlign = VerticalAlign.Top
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "Pager Pin : "
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(300)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = dt.Rows(i).Item("PagerPin").ToString
                rowItem.Cells.Add(c1)

                tblDept.Rows.Add(rowItem)

            End If


            ' ***  LINE ROW
            rowItem = New TableRow
            rowItem.CssClass = "GRID_DATA"
            rowItem.BackColor = Color.FromName("White")
            c1 = New TableCell
            c1.ColumnSpan = 2
            c1.HorizontalAlign = HorizontalAlign.Left
            c1.Text = "<hr width=100%>"
            rowItem.Cells.Add(c1)
            tblDept.Rows.Add(rowItem)

            ' ***  ADD SPACING
            MenuSpacer(tblDept, 20)

            i = i + 1

        Loop



    End Sub


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
               Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
        If String.IsNullOrEmpty(strLogin) Then
            strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
        End If

        Dim strDept As String = Request.Params("type")

        ' ***  BUILD SQL STATEMENT
        Select Case strDept
            Case "audit"
                lblTitle.Text = "<h2>Auditors</h2>"
            Case "book"
                lblTitle.Text = "<h2>Booking</h2>"
            Case "concess"
                lblTitle.Text = "<h2>Concessions</h2>"
            Case "field_mis"
                lblTitle.Text = "<h2>MIS Field Services</h2>"
            Case "field_hr"
                lblTitle.Text = "<h2>Field Human Resources</h2>"
            Case "mgmt"
                lblTitle.Text = "<h2>Operations</h2>"
            Case "support"
                lblTitle.Text = "<h2>Operations Support</h2>"
            Case "misc"
                lblTitle.Text = "<h2>Operations Miscellaneous</h2>"
            Case "mark"
                lblTitle.Text = "<h2>Marketing / Sales</h2>"
            Case Else
                lblTitle.Text = ""
        End Select


        If Not Page.IsPostBack Then

            BuildList(strLogin, strDept)

        End If

    End Sub


End Class
