using System;

namespace NETInnovation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Customer customer = new(); //Bu şekilde new kullanımı da mevcuttur
            customer.Age = 30;

            var prototypeCustomer=(Customer)customer.CloneCustomer(); //Klonlama işlemi yapılmıştır.Aynı Entity başka adreste de yer alıyor artık
            Console.WriteLine(prototypeCustomer.Age);
            if (customer.Equals(prototypeCustomer))
            {
                Console.WriteLine("Eşit");
            }
            else
            {
                Console.WriteLine("Eşit Değil");
            }


            MyClass myClass = new() {Age=30,Name="Eray" }; //Eski usül new işlemi de uygulanabilirdi
            var myClass_2 = myClass with { Age = 15, Name = "Berkay" }; //Klonlama işlemi records larda çok daha kolay yapılır
           
        }
    }

    class Customer:PrototypeCustomer
    {
        public string Name { get; init; } //init readonly anlamı katıyor.Bu property e değer atama işlemi ya yapıcı metotta olabilir ya da örneklenirken olabilir
        public int Age { get; set; }

        public Customer()
        {
            Name = "Eray";
            Console.WriteLine("Customer Calıstı");
        }

        public override PrototypeCustomer CloneCustomer()
        {
            return this.MemberwiseClone() as PrototypeCustomer;
        }
    }


    abstract class PrototypeCustomer
    {
        public abstract PrototypeCustomer CloneCustomer();
    }


    record MyClass //Record oluşturduk
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
