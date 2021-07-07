using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor.Application.Dashboard.Models.BitrixModels
{
    public class TelephonyModel
    {
        public string ID { get; set; }
        public string PORTAL_USER_ID { get; set; }
        public string PORTAL_NUMBER { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string CALL_ID { get; set; }
        public string EXTERNAL_CALL_ID { get; set; }
        public string CALL_CATEGORY { get; set; }
        public string CALL_DURATION { get; set; }
        public DateTime CALL_START_DATE { get; set; }
        public string CALL_VOTE { get; set; }
        public string COST { get; set; }
        public string COST_CURRENCY { get; set; }
        public string CALL_FAILED_CODE { get; set; }
        public string CALL_FAILED_REASON { get; set; }
        public string CRM_ENTITY_TYP { get; set; }
        public string CRM_ENTITY_ID { get; set; }
        public string CRM_ACTIVITY_ID { get; set; }
        public string REST_APP_ID { get; set; }
        public string REST_APP_NAME { get; set; }
        public string TRANSCRIPT_ID { get; set; }
        public string TRANSCRIPT_PENDING { get; set; }
        public string SESSION_ID { get; set; }
        public string REDIAL_ATTEMPT { get; set; }
        public string COMMENT { get; set; }
        public string RECORD_FILE_ID { get; set; }
        public string CALL_TYPE { get; set; }
    }
}
