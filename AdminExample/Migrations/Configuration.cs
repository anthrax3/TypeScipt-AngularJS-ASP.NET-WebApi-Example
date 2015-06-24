using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Core.Models;
using Data;
using Helpers;
using Helpers.Extensions;

namespace AdminExample.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AdminExample.App_Data.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //������
            var childBicycle = new Product(1, "��������� �������", "�������� � ������ ������������ � �������, ������ ���� ���� ����� ������������ ���������, ��, ���, ��������� � ����� ����.", "images/products/bicycle.png", 14990);
            var fastBicycle = new Product(2, "��������� �������", "�������� ������ �� 5 �����, ��� ������������� ����!", "images/products/speedBicycle.jpg", 29990);
            var rollerSkates = new Product(3, "��������� ������", "������������ ���� ������� �� ����!", "images/products/skates.jpg", 5990);
            var rocket = new Product(4, "������", "����� �� ���� ��������!", "images/products/rocket.png", 99999);
            var guitar = new Product(6, "������", "�������������� ������������������ ���� � ���� ��������.", "images/products/guitar.jpg", 990);
            var scooter = new Product(7, "�������", "�������� ����������� �� ��������!", "images/products/scooter.jpg", 990);
            var treadmill = new Product(8, "������� �������", "��� ������� ���������, ���� ������!", "images/products/treadmill.jpg", 19900);
            var bike = new Product(9, "��������", "����������� ���� ��� ������� �����������.", "images/products/bike.jpeg", 199900);
            var iphonePack = new Product(10, "������ (��������)", "����� �������, �������� ������� ��� ����������� �����. ����� ������ ���� �����, ��� ����������� �� �������!", "images/products/iphones.png", 9999);
            var freezer = new Product(21, "�����������", "�������� ������� �� ����� ����!", "images/products/freezer.jpg", 19999);
            var mangal = new Product(14, "������", "������� ��� �������� � ������.", "images/products/mangal.jpg", 229);
            var taburet = new Product(15, "�������", "�������� ��������� �� ������ ��� ����������� �������� ����� ��� ���� ���.", "images/products/taburet.jpg", 729);
            //���������
            var dvd = new Product(13, "DVD ����", "�������� �� ���� �� ��� ���������.", "images/products/dvd.jpg", 9, ProductType.Accessorise);
            var ivansHelmet = new Product(16, "���� ����� ��������", "�������� ���� ��� ������ ���������.", "images/products/ivans_helmet.jpg", 99999, ProductType.Accessorise);
            taburet.AddAccessorise(ivansHelmet);
            iphonePack.AddAccessorise(ivansHelmet);
            dvd.AddAccessorise(ivansHelmet);
            var bikeHelmet = new Product(17, "������������� ����", "�������� ������ ��� ����� ������.", "images/products/bike_helmet.jpg", 9899, ProductType.Accessorise);
            bike.AddAccessorise(bikeHelmet);
            rocket.AddAccessorise(bikeHelmet);
            fastBicycle.AddAccessorise(bikeHelmet);
            var childHelmet = new Product(18, "������� ����", "����������� ������ �������!", "images/products/childhelmet.jpg", 7890, ProductType.Accessorise);
            childBicycle.AddAccessorise(childHelmet);
            scooter.AddAccessorise(childHelmet);
            rollerSkates.AddAccessorise(childHelmet);
            var luna = new Product(19, "����", "������� ������� ������� ������������ ��������!", "images/products/luna.png", 777, ProductType.Accessorise);
            mangal.AddAccessorise(luna);
            rocket.AddAccessorise(luna);
            var childGlasses = new Product(20, "������� ����", "����� ������ �� ������� �����!", "images/products/childGlasses.jpeg", 199, ProductType.Accessorise);
            childBicycle.AddAccessorise(childGlasses);
            rollerSkates.AddAccessorise(childGlasses);
            scooter.AddAccessorise(childGlasses);
            var banana = new Product(11, "������", "������ ������� ��� ��������!", "images/products/banan.jpg", 99, ProductType.Accessorise);
            mangal.AddAccessorise(banana);
            taburet.AddAccessorise(banana);
            freezer.AddAccessorise(banana);
            var milk = new Product(12, "������", "������ ������� �������, ���� ��� ������!", "images/products/milk.jpg", 59, ProductType.Accessorise);
            mangal.AddAccessorise(milk);
            taburet.AddAccessorise(milk);
            freezer.AddAccessorise(milk);
            var iphoneCase = new Product(22, "����� ��� ��������", "��������� �������������� � �������!", "images/products/iphoneCase.png", 1199, ProductType.Accessorise);
            iphonePack.AddAccessorise(iphoneCase);
            iphonePack.AddAccessorise(dvd);
            var beerBottle = new Product(23, "����", "��� ��� ���� ������� ����-����!", "images/products/beer.jpg", 89, ProductType.Accessorise);
            guitar.AddAccessorise(beerBottle);
            var buben = new Product(5, "����� ���������", "����������� ���� ��� ������� ������������, �������� �� ������� ���������.", "images/products/buben.jpg", 5000, ProductType.Accessorise);
            mangal.AddAccessorise(buben);
            //
            var newAccessorises = new[]
            {
                ivansHelmet,
                bikeHelmet,
                childHelmet,
                luna,
                childGlasses,
                banana,
                milk,
                iphoneCase,
                beerBottle,
                buben
            };
            foreach (var accessorise in newAccessorises)
            {
                context.Products.Attach(accessorise);
                context.Products.AddOrUpdate(accessorise);
            }
            var newProducts = new[]
            {
                childBicycle,
                fastBicycle,
                rollerSkates,
                rocket,
                guitar,
                scooter,
                treadmill,
                bike,
                iphonePack,
                freezer,
                dvd,
                mangal,
                taburet
            };
            foreach (var product in newProducts)
            {
                context.Products.Attach(product);
                context.Products.AddOrUpdate(product);
            }
            //
            var managers = new[]
            {
               Manager.Create(1,"�������", "�������", "��������", "/images/faces/manager_1.jpg"),
               Manager.Create(2,"��������", "��������", "��������", "/images/faces/manager_2.jpg"),
               Manager.Create(3,"�������", "����", "������������", "/images/faces/manager_3.jpg"),
               Manager.Create(4,"����������", "�����", "��������", "/images/faces/manager_4.jpg"),
               Manager.Create(5,"�������", "�����", "��������", "/images/faces/manager_5.jpg"),
               Manager.Create(6,"�����", "�������", "����������", "/images/faces/manager_6.jpg"),
               Manager.Create(7,"�������", "��������", "����������", "/images/faces/manager_7.jpg"),
               Manager.Create(8,"��������", "������", "����������", "/images/faces/manager_8.jpg"),
               Manager.Create(9,"��������", "�����", "��������", "/images/faces/manager_9.jpg"),
               Manager.Create(10,"����", "���������", "����������", "/images/faces/manager_10.jpg"),
               Manager.Create(11,"����������", "�����", "��������", "/images/faces/manager_11.jpg"),
               Manager.Create(12,"��������", "���������", "����������", "/images/faces/manager_12.jpg"),
               Manager.Create(13,"���������", "�������", "������������", "/images/faces/manager_13.jpg"),
               Manager.Create(14,"�������", "�����", "����������", "/images/faces/manager_14.jpg"),
               Manager.Create(15,"�����������", "����", "���������", "/images/faces/manager_15.jpg"),
            };
            context.Managers.AddOrUpdate(managers);
            //
            var addresses = new[]
            {
                new Address("������", "������", "��. ���������������������", 22),
                new Address("���������", "����-���", "��. ��������", 123),
                new Address("������", "�����-���������","��. �����������",12),
            };
            var contacts = new[]
            {
                "+7 (123) 555-55-55",
                "fake_address@gamil.com",
                "unhuman_1970@mail.net",
                "+7 (123) 456-78-90",
            };
            var notes = new[]
            {
                "������� �� ����� 19-00!",
                "������� �� ������ 12-00!!",
                "���������� ������ �� ��.",
                "����������� ���������� ��� �����-������ ������� ������.",
                "��������� �� ������ ��� � ������������ (������ ��������)"
            };
            //
            var allOrderItems = context.OrderItems.ToList();
            //�������� ��������
            for (var orderId = 1; orderId <= 100; orderId++)
            {
                var address = addresses.Shuffle().First();
                var manager = managers.Shuffle().First();
                var contact = contacts.Shuffle().First();
                var note = notes.Shuffle().First();
                var random = new Random();
                var clientName = GenerateRandomName();
                var order = new Order(orderId, clientName, DateTime.Now, manager, address, contact, note);
                const int maxCountOfItems = 5;
                var numberOfItems = random.Next(1, maxCountOfItems);
                Console.WriteLine(numberOfItems);
                var products = newProducts.Shuffle().Take(numberOfItems);
                foreach (var product in products)
                {
                    var itemCount = random.Next(1, 5);
                    order.AddOrderItem(product, itemCount);
                }
                context.Orders.AddOrUpdate(order);
                var newOrderItems = order.Items.ToArray();
                allOrderItems = allOrderItems.Except(newOrderItems).ToList();
                context.OrderItems.AddOrUpdate(newOrderItems);
            }
            context.Set<OrderItem>().RemoveRange(allOrderItems);
            //
            context.SaveChanges();
        }

        private static Name GenerateRandomName()
        {
            var random = new Random();
            var isMale = Convert.ToBoolean(random.Next(0, 1));
            //
            if (isMale)
            {
                return new Name(Generate.RandomMaleLastName(), Generate.RandomMaleName(), Generate.RandomMaleMiddleName());
            }
            return new Name(Generate.RandomFemaleLastName(), Generate.RandomFemaleName(), Generate.RandomFemaleMiddleName());
        }
    }
}
