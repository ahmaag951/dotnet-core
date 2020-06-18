using FizzWare.NBuilder;
using System;
using System.Linq;

namespace NBuilderAndFaker
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = Builder<Customer>.CreateListOfSize(100)
            .All()
                .With(c => c.FirstName = Faker.Name.First())
                .With(c => c.LastName = Faker.Name.Last())
                .With(c => c.EmailAddress = Faker.Internet.Email())
                .With(c => c.TelephoneNumber = Faker.Phone.Number())
            .Build();
            var context = new ApplicationContext();

            context.Customers.AddRange(customers.ToArray());
            context.SaveChanges();

            Console.WriteLine("Hello World!");
        }
    }
}
