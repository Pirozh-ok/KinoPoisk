namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IEmailService {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendEmailResultAuthentificationWithGoogle(string email);
    }
}
