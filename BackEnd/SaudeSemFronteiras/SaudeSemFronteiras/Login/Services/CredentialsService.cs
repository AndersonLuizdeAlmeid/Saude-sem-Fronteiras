using System.Net.Mail;
using System.Net;
using CSharpFunctionalExtensions;

namespace SaudeSemFronteiras.Application.Login.Services;
public class CredentialsService
{
    public static string SendConfirmationEmail(string email, CancellationToken cancellationToken)
    {
        try
        {
            var fromAddress = new MailAddress("saudesemfronteiras2024@gmail.com", "Saude Sem Fronteiras");
            var toAddress = new MailAddress(email);
            const string fromPassword = "okvxfeinubutenxn";

            var confirmationCode = GenerateConfirmationCode();
            const string subject = "Código de Confirmação";
            string body = $"Seu código de confirmação é: {confirmationCode}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            return confirmationCode;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static string GenerateConfirmationCode()
    {
        Random random = new Random();
        return random.Next(100000, 999999).ToString(); // Gera um número de 6 dígitos
    }

}
