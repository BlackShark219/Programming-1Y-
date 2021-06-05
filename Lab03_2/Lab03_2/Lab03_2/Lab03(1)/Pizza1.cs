using System;
using System.Collections.Generic;

namespace Lab03_1_
{
    class Pizza : Dish
    {
        public enum TypeOfBorder
        {
            Usual,
            Meat,
            Cheese
        }
        private TypeOfBorder border;
        public TypeOfBorder Border { get { return border; } set { border = value; } }

        public Pizza(): base(new List<Ingredient>(),20)
        {
        }

        public Pizza(List<Ingredient> ingredients, double size, TypeOfBorder Border)
            : base(ingredients, size)
        {
            this.Border = Border;
        }

        public override string ToString()
        {
            string[] bortik = { "usual", "meat", "cheese" };
            string text = "Pizza contains\n";
            for (int i = 0; i < ingredients.Count; i++)
            {
                text += ingredients[i].ToString() + "\n";
            }
            text += "size " + size + " sm., type of border " + bortik[(int)Border];
            return text;
        }

        public override double GetPrice()
        {
            // тут алгоритм расчета
            return PriceofIngridients + (int)Border * 5;
        }
    }
}
