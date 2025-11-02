using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NotificationCore.Domain.ValueObject
{
    public sealed record NotificationKey
    {
        public string Value { get; }

        private NotificationKey() { }

        public NotificationKey(string value)
        {
            Value = value;
        }

        public static implicit operator NotificationKey(string value) => new NotificationKey(value);
        public static implicit operator string(NotificationKey fullName) => fullName == null ? string.Empty : fullName.Value;
    }
}
