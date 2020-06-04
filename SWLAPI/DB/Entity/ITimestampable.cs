using System;

namespace SWLAPI.DB.Entity
{
    interface ITimestampable
    {
        DateTime CreatedAt { set; get; }
        DateTime? ModifiedAt { set; get; }
    }
}
