using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Pizza p = new Pizza();
            Console.WriteLine(p.ToString());
            Console.WriteLine($"Коштує {p.GetPrice()}грн.");
            Console.WriteLine("---------next pizza:");
            List<Ingredient> ingredients = new List<Ingredient>();
            for (int i = 0; i < 5; i++)
            {
                Ingredient ing = new Ingredient((Ingridients)i, r.Next(10, 50), r.Next(5, 100));
                ingredients.Add(ing);
            }

            Pizza p2 = new Pizza(ingredients, 30, Pizza.TypeOfBorder.Cheese);
            Console.WriteLine(p2.ToString());
            Console.WriteLine($"Коштує {p2.GetPrice()}грн.");
            Console.WriteLine("---------modific pizza:");
            p2.AddIngredient(new Ingredient((Ingridients)1, 15, 20));
            Console.WriteLine(p2.ToString());
            Console.WriteLine($"Коштує {p2.GetPrice()}грн.");
            p2.RemoveIngredient(Ingridients.Ham);
            Console.WriteLine("---------revoved pizza:");
            Console.WriteLine(p2.ToString());
            Console.WriteLine($"Коштує {p2.GetPrice()}грн.");
            Dish[] D = new Dish[2];
            D[0] = p;
            D[1] = p2;
            // D[2] = new Panini();
            // D[3] = new Pasta();
            foreach (var d in D)
            {
                Console.WriteLine(d.ToString() + " коштує " + d.GetPrice() + " грн.");
            }
            Console.ReadKey();
        }
    }
}
