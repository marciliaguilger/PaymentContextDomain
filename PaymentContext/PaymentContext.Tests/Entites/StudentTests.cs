using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entites
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarAssinatura()
        {
            var name = new Name("Teste","Teste");
            foreach(var not in name.Notifications)
            {
                // not.Message;
            }
        }
    }
}