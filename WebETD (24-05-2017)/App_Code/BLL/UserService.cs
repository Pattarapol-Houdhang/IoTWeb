using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserService
/// </summary>
public class UserService
{

    private etd_userTableAdapter userTba;

	public UserService()
	{
		//
		// TODO: Add constructor logic here
		//
        userTba = new etd_userTableAdapter();
	}

    private ArrayList DataTableToObjects(DataTable tb, Type t)
    {
        ArrayList ls = new ArrayList();
        if (tb.Rows != null)
        {
            foreach (DataRow item in tb.Rows)
            {
                object ob = DataRowToObject(item, t);
                ls.Add(ob);
            }
        }
        return ls;
    }

    private object DataRowToObject(DataRow r, Type t)
    {
        if (t == typeof(UserInfo))
        {
            UserInfo item = new UserInfo();
            DataSet.etd_userRow dr = (DataSet.etd_userRow)r;

            item.User_code = dr.user_code;
            item.User_name = dr.user_name;
            item.User_surname = dr.user_surname;
            item.User_sect = dr.user_sect;
            item.User_permission = dr.user_permission;
            item.User_first_login = dr.user_first_login;

            return item;
        }
        return null;
    }

    public bool insertNewUser(UserInfo userInfo)
    {
        try
        {
            userTba.InsertNewUser(userInfo.User_code, userInfo.User_name, userInfo.User_surname, userInfo.User_sect,
                                  userInfo.User_permission, userInfo.User_password, userInfo.User_passwordSt, userInfo.User_first_login);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public UserInfo CheckUserAvailableOnSystem(string userID)
    {
        try
        {
            DataTable tb = userTba.GetDataByUserID(userID);

            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                return (UserInfo)DataRowToObject(dr, typeof(UserInfo));
            }
            return null;

        }
        catch { return null; }
    }

    public UserInfo CheckLogin(string username, string password)
    {
        try
        {
            DataTable tb = userTba.GetUserLoginData(username, password);
            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                return (UserInfo)DataRowToObject(dr, typeof(UserInfo));
            }
            return null;
        }
        catch { return null; }
    }

    public void ChangePassword(string userName, string password)
    {
        userTba.UpdatePassword(password, userName);
    }

    public void ChangeStatusFirst(string userName)
    {
        userTba.UpdateFirstLogin(false, userName);
    }
}