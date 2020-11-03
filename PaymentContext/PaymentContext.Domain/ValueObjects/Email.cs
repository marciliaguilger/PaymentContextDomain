using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email  : ValueObject
    {
        public Email(string addres)
        {
            Addres = addres;
            AddNotifications(new Contract()
            .Requires()
            .IsEmail(Addres,"Email.Address", "E-mail inválido")
            );
        }

        public string Addres { get; private set; }
    }
}