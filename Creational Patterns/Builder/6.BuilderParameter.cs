using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    //We want to froce the API consumers to use the Builder whatever they like or not.
    //This can be done that we take the builder as a parameter.
    public class Email
    {
        public string From, To, Subject, Body;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"[From]: {From} [TO]: {To} [Subject]: {Subject} [Body]: {Body}");
            return sb.ToString();
        }
    }

    public class MailService
    {
        public class EmailBuilder
        {
            private readonly Email email;

            public EmailBuilder(Email email) => this.email = email;

            public EmailBuilder From(string from)
            {
                email.From = from;
                return this;
            }

            public EmailBuilder To(string to)
            {
                email.To = to;
                return this;
            }

            public EmailBuilder Subject(string value)
            {
                email.Subject = value;
                return this;
            }

            public EmailBuilder Body(string body)
            {
                email.Body = body;
                return this;
            }
        }

        private void SendEmailInternal(Email email)
        {
            Console.WriteLine(email);
        }

        public void SendEmail(Action<EmailBuilder> builder)
        {
            var email = new Email();
            builder(new EmailBuilder(email));
            SendEmailInternal(email);
        }
    }

    public static class TestWithBuilderParameter
    {
        public static void Execute()
        {
            Console.WriteLine(nameof(TestWithBuilderParameter));
            var ms = new MailService();
            ms.SendEmail(email => email.From("foo@bar.com")
            .To("bar@baz.com")
            .Body("hello world"));
        }
    }
}