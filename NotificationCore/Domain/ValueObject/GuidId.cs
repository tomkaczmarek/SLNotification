using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Domain.ValueObject
{
    public sealed record GuidId
    {
        public Guid Value { get; }

        private GuidId() { }

        public GuidId(Guid value)
        {
            Value = value;
        }

        public static implicit operator GuidId(Guid value) => new GuidId(value);
        public static implicit operator Guid(GuidId value) => value.Value;
    }
}
