' *******************************************
' ***       NAI_Utils.vb    10/9/2014       RG
' ***
' ***
' *******************************************

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class NAI_Utils

    Function GetTheatres() As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .CommandText = "SELECT * FROM AS400.dbo.REPLOC WHERE    (RELSTS = 'A' OR REDOPN > GETDATE()) AND RELOC# < 2000  ORDER BY RELNMI"
            .CommandType = CommandType.Text
            .Connection = cn

        End With

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        cn.Close()

        Return ds

    End Function


    Function GetJobCodes() As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .CommandText = "SELECT DISTINCT * FROM tblJobCodes WHERE job = jobsec ORDER BY JobDescription"
            .CommandType = CommandType.Text
            .Connection = cn

        End With

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        cn.Close()

        Return ds

    End Function


    Function GetTheatreName(ByVal p_theatre As Integer) As String
        Dim strTemp As String
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand
        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_GetLocationName"

            .Parameters.Add("@loc", SqlDbType.Int).Value = p_theatre
            .Parameters.Add("@name", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output

            .ExecuteNonQuery()
            strTemp = .Parameters("@name").Value

        End With

        cn.Close()

        Return strTemp

    End Function


    Function ViewMenuItem(ByVal p_login As String, p_group As String) As Boolean
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim strSQL As String = "EXEC master..xp_logininfo '" & p_login & "', @option='all' "
        Dim cmd As New SqlCommand(strSQL, cn)

        Dim booResult As Boolean = False

        With cmd
            .CommandType = CommandType.Text
            .Connection = cn

        End With

        cn.Open()

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        While rdr.Read()
            If Not IsDBNull(rdr("permission path")) Then
                If UCase(rdr("permission path")) = p_group Then booResult = True
            End If
        End While

        rdr.Close()

        Return booResult

    End Function


    Function ViewAppLink(ByVal p_login As String, p_app As String) As Boolean
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim strSQL As String = "SELECT * FROM applink_data WHERE user_id = '" & p_login & "' AND app = '" & p_app & "' AND status = 'A' "
        Dim cmd As New SqlCommand(strSQL, cn)

        Dim booResult As Boolean = False

        With cmd
            .CommandType = CommandType.Text
            .Connection = cn

        End With

        cn.Open()
        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.HasRows Then booResult = True
        rdr.Close()

        Return booResult

    End Function


    Function GetLinkSetting(ByVal p_link As String) As String
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM doclink_hdr_data WHERE link = '" & Trim(p_link) & "'", cn)
        Dim strDataValue As String = ""
        cn.Open()

        Dim rdr As SqlDataReader = cmd.ExecuteReader()
        While rdr.Read()
            If Not IsDBNull(rdr("ref")) Then strDataValue = Trim(rdr("ref"))
        End While
        cn.Close()

        Return strDataValue

    End Function


    Function GetAppSetting(ByVal strKey As String) As String
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand("SELECT * FROM app_settings WHERE reg_key = '" & Trim(strKey) & "'", cn)
        Dim strDataValue As String = " "
        cn.Open()

        Dim rdr As SqlDataReader = cmd.ExecuteReader()
        While rdr.Read()
            strDataValue = Trim(rdr("reg_value"))
        End While
        cn.Close()

        Return strDataValue

    End Function


End Class
