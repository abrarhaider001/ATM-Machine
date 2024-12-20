using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm_Machine.Classes
{
    public class LoanRequestClass
    {
        private int requestId;
        private int userId;
        private decimal loanAmount;
        private string requestDate;
        private string status;

        public LoanRequestClass(int requestId, int userId, decimal loanAmount, string requestDate, string status)
        {
            this.requestId = requestId;
            this.userId = userId;
            this.loanAmount = loanAmount;
            this.requestDate = requestDate;
            this.status = status;
        }

        public int RequestId
        {
            get { return requestId; }
            set
            {
                requestId = value;
            }
        }

        public int UserId
        {
            get { return userId; }
            set
            {
                userId = value;
            }
        }

        public decimal LoanAmount
        {
            get { return loanAmount; }
            set
            {
                loanAmount = value;
            }
        }

        public string RequestDate
        {
            get { return requestDate; }
            set
            {
                requestDate = value;
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
            }
        }
    }
}

