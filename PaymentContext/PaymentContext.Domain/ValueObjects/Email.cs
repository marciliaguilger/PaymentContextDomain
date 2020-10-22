using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email  : ValueObject
    {
        public Email(string addres)
        {
            Addres = addres;
        }

        public string Addres { get; private set; }
    }
}