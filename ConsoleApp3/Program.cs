using ConsoleApp3;
using System.Collections.Generic;
namespace ConsoleApp3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Drink> drinks = new List<Drink>();
            List<OrderItem> orders = new List<OrderItem>();

            //新增飲料品項
            AddNewDrink(drinks);

            //顯示所有飲料菜單
            DisplayDrinkMenu(drinks);

            //訂購飲料
            PlaceOrder(orders, drinks);

            //計算售價
            CalculatePrice(orders, drinks);
        }

        private static void CalculatePrice(List<OrderItem> myOrders, List<Drink> myDrinks)
        {
            Console.WriteLine("開始計算售價");
            double total = 0.0;
            string message = "";
            double sellPrice = 0.0;

            foreach (OrderItem item in myOrders) total += item.SubTotal;

            if (total >= 500)
            {
                message = "訂購滿500元以上者打8折";
                sellPrice = total * 0.8;
            }
            else if (total >= 300)
            {
                message = "訂購滿300元以上者打85折";
                sellPrice = total * 0.85;
            }
            else if (total >= 200)
            {
                message = "訂購滿200元以上者打9折";
                sellPrice = total * 0.9;
            }
            else
            {
                message = "訂購未滿200元以上者不打折";
                sellPrice = total;
            }

            Console.WriteLine();
            Console.WriteLine($"您所共訂購{myOrders.Count}項飲料，總計{total}元，{message}，合計需付款{sellPrice}元。訂購清單如下：");
            int i = 1;
            foreach (var item in myOrders)
            {
                Drink drink = myDrinks[item.Index];
                Console.WriteLine($"{i}:{drink.Name}{drink.Size}，每杯{drink.Price}元，訂購{item.Quantity}杯，小計{item.SubTotal}元");
                i++;
            }
        }

        private static void PlaceOrder(List<OrderItem> myOrders, List<Drink> myDrinks)
        {
            Console.WriteLine();
            Console.WriteLine("開始訂購飲料，請按x鍵離開。");
            string s;
            while (true)
            {
                int index, quantity, subtotal;

                Console.Write("請輸入您所要的飲料編號: ");
                s = Console.ReadLine();
                if (s == "x") break;
                else index = Convert.ToInt32(s);

                Console.Write("請輸入您所要的飲料杯數: ");
                s = Console.ReadLine();
                if (s == "x") break;
                else quantity = Convert.ToInt32(s);

                Drink drink = myDrinks[index];
                subtotal = drink.Price * quantity;
                myOrders.Add(new OrderItem() { Index = index, Quantity = quantity, SubTotal = subtotal });
                Console.WriteLine($"您訂購{drink.Name}{drink.Size}{quantity}杯，每杯{drink.Price}元，小計{subtotal}元。");
                Console.WriteLine();
            }
        }

        private static void DisplayDrinkMenu(List<Drink> myDrinks)
        {
            //for (int i = 0; i<drinks.Count; i++)
            //{
            //    Console.WriteLine($"{drinks[i].Name}  {drinks[i].Size}  {drinks[i].Price}");
            //}

            Console.WriteLine("飲料清單");
            Console.WriteLine("---------------------------");
            int i = 0;
            Console.WriteLine(String.Format("{0,-4}{1,-5}{2,2}{3,7}", "編號", "品名", "大小", "價格"));
            Console.WriteLine("---------------------------");
            foreach (Drink drink in myDrinks)
            {
                Console.WriteLine($"{i,-6}{drink.Name,-5}{drink.Size,-5}{drink.Price,7:C0}");
                i++;
            }
            Console.WriteLine("---------------------------");
        }

        private static void AddNewDrink(List<Drink> myDrinks)
        {
            //Drink drink1 = new Drink() { Name = "紅茶", Size = "大杯", Price = 50 };
            //drinks.Add(drink1);

            myDrinks.Add(new Drink() { Name = "紅茶", Size = "大杯", Price = 50 });
            myDrinks.Add(new Drink() { Name = "紅茶", Size = "小杯", Price = 30 });
            myDrinks.Add(new Drink() { Name = "綠茶", Size = "大杯", Price = 50 });
            myDrinks.Add(new Drink() { Name = "綠茶", Size = "大杯", Price = 30 });
            myDrinks.Add(new Drink() { Name = "咖啡", Size = "大杯", Price = 70 });
            myDrinks.Add(new Drink() { Name = "咖啡", Size = "大杯", Price = 50 });
        }
    }
}
