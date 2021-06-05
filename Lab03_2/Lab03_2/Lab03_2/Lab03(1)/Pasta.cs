using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03_1_
{
    class Pasta : Dish
    {
        public enum TypeOfSauce
        {
            TomatoPaste,
            MeatwKetchup,
            CheeseSauce
        }
        private TypeOfSauce sauce;
        public TypeOfSauce Sauce { get { return sauce; } set { sauce = value; } }
        public Pasta() : base(new List<Ingredient>(), 20)
        {
        }

        public Pasta(List<Ingredient> ingredients, double size,TypeOfSauce sauce)
            : base(ingredients, size)
        {
            this.Sauce = Sauce;
        }

        public override string ToString()
        {
            string[] sauce = { "TomatoPaste", "MeatwKetchup", "CheeseSauce" };
            string text = "pasta contains\n";
            for (int i = 0; i < ingredients.Count; i++)
            {
                text += ingredients[i].ToString() + "\n";
            }
            text += "size " + size + " g., type of sauce " + sauce[(int)Sauce];
            return text;
        }

        public override double GetPrice()
        {
            // тут алгоритм расчета
            return PriceofIngridients + (int)Sauce * 2.5;
        }
    }
}
