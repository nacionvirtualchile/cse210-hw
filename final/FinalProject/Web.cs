using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Web: OnlineService
{

//VARIABLES
    private int _extraModules;


//CONSTRUCTORS
    public Web (int extraModules, string name, string domain, int priceFirstYear, string description) : base (name, domain, description)
    {
        _extraModules = extraModules;
    }



//METHODS
    public void SetExtraModules(int extraModules) {
        _extraModules = extraModules;
    }
    public int GetExtraModules() {
        return _extraModules;
    }


    public override int CalculatePriceFirstYear() {
        int calculatedPrice = base.GetPriceFirstYear() + (50  * _extraModules);
        base.SetPriceFirstYear(calculatedPrice);
        return calculatedPrice;
    }
    public override void DisplayInfoService() {
        Console.WriteLine("______________");
        Console.WriteLine("______________");
        Console.WriteLine("DISPLAY WEB SERVICE");
        Console.WriteLine($"Domain: {base.GetDomain}");
        Console.WriteLine($"Quantity Extra Modules: {_extraModules}");
        Console.WriteLine($"Price First Year: {base.GetPriceFirstYear}");
        Console.WriteLine($"Description: {base.GetDescription}");
        Console.WriteLine("______________");
        Console.WriteLine("______________");
    }


}
