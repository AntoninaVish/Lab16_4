using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;


namespace Lab16_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty; //пустая строка, равносильна пустым кавычкам
            using (StreamReader sr= new StreamReader("../../../../Products.json"))
            {
                jsonString = sr.ReadToEnd(); //создаем строковую переменную, считываем строку
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString); // строку превращаем в массив объектов

            Product maxProduct = products[0]; //сохраняем продукт, в него присваиваем нулевую строку, первый товар имеет максимальную цену

            foreach (Product p in products) //определяем название самого дорогого товара
            {
                if (p.Price>maxProduct.Price)
                {
                    maxProduct = p;
                }

            }
            Console.WriteLine($"{maxProduct.Code} {maxProduct.Name} {maxProduct.Price}");// выводим код, название и цену самого дорогого товара
            Console.ReadKey();
        }
    }
}
