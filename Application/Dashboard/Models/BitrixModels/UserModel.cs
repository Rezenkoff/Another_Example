using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor.Application.Dashboard.Models.BitrixModels
{
    public class UserModel
    {
         public string ID { get; set; }
         public string ACTIVE { get; set; }
         public string EMAIL { get; set; }
         public string NAME { get; set; }
         public string LAST_NAME { get; set; }
         public string SECOND_NAME { get; set; }
         public string PERSONAL_GENDER { get; set; }
         public string PERSONAL_PROFESSION { get; set; }
         public string PERSONAL_WWW { get; set; }
         public DateTime PERSONAL_BIRTHDAY { get; set; }
         public string PERSONAL_PHOTO { get; set; }
         public string PERSONAL_ICQ { get; set; }
         public string PERSONAL_PHONE { get; set; }
         public string PERSONAL_FAX { get; set; }
         public string PERSONAL_MOBILE { get; set; }
         public string PERSONAL_PAGER { get; set; }
         public string PERSONAL_STREET { get; set; }
         public string PERSONAL_CITY { get; set; }
         public string PERSONAL_STATE { get; set; }
         public string PERSONAL_ZIP { get; set; }
         public string PERSONAL_COUNTRY { get; set; }
         public string WORK_COMPANY { get; set; }
         public string WORK_POSITION { get; set; }
         public string WORK_PHONE { get; set; }
         public int[] UF_DEPARTMENT { get; set; }              
         public string UF_INTERESTS { get; set; }
         public string UF_SKILLS { get; set; }
         public string UF_WEB_SITES { get; set; }
         public string UF_XING { get; set; }
         public string UF_LINKEDIN { get; set; }
         public string UF_FACEBOOK { get; set; }
         public string UF_TWITTER { get; set; }
         public string UF_SKYPE { get; set; }
         public string UF_DISTRICT { get; set; }
         public string UF_PHONE_INNER { get; set; }
         public string USER_TYPE { get; set; }
    }
}
