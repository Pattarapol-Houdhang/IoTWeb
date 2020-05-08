using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfo
/// </summary>
public class UserInfo
{
	public UserInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string user_code;
    private string user_name;
    private string user_surname;
    private string user_sect;
    private string user_permission;
    private string user_password;
    private string user_passwordSt;
    private bool user_first_login;

    public bool User_first_login
    {
        get { return user_first_login; }
        set { user_first_login = value; }
    }

    public string User_passwordSt
    {
        get { return user_passwordSt; }
        set { user_passwordSt = value; }
    }

    public string User_password
    {
        get { return user_password; }
        set { user_password = value; }
    }

    public string User_permission
    {
        get { return user_permission; }
        set { user_permission = value; }
    }

    public string User_sect
    {
        get { return user_sect; }
        set { user_sect = value; }
    }

    public string User_surname
    {
        get { return user_surname; }
        set { user_surname = value; }
    }

    public string User_name
    {
        get { return user_name; }
        set { user_name = value; }
    }

    public string User_code
    {
        get { return user_code; }
        set { user_code = value; }
    }
}