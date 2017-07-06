Imports System.Drawing
Imports System.Data


Partial Class Main_phonePermsSet

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone
    Dim EmpSys As NAI_Emp = New NAI_Emp
    Dim SecuritySys As NAI_Security = New NAI_Security
    Private Shared prevPage As String = String.Empty


    Sub FillEmpBox()
        Dim ds As DataSet = SecuritySys.GetPerms_List()
        With ddlEmps
            .DataTextField = "empDisplayName"
            .DataValueField = "empAutoNum"
            .DataSource = ds
            .DataBind()
        End With
        ddlEmps.Items.Insert(0, New ListItem("--", "0"))

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' ***  CAPTURE LOGIN
        Dim strLogin As String = Right(Request.ServerVariables("LOGON_USER"), _
          Len(Request.ServerVariables("LOGON_USER")) - InStr(1, Request.ServerVariables("LOGON_USER"), "\"))
        If String.IsNullOrEmpty(strLogin) Then
            strLogin = System.Security.Principal.WindowsIdentity.GetCurrent().Name
            strLogin = Right(strLogin, Len(strLogin) - InStr(1, strLogin, "\"))
        End If


        Try
            ' ***  CAPTURE PREVIOUS PAGE
            prevPage = Request.UrlReferrer.ToString()

            ' ***  SET PAGE HEADER
            lblTitle.Text = "<h2>Assign Phone List Permissions</h2>"


            If Not Page.IsPostBack Then
                FillEmpBox()
            Else
                If ddlEmps.SelectedIndex <> 0 Then
                    Dim currentEmp As PhoneSecuity
                    currentEmp = SecuritySys.GetPhonePermsData(ddlEmps.SelectedValue)

                    If Not (currentEmp Is Nothing) Then
                        With currentEmp
                            lblId.Text = .ID
                            lblSecurityNum.Text = .SecurityID
                            lblAlias.Text = .NetAlias
                            If .UpdatePersonnel = "True" Then chkUpdate.Checked = True
                            If .ViewAuditOffice = "True" Then chkAuditOffice.Checked = True
                            If .ViewAuditHome = "True" Then chkAuditHome.Checked = True
                            If .ViewOpsMgmt = "True" Then chkOpsMgmt.Checked = True
                            If .ViewOpsSupport = "True" Then chkOpsSupport.Checked = True
                            If .UpdateOps = "True" Then chkOpsUpdate.Checked = True
                            If .ViewAreaMgr = "True" Then chkDMView.Checked = True
                            If .UpdateAreaMgr = "True" Then chkDMUpdate.Checked = True
                            If .UpdateAreaOffice = "True" Then chkDOUpdate.Checked = True

                        End With
                    End If

                End If

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


            Dim currentPerms As PhoneSecuity = New PhoneSecuity

            With currentPerms
                .ID = lblId.Text
                .SecurityID = lblSecurityNum.Text
                .NetAlias = lblAlias.Text
                If chkUpdate.Checked = True Then
                    .UpdatePersonnel = "1"
                Else
                    .UpdatePersonnel = "0"
                End If
                If chkAuditOffice.Checked = True Then
                    .ViewAuditOffice = "1"
                Else
                    .ViewAuditOffice = "0"
                End If
                If chkAuditHome.Checked = True Then
                    .ViewAuditHome = "1"
                Else
                    .ViewAuditHome = "0"
                End If
                If chkOpsMgmt.Checked = True Then
                    .ViewOpsMgmt = "1"
                Else
                    .ViewOpsMgmt = "0"
                End If
                If chkOpsSupport.Checked = True Then
                    .ViewOpsSupport = "1"
                Else
                    .ViewOpsSupport = "0"
                End If
                If chkOpsUpdate.Checked = True Then
                    .UpdateOps = "1"
                Else
                    .UpdateOps = "0"
                End If
                If chkDMView.Checked = True Then
                    .ViewAreaMgr = "1"
                Else
                    .ViewAreaMgr = "0"
                End If
                If chkDMUpdate.Checked = True Then
                    .UpdateAreaMgr = "1"
                Else
                    .UpdateAreaMgr = "0"
                End If
                If chkDOUpdate.Checked = True Then
                    .UpdateAreaOffice = "1"
                Else
                    .UpdateAreaOffice = "0"
                End If
            End With


            ' ***  IF THERE IS NO ENTRY FOR THE EMPLOYEE - CREATE ONE 
            If Not SecuritySys.PermsRecExists(currentPerms.ID) Then
                SecuritySys.InsertPermsRec(currentPerms.ID)
            End If

            SecuritySys.UpdatePerms(currentPerms)


            Response.Redirect("menuPhoneList.aspx", False)
            'lblMessage.Text = "Saved"

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

    End Sub


    Protected Sub cmdReturn_Click(sender As Object, e As System.EventArgs) Handles cmdReturn.Click
        'Response.Redirect(prevPage, False)
        Response.Redirect("menuPhoneList.aspx", False)

    End Sub

End Class
