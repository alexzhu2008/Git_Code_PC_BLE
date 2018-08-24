using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_BLE_SDK_PC_CSharp.Utils
{
    public class OperationRecord
    {
        public DateTime Date { set; get; }

        public int UserId { set; get; }
        public int OperationType { set; get; }
        public int UserType { set; get; }
    }
}
