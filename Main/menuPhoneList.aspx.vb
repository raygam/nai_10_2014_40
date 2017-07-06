Imports System.Drawing


Partial Class Main_menuPhoneList

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim SecuritySys As NAI_Security = New NAI_Security


    Sub ShowMenuHeading(p_tbl As Table, m_display As String)
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim strTextSpacer As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"

        rowItem = New TableRow
        rowItem.CssClass = "GRID_HEADER"
        rowItem.BackColor = Color.FromName("White")
        c1 = New TableCell
        c1.Width = Unit.Pixel(200)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = strTextSpacer & m_display
        rowItem.Cells.Add(c1)
        p_tbl.Rows.Add(rowItem)

    End Sub


    Sub ShowMenuItem(p_tbl As Table, m_link As String, m_target As String, m_display As String)
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim strTextSpacer As String = ""

        rowItem = New TableRow
        rowItem.CssClass = "GRID_DATA"
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
        ' ***  EVERYONE CAN SEE THESE OPTIONS
        ShowMenuHeading(tblPhone1, "Home Office Phones")
        MenuSpacer(tblPhone1, 5)
        ShowMenuItem(tblPhone1, "phoneHomeOffice.aspx?type=name", "_main", "Home Office By Name")
        ShowMenuItem(tblPhone1, "phoneHomeOffice.aspx?type=ext", "_main", "Home Office By Extension")
        ShowMenuItem(tblPhone1, "phoneHomeOfficeDept.aspx", "_main", "Home Office By Department")
        ShowMenuItem(tblPhone1, "phoneHomeOfficeFax.aspx", "_main", "Home Office Fax Numbers")
        MenuSpacer(tblPhone1, 30)
        ShowMenuHeading(tblPhone1, "Theatres")
        MenuSpacer(tblPhone1, 5)
        ShowMenuItem(tblPhone1, "phoneDistrictList.aspx", "_main", "City Areas / Managers")
        ShowMenuItem(tblPhone1, "phoneTheatres.aspx?circuit=USA", "_main", "US Theatres")
        ShowMenuItem(tblPhone1, "phoneTheatres.aspx?circuit=140", "_main", "UK Theatres")
        ShowMenuItem(tblPhone1, "phoneTheatres.aspx?circuit=303", "_main", "Argentina Theatres")
        ShowMenuItem(tblPhone1, "phoneTheatres.aspx?circuit=304", "_main", "Brazil Theatres")
        'ShowMenuItem(tblPhone1, "phoneTheatres.aspx?circuit=DI", "_main", "Drive-Ins")
        'ShowMenuItem(tblPhone1, "phoneTheatres.aspx?circuit=FLEA", "_main", "Flea Markets")
        MenuSpacer(tblPhone1, 10)


        ShowMenuHeading(tblPhone2, "Operations Phone Lists")
        MenuSpacer(tblPhone2, 5)
        ShowMenuItem(tblPhone2, "phoneDeptList.aspx?type=audit", "_main", "Auditors")
        ShowMenuItem(tblPhone2, "phoneDeptList.aspx?type=book", "_main", "Bookings")
        ShowMenuItem(tblPhone2, "phoneDeptList.aspx?type=concess", "_main", "Concessions")
        ShowMenuItem(tblPhone2, "phoneDeptList.aspx?type=field_mis", "_main", "MIS Field Services")
        ShowMenuItem(tblPhone2, "phoneDeptList.aspx?type=mgmt", "_main", "Operations")
        ShowMenuItem(tblPhone2, "phoneDeptList.aspx?type=support", "_main", "Operations Support Team")
        'ShowMenuItem(tblPhone2, "phoneDeptList.aspx?type=field_hr", "_main", "Field HR Department")
        'ShowMenuItem(tblPhone2, "phoneDeptList.aspx?type=misc", "_main", "Operations - Miscellaneous")
        'ShowMenuItem(tblPhone2, "phoneDeptList.aspx?type=mark", "_main", "Marketing / Sales")


        ' ***  SHOW PERSONNEL ITEMS IF PART OF THE InrtanetPhoneMain GROUP
        If UtilSys.ViewMenuItem("NAI\" & m_login, UCase("NAI\IntranetPhoneMain")) Then
            MenuSpacer(tblPhone2, 30)
            ShowMenuHeading(tblPhone2, "Personnel Maintenance")
            MenuSpacer(tblPhone2, 5)
            ShowMenuItem(tblPhone2, "phonePermsSet.aspx", "_main", "Assign Permissions")
            ShowMenuItem(tblPhone2, "phoneEmpMain.aspx", "_main", "Employee Maintenance")
            ShowMenuItem(tblPhone2, "econtactMaintain.aspx", "_main", "Emergency Contact Maintenance")
        End If


        ' ***  SHOW FIELD PERSONNEL ITEMS IF USER IS A DISTRICT MANANGER
        ' ***  OR PART OF OPERATIONS 
        If SecuritySys.IsOps(m_login) Then
            MenuSpacer(tblPhone2, 30)
            ShowMenuHeading(tblPhone2, "Field Maintenance")
            MenuSpacer(tblPhone2, 5)
            ShowMenuItem(tblPhone2, "fieldEmpSelect.aspx?dist=0", "_main", "Field Employee Maintenance")
            ShowMenuItem(tblPhone2, "fieldSelectTheatre.aspx?dist=0", "_main", "Theatre Maintenance")

        Else
            If SecuritySys.IsDistrictUser(m_login) Then
                Dim m_dist As String = SecuritySys.GetDistrict(m_login)
                MenuSpacer(tblPhone2, 30)
                ShowMenuHeading(tblPhone2, "Field Maintenance")
                MenuSpacer(tblPhone2, 5)
                ShowMenuItem(tblPhone2, "fieldEmpSelect.aspx?dist=" & m_dist, "_main", "Field Employee Maintenance")
                ShowMenuItem(tblPhone2, "fieldSelectTheatre.aspx?dist=" & m_dist, "_main", "Theatre Maintenance")

            End If

        End If

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


    ' *****************************************************
    ' *****************************************************

End Class
