using System;

namespace BeOn.Models
{
    public interface ITimestampable
    {
        public DateTime Timestamp { get; }
    }
}
