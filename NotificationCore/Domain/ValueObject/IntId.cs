using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Domain.ValueObject
{
    public sealed record IntId
    {
        public int Value { get; }

        private IntId() { }

        public IntId(int value)
        {
            Value = value;
        }

        public static implicit operator IntId(int value) => new IntId(value);
        public static implicit operator int(IntId value) => value.Value;
    }
}
