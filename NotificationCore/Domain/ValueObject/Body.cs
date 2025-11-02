using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NotificationCore.Domain.ValueObject
{
    public sealed record Body
    {
        public string Value { get; }

        private Body() { }

        public Body(string value)
        {
            Value = value;
        }

        public static implicit operator Body(string value) => new Body(value);
        public static implicit operator string(Body value) => value == null ? string.Empty : value.Value;
    }
}
