using DecoratorPattern.Factory;

namespace DecoratorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CoffeeShop starbuzz = new StarbuzzCoffeeShop();

            starbuzz.OrderCoffee(CoffeeMix.Espresso);
            starbuzz.OrderCoffee(CoffeeMix.Lungo);
            starbuzz.OrderCoffee(CoffeeMix.Americano);
            starbuzz.OrderCoffee(CoffeeMix.Cappuccino);
            starbuzz.OrderCoffee(CoffeeMix.Mocha);
            starbuzz.OrderCoffee(CoffeeMix.ChocolateMilk);
            starbuzz.OrderCoffee(CoffeeMix.IrishCoffee);
        }
    }
}
