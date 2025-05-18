using System;

namespace LMSWithArrayList.Models
{
    public class ItemHistory
    {
        public int ItemId { get; set; }
        public string Operation { get; set; } // "Borrowed" or "Returned"
        public DateTime OperationDate { get; set; }
        public string UserName { get; set; }

        public ItemHistory(int itemId, string operation, string userName)
        {
            ItemId = itemId;
            Operation = operation;
            OperationDate = DateTime.Now;
            UserName = userName;
        }

        public override string ToString()
        {
            return $"[{OperationDate:yyyy-MM-dd HH:mm:ss}] {Operation} by {UserName}";
        }
    }
}