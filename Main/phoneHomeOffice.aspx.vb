Imports System.Drawing
Imports System.Data


Partial Class Main_phoneHomeOffice

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone


    Sub WriteListHeading(m_table As Table)
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim strTextSpacer As String = ""

        rowItem = New TableRow
        rowItem.CssClass = "GRID_HEADER"        
        rowItem.BackColor = Color.FromName("Silver")
        c1 = New TableCell
        c1.Width = Unit.Pixel(150)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = "Name"
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(25)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Right
        c1.Text = "Ext"
        rowItem.Cells.Add(c1)

        m_table.Rows.Add(rowItem)

    End Sub


    Sub WriteListItem(m_table As Table, m_name As String, m_ext As String)
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
        c1.Text = m_name
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(25)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Right
        c1.Text = m_ext
        rowItem.Cells.Add(c1)

        m_table.Rows.Add(rowItem)

    End Sub


    Sub BuildList(m_login As String, m_type As String)

        Dim phoneDS As DataSet = PhoneSys.GetHomeOffice(m_type)
        Dim phoneDT As DataTable = phoneDS.Tables(0)
        Dim rowIndex As Integer = 0
        Dim count As Integer = phoneDS.Tables(0).Rows.Count()
        Dim rows As Decimal = count / 3
        If Len(rows) > 3 Then rows = rows + 1

        rowIndex = 0
        ' ***  POPULATE LEFT COLUMN
        WriteListHeading(tblPhone1)
        Do Until rowIndex >= rows - 1
            WriteListItem(tblPhone1, phoneDT.Rows(rowIndex).Item("empDisplayName").ToString, _
                             phoneDT.Rows(rowIndex).Item("empExtension").ToString)
            rowIndex = rowIndex + 1
        Loop

        ' ***  POPULATE MIDDLE COLUMN
        WriteListHeading(tblPhone2)
        Do Until rowIndex >= (rows * 2) - 2
            WriteListItem(tblPhone2, phoneDT.Rows(rowIndex).Item("empDisplayName").ToString, _
                             phoneDT.Rows(rowIndex).Item("empExtension").ToString)
            rowIndex = rowIndex + 1
        Loop


        ' ***  POPULATE RIGHT COLUMN
        WriteListHeading(tblPhone3)
        Do Until rowIndex >= count
            WriteListItem(tblPhone3, phoneDT.Rows(rowIndex).Item("empDisplayName").ToString, _
                            phoneDT.Rows(rowIndex).Item("empExtension").ToString)
            rowIndex = rowIndex + 1
        Loop



    End Sub


    Sub SetLinks(m_type As String)

        Select Case m_type
            Case "ext"
                lnkHO.NavigateUrl = "phoneHomeOffice.aspx?type=name"
                lnkHO.Text = "View By Name"
                lnkDept.NavigateUrl = "phoneHomeOfficeDept.aspx"
                lnkDept.Text = "View By Department"

            Case "name"
                lnkHO.NavigateUrl = "phoneHomeOffice.aspx?type=ext"
                lnkHO.Text = "View By Extension"
                lnkDept.NavigateUrl = "phoneHomeOfficeDept.aspx"
                lnkDept.Text = "View By Department"

            Case Else
                lnkDept.NavigateUrl = "phoneHomeOfficeDept.aspx"
                lnkDept.Text = "View By Department"
                lnkHO.NavigateUrl = "phoneHomeOffice.aspx?type=name"
                lnkHO.Text = "View By Name"

        End Select

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
                 Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
        If String.IsNullOrEmpty(strLogin) Then
            strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
        End If

        Dim strType As String = Request.Params("type")

        If Not Page.IsPostBack Then

            SetLinks(strType)
            BuildList(strLogin, strType)

        End If

    End Sub


End Class
