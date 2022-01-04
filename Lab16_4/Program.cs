using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;// подключаемые пространства имен
using System.IO;// подключаемые пространства имен
using System.Text.Encodings.Web;// подключаемые пространства имен
using System.Text.Unicode;// подключаемые пространства имен

namespace Lab16_4
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;// константа
            Product[] products = new Product[n];// массив
            for (int i = 0; i < n; i++) 
            {
             Console.WriteLine("Введите код товара");//вводит пользователь из клавиатуры код товара
             int code = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine("Введите название товара");//вводит пользователь из клавиатуры код название товара
             string name = Console.ReadLine();
             Console.WriteLine("Введите цену товара"); //вводит пользователь из клавиатуры цену товара
             int price = Convert.ToInt32(Console.ReadLine());
             products [i] = new Product() { Code = code, Name = name, Price = price };//новый экземпляр класса product
            }
            JsonSerializerOptions options = new JsonSerializerOptions()  //создаем экземпляр json
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), //поле которое определяет его кодировку, статический метод Create
                                                                                                       //UnicodeRanges это перечисление
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options);//сериализуем массив в json-строку

            using (StreamWriter sw=new StreamWriter("../../../../Products.json")) //сохраняем в файл
            {
                sw.WriteLine(jsonString);    
            }
        }
    }
}
