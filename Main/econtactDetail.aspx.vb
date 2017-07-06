Imports System.Drawing
Imports System.Data
Imports System.Net.Mail


Partial Class Main_econtactDetail

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone
    Dim EmpSys As NAI_Emp = New NAI_Emp
    Dim SecuritySys As NAI_Security = New NAI_Security
    Private Shared prevPage As String = String.Empty


    Sub SendAlert(ByVal strBody As String)
        Dim objMail As MailMessage
        objMail = New MailMessage
        With objMail
            .From = New MailAddress("Home_Office@National-Amusements.com")
            .To.Add("RGambardella@National-Amusements.com")
            .Subject = "Alert - Emergency Contact Change"
            .Body = strBody
            .IsBodyHtml = True

        End With

        Dim smtp As SmtpClient = New SmtpClient("127.0.0.1")
        smtp.Send(objMail)

    End Sub


    Sub GetEcontact(m_id As Integer)
        Dim currentEmp As EContact
        currentEmp = EmpSys.GetEContactData(m_id)

        If Not (currentEmp Is Nothing) Then
            With currentEmp
                lblEmpId.Text = .EmpId
                lblContactID.Text = .ContactId
                lblFirst.Text = .FirstName
                lblLast.Text = .LastName
                txtAddress1.Text = .HomeAddress1
                txtAddress2.Text = .HomeAddress2
                txtCity.Text = .HomeCity
                txtState.Text = .HomeState
                txtPostal.Text = .HomePostal
                txtPhone.Text = .HomePhone
                txtContactFirst.Text = .ContactFirst
                txtContactLast.Text = .ContactLast
                txtContactRelation.Text = .Relationship
                txtContactPhone.Text = .ContactPhone
                txtPlate1.Text = .Auto1License
                txtState1.Text = .Auto1State
                txtColor1.Text = .Auto1Color
                txtMake1.Text = .Auto1Make
                txtModel1.Text = .Auto1Model
                txtYear1.Text = .Auto1Year
                txtPlate2.Text = .Auto2License
                txtState2.Text = .Auto2State
                txtColor2.Text = .Auto2Color
                txtMake2.Text = .Auto2Make
                txtModel2.Text = .Auto2Model
                txtYear2.Text = .Auto2Year

            End With
        End If

        lblTitle.Text = "<h2>Emergency Contact - " & currentEmp.FirstName & " " & currentEmp.LastName & "</h2>"

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' ***  CAPTURE LOGIN
        Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
           Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
        If String.IsNullOrEmpty(strLogin) Then
            strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
        End If

        Dim intID As Integer = CInt(Request.Params("id"))

        Try
            If Not Page.IsPostBack Then
                GetEcontact(intID)

                prevPage = Request.UrlReferrer.ToString()

            End If

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

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

            Dim currentEmp As EContact = New EContact
            With currentEmp
                .EmpId = lblEmpId.Text
                .ContactId = lblContactID.Text
                .FirstName = lblFirst.Text
                .LastName = lblLast.Text
                .HomeAddress1 = txtAddress1.Text
                .HomeAddress2 = txtAddress2.Text
                .HomeCity = txtCity.Text
                .HomeState = txtState.Text
                .HomePostal = txtPostal.Text
                .HomePhone = txtPhone.Text
                .ContactFirst = txtContactFirst.Text
                .ContactLast = txtContactLast.Text
                .Relationship = txtContactRelation.Text
                .ContactPhone = txtContactPhone.Text
                .Auto1License = txtPlate1.Text
                .Auto1State = txtState1.Text
                .Auto1Color = txtColor1.Text
                .Auto1Make = txtMake1.Text
                .Auto1Model = txtModel1.Text
                .Auto1Year = txtYear1.Text
                .Auto2License = txtPlate2.Text
                .Auto2State = txtState2.Text
                .Auto2Color = txtColor2.Text
                .Auto2Make = txtMake2.Text
                .Auto2Model = txtModel2.Text
                .Auto2Year = txtYear2.Text

            End With

            ' ***  IF THERE IS NO ENTRY FOR THE EMPLOYEE - CREATE ONE 
            If Not EmpSys.EContactRecExists(currentEmp.EmpId) Then
                EmpSys.InsertEContactRec(currentEmp.EmpId)
            End If

            EmpSys.UpdateEContact(currentEmp)

            ' ***  SEND MESSAGE
            Dim xBody As String = "Emergency contact information has been updated for : " & currentEmp.FirstName & " " & currentEmp.LastName
            SendAlert(xBody)


            Response.Redirect(prevPage, False)

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

    End Sub


    Protected Sub cmdReturn_Click(sender As Object, e As System.EventArgs) Handles cmdReturn.Click
        Response.Redirect(prevPage, False)

    End Sub

End Class
