using System;
using MediatR;

namespace PizzaMarket.Logic.UseCases.CreateCustomer
{
    public class CreateCustomerRequest : INotification
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }
        public string Phone { get; }

        public CreateCustomerRequest(string firstName, string lastName, string address, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
        }
    }
}
