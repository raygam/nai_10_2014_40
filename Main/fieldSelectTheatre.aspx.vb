Imports System.Data
Imports System.Drawing


Partial Class Main_fieldSelectTheatre

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone
    Dim EmpSys As NAI_Emp = New NAI_Emp
    Dim SecuritySys As NAI_Security = New NAI_Security
    Private Shared prevPage As String = String.Empty


    Sub FillTheatreBox(m_district As String)
        Dim ds As DataSet
        If (Len(Trim(m_district)) > 0) And (m_district <> "0") Then
            ds = PhoneSys.GetTheatresByDistrict(CInt(m_district))
        Else
            ds = UtilSys.GetTheatres()
        End If

        With ddlTheatres
            .DataTextField = "RELNMI"
            .DataValueField = "RELOC#"
            .DataSource = ds
            .DataBind()
        End With
        ddlTheatres.Items.Insert(0, New ListItem("--", "0"))

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' ***  CAPTURE LOGIN
        Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
          Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
        If String.IsNullOrEmpty(strLogin) Then
            strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
        End If

        lblTitle.Text = "<h2>Theatre Maintenance</h2>"

        If Not Page.IsPostBack Then
            FillTheatreBox(Request.Params("dist"))

            prevPage = Request.UrlReferrer.ToString()

        End If

    End Sub


    Protected Sub cmdEdit_Click(sender As Object, e As System.EventArgs) Handles cmdEdit.Click
        Try
            If ddlTheatres.SelectedValue = 0 Then
                lblMessage.Text = "Please select a theatre to edit."

            Else
                Response.Redirect("phoneTheatreDetail.aspx?unit=" & ddlTheatres.SelectedValue, False)

            End If

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

    End Sub


    Protected Sub cmdReturn_Click(sender As Object, e As System.EventArgs) Handles cmdReturn.Click
        Response.Redirect(prevPage, False)

    End Sub


End Class
