using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03_1_
{
    class Panini:Dish
    {
        public enum TypeOfBread
        {
            White,
            Dark,
            Cheese
        }
        private TypeOfBread bread;
        public TypeOfBread Bread { get { return bread; } set { bread = value; } }

        public Panini() : base(new List<Ingredient>(), 20)
        {
        }

        public Panini(List<Ingredient> ingredients, double size, TypeOfBread bread)
            : base(ingredients, size)
        {
            this.Bread = Bread;
        }

        public override string ToString()
        {
            string[] bread = { "white", "dark", "cheese" };
            string text = "Panini contains\n";
            for (int i = 0; i < ingredients.Count; i++)
            {
                text += ingredients[i].ToString() + "\n";
            }
            text += "size " + size + "length sm., type of bread " + bread[(int)Bread];
            return text;
        }

        public override double GetPrice()
        {
            // тут алгоритм расчета
            return BasePrice + (int)Bread * 10;
        }
    }
}
