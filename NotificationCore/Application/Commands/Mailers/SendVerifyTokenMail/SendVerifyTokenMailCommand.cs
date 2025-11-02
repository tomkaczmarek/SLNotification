using NotificationCore.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Mailers.SendVerifyTokenMail
{
    public class SendVerifyTokenMailCommand : ICommand
    {
        public string Email { get; set; }
        public string TemplateKey { get; set; }
        public string Token { get; set; }
    }
}
