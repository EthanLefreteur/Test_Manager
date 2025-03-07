using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Log email sending instead of actually sending an email
        Console.WriteLine($"Simulating email to {email} with subject '{subject}'");
        return Task.CompletedTask;
    }
}