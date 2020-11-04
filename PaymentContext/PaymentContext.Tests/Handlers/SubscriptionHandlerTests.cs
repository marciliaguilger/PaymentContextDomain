using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName ="Frida";
            command.LastName ="Kahlo";
            command.Document ="99999999999";
            command.Email ="frida@email.com";
            command.BarCode ="123456789";
            command.BoletoNumber ="123456789";
            command.PaymentNumber ="123121";
            command.PaidDate =DateTime.Now;
            command.ExpireDate =DateTime.Now.AddMonths(1);
            command.Total =60;
            command.TotalPaid =60;
            command.Payer ="Frida";
            command.PayerDocument ="12345678911";
            command.PayerDocumentType =EDocumentType.CPF;
            command.PayerEmail ="frida@email.com";        
            command.Street ="asasas";
            command.Number ="11111";
            command.Neighborhood ="asdasd";
            command.City="asasa";
            command.State ="asasas";
            command.Country ="asasas";
            command.ZipCode ="12345678";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);

        }
        
    }
}