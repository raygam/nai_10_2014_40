Imports System.Drawing
Imports System.Data

Partial Class Main_phoneDistrictList

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone


    Sub WriteHeading()
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim strTextSpacer As String = ""

        rowItem = New TableRow
        rowItem.CssClass = "GRID_HEADER"
        rowItem.BackColor = Color.FromName("White")

        c1 = New TableCell
        c1.Width = Unit.Pixel(50)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = ""
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(200)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = "City Area"
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(200)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = "Area Manager"
        rowItem.Cells.Add(c1)

        tblDistrict.Rows.Add(rowItem)

    End Sub


    Sub WriteListItem(m_district As String, m_districtname As String, m_dmname As String)
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim strTextSpacer As String = ""

        rowItem = New TableRow
        rowItem.CssClass = "GRID_DATA"
        rowItem.BackColor = Color.FromName("White")

        c1 = New TableCell
        c1.Width = Unit.Pixel(50)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = "<a href=phoneDistrictDetail.aspx?district=" & m_district & ">" & m_district & "</a>"
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(200)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = m_districtname
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(200)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = m_dmname
        rowItem.Cells.Add(c1)

        tblDistrict.Rows.Add(rowItem)

    End Sub


    Sub BuildList(m_login As String)

        Dim ds As DataSet = PhoneSys.GetDistrictList()
        Dim dt As DataTable = ds.Tables(0)
        Dim i As Int32 = 0

        WriteHeading()
        MenuSpacer(tblDistrict, 10)

        Do While i <= dt.Rows.Count - 1

            WriteListItem(dt.Rows(i).Item("REDISTRICT").ToString, dt.Rows(i).Item("REDISNAME").ToString, dt.Rows(i).Item("REDMNAME").ToString)
            i = i + 1

        Loop

    End Sub


    Sub MenuSpacer(p_tbl As Table, p_size As Integer)
        Dim rowItem As TableRow = New TableRow
        Dim c1 As TableCell = New TableCell
        c1.Height = Unit.Pixel(p_size)
        rowItem.Cells.Add(c1)
        p_tbl.Rows.Add(rowItem)

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
        Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
        If String.IsNullOrEmpty(strLogin) Then
            strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
        End If

        lblTitle.Text = "<h2>City Areas / Managers </h2>"

        If Not Page.IsPostBack Then
            BuildList(strLogin)

        End If

    End Sub


End Class
