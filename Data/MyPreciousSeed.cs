using CSMS.Models.DomainModels;

namespace CSMS.Data
{
    public static class MyPreciousSeed
    {
        public static async Task Initialize(CleaningServiceContext context)
        {
            context.Database.EnsureCreated(); // -> Database created

            if (context.Orders.Any())
            {
                return; // -> Database seeded so no need to do that.
            }

            await Seed(context);
        }

        public static async Task Seed(CleaningServiceContext context)
        {
            Person p1 = new Person("Bingleton", null, "MASusmith", DateTime.SpecifyKind(DateTime.Parse("13/05/1999"), DateTimeKind.Utc), "Bingleton@bing.com", "666-999-420", null, null, null, "l1c3nc3");
            Person p2 = new Person("General", null, "Borkowskie", DateTime.SpecifyKind(DateTime.Parse("02/02/1994"), DateTimeKind.Utc), "PogromcaStudentów@gmail.com", "234-425-542", 20.00, null, null, null);
            Person p3 = new Person("Samuel", null, "Bruh", DateTime.SpecifyKind(DateTime.Parse("24/11/1995"), DateTimeKind.Utc), "NotSamuelJackson@mailus.com", "542-521-464", 20.00, null, null, null);
            Person p4 = new Person("Slow", null, "Student", DateTime.SpecifyKind(DateTime.Parse("14/09/1991"), DateTimeKind.Utc), "AmSlow@mailus.com", "524-636-234", 20.00, null, null, null);
            Person p5 = new Person("Adam", null, "Szmigielski", DateTime.SpecifyKind(DateTime.Parse("15/07/1410"), DateTimeKind.Utc), "ASzmige@mailus.com", "111-222-333", 20.00, null, null, null);
            Person p6 = new Person("John", null, "Kowalski", DateTime.SpecifyKind(DateTime.Parse("19/03/1990"), DateTimeKind.Utc), "TypicalKowalski@mailus.com", "425-342-132", 20.00, null, null, null);
            Person p7 = new Person("Peter", null, "Potocki", DateTime.SpecifyKind(DateTime.Parse("03/04/1910"), DateTimeKind.Utc), "Peterus@mailus.com", "432-421-233", 20.00, null, null, null);
            Person p8 = new Person("Joe", null, "Mama", DateTime.SpecifyKind(DateTime.Parse("03/04/1910"), DateTimeKind.Utc), "JoeMama@mailus.com", "432-421-233", null, 50.00, null, null);
            Person p9 = new Person("Sussy", null, "Baka", DateTime.SpecifyKind(DateTime.Parse("05/04/2000"), DateTimeKind.Utc), "Amogus@sus.com", "452-642-124", null, 50.00, null, null);
            Person p10 = new Person("Walter", "Cocainer", "White", DateTime.SpecifyKind(DateTime.Parse("08/07/1998"), DateTimeKind.Utc), "FreeMeth@drugs.com", "357-546-754", null, null, 2000.00, null);

            context.Persons.Add(p1);
            context.Persons.Add(p2);
            context.Persons.Add(p3);
            context.Persons.Add(p4);
            context.Persons.Add(p5);
            context.Persons.Add(p6);
            context.Persons.Add(p7);
            context.Persons.Add(p8);
            context.Persons.Add(p9);
            context.Persons.Add(p10);

            await context.SaveChangesAsync();

            Warehouse w1 = new Warehouse(20);

            context.Warehouses.Add(w1);

            await context.SaveChangesAsync();

            Car c1 = new Car();
            Car c2 = new Car();
            Car c3 = new Car();

            context.Cars.Add(c1);
            context.Cars.Add(c2);
            context.Cars.Add(c3);

            await context.SaveChangesAsync();

            c1.SetWarehouse(w1);
            c2.SetWarehouse(w1);
            c3.SetWarehouse(w1);

            await context.SaveChangesAsync();

            p8._employee._driver.UseCar(c1);
            p9._employee._driver.UseCar(c2);

            await context.SaveChangesAsync();

            CleaningOffer of1 = new CleaningOffer("Wiziszmje?", 50.00, 5, null, null);
            CleaningOffer of2 = new CleaningOffer("Wizisz?", 200.00, null, 500.00, null);
            CleaningOffer of3 = new CleaningOffer("BREK", 100.00, 5, null, new List<string>() { "Domejstos", "Fluoroantimonic acid", "Ludwik" });
            CleaningOffer of4 = new CleaningOffer(";", 500.00, null, 500.00, new List<string>() { "Aughhh", "SilverPaint", "Wiziszmje???" });

            context.CleaningOffers.Add(of1);
            context.CleaningOffers.Add(of2);
            context.CleaningOffers.Add(of3);
            context.CleaningOffers.Add(of4);

            await context.SaveChangesAsync();

            p10._client.ViewOffer(of1);
            p10._client.ViewOffer(of2);
            p10._client.ViewOffer(of3);
            p10._client.ViewOffer(of4);

            await context.SaveChangesAsync();

            Order o1 = new Order(DateTime.SpecifyKind(DateTime.Parse("02/07/2022"), DateTimeKind.Utc), p10._client, of1, new HashSet<Cleaner>() { p2._employee._cleaner, p3._employee._cleaner }, p8._employee._driver);
            Order o2 = new Order(DateTime.SpecifyKind(DateTime.Parse("05/07/2022"), DateTimeKind.Utc), p10._client, of3);
            Order o3 = new Order(DateTime.SpecifyKind(DateTime.Parse("12/07/2022"), DateTimeKind.Utc), p10._client, of2);
            Order o4 = new Order(DateTime.SpecifyKind(DateTime.Parse("15/07/2022"), DateTimeKind.Utc), p10._client, of2);
            Order o5 = new Order(DateTime.SpecifyKind(DateTime.Parse("20/07/2022"), DateTimeKind.Utc), p10._client, of3, new HashSet<Cleaner>() { p2._employee._cleaner, p3._employee._cleaner }, p9._employee._driver);

            context.Orders.Add(o1);
            context.Orders.Add(o2);
            context.Orders.Add(o3);
            context.Orders.Add(o4);
            context.Orders.Add(o5);

            await context.SaveChangesAsync();
        }
    }
}
