' *******************************************
' ***       NAI_Emp.vb    10/23/2014       RG
' ***
' ***
' *******************************************

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class Employee
    Public ID As Integer
    Public FirstName As String
    Public LastName As String
    Public OfficeAddress1 As String
    Public OfficeAddress2 As String
    Public JobClass As String
    Public JobClass2 As String
    Public Location As String
    Public Email As String
    Public NetAlias As String
    Public OfficeCity As String
    Public OfficeState As String
    Public OfficePostal As String
    Public OfficePhone As String
    Public OfficeSpeedDial As String
    Public OfficeFax As String
    Public ActiveFlag As String
    Public Title As String
    Public HomeAdd1 As String
    Public HomeAdd2 As String
    Public HomeCity As String
    Public HomeState As String
    Public HomePostal As String
    Public HomePhone As String
    Public Mobile As String
    Public Extension As String

End Class


Public Class EContact
    Public EmpId As Integer
    Public ContactId As Integer
    Public FirstName As String
    Public LastName As String
    Public HomeAddress1 As String
    Public HomeAddress2 As String
    Public HomeCity As String
    Public HomeState As String
    Public HomePostal As String
    Public HomePhone As String
    Public ContactFirst As String
    Public ContactLast As String
    Public ContactPhone As String
    Public Relationship As String
    Public Auto1License As String
    Public Auto1State As String
    Public Auto1Color As String
    Public Auto1Make As String
    Public Auto1Model As String
    Public Auto1Year As String
    Public Auto2License As String
    Public Auto2State As String
    Public Auto2Color As String
    Public Auto2Make As String
    Public Auto2Model As String
    Public Auto2Year As String

End Class


Public Class NAI_Emp

    Function GetFieldEmps(p_dist As String) As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand()
        Dim strSQL As String = ""
        Dim strOrder As String = ""

        If p_dist = 0 Then
            strSQL = "SELECT B.LocationNum, B.empFirstName, B.empAutoNum, B.empLastName, B.empDisplayName, " & _
                            " B.JobClass, B.empActiveFlag " & _
                            " FROM vwLocationInfo A INNER JOIN tblPersonnel B ON A.LocNum = B.LocationNum " & _
                            " WHERE ((B.empFirstName) Is Not Null) AND ((B.empLastName) Is Not Null) " & _
                            " AND ((B.empActiveFlag)= 'A' ) " & _
                            " ORDER BY B.empDisplayName "

        Else
            strSQL = "SELECT B.LocationNum, B.empFirstName, B.empAutoNum, B.empLastName, B.empDisplayName, " & _
                            " B.JobClass, B.empActiveFlag " & _
                            " FROM vwLocationInfo A INNER JOIN tblPersonnel B ON A.LocNum = B.LocationNum " & _
                            " WHERE ((B.empFirstName) Is Not Null) AND ((B.empLastName) Is Not Null) " & _
                            " AND ((A.[REDMGR#])= " & p_dist & ") AND ((B.empActiveFlag)= 'A' ) " & _
                            " ORDER BY B.empDisplayName "
        End If


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


    Sub InsertEContactRec(ByVal p_id As Integer)
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_EContact_Insert"

            .Parameters.Add("@id", SqlDbType.Int).Value = p_id

            .ExecuteNonQuery()

        End With

        cn.Close()

    End Sub


    Function EContactRecExists(p_id As Integer) As Boolean
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand
        Dim blnResult As Boolean = False

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM tblContactInfo WHERE employee_id = " & p_id

        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.HasRows Then blnResult = True

        Return blnResult

    End Function


    Sub UpdateEContact(ByVal pRec As EContact)
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_EContact_Update"

            .Parameters.Add("@id", SqlDbType.Int).Value = pRec.EmpId
            .Parameters.Add("@first", SqlDbType.VarChar, 50).Value = pRec.FirstName
            .Parameters.Add("@last", SqlDbType.VarChar, 50).Value = pRec.LastName
            .Parameters.Add("@address1", SqlDbType.VarChar, 50).Value = pRec.HomeAddress1
            .Parameters.Add("@address2", SqlDbType.VarChar, 50).Value = pRec.HomeAddress2
            .Parameters.Add("@city", SqlDbType.VarChar, 50).Value = pRec.HomeCity
            .Parameters.Add("@state", SqlDbType.VarChar, 5).Value = pRec.HomeState
            .Parameters.Add("@postal", SqlDbType.VarChar, 50).Value = pRec.HomePostal
            .Parameters.Add("@phone", SqlDbType.VarChar, 15).Value = pRec.HomePhone
            .Parameters.Add("@contact_fname", SqlDbType.VarChar, 50).Value = pRec.ContactFirst
            .Parameters.Add("@contact_lname", SqlDbType.VarChar, 50).Value = pRec.ContactLast
            .Parameters.Add("@contact_phone", SqlDbType.VarChar, 15).Value = pRec.ContactPhone
            .Parameters.Add("@relationship", SqlDbType.VarChar, 50).Value = pRec.Relationship
            .Parameters.Add("@veh1_license", SqlDbType.VarChar, 10).Value = pRec.Auto1License
            .Parameters.Add("@veh1_state", SqlDbType.VarChar, 5).Value = pRec.Auto1State
            .Parameters.Add("@veh1_color", SqlDbType.VarChar, 20).Value = pRec.Auto1Color
            .Parameters.Add("@veh1_make", SqlDbType.VarChar, 50).Value = pRec.Auto1Make
            .Parameters.Add("@veh1_model", SqlDbType.VarChar, 50).Value = pRec.Auto1Model
            .Parameters.Add("@veh1_year", SqlDbType.VarChar, 5).Value = pRec.Auto1Year
            .Parameters.Add("@veh2_license", SqlDbType.VarChar, 10).Value = pRec.Auto2License
            .Parameters.Add("@veh2_state", SqlDbType.VarChar, 5).Value = pRec.Auto2State
            .Parameters.Add("@veh2_color", SqlDbType.VarChar, 20).Value = pRec.Auto2Color
            .Parameters.Add("@veh2_make", SqlDbType.VarChar, 50).Value = pRec.Auto2Make
            .Parameters.Add("@veh2_model", SqlDbType.VarChar, 50).Value = pRec.Auto2Model
            .Parameters.Add("@veh2_year", SqlDbType.VarChar, 5).Value = pRec.Auto2Year


            .ExecuteNonQuery()

        End With

        cn.Close()

    End Sub


    Function GetEContactData(ByVal p_id As Int32) As EContact
        Dim clsEmp As New EContact
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand
        Dim strSQL As String = ""

        strSQL = "SELECT A.*, B.empFirstName, B.empLastName " & _
                        " FROM tblContactInfo A RIGHT OUTER JOIN tblPersonnel B ON A.employee_id  = B.empAutoNum " & _
                        " WHERE B.empAutoNum = " & p_id

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = strSQL
        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.Read() Then
            With clsEmp
                .EmpId = p_id
                If Not IsDBNull(rdr("contact_id")) Then .ContactId = Trim(rdr("contact_id"))
                If Not IsDBNull(rdr("first_name")) Then
                    .FirstName = Trim(rdr("first_name"))
                Else
                    If Not IsDBNull(rdr("empfirstname")) Then
                        .FirstName = Trim(rdr("empfirstname"))
                    End If
                End If
                If Not IsDBNull(rdr("last_name")) Then
                    .LastName = Trim(rdr("last_name"))
                Else
                    If Not IsDBNull(rdr("emplastname")) Then
                        .LastName = Trim(rdr("emplastname"))
                    End If
                End If
                If Not IsDBNull(rdr("address1")) Then .HomeAddress1 = Trim(rdr("address1"))
                If Not IsDBNull(rdr("address2")) Then .HomeAddress2 = Trim(rdr("address2"))
                If Not IsDBNull(rdr("city")) Then .HomeCity = Trim(rdr("city"))
                If Not IsDBNull(rdr("state")) Then .HomeState = Trim(rdr("state"))
                If Not IsDBNull(rdr("postal_code")) Then .HomePostal = Trim(rdr("postal_code"))
                If Not IsDBNull(rdr("phone")) Then .HomePhone = Trim(rdr("phone"))
                If Not IsDBNull(rdr("contact_fname")) Then .ContactFirst = Trim(rdr("contact_fname"))
                If Not IsDBNull(rdr("contact_lname")) Then .ContactLast = Trim(rdr("contact_lname"))
                If Not IsDBNull(rdr("contact_day_phone")) Then .ContactPhone = Trim(rdr("contact_day_phone"))
                If Not IsDBNull(rdr("relationship")) Then .Relationship = Trim(rdr("relationship"))
                If Not IsDBNull(rdr("veh1_lic_plate")) Then .Auto1License = Trim(rdr("veh1_lic_plate"))
                If Not IsDBNull(rdr("veh1_state")) Then .Auto1State = Trim(rdr("veh1_state"))
                If Not IsDBNull(rdr("veh1_color")) Then .Auto1Color = Trim(rdr("veh1_color"))
                If Not IsDBNull(rdr("veh1_make")) Then .Auto1Make = Trim(rdr("veh1_make"))
                If Not IsDBNull(rdr("veh1_model")) Then .Auto1Model = Trim(rdr("veh1_model"))
                If Not IsDBNull(rdr("veh1_year")) Then .Auto1Year = Trim(rdr("veh1_year"))
                If Not IsDBNull(rdr("veh2_lic_plate")) Then .Auto2License = Trim(rdr("veh2_lic_plate"))
                If Not IsDBNull(rdr("veh2_state")) Then .Auto2State = Trim(rdr("veh2_state"))
                If Not IsDBNull(rdr("veh2_color")) Then .Auto2Color = Trim(rdr("veh2_color"))
                If Not IsDBNull(rdr("veh2_make")) Then .Auto2Make = Trim(rdr("veh2_make"))
                If Not IsDBNull(rdr("veh2_model")) Then .Auto2Model = Trim(rdr("veh2_model"))
                If Not IsDBNull(rdr("veh2_year")) Then .Auto2Year = Trim(rdr("veh2_year"))

            End With

        End If

        rdr.Close()

        Return clsEmp

    End Function


    Function GetEcontactList() As DataSet
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand()
        Dim strSQL As String = ""
        Dim strOrder As String = ""

        strSQL = "SELECT *  FROM vw_Contacts1 ORDER BY last_name"

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


    Function InsertEmployee() As Integer
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_EmployeeInsert"

            .Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output

            .ExecuteNonQuery()

        End With

        Dim intNewId As Integer = cmd.Parameters("@id").Value()

        cn.Close()

        Return intNewId

    End Function


    Sub RemoveEmployee(ByVal p_id As Integer)
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "UPDATE tblPersonnel SET empActiveFlag = 'I' WHERE empAutoNum = " & p_id

            .ExecuteNonQuery()

        End With

        cn.Close()

    End Sub


    Function GetEmployeeData(ByVal p_id As Int32) As Employee
        Dim clsEmp As New Employee
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.Text
            .CommandText = "SELECT * FROM tblPersonnel WHERE empAutoNum = " & p_id
        End With

        Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If rdr.Read() Then
            With clsEmp
                .ID = p_id
                If Not IsDBNull(rdr("empTitle")) Then .Title = Trim(rdr("empTitle"))
                If Not IsDBNull(rdr("empfirstname")) Then .FirstName = Trim(rdr("empfirstname"))
                If Not IsDBNull(rdr("emplastname")) Then .LastName = Trim(rdr("emplastname"))
                If Not IsDBNull(rdr("LocationNum")) Then .Location = Trim(rdr("LocationNum"))
                If Not IsDBNull(rdr("empAlias")) Then .NetAlias = Trim(rdr("empAlias"))
                If Not IsDBNull(rdr("empActiveFlag")) Then .ActiveFlag = Trim(rdr("empActiveFlag"))
                If Not IsDBNull(rdr("empExtension")) Then .Extension = Trim(rdr("empExtension"))
                If Not IsDBNull(rdr("JobClass")) Then .JobClass = Trim(rdr("JobClass"))
                If Not IsDBNull(rdr("JobClass2")) Then .JobClass2 = Trim(rdr("JobClass2"))
                If Not IsDBNull(rdr("HomeAddressLine1")) Then .OfficeAddress1 = Trim(rdr("HomeAddressLine1"))
                If Not IsDBNull(rdr("HomeAddressLine2")) Then .OfficeAddress2 = Trim(rdr("HomeAddressLine2"))
                If Not IsDBNull(rdr("city")) Then .OfficeCity = Trim(rdr("city"))
                If Not IsDBNull(rdr("state")) Then .OfficeState = Trim(rdr("state"))
                If Not IsDBNull(rdr("postalcode")) Then .OfficePostal = Trim(rdr("postalcode"))
                If Not IsDBNull(rdr("OfficePhone")) Then .OfficePhone = Trim(rdr("OfficePhone"))
                If Not IsDBNull(rdr("OfficeSpeedDial")) Then .OfficeSpeedDial = Trim(rdr("OfficeSpeedDial"))
                If Not IsDBNull(rdr("OfficeFax")) Then .OfficeFax = Trim(rdr("OfficeFax"))
                If Not IsDBNull(rdr("EmailAddress")) Then .Email = Trim(rdr("EmailAddress"))
                If Not IsDBNull(rdr("HomePhone")) Then .HomePhone = Trim(rdr("HomePhone"))
                If Not IsDBNull(rdr("HomeLine1")) Then .HomeAdd1 = Trim(rdr("HomeLine1"))
                If Not IsDBNull(rdr("HomeLine2")) Then .HomeAdd2 = Trim(rdr("HomeLine2"))
                If Not IsDBNull(rdr("HomeCity")) Then .HomeCity = Trim(rdr("HomeCity"))
                If Not IsDBNull(rdr("HomeState")) Then .HomeState = Trim(rdr("HomeState"))
                If Not IsDBNull(rdr("HomePostal")) Then .HomePostal = Trim(rdr("HomePostal"))
                If Not IsDBNull(rdr("HomeCellPhone")) Then .Mobile = Trim(rdr("HomeCellPhone"))

            End With

        End If

        rdr.Close()

        Return clsEmp

    End Function


    Sub UpdateEmployee(ByVal pRec As Employee)
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DataConn").ConnectionString)
        Dim cmd As New SqlCommand

        cn.Open()

        With cmd
            .Connection = cn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_EmployeeUpdate"

            .Parameters.Add("@id", SqlDbType.Int).Value = pRec.ID
            .Parameters.Add("@title", SqlDbType.VarChar, 50).Value = pRec.Title
            .Parameters.Add("@first", SqlDbType.VarChar, 50).Value = pRec.FirstName
            .Parameters.Add("@last", SqlDbType.VarChar, 50).Value = pRec.LastName
            .Parameters.Add("@loc", SqlDbType.VarChar, 6).Value = pRec.Location
            .Parameters.Add("@email", SqlDbType.VarChar, 50).Value = pRec.Email
            .Parameters.Add("@alias", SqlDbType.VarChar, 50).Value = pRec.NetAlias
            .Parameters.Add("@active", SqlDbType.VarChar, 2).Value = pRec.ActiveFlag
            .Parameters.Add("@extension", SqlDbType.VarChar, 15).Value = pRec.Extension
            .Parameters.Add("@officeadd1", SqlDbType.VarChar, 50).Value = pRec.OfficeAddress1
            .Parameters.Add("@officeadd2", SqlDbType.VarChar, 50).Value = pRec.OfficeAddress2
            .Parameters.Add("@officecity", SqlDbType.VarChar, 50).Value = pRec.OfficeCity
            .Parameters.Add("@officestate", SqlDbType.VarChar, 50).Value = pRec.OfficeState
            .Parameters.Add("@officepostal", SqlDbType.VarChar, 50).Value = pRec.OfficePostal
            .Parameters.Add("@officephone", SqlDbType.VarChar, 50).Value = pRec.OfficePhone
            .Parameters.Add("@officesd", SqlDbType.VarChar, 50).Value = pRec.OfficeSpeedDial
            .Parameters.Add("@officefax", SqlDbType.VarChar, 50).Value = pRec.OfficeFax
            .Parameters.Add("@homeadd1", SqlDbType.VarChar, 50).Value = pRec.HomeAdd1
            .Parameters.Add("@homeadd2", SqlDbType.VarChar, 50).Value = pRec.HomeAdd2
            .Parameters.Add("@homecity", SqlDbType.VarChar, 50).Value = pRec.HomeCity
            .Parameters.Add("@homestate", SqlDbType.VarChar, 50).Value = pRec.HomeState
            .Parameters.Add("@homepostal", SqlDbType.VarChar, 50).Value = pRec.HomePostal
            .Parameters.Add("@homephone", SqlDbType.VarChar, 50).Value = pRec.HomePhone
            .Parameters.Add("@homecell", SqlDbType.VarChar, 50).Value = pRec.Mobile
            .Parameters.Add("@job", SqlDbType.VarChar, 50).Value = pRec.JobClass

            .ExecuteNonQuery()

        End With

        cn.Close()

    End Sub


End Class
