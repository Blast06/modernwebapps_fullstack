using FluentValidator;
using FluentValidator.Validation;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email() { }
        public Email(string emailAddress)
        {
            EmailAddress = emailAddress;

            AddNotifications(new ValidationContract()
                .IsEmail("EmailAddress", "EmailAddress", "Should inform EmailAddress in Correct Format")                
            );            
        }

        public string EmailAddress { get; private set; }
    }
}
