using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_cs_
{
    enum Season
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }
    enum Discount
    {
        VIP,
        SecondVisit,
        None
    }
    internal class PriceCalculator
    {
        decimal priceForDay;
        int amountOfDays;
        Season season;
        Discount discount;
        decimal totalPrice;
        public PriceCalculator(decimal priceForDay, int amountOfDays, Season season, Discount discount)
        {
            this.priceForDay = priceForDay;
            this.amountOfDays = amountOfDays;
            this.season = season;
            this.discount = discount;
        }
        public PriceCalculator(decimal priceForDay, int amountOfDays, Season season)
        {
            this.priceForDay = priceForDay;
            this.amountOfDays = amountOfDays;
            this.season = season;
            this.discount = Discount.None;
        }
        public decimal CalculatePrice()
        {
            totalPrice = priceForDay * amountOfDays;
            switch (season)
            {
                case Season.Winter:
                    totalPrice *= 3.0m;
                    break;
                case Season.Spring:
                    totalPrice *= 2.0m;
                    break;
                case Season.Summer:
                    totalPrice *= 4.0m;
                    break;
                case Season.Autumn:
                    totalPrice *= 1.0m;
                    break;
            }
            switch (discount)
            {
                case Discount.VIP:
                    totalPrice *= 0.8m;
                    break;
                case Discount.SecondVisit:
                    totalPrice *= 0.9m;
                    break;
                case Discount.None:
                    break;
            }
            return totalPrice;
        }
    }
}
