using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using HRService;
using EmailService;

/// <summary>
/// Summary description for CUserLoginData
/// </summary>
public class CUserLoginData
{
    ConnectDB oConn = new ConnectDB();
    HRService.HRMSWebService oHRService = new HRMSWebService();
    EmailService.Mail oMail = new Mail();
    public MDUserLoginData GetUser(string inSearch)
    {
        inSearch = inSearch + "%";
        MDUserLoginData oUser = new MDUserLoginData();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = @"SELECT username,password,firstname,lastname,empCode";
        sql.CommandText += @",department,position,email,active,createby,createdate";
        sql.CommandText += @",updateby,updatedate";
        sql.CommandText += @" FROM userList";
        sql.CommandText += @" WHERE ISNULL(username,'')+ISNULL(firstname,'')+ISNULL(lastname,'')";
        sql.CommandText += @"+ISNULL(empCode,'') like @inSearch --AND username != 'admin'";
        sql.Parameters.Add(new SqlParameter("@inSearch", inSearch));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDUserLoginData.CMDUserLoginData oMD = new MDUserLoginData.CMDUserLoginData();
                oMD.Username = row["username"].ToString();
                oMD.firstname = row["firstname"].ToString();
                oMD.lastname = row["lastname"].ToString();
                oMD.empCode = row["empCode"].ToString();
                oMD.department = row["department"].ToString();
                oMD.position = row["position"].ToString();
                oMD.email = row["email"].ToString();
                oMD.active = row["active"].ToString();
                oMD.createby = row["createby"].ToString();
                oMD.createdate = row["createdate"].ToString();
                oMD.updateby = row["updateby"].ToString();
                oMD.updatedate = row["updatedate"].ToString();
                oUser.ListOfUser.Add(oMD);
            }
        }

        return oUser;

    }

    public MDUserLoginData GetUserByUsername(string username)
    {
        MDUserLoginData oUser = new MDUserLoginData();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = @"SELECT username,password,firstname,lastname,empCode";
        sql.CommandText += @",department,position,email,active,createby,createdate";
        sql.CommandText += @",updateby,updatedate";
        sql.CommandText += @" FROM userList";
        sql.CommandText += @" WHERE username = @username --AND username != 'admin'";
        sql.Parameters.Add(new SqlParameter("@username", username));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDUserLoginData.CMDUserLoginData oMD = new MDUserLoginData.CMDUserLoginData();
                oMD.Username = row["username"].ToString();
                oMD.firstname = row["firstname"].ToString();
                oMD.lastname = row["lastname"].ToString();
                oMD.empCode = row["empCode"].ToString();
                oMD.department = row["department"].ToString();
                oMD.position = row["position"].ToString();
                oMD.email = row["email"].ToString();
                oMD.active = row["active"].ToString();
                oMD.createby = row["createby"].ToString();
                oMD.createdate = row["createdate"].ToString();
                oMD.updateby = row["updateby"].ToString();
                oMD.updatedate = row["updatedate"].ToString();
                oUser.ListOfUser.Add(oMD);
            }
        }

        return oUser;

    }

    public string UploadUserFromADtoIOT(string username, string empCode, string UploadBy)
    {
        string result = "";
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = @"SELECT username";
        sql.CommandText += @" WHERE username=@username";
        sql.Parameters.Add(new SqlParameter("@username", username));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            return "Error: This Username already exists in this system. If forgot your password please click 'Lost your password?' bellow.";
        }

        string FirstName = "";
        string LastName = "";
        string FullName = "";
        string Department = "";
        string Position = "";
        string Email = "";

        EmployeeInfo oEmp = new EmployeeInfo();
        if (empCode != "")
        {
            oEmp = oHRService.GetEmployeeData(empCode);
            if (oEmp != null)
            {
                NameInfo oNameInfo = new NameInfo();
                oNameInfo = oEmp.NameInEng;
                if (oNameInfo != null)
                {
                    FirstName = oNameInfo.Name;
                    LastName = oNameInfo.Surname;
                    FullName = FirstName + " " + LastName;
                }
                DivisionInfo oDivision = new DivisionInfo();
                oDivision = oEmp.Division;
                if (oDivision != null)
                {
                    Department = oDivision.Name;
                }
                PositionInfo oPosition = new PositionInfo();
                oPosition = oEmp.Position;
                if (oPosition != null)
                {
                    Position = oPosition.NameEng;
                }
            }
            Email = oEmp.Email;
        }
        else
        {

        }

        try
        {
            sql = new SqlCommand();
            sql.CommandText = @"INSERT INTO userList VALUES(@username,@password,@firstname,@lastname,@empCode,@department";
            sql.CommandText += @",@position,@email,@active,@createby,@createdate,@updateby,@updatedate)";
            sql.Parameters.Add(new SqlParameter("@username", username));
            sql.Parameters.Add(new SqlParameter("@password", ""));
            sql.Parameters.Add(new SqlParameter("@firstname", FirstName));
            sql.Parameters.Add(new SqlParameter("@lastname", LastName));
            sql.Parameters.Add(new SqlParameter("@empCode", empCode));
            sql.Parameters.Add(new SqlParameter("@department", Department));
            sql.Parameters.Add(new SqlParameter("@position", Position));
            sql.Parameters.Add(new SqlParameter("@email", Email));
            sql.Parameters.Add(new SqlParameter("@active", 1));
            sql.Parameters.Add(new SqlParameter("@createby", UploadBy));
            sql.Parameters.Add(new SqlParameter("@createdate", DateTime.Now));
            sql.Parameters.Add(new SqlParameter("@updateby", UploadBy));
            sql.Parameters.Add(new SqlParameter("@updatedate", DateTime.Now));
            oConn.ExecuteCommand(sql);
        }
        catch (Exception)
        {

        }





        return result;
    }

    public string UpdateUserList(string username, string firstname, string lastname, string empCode, string department, string position, string email, int active
        , string updateby)
    {
        string result = "";
        try
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = @"UPDATE userList SET firstname=@firstname,lastname=@lastname,empCode=@empCode,department=@department";
            sql.CommandText += @"position=@position,email=@email,active=@active,updateby=@updateby,updatedate=@updatedate";
            sql.CommandText += @" WHERE username = @username";
            sql.Parameters.Add(new SqlParameter("@username", username));
            sql.Parameters.Add(new SqlParameter("@firstname", firstname));
            sql.Parameters.Add(new SqlParameter("@lastname", lastname));
            sql.Parameters.Add(new SqlParameter("@empCode", empCode));
            sql.Parameters.Add(new SqlParameter("@position", position));
            sql.Parameters.Add(new SqlParameter("@department", department));
            sql.Parameters.Add(new SqlParameter("@email", email));
            sql.Parameters.Add(new SqlParameter("@active", active));
            sql.Parameters.Add(new SqlParameter("@updateby", updateby));
            sql.Parameters.Add(new SqlParameter("@updatedate", DateTime.Now));
            oConn.ExecuteCommand(sql);
        }
        catch (Exception ex)
        {
            result = ex.ToString();
        }

        return result;
    }

    public string DeleteUserList(string username)
    {
        string result = "";
        try
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = @"DELETE FROM userList WHERE username=@username";
            sql.Parameters.Add(new SqlParameter("@username", username));
            oConn.ExecuteCommand(sql);
        }
        catch (Exception ex)
        {
            result = ex.ToString();
        }


        return result;
    }


    public string CheckUserInSystem(string username)
    {
        string result = "false";
        try
        {
            SqlCommand sql = new SqlCommand();
            DataTable dTable = new DataTable();
            sql.CommandText = @"SELECT username FROM userlist WHERE username=@username";
            sql.Parameters.Add(new SqlParameter("@username", username));
            dTable = oConn.Query(sql);
            if (dTable.Rows.Count > 0)
            {
                result = "true";
            }
            else
            {
                result = "false";
            }

        }
        catch (Exception ex)
        {
            result = ex.ToString();
        }

        return result;
    }

    public bool CheckUserHavePassword(string username)
    {
        bool result = false;

        SqlCommand sql = new SqlCommand();
        DataTable dTable = new DataTable();
        sql.CommandText = @"SELECT password FROM userlist WHERE username=@username";
        sql.Parameters.Add(new SqlParameter("@username", username));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            if (dTable.Rows[0]["password"].ToString() == "")
            {
                result = false;
            }
            else
            {
                result = true;
            }

        }
        else
        {
            result = false;
        }



        return result;
    }

    public MDUserLoginData LoginSystem(string username, string password)
    {
        MDUserLoginData oUser = new MDUserLoginData();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = @"SELECT username,password,firstname,lastname,empCode";
        sql.CommandText += @",department,position,email,active,createby,createdate";
        sql.CommandText += @",updateby,updatedate";
        sql.CommandText += @" FROM userList";
        sql.CommandText += @" WHERE username=@username AND password=@password";
        sql.Parameters.Add(new SqlParameter("@username", username));
        sql.Parameters.Add(new SqlParameter("@password", password));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDUserLoginData.CMDUserLoginData oMD = new MDUserLoginData.CMDUserLoginData();
                oMD.Username = row["username"].ToString();
                oMD.firstname = row["firstname"].ToString();
                oMD.lastname = row["lastname"].ToString();
                oMD.empCode = row["empCode"].ToString();
                oMD.department = row["department"].ToString();
                oMD.position = row["position"].ToString();
                oMD.email = row["email"].ToString();
                oMD.active = row["active"].ToString() == "1" ? "Active" : "Inactive";
                oMD.createby = row["createby"].ToString();
                oMD.createdate = row["createdate"].ToString();
                oMD.updateby = row["updateby"].ToString();
                oMD.updatedate = row["updatedate"].ToString();

                // Insert Group
                sql = new SqlCommand();
                DataTable dTableGroup = new DataTable();
                sql.CommandText = "SELECT uig_id,username,ug.ug_id,ug_name";
                sql.CommandText += " FROM UserInGroup uig";
                sql.CommandText += " LEFT JOIN UserGroupList ug ON uig.ug_id = ug.ug_id";
                sql.CommandText += " WHERE username = @username";
                sql.Parameters.Add(new SqlParameter("@username", username));
                dTableGroup = oConn.Query(sql);
                if (dTableGroup.Rows.Count > 0)
                {
                    foreach (DataRow rowGroup in dTableGroup.Rows)
                    {
                        MDUserLoginData.CMDUserLoginData.CGroup oMDGroup = new MDUserLoginData.CMDUserLoginData.CGroup();
                        oMDGroup.GroupID = rowGroup["ug_id"] != DBNull.Value ? Convert.ToInt32(rowGroup["ug_id"]) : 0;
                        oMDGroup.GroupName = rowGroup["ug_name"].ToString();
                        oMD.ListOfGroup.Add(oMDGroup);
                    }
                }
                oUser.ListOfUser.Add(oMD);
            }
        }

        return oUser;

    }

    public MDUserLoginData LoginSystem(string username)
    {
        MDUserLoginData oUser = new MDUserLoginData();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = @"SELECT username,password,firstname,lastname,empCode";
        sql.CommandText += @",department,position,email,active,createby,createdate";
        sql.CommandText += @",updateby,updatedate";
        sql.CommandText += @" FROM userList";
        sql.CommandText += @" WHERE username=@username";
        sql.Parameters.Add(new SqlParameter("@username", username));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDUserLoginData.CMDUserLoginData oMD = new MDUserLoginData.CMDUserLoginData();
                oMD.Username = row["username"].ToString();
                oMD.firstname = row["firstname"].ToString();
                oMD.lastname = row["lastname"].ToString();
                oMD.empCode = row["empCode"].ToString();
                oMD.department = row["department"].ToString();
                oMD.position = row["position"].ToString();
                oMD.email = row["email"].ToString();
                oMD.active = row["active"].ToString();
                oMD.createby = row["createby"].ToString();
                oMD.createdate = row["createdate"].ToString();
                oMD.updateby = row["updateby"].ToString();
                oMD.updatedate = row["updatedate"].ToString();

                // Insert Group
                sql = new SqlCommand();
                DataTable dTableGroup = new DataTable();
                sql.CommandText = "SELECT uig_id,username,ug.ug_id,ug_name";
                sql.CommandText += " FROM UserInGroup uig";
                sql.CommandText += " LEFT JOIN UserGroupList ug ON uig.ug_id = ug.ug_id";
                sql.CommandText += " WHERE username = @username";
                sql.Parameters.Add(new SqlParameter("@username", username));
                dTableGroup = oConn.Query(sql);
                if (dTableGroup.Rows.Count > 0)
                {
                    foreach (DataRow rowGroup in dTableGroup.Rows)
                    {
                        MDUserLoginData.CMDUserLoginData.CGroup oMDGroup = new MDUserLoginData.CMDUserLoginData.CGroup();
                        oMDGroup.GroupID = rowGroup["ug_id"] != DBNull.Value ? Convert.ToInt32(rowGroup["ug_id"]) : 0;
                        oMDGroup.GroupName = rowGroup["ug_name"].ToString();
                        oMD.ListOfGroup.Add(oMDGroup);
                    }
                }
                oUser.ListOfUser.Add(oMD);
            }
        }

        return oUser;

    }

    public void InsertUser(string username,string password,string firstname,string lastname
        ,string empCode, string department,string position,string email,int active,string UpdateBy)
    {
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "INSERT INTO Userlist VALUES(@username,@password,@firstname,@lastname,@empCode,@department";
        sql.CommandText += ",@position,@email,@active,@createby,@createdate,@updateby,@updatedate)";
        sql.Parameters.Add(new SqlParameter("@username", username));
        sql.Parameters.Add(new SqlParameter("@password", password));
        sql.Parameters.Add(new SqlParameter("@firstname", firstname));
        sql.Parameters.Add(new SqlParameter("@lastname", lastname));
        sql.Parameters.Add(new SqlParameter("@empCode", empCode));
        sql.Parameters.Add(new SqlParameter("@department", department));
        sql.Parameters.Add(new SqlParameter("@position", position));
        sql.Parameters.Add(new SqlParameter("@email", email));
        sql.Parameters.Add(new SqlParameter("@active", active));
        sql.Parameters.Add(new SqlParameter("@createby", UpdateBy));
        sql.Parameters.Add(new SqlParameter("@createdate", DateTime.Now));
        sql.Parameters.Add(new SqlParameter("@updateby", UpdateBy));
        sql.Parameters.Add(new SqlParameter("@updatedate", DateTime.Now));
        oConn.ExecuteCommand(sql);
    }

    public void UpdateUser(string username, string firstname, string lastname
        , string empCode, string department, string position, string email, int active, string UpdateBy)
    {
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "UPDATE Userlist SET firstname=@firstname,lastname=@lastname,empCode=@empCode,department=@department";
        sql.CommandText += ",position=@position,email=@email,active=@active,updateby=@updateby,updatedate=@updatedate";
        sql.CommandText += " WHERE username=@username";
        sql.Parameters.Add(new SqlParameter("@username", username));
        sql.Parameters.Add(new SqlParameter("@firstname", firstname));
        sql.Parameters.Add(new SqlParameter("@lastname", lastname));
        sql.Parameters.Add(new SqlParameter("@empCode", empCode));
        sql.Parameters.Add(new SqlParameter("@department", department));
        sql.Parameters.Add(new SqlParameter("@position", position));
        sql.Parameters.Add(new SqlParameter("@email", email));
        sql.Parameters.Add(new SqlParameter("@active", active));
        sql.Parameters.Add(new SqlParameter("@createby", UpdateBy));
        sql.Parameters.Add(new SqlParameter("@createdate", DateTime.Now));
        sql.Parameters.Add(new SqlParameter("@updateby", UpdateBy));
        sql.Parameters.Add(new SqlParameter("@updatedate", DateTime.Now));
        oConn.ExecuteCommand(sql);
    }

    public void DeleteUser(string username)
    {
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("DELETE FROM Userlist WHERE username='"+ username +"'");
        oConn.ExecuteCommand(sbd.ToString());
    }

}