using System;
using System.Collections.Generic;

namespace Lab03_1_
{
    enum Ingridients
    {
        Salami,
        Ham,
        Tomatoes,
        Parmesan,
        Fat,
        Garlic
    }
    class Ingredient
    {
        public Ingridients ingridient;
        private double weight;
        protected double price;
        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
                else throw new InvalidPrice();
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
                else throw new InvalidWeight();
            }
        }

        public Ingredient(Ingridients ingridient, double weight, double price)
        {
            this.ingridient = ingridient;
            this.Weight = weight;
            this.Price = price;
        }
        public override string ToString()
        {
            return ingridient + ": weight " + weight + "g., price " + Price + "grn.";
        }
    }

    public class InvalidIngredientException : Exception
    {
        public InvalidIngredientException() { }
        public override string Message
        {
            get { return "Incorrect ingridient"; }
        }
    }
    public class InvalidPrice : Exception
    {
        public InvalidPrice() { }
        public override string Message
        {
            get { return "Incorrect price value"; }
        }
    }

    public class InvalidWeight : Exception
    {
        public InvalidWeight() { }
        public override string Message
        {
            get { return "Incorrect weight value"; }
        }
    }
    public class InvalidSize : Exception
    {
        public InvalidSize() { }
        public override string Message
        {
            get { return "Incorrect size value"; }
        }
    }


    abstract class Dish
    {
        public double size;
        public List<Ingredient> ingredients;
        public double Size { get { return size; } set { if (size > 0) size = value; else throw new InvalidSize(); } }
        public List<Ingredient> Ingridients { get { return ingredients; } set { ingredients = value; } }
        public double PriceofIngridient        
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < ingredients.Count; i++)
                { sum += ingredients[i].Price; }
                return sum;
            }            
            //{
            //    PriceofIngridient = value;
            //}
        }
        public double BasePrice
        {
            get
            {
               return PriceofIngridient + size * 1.8;
            }
        }
        public abstract double GetPrice(); // це абстрактний ми маємо перевизначити!

        //public virtual double BasePrice(double size,double sum)
        //{
        //    sum += size * 1.8;
        //    return sum;
        //}
        public Dish()
        {
            ingredients = new List<Ingredient>();
            size = 23;
            
        }
        public Dish(List<Ingredient> ingredients, double size)
        {
            this.ingredients = ingredients;
            this.size = size;
        }
        public  void AddIngredient(Ingredient ing)
        {
            ingredients.Add(ing);
        }

        public  void RemoveIngredient(Ingridients ing)
        {
            bool no = true;
            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients[i].ingridient == ing)
                {
                    ingredients.RemoveAt(i);
                    no = false;
                }
            }
            if (no)
                throw new InvalidIngredientException();

        }
        public override string ToString()
        {
            string text = "Dish contains\n";
            for (int i = 0; i < ingredients.Count; i++)
            {
                text += ingredients[i].ToString() + "\n";
            }
            text += "size " + size + " sm.";
            return text;
        }
    }
}
