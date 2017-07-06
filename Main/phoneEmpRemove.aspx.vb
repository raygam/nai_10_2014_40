Imports System.Drawing
Imports System.Data


Partial Class Main_phoneEmpRemove

    Inherits System.Web.UI.Page

    ' ***  CLASS VARIABLES
    Dim UtilSys As NAI_Utils = New NAI_Utils
    Dim PhoneSys As NAI_Phone = New NAI_Phone
    Dim EmpSys As NAI_Emp = New NAI_Emp
    Dim SecuritySys As NAI_Security = New NAI_Security
    Private Shared prevPage As String = String.Empty


    Sub GetEmployee(m_id As Integer)
        Dim currentEmp As Employee = EmpSys.GetEmployeeData(m_id)
        If Not (currentEmp Is Nothing) Then
            Label1.Text = "Are you sure you want to remove " & currentEmp.FirstName & " " & currentEmp.LastName & " ?  Click Remove to continue, Return to go back."
        End If

    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblTitle.Text = "<h2>Remove Employee</h2>"

        Dim strID As String = Request.Params("id")
        lblId.Text = strID

        If Not Page.IsPostBack Then
            Try
                prevPage = Request.UrlReferrer.ToString()

                GetEmployee(CInt(strID))

            Catch ex As Exception
                lblMessage.Text = ex.Message

            End Try

        End If

    End Sub


    Protected Sub cmdRemove_Click(sender As Object, e As System.EventArgs) Handles cmdRemove.Click
        Try
            EmpSys.RemoveEmployee(lblId.Text)

            Response.Redirect(prevPage, False)

        Catch ex As Exception
            lblMessage.Text = ex.Message

        End Try

    End Sub


    Protected Sub cmdReturn_Click(sender As Object, e As System.EventArgs) Handles cmdReturn.Click
        Response.Redirect(prevPage, False)

    End Sub

End Class
