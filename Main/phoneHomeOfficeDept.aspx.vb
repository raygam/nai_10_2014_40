Imports System.Drawing
Imports System.Data


Partial Class Main_phoneHomeOfficeDept

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone


    Sub WriteDeptHeading(m_table As Table, m_dept As String)
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim strTextSpacer As String = ""

        rowItem = New TableRow
        rowItem.CssClass = "GRID_HEADER"
        rowItem.BackColor = Color.FromName("Silver")

        c1 = New TableCell
        c1.ColumnSpan = 5
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = m_dept
        rowItem.Cells.Add(c1)

        m_table.Rows.Add(rowItem)

    End Sub


    Sub WriteJobHeading(m_table As Table, m_job As String)
        Dim rowItem As TableRow
        Dim c1 As TableCell

        rowItem = New TableRow
        rowItem.CssClass = "GRID_HEADER"
        rowItem.BackColor = Color.FromName("White")

        c1 = New TableCell
        c1.BackColor = Color.FromName("White")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = ""
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.ColumnSpan = 4
        c1.BackColor = Color.FromName("White")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = m_job
        rowItem.Cells.Add(c1)

        m_table.Rows.Add(rowItem)

    End Sub


    Sub WriteListItem(m_table As Table, m_name As String, m_ext As String, m_title As String)
        Dim rowItem As TableRow
        Dim c1 As TableCell
        Dim strTextSpacer As String = ""

        rowItem = New TableRow
        rowItem.CssClass = "GRID_DATA"
        rowItem.BackColor = Color.FromName("White")

        c1 = New TableCell
        c1.Width = Unit.Pixel(50)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = ""
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(50)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = ""
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(150)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = m_name
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(50)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = m_ext
        rowItem.Cells.Add(c1)

        c1 = New TableCell
        c1.Width = Unit.Pixel(300)
        c1.BorderColor = Color.FromName("#C0C0C0")
        c1.HorizontalAlign = HorizontalAlign.Left
        c1.Text = m_title
        rowItem.Cells.Add(c1)

        m_table.Rows.Add(rowItem)

    End Sub


    Sub BuildList(m_login As String)
        Dim dsJobs1 As DataSet = PhoneSys.GetJobCodes()
        Dim dtJobs1 As DataTable = dsJobs1.Tables(0)
        Dim i As Int32 = 0

        Dim dsJobs2 As DataSet
        Dim dtJobs2 As DataTable
        Dim j As Int32 = 0

        Dim dsEmps As DataSet
        Dim dtEmps As DataTable
        Dim k As Int32 = 0


        ' ***  RETRIEVE HOME OFFICE DEPARTMENTS
        i = 0
        Do While i <= dtJobs1.Rows.Count - 1

            ' ***  SHOW DEPARTMENT HEADING
            WriteDeptHeading(tblDept, dtJobs1.Rows(i).Item("JobDescription"))

            ' ***  RETRIEVE SUB JOB CLASSES PER DEPARTMENT
            dsJobs2 = PhoneSys.GetJobCodes_Second(dtJobs1.Rows(i).Item("job"))
            dtJobs2 = dsJobs2.Tables(0)

            j = 0
            Do While j <= dtJobs2.Rows.Count - 1

                ' ***  SHOW JOB HEADING - ONLY IF THERE ARE MORE THAN 1 JOB CLASS
                If j > 0 Then WriteJobHeading(tblDept, dtJobs2.Rows(j).Item("JobDescription"))

                ' **  RETRIEVE EMPLOYEES
                dsEmps = PhoneSys.GetHomeOffice_Dept(dtJobs2.Rows(j).Item("JobSec"))
                dtEmps = dsEmps.Tables(0)

                k = 0
                Do While k <= dtEmps.Rows.Count - 1

                    ' ***  SHOW EMPLOYEE NAME, EXTENSION AND TITLE
                    WriteListItem(tblDept, dtEmps.Rows(k).Item("empDisplayName"), dtEmps.Rows(k).Item("empExtension"), dtEmps.Rows(k).Item("empTitle"))

                    k = k + 1

                Loop

                j = j + 1

            Loop

            i = i + 1

        Loop


    End Sub


    Sub SetLinks()
        lnkHOName.NavigateUrl = "phoneHomeOffice.aspx?type=name"
        lnkHOName.Text = "View By Name"
        lnkHOExt.NavigateUrl = "phoneHomeOffice.aspx?type=ext"
        lnkHOExt.Text = "View By Extension"

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
               Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
        If String.IsNullOrEmpty(strLogin) Then
            strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
        End If

        If Not Page.IsPostBack Then

            SetLinks()
            BuildList(strLogin)

        End If

    End Sub


End Class
