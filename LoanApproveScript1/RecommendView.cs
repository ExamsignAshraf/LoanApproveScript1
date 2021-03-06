using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApproveScript1
{
    public class RecommendView
    {
        public string CustomerName { get; set; }
        public int LoanAmount { get; set; }
        public DateTime RequestDate { get; set; }
        public int LoanPeriod { get; set; }
        public string EmpName { get; set; }
        public string RequestID { get; set; }
        public string CustomerID { get; set; }
        public string BranchID { get; set; }
        public string SHGId { get; set; }
        private string _empid;
        public string EmpId
        {
            get
            {
                return _empid;
            }
            set
            {
                _empid = value;

            }
        }
        public string BranchName { get; set; }
        public string CenterName { get; set; }
        public string CollectionDay { get; set; }
        public DateTime SamuApproveDate { get; set; }
        private bool _isrecommend;
        public bool IsRecommend
        {
            get
            {
                return _isrecommend;
            }
            set
            {
                _isrecommend = value;
                
            }
        }
        public string LoanType { get; set; }
        public string ReportId { get; set; }
        public string HimarkRefNumber { get; set; }
    }
}
