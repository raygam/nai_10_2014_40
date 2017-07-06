
Partial Class Main_menuContactUsMsg

    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If Request.Params("sent") = True Then
                lblMessage.Text = "Your message was sent successfully."
            Else
                lblMessage.Text = "An error occurred sending your message."
            End If

        End If

    End Sub

End Class
