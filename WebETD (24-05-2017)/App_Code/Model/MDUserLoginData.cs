using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CUserLoginData
/// </summary>
public class MDUserLoginData
{
    public class CMDUserLoginData
    {
        public string Username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string fullname { get; set; }
        public string empCode { get; set; }
        public string department { get; set; }
        public string position { get; set; }
        public string email { get; set; }
        public string active { get; set; }
        public string createby { get; set; }
        public string createdate { get; set; }
        public string updateby { get; set; }
        public string updatedate { get; set; }

        public class CGroup
        {
            public int GroupID { get; set; }
            public string GroupName { get; set; }
            
        }

        public List<CGroup> ListOfGroup;

        public CMDUserLoginData()
        {
            ListOfGroup = new List<CGroup>();
        }
    }

    public List<CMDUserLoginData> ListOfUser;
    public MDUserLoginData()
    {
        ListOfUser = new List<CMDUserLoginData>();
    }

}