using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> FoodOrders;
        private List<IDrink> DrinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            FoodOrders = new List<IBakedFood>();
            DrinkOrders = new List<IDrink>();

            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
        }


        public int TableNumber  { get; private set; }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price
        {

            get
            {
                return PricePerPerson * NumberOfPeople;
            }
        }

        public void Clear()
        {
            IsReserved = false;
            FoodOrders.Clear();
            DrinkOrders.Clear();
            NumberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal bill = 0;

            foreach (IBakedFood food in FoodOrders)
            {
                bill += food.Price;
            }

            foreach (IDrink drink in DrinkOrders)
            {
                bill += drink.Price;
            }

            return bill;
        }

        public string GetFreeTableInfo()
        {
            return $"Table: {TableNumber}\r\n" +
                    $"Type: {GetType().Name}\r\n" +
                    $"Capacity: {Capacity}\r\n" +
                    $"Price per Person: {PricePerPerson}";
        }

        public void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
