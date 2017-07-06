Imports System.Drawing
Imports System.Data


Partial Class Main_phoneHomeOfficeFax

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone


    Sub WriteListItem(m_desc As String, m_fax As String)
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim strTextSpacer As String = ""

        rowItem = New TableRow
        rowItem.CssClass = "GRID_DATA"
        rowItem.BackColor = Color.FromName("White")
        c1 = New TableCell
        c1.Width = Unit.Pixel(125)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = m_desc
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(100)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = m_fax
        rowItem.Cells.Add(c1)

        tblFax.Rows.Add(rowItem)

    End Sub


    Sub BuildList(m_login As String)

        Dim ds As DataSet = PhoneSys.GetHomeOffice_Fax()
        Dim dt As DataTable = ds.Tables(0)
        Dim i As Int32 = 0

        Do While i <= dt.Rows.Count - 1

            WriteListItem(dt.Rows(i).Item("fax_description").ToString, dt.Rows(i).Item("fax_number").ToString)
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

        If Not Page.IsPostBack Then
            BuildList(strLogin)

        End If

    End Sub


End Class
