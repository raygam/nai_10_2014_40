' *******************************************
' ***       NAI_ContactUs.vb      10/14/2014       RG
' ***
' ***
' *******************************************

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail


Public Class NAI_ContactUs


    Function SendSupportMessage(ByVal intToID As Integer, ByVal strName As String, _
                                    ByVal strFrom As String, ByVal strBody As String) As Boolean
        Dim oMsg As MailMessage = New MailMessage
        With oMsg
            .To.Add(GetSupportData("EMAIL", intToID))
            .From = New MailAddress(strFrom)
            .Subject = " *** MIS Support -- " & GetSupportData("SUBJECT", intToID) & " *** "
            .IsBodyHtml = True
            .Body = strBody
        End With

        Dim smtp As SmtpClient = New SmtpClient("127.0.0.1")

        Try
            smtp.Send(oMsg)
            oMsg = Nothing
            'Return "Your message has been sent."
            Return True

        Catch ex As Exception
            'Return ex.Message
            'Return "An error occurred sending your message."
            Return False

        End Try

    End Function


    Function GetAppSetting(ByVal strKey As String) As String
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM app_settings WHERE reg_key = '" & Trim(strKey) & "'", cn)
        Dim strDataValue As String = ""
        cn.Open()

        Dim rdr As SqlDataReader = cmd.ExecuteReader()
        While rdr.Read()
            strDataValue = Trim(rdr("reg_value"))
        End While
        cn.Close()

        Return strDataValue

    End Function


    Function GetSupportData(ByVal strType As String, ByVal intId As Integer) As String
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM contact_us_data WHERE rec_id = " & intId, cn)
        Dim strDataValue As String = ""
        cn.Open()

        Dim rdr As SqlDataReader = cmd.ExecuteReader()
        While rdr.Read()
            Select Case strType
                Case "SUBJECT"
                    strDataValue = Trim(rdr("contact_issue"))
                Case "EMAIL"
                    strDataValue = Trim(rdr("contact_email"))

            End Select

        End While
        cn.Close()

        Return strDataValue

    End Function


    Function GetSubjects() As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM contact_us_data WHERE active_flag = 'A' ORDER BY contact_issue ", cn)

        cmd.CommandType = CommandType.Text
        cmd.Connection = cn

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)

        Return ds

    End Function


End Class
