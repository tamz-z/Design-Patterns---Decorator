using DecoratorPattern.Beverages;
using DecoratorPattern.Condiments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Factory
{
    internal class StarbuzzCoffeeShop : CoffeeShop
    {
        protected override Beverage CreateCoffee(CoffeeMix mix)
        {
            switch (mix)
            {
                case CoffeeMix.Espresso:
                    return new Espresso();
                case CoffeeMix.Doppio:
                    return new Espresso(new Espresso());
                case CoffeeMix.Lungo:
                    return new Water(new Espresso());
                case CoffeeMix.Macchiato:
                    return new MilkFoam(new Espresso());
                case CoffeeMix.Corretta:
                    return new Liquor(new Espresso());
                case CoffeeMix.ConPanna:
                    return new Whip(new Espresso());
                case CoffeeMix.Cappuccino:
                    return new MilkFoam(new SteamedMilk(new Espresso()));
                case CoffeeMix.Americano:
                    return new Water(new Water(new Espresso()));
                case CoffeeMix.CaffeLatte:
                    return new MilkFoam(new SteamedMilk(new SteamedMilk(new Espresso())));
                case CoffeeMix.FlatWhite:
                    return new SteamedMilk(new SteamedMilk(new Espresso()));
                case CoffeeMix.Romana:
                    return new Lemon(new Espresso());
                case CoffeeMix.Morocchino:
                    return new MilkFoam(new Chocolate(new Espresso()));
                case CoffeeMix.Mocha:
                    return new Whip(new SteamedMilk(new Chocolate(new Espresso())));
                case CoffeeMix.Bicerin:
                    return new Whip(new WhiteChocolate(new BlackChocolate(new Espresso())));
                case CoffeeMix.Breve:
                    return new HalfMilk(new MilkFoam(new Espresso()));
                case CoffeeMix.RafCoffee:
                    return new Cream(new VanillaSugar(new Espresso()));
                case CoffeeMix.MeadRaf:
                    return new Cream(new Honey(new Espresso()));
                case CoffeeMix.Galao:
                    return new MilkFoam(new MilkFoam(new Espresso()));
                case CoffeeMix.CaffeAffogato:
                    return new IceCream(new Espresso(new Espresso()));
                case CoffeeMix.ViennaCoffee:
                    return new Whip(new Whip(new Espresso(new Espresso())));
                case CoffeeMix.Glace:
                    return new IceCream(new Espresso());
                case CoffeeMix.ChocolateMilk:
                    return new Milk(new Milk(new Chocolate()));
                case CoffeeMix.DemiCreme:
                    return new Cream(new Cream(new Espresso(new Espresso())));
                case CoffeeMix.LatteMacchiato:
                    return new MilkFoam(new SteamedMilk(new SteamedMilk(new Espresso())));
                case CoffeeMix.Freddo:
                    return new Ice(new Liquor(new Espresso()));
                case CoffeeMix.Frappuccino:
                    return new Whip(new SteamedMilk(new Ice(new Espresso())));
                case CoffeeMix.CaramelFrappuccino:
                    return new Syrup(new Cream(new SteamedMilk(new Ice(new Espresso()))));
                case CoffeeMix.Frappe:
                    return new IceCream(new SteamedMilk(new SteamedMilk(new Espresso())));
                case CoffeeMix.IrishCoffee:
                    return new Whip(new Whiskey(new Espresso(new Espresso())));
                default:
                    throw new ArgumentException(mix + " is not on the menu");
            }
        }
    }
}
