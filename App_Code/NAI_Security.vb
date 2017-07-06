' *******************************************
' ***       NAI_Security.vb    10/28/2014       RG
' ***
' ***
' *******************************************

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class PhoneSecuity
    Public ID As Integer
    Public SecurityID As Integer
    Public NetAlias As String
    Public Unit As String
    Public UpdatePersonnel As String
    Public ViewAuditOffice As String
    Public ViewAuditHome As String
    Public ViewOpsMgmt As String
    Public ViewOpsSupport As String
    Public UpdateOps As String
    Public ViewAreaMgr As String
    Public UpdateAreaMgr As String
    Public UpdateAreaOffice As String

End Class


Public Class NAI_Security

    Function IsOps(p_login As String) As Boolean
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand
        Dim blnResult As Boolean = False
        Dim strSQL As String = ""

        ' strSQL = "SELECT * FROM tblPersonnel " & _
        '              " WHERE empAlias = '" & p_login & "' AND empActiveFlag = 'A' " & _
        '           " AND ( district IS NOT NULL OR LEFT(JobClass, 3) = 030) "

        strSQL = "SELECT * FROM tblPersonnel " & _
                        " WHERE empAlias = '" & p_login & "' AND empActiveFlag = 'A' " & _
                        " AND ( LEFT(JobClass, 3) = 030) "

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = strSQL

        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.HasRows Then blnResult = True

        Return blnResult

    End Function


    Function IsDistrictUser(p_login As String) As Boolean
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand
        Dim blnResult As Boolean = False
        Dim strSQL As String = ""

        strSQL = "SELECT * FROM tblPersonnel " & _
                        " WHERE empAlias = '" & p_login & "' AND empActiveFlag = 'A' " & _
                        " AND ( district IS NOT NULL) AND JobClass = 109"

        'strSQL = "SELECT * FROM tblPersonnel " & _
        '      " WHERE empAlias = '" & p_login & "' AND empActiveFlag = 'A' " & _
        '    " AND ( LEFT(JobClass, 3) = 030) "

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = strSQL

        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.HasRows Then blnResult = True

        Return blnResult

    End Function


    Function GetDistrict(p_login As String) As String
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand
        Dim strDistrict As String = "0"
        Dim strSQL As String = ""

        strSQL = "SELECT * FROM tblPersonnel " & _
                " WHERE empAlias = '" & p_login & "' AND empActiveFlag = 'A' " & _
                " AND ( district IS NOT NULL) AND JobClass = 109"

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = strSQL

        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.HasRows Then
            While rdr.Read()
                If Len(rdr("district")) > 0 Then strDistrict = rdr("district")
            End While
        End If

        Return strDistrict

    End Function


    Function IsHR(p_login As String) As Boolean
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand
        Dim blnResult As Boolean = False
        Dim strSQL As String = ""

        strSQL = "SELECT * FROM tblPersonnel " & _
                        " WHERE empAlias = '" & p_login & "' AND empActiveFlag = 'A' " & _
                        " AND ( district IS NOT NULL OR LEFT(JobClass, 3) = 060) "

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = strSQL

        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.HasRows Then blnResult = True

        Return blnResult

    End Function


    Sub InsertPermsRec(ByVal p_id As Integer)
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_PhonePermsInsert"

            .Parameters.Add("@id", SqlDbType.Int).Value = p_id

            .ExecuteNonQuery()

        End With

        cn.Close()

    End Sub


    Function PermsRecExists(p_id As Integer) As Boolean
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand
        Dim blnResult As Boolean = False

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM tblPhoneSecurity WHERE empAutonum = " & p_id

        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.HasRows Then blnResult = True

        Return blnResult

    End Function


    Sub UpdatePerms(ByVal pRec As PhoneSecuity)
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_PhonePermsUpdate"

            .Parameters.Add("@id", SqlDbType.Int).Value = pRec.ID
            .Parameters.Add("@alias", SqlDbType.VarChar, 50).Value = pRec.NetAlias
            .Parameters.Add("@updpers", SqlDbType.VarChar, 1).Value = pRec.UpdatePersonnel
            .Parameters.Add("@auditoff", SqlDbType.VarChar, 1).Value = pRec.ViewAuditOffice
            .Parameters.Add("@auditpers", SqlDbType.VarChar, 1).Value = pRec.ViewAuditHome
            .Parameters.Add("@opsmgmt", SqlDbType.VarChar, 1).Value = pRec.ViewOpsMgmt
            .Parameters.Add("@opssup", SqlDbType.VarChar, 1).Value = pRec.ViewOpsSupport
            .Parameters.Add("@opsupd", SqlDbType.VarChar, 1).Value = pRec.UpdateOps
            .Parameters.Add("@dmview", SqlDbType.VarChar, 1).Value = pRec.ViewAreaMgr
            .Parameters.Add("@dmupd", SqlDbType.VarChar, 1).Value = pRec.UpdateAreaMgr
            .Parameters.Add("@doupd", SqlDbType.VarChar, 1).Value = pRec.UpdateAreaOffice

            .ExecuteNonQuery()

        End With

        cn.Close()

    End Sub


    Function GetPhonePermsData(ByVal p_id As Int32) As PhoneSecuity
        Dim clsEmp As New PhoneSecuity
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand
        Dim strSQL As String = ""

        strSQL = "SELECT A.*, B.* FROM tblPersonnel A " & _
                        " LEFT OUTER JOIN tblPhoneSecurity B ON A.empAutoNum = B.empAutoNum " & _
                        " WHERE A.empAutoNum = " & p_id & " AND A.empActiveFlag = 'A' "
        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = strSQL
        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.Read() Then
            With clsEmp
                .ID = p_id
                If Not IsDBNull(rdr("SecurityAutoNum")) Then .SecurityID = Trim(rdr("SecurityAutoNum"))
                If Not IsDBNull(rdr("empAlias")) Then .NetAlias = Trim(rdr("empAlias"))
                If Not IsDBNull(rdr("LocationNum")) Then .Unit = Trim(rdr("LocationNum"))
                If Not IsDBNull(rdr("maintain")) Then .UpdatePersonnel = Trim(rdr("maintain"))
                If Not IsDBNull(rdr("auditors")) Then .ViewAuditOffice = Trim(rdr("auditors"))
                If Not IsDBNull(rdr("auditorspers")) Then .ViewAuditHome = Trim(rdr("auditorspers"))
                If Not IsDBNull(rdr("opsmgmtpers")) Then .ViewOpsMgmt = Trim(rdr("opsmgmtpers"))
                If Not IsDBNull(rdr("opssupportpers")) Then .ViewOpsSupport = Trim(rdr("opssupportpers"))
                If Not IsDBNull(rdr("opschange")) Then .UpdateOps = Trim(rdr("opschange"))
                If Not IsDBNull(rdr("dmpers")) Then .ViewAreaMgr = Trim(rdr("dmpers"))
                If Not IsDBNull(rdr("dmchange")) Then .UpdateAreaMgr = Trim(rdr("dmchange"))
                If Not IsDBNull(rdr("dochange")) Then .UpdateAreaOffice = Trim(rdr("dochange"))

            End With

        End If

        rdr.Close()

        Return clsEmp

    End Function


    Function GetPerms_List() As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand
        Dim strSQL As String = ""

        strSQL = "SELECT * FROM tblPersonnel " & _
                            " WHERE empAlias IS NOT NULL AND empAlias <> '' AND empActiveFlag = 'A' AND empFirstName <> '' " & _
                            " ORDER BY empDisplayName ASC "

        cn.Open()

        With cmd
            .CommandText = strSQL
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


End Class
