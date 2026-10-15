using DecoratorPattern.Beverages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Factory
{
    internal abstract class CoffeeShop
    {
        public Beverage OrderCoffee(CoffeeMix mix)
        {
            Beverage beverage = CreateCoffee(mix);
            Console.WriteLine(mix + ": " + beverage.GetDescription() + " $" + beverage.cost().ToString("0.00"));
            return beverage;
        }

        // factory method, de subclass bepaalt hoe het drankje gemaakt wordt
        protected abstract Beverage CreateCoffee(CoffeeMix mix);
    }
}
