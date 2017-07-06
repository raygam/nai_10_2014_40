Imports System.Drawing
Imports System.Data


Partial Class Main_econtactMaintain

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone
    Dim EmpSys As NAI_Emp = New NAI_Emp
    Dim SecuritySys As NAI_Security = New NAI_Security
    Private Shared prevPage As String = String.Empty


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

        rowItem = New TableRow
        rowItem.CssClass = "GRID_HEADER"

        c1 = New TableCell
        c1.Width = Unit.Pixel(50)
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = ""
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(125)
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = "Name"
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(125)
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = "Contact Name"
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(100)
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = "Contact Phone"
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(50)
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = "Relationship"
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(50)
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = "Ext."
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(50)
        c1.HorizontalAlign = HorizontalAlign.Center
        c1.Text = "Dept"
        rowItem.Cells.Add(c1)

        tblResults.Rows.Add(rowItem)

    End Sub


    Sub BuildList()
        Dim ds As DataSet = EmpSys.GetEcontactList()
        Dim dt As DataTable = ds.Tables(0)
        Dim i As Int32 = 0
        Dim blnCss As Boolean = True

        BuildHeading()
        MenuSpacer(tblResults, 5)


        ' ***  POPULATE LEFT COLUMN
        Do While i <= dt.Rows.Count - 1

            Dim rowItem As TableRow
            Dim c1 As TableCell
            Dim strTextSpacer As String = ""

            rowItem = New TableRow
            If blnCss Then
                rowItem.CssClass = "GRID_DATA"
            Else
                rowItem.CssClass = "GRID_DATA_ALT2"
            End If


            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.VerticalAlign = VerticalAlign.Middle
            c1.Text = "<a href='econtactDetail.aspx?id=" & dt.Rows(i).Item("employee_id") & "'>Edit</a>"
            rowItem.Cells.Add(c1)

            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.VerticalAlign = VerticalAlign.Middle
            c1.Text = dt.Rows(i).Item("first_name").ToString & " " & dt.Rows(i).Item("last_name").ToString
            rowItem.Cells.Add(c1)

            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.VerticalAlign = VerticalAlign.Middle
            c1.Text = dt.Rows(i).Item("contact_fname").ToString & " " & dt.Rows(i).Item("contact_lname").ToString
            rowItem.Cells.Add(c1)

            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.VerticalAlign = VerticalAlign.Middle
            c1.Text = dt.Rows(i).Item("contact_day_phone").ToString
            rowItem.Cells.Add(c1)

            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.VerticalAlign = VerticalAlign.Middle
            c1.Text = dt.Rows(i).Item("relationship").ToString
            rowItem.Cells.Add(c1)

            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.VerticalAlign = VerticalAlign.Middle
            c1.Text = dt.Rows(i).Item("empExtension").ToString
            rowItem.Cells.Add(c1)

            c1 = New TableCell
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.VerticalAlign = VerticalAlign.Middle
            c1.Text = dt.Rows(i).Item("abbrev").ToString
            rowItem.Cells.Add(c1)

            tblResults.Rows.Add(rowItem)

            MenuSpacer(tblEmp, 2)

            blnCss = Not blnCss

            i = i + 1

        Loop


    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' ***  CAPTURE LOGIN
        Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
           Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
        If String.IsNullOrEmpty(strLogin) Then
            strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
        End If


        lblTitle.Text = "<h2>Emergency Contact Information</h2>"


        If Not Page.IsPostBack() Then
            BuildList()

        End If

    End Sub


    Protected Sub lnkExport_Click(sender As Object, e As System.EventArgs) Handles lnkExport.Click
        Try
            Dim gv As New GridView
            gv.DataSource = EmpSys.GetEcontactList()
            gv.DataBind()

            GridViewExportUtil.Export("econtact_data.xls", gv)

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

    End Sub


    Protected Sub cmdSearch_Click(sender As Object, e As System.EventArgs) Handles cmdSearch.Click
        Try

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

    End Sub


End Class
