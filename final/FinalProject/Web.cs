using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Web: OnlineService
{

//VARIABLES
    private int _extraModules;


//CONSTRUCTORS
    public Web (string type, int extraModules, string name, int domains, int basePrice, string description) : base (type, name, domains, basePrice, description)
    {
        _extraModules = extraModules;

    }



//METHODS
    public override void SetExtraModules(int extraModules) {
        _extraModules = extraModules;
    }
    public override int GetExtraModules() {
        return _extraModules;
    }


    public override int CalculatePriceFirstYear() {
        int calculatedPrice = base.GetBasePrice() + (25000  * _extraModules) + (15000  * base.GetDomains());
        base.SetPriceFirstYear(calculatedPrice);
        return calculatedPrice;
    }
    public override void DisplayInfoService() {
        Console.Write($"Type:{base.GetType()} - ");
        Console.Write($"Name:{base.GetName()} - ");
        Console.Write($"Domains:{base.GetDomains()} - ");
        Console.Write($"Extra Modules:{_extraModules} - ");
        Console.Write($"Base Price:{base.GetBasePrice()} - ");
        Console.WriteLine($"Price First Year:{base.GetPriceFirstYear()}");
        Console.WriteLine($"Description:{base.GetDescription()} ");
        

    }


}
