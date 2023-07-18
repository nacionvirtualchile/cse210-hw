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
    public Ecommerce (string type, int extraModules, string name, int domains, int basePrice, string description, Boolean paidMethods, Boolean shipment) : base (type, name, domains, basePrice, description)
    {
        _extraModules = extraModules;
        _shipment = shipment;
        _paidMethods = paidMethods;

    }



//METHODS
    public override void SetExtraModules(int extraModules) {
        _extraModules = extraModules;
    }
    public override void SetPaidMethods(Boolean paidMethods) {
        _paidMethods = paidMethods;
    }
    public override void SetShipment(Boolean shipment) {
        _shipment = shipment;
    }
    public override int GetExtraModules() {
        return _extraModules;
    }
    public override Boolean GetPaidMethods() {
        return _paidMethods;
    }
    public override Boolean GetShipment() {
        return _shipment;
    }

    public override int CalculatePriceFirstYear() {
        int calculatedPrice = base.GetBasePrice() + (35000  * _extraModules) + (15000  * base.GetDomains());
        if (_paidMethods == true){
            calculatedPrice += 35000;
        }
        if (_shipment == true){
            calculatedPrice += 35000;
        }
        base.SetPriceFirstYear(calculatedPrice);
        return calculatedPrice;
    }
    
    public override void DisplayInfoService() {
        Console.Write($"Type:{base.GetType()} - ");
        Console.Write($"Name:{base.GetName()} - ");
        Console.Write($"Domain:{base.GetDomains()} - ");
        Console.Write($"Extra Modules:{_extraModules} - ");
        Console.Write($"Paid Methods?:{_paidMethods} - ");
        Console.Write($"Shipment?:{_shipment} - ");
        Console.Write($"Base Price:{base.GetBasePrice()} - ");
        Console.WriteLine($"Price First Year:{base.GetPriceFirstYear()}");
        Console.WriteLine($"Description:{base.GetDescription()} ");
    }


}
