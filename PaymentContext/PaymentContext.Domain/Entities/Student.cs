using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name,document,email); //agrupamento dos erros que possam eventualmente ter ocorrido dentro de name, document e email para dentro da classe student
        }

        public Name Name {get ; private set;}
        public Document Document { get;  private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        
        //Usando list, permitimos que sejam adicionas assinaturas fora da classe. 
        //Com IReadOnly, obrigamos o programador a utilizar o método especifico para isso.
        // Método de anti corrupção de código
        // public List<Subscription> Subscriptions {get;set;}
        public IReadOnlyCollection<Subscription> Subscriptions {get {return _subscriptions.ToArray();}}


        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;
            foreach(var sub in _subscriptions)
            {
                if(sub.Active)
                    hasSubscriptionActive = true;
            }


            //add notificação via contrato 
            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Voce já tem uma assinatura ativa")
                .AreNotEquals(0,subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura não possui pagamentos.")
            );
            
            if (Valid)
                _subscriptions.Add(subscription);
            //notificação sem contrato
            // if(hasSubscriptionActive)
            //     AddNotification("Student.Subscriptions", "Voce já tem uma assinatura ativa");


        }
    }
}