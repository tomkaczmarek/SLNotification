using NotificationCore.Abstractions.Commands;
using NotificationCore.Abstractions.Mailer;
using NotificationCore.Abstractions.Response;
using NotificationCore.Infrastructure.Mailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCore.Application.Commands.Mailers.SendVerifyTokenMail
{
    public class SendVerifyTokenMailHandler : ICommandHandler<SendVerifyTokenMailCommand>
    {

        private IMailer _mailer;

        public SendVerifyTokenMailHandler(IMailer mailer)
        {
            _mailer = mailer;
        }

        public async Task<ApiResponse> HandleAsync(SendVerifyTokenMailCommand command, CancellationToken cancellationToken)
        {
            await _mailer.Send(new MailBody(PrepareBody(command.Token)), cancellationToken);
            return new ApiResponse();
        }

        public string PrepareBody(string token)
        {
            return @$"<!DOCTYPE html>
                        <html>
                          <body style=""font-family: Arial, sans-serif; background-color: #f9f9f9; padding: 20px;"">
                            <div style=""max-width: 600px; margin: auto; background-color: #eeeeee; padding: 30px; border-radius: 4px;"">
                              <h2 style=""text-align: center; color: #333;"">Soundlink</h2>
                              <p style=""text-align: center; font-size: 18px; color: #555;"">Aktywuj konto</p>
                              <p style=""text-align: center; margin-top: 30px;"">
                                <a href=""https://localhost:7127/Authentication/confirm?token={token}"" 
                                   style=""display: inline-block; background-color: #4CAF50; color: white; padding: 12px 24px; text-decoration: none; border-radius: 4px;"">
                                   Kliknij tutaj, aby aktywować konto
                                </a>
                              </p>
                              <p style=""text-align: center; margin-top: 20px; font-size: 14px; color: #777;"">
                                Lub skopiuj i wklej ten link do przeglądarki:<br>
                                <a href=""https://localhost:7127/Authentication/confirm?token={token}"" style=""color: #333;"">
                                  https://localhost:7127/Authentication/confirm?token={token}
                                </a>
                              </p>
                            </div>
                          </body>
                        </html>";
        }
    }
}
