Imports System.Drawing


Partial Class Main_menuRptOptions

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils


    Sub ShowMenuItem(p_tbl As Table, m_link As String, m_target As String, m_display As String)
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim strTextSpacer As String = ""

        rowItem = New TableRow
        rowItem.CssClass = "GRID_HEADER"
        rowItem.BackColor = Color.FromName("White")
        c1 = New TableCell
        c1.Wrap = False
        c1.Width = Unit.Pixel(250)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = "<li><a href=" & m_link & " TARGET='" & m_target & "'>" & m_display & "</a></li>"
        rowItem.Cells.Add(c1)
        p_tbl.Rows.Add(rowItem)

    End Sub


    Sub MenuSpacer(p_tbl As Table, p_size As Integer)
        Dim rowItem As TableRow = New TableRow
        Dim c1 As TableCell = New TableCell
        c1.Height = Unit.Pixel(p_size)
        rowItem.Cells.Add(c1)
        p_tbl.Rows.Add(rowItem)

    End Sub


    Sub BuildMenu(m_login As String)
        ' ***EVERYONE CAN SEE
        ShowMenuItem(tblRptLinks, "rptListing.aspx", "_main", "Management Reports")
        ShowMenuItem(tblRptLinks, "../../MTC/testuser.asp", "_new", "MovieTickets.com")

        If UtilSys.ViewMenuItem("NAI\" & m_login, UCase("NAI\CircuitInfo")) Or UtilSys.ViewAppLink(m_login, "CIRCUITINFO") Then
            ShowMenuItem(tblRptLinks, "../../CircuitInfo", "_new", "General Circuit Information")
        End If

        If UtilSys.ViewMenuItem("NAI\" & m_login, UCase("NAI\IntranetPopcornRpt")) Then
            ShowMenuItem(tblRptLinks, "../../../Popawards", "_new", "Popcorn Club Web Inquiry/Reports")
        End If

        ' ***EVERYONE CAN SEE
        ShowMenuItem(tblRptLinks, "../../SAS/", "_new", "Special Advanced Screening Reports")

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
                      Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
        If String.IsNullOrEmpty(strLogin) Then
            strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
        End If

        If Not Page.IsPostBack Then
            BuildMenu(strLogin)

        End If

    End Sub

End Class
