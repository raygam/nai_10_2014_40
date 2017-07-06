Imports System.Drawing
Imports System.Data


Partial Class Main_phoneEmpDetail

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone
    Dim EmpSys As NAI_Emp = New NAI_Emp
    Private Shared prevPage As String = String.Empty


    Sub ShowEmployeeData(ByVal m_id As String)
        Dim currentEmp As Employee

        ' ***  RETRIEVE EMPLOYEE DATA
        currentEmp = EmpSys.GetEmployeeData(m_id)

        If Not (currentEmp Is Nothing) Then
            With currentEmp
                ' ***  SHOW TITLE
                lblTitle.Text = "<h2>Information for " & .FirstName & " " & .LastName & "</h2>"
                lblID.Text = .ID
                txtFirst.Text = .FirstName
                txtLast.Text = .LastName
                txtAlias.Text = .NetAlias
                txtEmail.Text = .Email
                txtTitle.Text = .Title
                If Len(Trim(.ActiveFlag)) = 0 Then
                    lblActive.Text = "A"
                Else
                    lblActive.Text = .ActiveFlag
                End If
                txtOfficeExt.Text = .Extension
                txtOfficeAdd1.Text = .OfficeAddress1
                txtOfficeAdd2.Text = .OfficeAddress2
                txtOfficeCity.Text = .OfficeCity
                txtOfficeState.Text = .OfficeState
                txtOfficePostal.Text = .OfficePostal
                txtOfficePhone.Text = .OfficePhone
                txtOfficeSD.Text = .OfficeSpeedDial
                txtOfficeFax.Text = .OfficeFax
                txtHomeAddress1.Text = .HomeAdd1
                txtHomeAddress2.Text = .HomeAdd2
                txtHomeCity.Text = .HomeCity
                txtHomeState.Text = .HomeState
                txtHomePostal.Text = .HomePostal
                txtHomePhone.Text = .HomePhone
                txtMobile.Text = .Mobile

                ddlJobClass.SelectedValue = .JobClass
                ddlLocation.SelectedValue = .Location

            End With


        End If


    End Sub


    Sub BuildJobsBox()
        Dim ds As DataSet = UtilSys.GetJobCodes()
        With ddlJobClass
            .DataTextField = "JobDescription"
            .DataValueField = "JobSec"
            .DataSource = ds
            .DataBind()
        End With
        ddlJobClass.Items.Insert(0, New ListItem("--", "0"))

    End Sub


    Sub BuildLocationsBox()
        Dim ds As DataSet = UtilSys.GetTheatres()
        With ddlLocation
            .DataTextField = "RELNMI"
            .DataValueField = "RELOC#"
            .DataSource = ds
            .DataBind()
        End With

        ddlLocation.Items.Insert(0, New ListItem("--", "0"))
        ddlLocation.Items.Insert(1, New ListItem("HOME OFFICE", "0001"))

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' ***  CAPTURE LOGIN
        Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
          Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
        If String.IsNullOrEmpty(strLogin) Then
            strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
        End If

        Dim strID As String = Request.Params("id")

        If Not Page.IsPostBack() Then

            Try
                prevPage = Request.UrlReferrer.ToString()

                BuildJobsBox()
                BuildLocationsBox()
                ShowEmployeeData(strID)


            Catch ex As Exception
                lblMessage.Text = ex.Message

            End Try

        End If


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

            Dim CurrentEmp As Employee = New Employee

            With CurrentEmp
                .ID = lblID.Text
                .Title = txtTitle.Text
                .FirstName = txtFirst.Text
                .LastName = txtLast.Text
                .Location = ddlLocation.SelectedValue
                .Email = txtEmail.Text
                .NetAlias = txtAlias.Text
                .ActiveFlag = lblActive.Text
                .Extension = txtOfficeExt.Text
                .OfficeAddress1 = txtOfficeAdd1.Text
                .OfficeAddress2 = txtOfficeAdd2.Text
                .OfficeCity = txtOfficeCity.Text
                .OfficeState = txtOfficeState.Text
                .OfficePostal = txtOfficePostal.Text
                .OfficePhone = txtOfficePhone.Text
                .OfficeSpeedDial = txtOfficeSD.Text
                .OfficeFax = txtOfficeFax.Text
                .HomeAdd1 = txtHomeAddress1.Text
                .HomeAdd2 = txtHomeAddress2.Text
                .HomeCity = txtHomeCity.Text
                .HomeState = txtHomeState.Text
                .HomePostal = txtHomePostal.Text
                .HomePhone = txtHomePhone.Text
                .Mobile = txtMobile.Text
                .JobClass = ddlJobClass.SelectedValue

            End With

            ' ***  UPDATE PROPERTY RECORD USING PROP DETAILS OBJECT
            EmpSys.UpdateEmployee(CurrentEmp)

            ' ***  REDIRECT TO LIST PAGE
            Response.Redirect(prevPage, False)
            'lblMessage.Text = "Saved"

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try


    End Sub


    Protected Sub cmdCancel_Click(sender As Object, e As System.EventArgs) Handles cmdCancel.Click
        Response.Redirect(prevPage)

    End Sub


End Class
