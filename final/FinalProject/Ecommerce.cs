using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Ecommerce : OnlineService
{
    //VARIABLES
    private Boolean _paidMethods;
    private Boolean _shipment;
    private int _extraModules;


//CONSTRUCTORS
    public Ecommerce (Boolean paidMethods, Boolean shipment, int extraModules, string name, string domain, int priceFirstYear, string description) : base (name, domain, description)
    {
        _extraModules = extraModules;
        _shipment = shipment;
        _paidMethods = paidMethods;

    }



//METHODS
    public void SetExtraModules(int extraModules) {
        _extraModules = extraModules;
    }
    public void SetPaidMethods(Boolean paidMethods) {
        _paidMethods = paidMethods;
    }
    public void SetShipment(Boolean shipment) {
        _shipment = shipment;
    }
    public int GetExtraModules() {
        return _extraModules;
    }
    public Boolean GetPaidMethods() {
        return _paidMethods;
    }
    public Boolean GetShipment() {
        return _shipment;
    }

    public override int CalculatePriceFirstYear() {
        int calculatedPrice = base.GetPriceFirstYear() + (50  * _extraModules);
        if (_paidMethods == true){
            calculatedPrice += 50;
        }
        if (_shipment == true){
            calculatedPrice += 50;
        }
        base.SetPriceFirstYear(calculatedPrice);
        return calculatedPrice;
    }
    public override void DisplayInfoService() {
        Console.WriteLine("______________");
        Console.WriteLine("______________");
        Console.WriteLine("DISPLAY ECOMMERCE SERVICE");
        Console.WriteLine($"Domain: {base.GetDomain}");
        Console.WriteLine($"Paid Methods?: {_paidMethods}");
        Console.WriteLine($"Shipment?: {_shipment}");
        Console.WriteLine($"Quantity Extra Modules: {_extraModules}");
        Console.WriteLine($"Price First Year: {base.GetPriceFirstYear}");
        Console.WriteLine($"Description: {base.GetDescription}");
        Console.WriteLine("______________");
        Console.WriteLine("______________");
    }


}
