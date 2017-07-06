Imports System.Drawing


Partial Class Main_menuContactUs

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone
    Dim ContactSys As NAI_ContactUs = New NAI_ContactUs


    Sub FillSubjects(ByVal subList As DropDownList)
        With subList
            .DataSource = ContactSys.GetSubjects()
            .DataTextField = "contact_issue"
            .DataValueField = "rec_id"
            .DataBind()

            ' *** ADD ENTRY FOR "Select Subject"
            .Items.Insert(0, New ListItem("---- Select Subject ----", "0"))

        End With

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            FillSubjects(ddlSubject)


        End If

    End Sub


    Protected Sub cmdSend_Click(sender As Object, e As System.EventArgs) Handles cmdSend.Click
        If Page.IsValid Then
            Dim intSubject As Integer = ddlSubject.SelectedValue
            Dim strFrom As String = Trim(txtEmail.Text)
            Dim strName As String = Trim(txtName.Text)
            Dim strBody As String = Trim(txtBody.Text)
            Dim strMessage As String = ""
            Dim booSend As Boolean


            ' ***  BUILD MESSAGE
            strMessage = "Name : " & strName & "<BR>"
            strMessage = strMessage & "Email : " & strFrom & "<BR>"
            strMessage = strMessage & "<HR size=1><BR>"
            strMessage = strMessage & strBody

            'lblMessage.Text = ContactSys.SendSupportMessage(intSubject, strName, strFrom, strMessage)
            booSend = ContactSys.SendSupportMessage(intSubject, strName, strFrom, strMessage)

            Response.Redirect("menuContactUsMsg.aspx?sent=" & booSend, False)

        End If

    End Sub


End Class
