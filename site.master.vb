Imports System.Drawing


Partial Class site

    Inherits System.Web.UI.MasterPage

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils


    Sub ShowMenuItem(m_link As String, m_target As String, m_display As String)
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim strTextSpacer As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
        Dim strLink As String = UtilSys.GetLinkSetting(m_link)

        rowItem = New TableRow
        rowItem.CssClass = "GRID_HEADER"
        rowItem.BackColor = Color.FromName("#A9A9A9")
        c1 = New TableCell
        c1.Width = Unit.Pixel(150)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        If Len(strLink) > 0 Then c1.Text = strTextSpacer & "<a href=" & strLink & " TARGET='" & m_target & "'>" & m_display & "</a>"
        rowItem.Cells.Add(c1)
        sideMenu.Rows.Add(rowItem)

    End Sub


    Sub MenuSpacer(p_size As Integer)
        Dim rowItem As TableRow = New TableRow
        Dim c1 As TableCell = New TableCell
        c1.Height = Unit.Pixel(p_size)
        rowItem.Cells.Add(c1)
        sideMenu.Rows.Add(rowItem)

    End Sub


    Sub BuildMenu(m_login As String)
        MenuSpacer(40)
        ShowMenuItem("PHONELISTX", "_main", "Phone List")
        ShowMenuItem("REPORTSX", "_main", "Reports")
        ShowMenuItem("APPSX", "_main", "Applications")
        ShowMenuItem("FORMSLINK", "_new", "Forms")
        ShowMenuItem("LINKSX", "_main", "Links")
        ShowMenuItem("CONTACTUSX", "_main", "Contact Us")
        ShowMenuItem("PHONEHELP", "_new", "Phone Help")
        MenuSpacer(25)

        ' ***  CHECK FOR USA DOCS PERMINSSIONS AND SHOW
        If UtilSys.ViewMenuItem("NAI\" & m_login, "NAI\USDOCS") Then
            ShowMenuItem("USADOCS", "_new", "USA Docs")
        End If

        ' ***  CHECK FOR UK DOCS PERMINSSIONS AND SHOW
        If UtilSys.ViewMenuItem("NAI\" & m_login, "NAI\UKDOCS") Then
            ShowMenuItem("UKDOCS", "_new", "UK Docs")
        End If

        ShowMenuItem("SAFETYAUDIT", "_new", "Safety Audit")

    End Sub



    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
                        Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
        If String.IsNullOrEmpty(strLogin) Then
            strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
        End If

        'If Not Page.IsPostBack Then

        BuildMenu(strLogin)

        'End If


    End Sub


    ' ****************************************************
    ' ****************************************************

End Class

