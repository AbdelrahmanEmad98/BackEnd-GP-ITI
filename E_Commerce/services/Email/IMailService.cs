namespace E_Commerce.API;
public interface IMailingService
{
    Task SendEmailAsync(string mailTo, string subject, string body);
}
