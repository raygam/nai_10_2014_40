' *******************************************
' ***       NAI_Phone.vb    10/14/2014       RG
' ***
' ***
' *******************************************

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class Theatre
    Public UnitNo As Integer
    Public UnitName As String
    Public Address1 As String
    Public Address2 As String
    Public City As String
    Public State As String
    Public Postal As String
    Public MailingAdd1 As String
    Public MailingAdd2 As String
    Public MailingCity As String
    Public MailingState As String
    Public MailingPostal As String
    Public Phone As String
    Public SpeedDial As String
    Public FaxNumber As String
    Public RecordingNumber As String
    Public RecSpeedDial As String
    Public CompanyNum As String
    Public CompanyName As String
    Public EIN As String

End Class


Public Class CityManager
    Public ID As Integer
    Public CityArea As Integer
    Public CAName As String
    Public JobClass As String
    Public FirstName As String
    Public LastName As String
    Public Address1 As String
    Public Address2 As String
    Public City As String
    Public State As String
    Public Postal As String
    Public ActiveFlag As String
    Public Title As String
    Public Phone As String
    Public FaxNumber As String
    Public Email As String
    Public HomeAdd1 As String
    Public HomeAdd2 As String
    Public HomeCity As String
    Public HomeState As String
    Public HomePostal As String
    Public HomePhone As String
    Public Mobile As String
    Public OfficeSpeedDial As String

End Class


Public Class CityArea
    Public CityArea As Integer
    Public CAName As String
    Public CAEmail As String

End Class



Public Class NAI_Phone

    ' ***  CLASS VARIABLES
    Dim EIN_Number As String


    Function FormatTaxID(ByVal ID As String) As String
        Dim TrimID As String
        Dim strReturn As String = ""

        If Len(ID) > 2 And ID <> "Not Found" Then
            TrimID = Trim(ID)
            If TrimID > " " Then
                strReturn = Left(TrimID, 2) & "-" & Right(TrimID, Len(TrimID) - 2)
            Else
                strReturn = " "
            End If
        End If

        Return strReturn
    End Function


    Function PadUnit(ByVal p_unit As String) As String
        Dim str4Digit As String = p_unit
        Do While Len(str4Digit) < 4
            str4Digit = "0" & str4Digit
        Loop
        Return str4Digit
    End Function


    Function TheatreExists(p_unit As Integer) As Boolean
        Dim clsTheatre As New Theatre
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand
        Dim blnResult As Boolean = False

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM tblLocationInfo WHERE LocNum = " & p_unit

        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.HasRows Then blnResult = True

        Return blnResult

    End Function


    Sub UpdateTheatre(ByVal pRec As Theatre)
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_TheatreUpdate"

            .Parameters.Add("@loc", SqlDbType.VarChar, 6).Value = pRec.UnitNo
            .Parameters.Add("@locname", SqlDbType.VarChar, 50).Value = pRec.UnitName
            .Parameters.Add("@address1", SqlDbType.VarChar, 50).Value = pRec.MailingAdd1
            .Parameters.Add("@address2", SqlDbType.VarChar, 50).Value = pRec.MailingAdd2
            .Parameters.Add("@city", SqlDbType.VarChar, 50).Value = pRec.MailingCity
            .Parameters.Add("@state", SqlDbType.VarChar, 50).Value = pRec.MailingState
            .Parameters.Add("@postal", SqlDbType.VarChar, 50).Value = pRec.MailingPostal
            .Parameters.Add("@phone", SqlDbType.VarChar, 50).Value = pRec.Phone
            .Parameters.Add("@sd", SqlDbType.VarChar, 50).Value = pRec.SpeedDial
            .Parameters.Add("@fax", SqlDbType.VarChar, 50).Value = pRec.FaxNumber
            .Parameters.Add("@recphone", SqlDbType.VarChar, 50).Value = pRec.RecordingNumber
            .Parameters.Add("@recsd", SqlDbType.VarChar, 50).Value = pRec.RecSpeedDial

            .ExecuteNonQuery()

        End With

        cn.Close()

    End Sub


    Sub InsertTheatre(ByVal p_unit As Integer)
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_TheatreInsert"

            .Parameters.Add("@loc", SqlDbType.VarChar, 6).Value = p_unit

            .ExecuteNonQuery()

        End With

        cn.Close()

    End Sub


    ' ***  RETRIEVE THEATRE DATA
    Function SelectTheatreData(ByVal p_unit As Int32) As Theatre
        Dim clsTheatre As New Theatre
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_GetLocationInfo"
            .Parameters.Add("@unit", SqlDbType.Int).Value = p_unit
        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.Read() Then
            With clsTheatre
                .UnitNo = rdr("RELOC#")
                .UnitName = rdr("RELNMI")
                .Address1 = Trim(rdr("READR1"))
                .Address2 = Trim(rdr("READR2"))
                .City = Trim(rdr("RECITY"))
                .State = Trim(rdr("RESTAT"))
                .Postal = Trim(rdr("REZIP"))
                If Not IsDBNull(rdr("phone")) Then .Phone = Trim(rdr("phone"))
                If Not IsDBNull(rdr("speeddial")) Then .SpeedDial = Trim(rdr("speeddial"))
                If Not IsDBNull(rdr("faxphone")) Then .FaxNumber = Trim(rdr("faxphone"))
                If Not IsDBNull(rdr("recordingphone")) Then .RecordingNumber = Trim(rdr("recordingphone"))
                If Not IsDBNull(rdr("recordingspeeddial")) Then .RecSpeedDial = Trim(rdr("recordingspeeddial"))
                If Not IsDBNull(rdr("address1")) Then .MailingAdd1 = Trim(rdr("address1"))
                If Not IsDBNull(rdr("address2")) Then .MailingAdd2 = Trim(rdr("address2"))
                If Not IsDBNull(rdr("city")) Then .MailingCity = Trim(rdr("city"))
                If Not IsDBNull(rdr("state")) Then .MailingState = Trim(rdr("state"))
                If Not IsDBNull(rdr("postalcode")) Then .MailingPostal = Trim(rdr("postalcode"))

                .CompanyNum = GetTheatreCompanyNumber(PadUnit(.UnitNo))
                .CompanyName = GetTheatreCompanyName(.CompanyNum)
                .EIN = FormatTaxID(EIN_Number)


            End With

        End If

        rdr.Close()

        Return clsTheatre

    End Function


    ' ***  RETRIEVE CITY MANAGER DATA
    Function SelectCityMgrData(ByVal p_ca As Int32) As CityManager
        Dim clsCM As New CityManager
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_GetDMInfo"
            .Parameters.Add("@district", SqlDbType.Int).Value = p_ca
        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.Read() Then
            With clsCM
                .CityArea = p_ca
                If Not IsDBNull(rdr("empautonum")) Then .ID = Trim(rdr("empautonum"))
                If Not IsDBNull(rdr("redisname")) Then .CAName = Trim(rdr("redisname"))
                If Not IsDBNull(rdr("empfirstname")) Then .FirstName = Trim(rdr("empfirstname"))
                If Not IsDBNull(rdr("emplastname")) Then .LastName = Trim(rdr("emplastname"))
                If Not IsDBNull(rdr("empTitle")) Then .Title = Trim(rdr("emptitle"))
                If Not IsDBNull(rdr("HomeAddressLine1")) Then .Address1 = Trim(rdr("HomeAddressLine1"))
                If Not IsDBNull(rdr("HomeAddressLine2")) Then .Address2 = Trim(rdr("HomeAddressLine2"))
                If Not IsDBNull(rdr("city")) Then .City = Trim(rdr("city"))
                If Not IsDBNull(rdr("state")) Then .State = Trim(rdr("state"))
                If Not IsDBNull(rdr("postalcode")) Then .Postal = Trim(rdr("postalcode"))
                If Not IsDBNull(rdr("empTitle")) Then .Title = Trim(rdr("empTitle"))
                If Not IsDBNull(rdr("OfficePhone")) Then .Phone = Trim(rdr("OfficePhone"))
                If Not IsDBNull(rdr("OfficeFax")) Then .FaxNumber = Trim(rdr("OfficeFax"))
                If Not IsDBNull(rdr("EmailAddress")) Then .Email = Trim(rdr("EmailAddress"))
                If Not IsDBNull(rdr("HomePhone")) Then .HomePhone = Trim(rdr("HomePhone"))
                If Not IsDBNull(rdr("HomeLine1")) Then .HomeAdd1 = Trim(rdr("HomeLine1"))
                If Not IsDBNull(rdr("HomeLine2")) Then .HomeAdd2 = Trim(rdr("HomeLine2"))
                If Not IsDBNull(rdr("HomeCity")) Then .HomeCity = Trim(rdr("HomeCity"))
                If Not IsDBNull(rdr("HomeState")) Then .HomeState = Trim(rdr("HomeState"))
                If Not IsDBNull(rdr("HomePostal")) Then .HomePostal = Trim(rdr("HomePostal"))
                If Not IsDBNull(rdr("HomeCellPhone")) Then .Mobile = Trim(rdr("HomeCellPhone"))
                If Not IsDBNull(rdr("OfficeSpeedDial")) Then .OfficeSpeedDial = Trim(rdr("OfficeSpeedDial"))

            End With

        End If

        rdr.Close()

        Return clsCM

    End Function


    Function GetTheatreCompanyNumber(ByVal p_unit As String) As String
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand
        Dim strSQL As String
        Dim strTemp As String

        strSQL = "SELECT ENTITY FROM AS400..LOCATION WHERE LOC = '" & p_unit & "'"

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = strSQL
        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.Read() Then
            strTemp = Trim(rdr("ENTITY"))
        Else
            strTemp = ""
        End If

        rdr.Close()

        Return strTemp

    End Function


    Function GetTheatreCompanyName(ByVal p_entity As String) As String
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand
        Dim strSQL As String
        Dim strTemp As String

        strSQL = "SELECT TAXID, NAME FROM AS400..PRSTATE WHERE ENTITY = " & p_entity

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = strSQL
        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.Read() Then
            strTemp = Trim(rdr("NAME"))
            EIN_Number = Trim(rdr("TAXID"))

        Else
            strTemp = ""
        End If

        rdr.Close()

        Return strTemp

    End Function


    Function GetTheatrePersonnel(ByVal p_unit As String) As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .CommandText = "sp_GetTheatrePersonnel"
            .CommandType = CommandType.StoredProcedure
            .Connection = cn

            .Parameters.Add("@unit", SqlDbType.Int).Value = p_unit

        End With

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        cn.Close()

        Return ds

    End Function


    Function GetTheatresByDistrict(ByVal p_district As Int32) As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .CommandText = "sp_GetTheatresByDistrict"
            .CommandType = CommandType.StoredProcedure
            .Connection = cn

            .Parameters.Add("@district", SqlDbType.Int).Value = p_district

        End With

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)
        cn.Close()

        Return ds

    End Function


    ' ***  RETRIEVE CITY AREA DATA
    Function SelectCityAreaData(ByVal p_ca As Int32) As CityArea
        Dim clsCA As New CityArea
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand()

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM AS400..REPDLOC WHERE REDISTRICT = " & p_ca & ""

        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.Read() Then
            With clsCA
                .CityArea = p_ca
                If Not IsDBNull(rdr("redisname")) Then .CAName = Trim(rdr("redisname"))
                If Not IsDBNull(rdr("redemail")) Then .CAEmail = Trim(rdr("redemail"))

            End With

        End If

        rdr.Close()

        Return clsCA

    End Function


    Function GetDistrictList() As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand()
        Dim strSQL As String = ""
        Dim strOrder As String = ""

        strSQL = "SELECT * FROM AS400..REPDLOC WHERE  RESTATUS = 'A' AND REDISTRICT < 305 ORDER BY REDISTRICT "

        With cmd
            .CommandText = strSQL
            .CommandType = CommandType.Text
            .Connection = cn

        End With

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)

        Return ds

    End Function


    Function GetPhoneDept(p_dept As String) As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand()
        Dim strSQL As String = ""
        Dim strWhere As String = ""
        Dim strOrder As String = ""

        ' ***  BUILD SQL STATEMENT
        Select Case p_dept
            Case "audit"
                strSQL = "SELECT * FROM tblPersonnel WHERE JobClass = '990' AND empActiveFlag = 'A' ORDER BY empLastName, empFirstName"
            Case "book"
                strSQL = "SELECT * FROM tblPersonnel WHERE JobClass = '050' AND empActiveFlag = 'A' ORDER BY empLastName, empFirstName"
            Case "concess"
                strSQL = "SELECT * FROM tblPersonnel WHERE JobClass2 = '035' AND empActiveFlag = 'A' ORDER BY empLastName, empFirstName"
            Case "field_mis"
                strSQL = "SELECT * FROM tblPersonnel WHERE JobClass = '440' AND empActiveFlag = 'A' ORDER BY empLastName, empFirstName"
            Case "field_hr"
                strSQL = "SELECT * FROM tblPersonnel WHERE JobClass = '185' AND empActiveFlag = 'A' ORDER BY empLastName, empFirstName"
            Case "mgmt"
                strSQL = "SELECT * FROM tblPersonnel WHERE JobClass2 = '0301' AND empActiveFlag = 'A' ORDER BY empLastName, empFirstName"
            Case "support"
                strSQL = "SELECT * FROM tblPersonnel WHERE JobClass2 = '0302' AND empActiveFlag = 'A' ORDER BY empLastName, empFirstName"
            Case "misc"
                strSQL = "SELECT * FROM tblPersonnel WHERE JobClass2 = '0303' AND empActiveFlag = 'A' ORDER BY empLastName, empFirstName"
            Case "mark"
                strSQL = "SELECT * FROM tblPersonnel WHERE JobClass2 = '08044' AND empActiveFlag = 'A' ORDER BY empLastName, empFirstName"
            Case Else
                strSQL = "SELECT * FROM tblPersonnel WHERE JobClass = '990' AND empActiveFlag = 'A' ORDER BY empLastName, empFirstName"
        End Select

        With cmd
            .CommandText = strSQL
            .CommandType = CommandType.Text
            .Connection = cn

        End With

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)

        Return ds

    End Function


    Function GetTheatrePhones(ByVal p_circuit As String) As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand()
        Dim strSQL As String = ""
        Dim strWhere As String = ""
        Dim strOrder As String = ""

        ' ***  SQL STATEMENT
        strSQL = "SELECT COALESCE(C.RELNMI,B.NAME) AS LOC_NAME , A.LocNum as LOC_NUMBER, A.* " & _
                            " FROM AS400..REPLOC C " & _
                            " LEFT OUTER JOIN tblLocationInfo A ON A.LocNum = C.RELOC# " & _
                            " LEFT OUTER JOIN AS400..LOCATION B ON A.LocNum = B.LOC "

        ' ***  BUILD WHERE CLAUSE
        Select Case p_circuit
            Case "USA"
                strWhere = "WHERE REDMGR# <= 200 AND REDMGR# <> 140 AND RELSTS = 'A' "
            Case "140"
                strWhere = "WHERE REDMGR# = 140 AND RELSTS = 'A' "
            Case "303"
                strWhere = "WHERE REDMGR# = 303 AND RELSTS = 'A' "
            Case "304"
                strWhere = "WHERE REDMGR# = 304 AND RELSTS = 'A' "
            Case "DI"
                strWhere = "WHERE LocNum IN (180, 240, 640) "
            Case "FLEA"
                strWhere = "WHERE LocNum IN (0012, 0022, 0023, 0025, 0027) "
            Case Else
                strWhere = "WHERE RELSTS = 'A' "
        End Select

        ' ***  ORDER BY CLAUSE
        strOrder = " ORDER BY LOC_NAME "

        ' ***  PUT STATEMENT TOGETHER
        strSQL = strSQL & strWhere & strOrder

        With cmd
            .CommandText = strSQL
            .CommandType = CommandType.Text
            .Connection = cn

        End With

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)

        Return ds

    End Function


    Function GetHomeOffice(ByVal p_type As String) As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand()
        Dim strSQL As String = ""
        Dim strOrder As String = ""

        If p_type = "ext" Then
            strOrder = " empExtension "
        Else
            strOrder = " empDisplayName "
        End If

        strSQL = "SELECT * FROM tblPersonnel WHERE empLastName <> ' ' AND empFirstName <> ' ' " & _
                " AND LocationNum = '0001' AND empActiveFlag = 'A' AND empExtension <> ' ' " & _
                " ORDER BY " & strOrder & " ASC "

        With cmd
            .CommandText = strSQL
            .CommandType = CommandType.Text
            .Connection = cn

        End With

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)

        Return ds

    End Function


    Function GetHomeOffice_Dept(p_dept As String) As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand()
        Dim strSQL As String = ""
        Dim strOrder As String = ""

        strSQL = "SELECT * FROM tblPersonnel WHERE JobClass = '" & p_dept & "' AND empExtension <> ' ' AND empActiveFlag = 'A'  ORDER BY empDisplayName"

        With cmd
            .CommandText = strSQL
            .CommandType = CommandType.Text
            .Connection = cn

        End With

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)

        Return ds

    End Function



    Function GetHomeOffice_Fax() As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand()
        Dim strSQL As String = ""
        Dim strOrder As String = ""

        strSQL = "SELECT * FROM fax_data WHERE fax_location = '0001' ORDER BY fax_description "

        With cmd
            .CommandText = strSQL
            .CommandType = CommandType.Text
            .Connection = cn

        End With

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)

        Return ds

    End Function


    Function GetJobCodes() As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand()
        Dim strSQL As String = ""
        Dim strOrder As String = ""

        strSQL = "SELECT tblJobCodes.Job, tblJobCodes.JobDescription " & _
            " FROM tblJobCodes WHERE (((tblJobCodes.[Co#])=200) AND ((Len([JobSec]))=3)) ORDER BY tblJobCodes.JobDescription"

        With cmd
            .CommandText = strSQL
            .CommandType = CommandType.Text
            .Connection = cn

        End With

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)

        Return ds

    End Function


    Function GetJobCodes_Second(p_dept As String) As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand()
        Dim strSQL As String = ""
        Dim strOrder As String = ""

        strSQL = "SELECT JobSec, JobDescription FROM tblJobCodes WHERE Job = '" & p_dept & "' GROUP BY JobSec, JobDescription ORDER BY JobSec "

        With cmd
            .CommandText = strSQL
            .CommandType = CommandType.Text
            .Connection = cn

        End With

        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim ds As New DataSet
        da.Fill(ds)

        Return ds

    End Function




End Class
