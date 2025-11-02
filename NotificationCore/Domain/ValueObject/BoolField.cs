using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NotificationCore.Domain.ValueObject
{
    public sealed record BoolField
    {
        public bool Value { get; }

        private BoolField() { }

        public BoolField(bool value)
        {
            Value = value;
        }

        public static implicit operator BoolField(bool value) => new BoolField(value);
        public static implicit operator bool(BoolField value) => value == null ? false : value.Value;
    }
}
