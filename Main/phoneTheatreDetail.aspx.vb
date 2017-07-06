Imports System.Drawing
Imports System.Data


Partial Class Main_phoneTheatreDetail

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone

    Private Shared prevPage As String = String.Empty


    Sub ShowTheatreData(ByVal m_unit As String)
        Dim ds As DataSet
        Dim dt As DataTable
        Dim c1 As TableCell
        Dim rowItem As TableRow
        Dim x As Int32
        Dim currentTheatre As Theatre

        ' ***  RETRIEVE THEATRE DATA
        currentTheatre = PhoneSys.SelectTheatreData(m_unit)

        If Not (currentTheatre Is Nothing) Then
            With currentTheatre
                lblTheatreName.Text = .UnitName
                lblTheatreNumber.Text = .UnitNo
                txtAddress1.Text = .MailingAdd1
                txtAddress2.Text = .MailingAdd2
                txtCity.Text = .MailingCity
                txtState.Text = .MailingState
                txtPostal.Text = .MailingPostal
                txtPhone.Text = .Phone
                txtSpeedDial.Text = .SpeedDial
                txtFax.Text = .FaxNumber
                txtRecording.Text = .RecordingNumber
                txtRecordingSpeed.Text = .RecSpeedDial
                lblCompany.Text = .CompanyNum & " - " & .CompanyName
                lblEIN.Text = .EIN

            End With


            ' ***   RETRIEVE THEATRE EMPLOYEES
            ds = PhoneSys.GetTheatrePersonnel(currentTheatre.UnitNo)
            dt = ds.Tables(0)

            x = 0
            Do While x <= dt.Rows.Count - 1
                rowItem = New TableRow
                rowItem.CssClass = "DATA"

                c1 = New TableCell
                c1.Width = Unit.Pixel(150)
                c1.HorizontalAlign = HorizontalAlign.Right
                c1.Text = dt.Rows(x).Item("JobDescription") & ": "
                rowItem.Cells.Add(c1)

                c1 = New TableCell
                c1.Width = Unit.Pixel(150)
                c1.HorizontalAlign = HorizontalAlign.Left
                c1.Text = "<a href='phoneEmpDetail.aspx?id=" & dt.Rows(x).Item("empautonum") & "'>" & dt.Rows(x).Item("emp_name") & "</a>"
                rowItem.Cells.Add(c1)

                tblEmp.Rows.Add(rowItem)

                x = x + 1

            Loop

        End If


    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' ***  CAPTURE LOGIN
        Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
          Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
        If String.IsNullOrEmpty(strLogin) Then
            strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
        End If


        Dim strTheatre As String = Request.Params("unit")
        If Len(strTheatre) = 0 Then strTheatre = 0

        If Not Page.IsPostBack() Then
            Try
                prevPage = Request.UrlReferrer.ToString()

                lblTitle.Text = "<h2>" & UtilSys.GetTheatreName(strTheatre) & " - (" & strTheatre & ")</h2>"
                ShowTheatreData(strTheatre)

            Catch ex As Exception
                lblMessage.Text = ex.Message

            End Try

        End If


    End Sub


    Protected Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
        Response.Redirect(prevPage)

    End Sub


    Protected Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click
        Try
            ' ***  CAPTURE LOGIN
            Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
              Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
            If String.IsNullOrEmpty(strLogin) Then
                strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
                strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
            End If

            Dim CurrentUnit As Theatre = New Theatre

            With CurrentUnit
                .UnitNo = lblTheatreNumber.Text
                .UnitName = lblTheatreName.Text
                .MailingAdd1 = txtAddress1.Text
                .MailingAdd2 = txtAddress2.Text
                .MailingCity = txtCity.Text
                .MailingState = txtState.Text
                .MailingPostal = txtPostal.Text
                .Phone = txtPhone.Text
                .SpeedDial = txtSpeedDial.Text
                .FaxNumber = txtFax.Text
                .RecordingNumber = txtRecording.Text
                .RecSpeedDial = txtRecordingSpeed.Text

            End With

            ' ***  IF THERE IS NO ENTRY FOR THE THEATRE - CREATE ONE 
            If Not PhoneSys.TheatreExists(CurrentUnit.UnitNo) Then
                PhoneSys.InsertTheatre(CurrentUnit.UnitNo)
            End If

            ' ***  UPDATE THEATRE DATA
            PhoneSys.UpdateTheatre(CurrentUnit)

            ' ***  REDIRECT TO LIST PAGE
            Response.Redirect("menuPhoneList.aspx", False)
            'lblMessage.Text = "Saved"

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

    End Sub


End Class
