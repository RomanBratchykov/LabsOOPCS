using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6;

public abstract class Food
{
        public virtual int Happiness { get; set; }
}
public class Bread : Food
{
    public Bread()
    {
        this.Happiness = 2;
    }
}
public class Apple : Food
{
    public Apple()
    {
        this.Happiness = 1;
    }
}
public class Lemnpas: Food
{
    public Lemnpas()
    {
        this.Happiness = 3;
    }
}
public class HoneyCake : Food
{
    public HoneyCake()
    {
        this.Happiness = 5;
    }
}
public class Melon : Food
{
    public Melon()
    {
        this.Happiness = 1;
    }
}
public class Mushrooms : Food
{
    public Mushrooms()
    {
        this.Happiness = -10;
    }
}
public class Other : Food
{
    public Other()
    {
        this.Happiness = -1;
    }
}
public class FoodFactory
{
    public static Food CreateFood(string foodType)
    {
        return foodType.ToLower() switch
        {
            "apple" => new Apple(),
            "lemnpas" => new Lemnpas(),
            "honeycake" => new HoneyCake(),
            "melon" => new Melon(),
            "mushrooms" => new Mushrooms(),
            _ => new Other(),
        };
    }
}
