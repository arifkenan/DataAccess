using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.Model.Abstract
{
    public class BaseEntity
    {
        public enum Status
        {
            Active = 1,
            Modify = 2,
            Passive = 3
        }
        public abstract class BaseEntitity
        {
            public int Id { get; set; }
            private DateTime _createDate = DateTime.Now;

            public DateTime CreateDate
            {
                get { return _createDate; }
                set { _createDate = value; }
            }

            public DateTime? UpdateDate { get; set; }

            public DateTime? DeleteDate { get; set; }
            private Status _status = Status.Active;

            public Status Status
            {
                get { return _status; }
                set { _status = value; }
            }
        }
    }
}
