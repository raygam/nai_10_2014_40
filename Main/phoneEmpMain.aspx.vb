Imports System.Drawing
Imports System.Data


Partial Class Main_phoneEmpMain

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

        lblTitle.Text = "<h2>Employee Maintenance</h2>"


        If Not Page.IsPostBack Then
            FillEmpBox()

        End If

    End Sub


    Protected Sub cmdAdd_Click(sender As Object, e As System.EventArgs) Handles cmdAdd.Click
        Dim intID As Integer

        Try
            intID = EmpSys.InsertEmployee()

            Response.Redirect("phoneEmpDetail.aspx?id=" & intID, False)

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

    End Sub


    Protected Sub cmdEdit_Click(sender As Object, e As System.EventArgs) Handles cmdEdit.Click
        If ddlEmps.SelectedValue = 0 Then
            lblMessage.Text = "Please select employee to edit."

        Else
            Response.Redirect("phoneEmpDetail.aspx?id=" & ddlEmps.SelectedValue, False)

        End If

    End Sub


    Protected Sub cmdReturn_Click(sender As Object, e As System.EventArgs) Handles cmdReturn.Click
        Response.Redirect("menuPhoneList.aspx", False)

    End Sub


    Protected Sub cmdRemove_Click(sender As Object, e As System.EventArgs) Handles cmdRemove.Click
        If ddlEmps.SelectedValue = 0 Then
            lblMessage.Text = "Please select employee to remove."

        Else
            Response.Redirect("phoneEmpRemove.aspx?id=" & ddlEmps.SelectedValue, False)

        End If

    End Sub

End Class
