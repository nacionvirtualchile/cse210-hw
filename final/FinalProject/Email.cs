using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Email : OnlineService
{
    
//VARIABLES
    private int _mailboxesQuantity;


//CONSTRUCTORS
    public Email (string type, int mailboxesQuantity, string name, int domains, int basePrice, string description) : base (type, name, domains, basePrice, description)
    {
        _mailboxesQuantity = mailboxesQuantity;
    }



//METHODS
    public override void SetMailboxesQuantity(int mailboxesQuantity) {
        _mailboxesQuantity = mailboxesQuantity;
    }
    public override int GetMailboxesQuantity() {
        return _mailboxesQuantity;
    }


    public override int CalculatePriceFirstYear() {
        int calculatedPrice = base.GetBasePrice() + (7000 * _mailboxesQuantity);
        base.SetPriceFirstYear(calculatedPrice);
        return calculatedPrice;
    }
    public override void DisplayInfoService() {
        Console.Write($"Type:{base.GetType()} - ");
        Console.Write($"Name:{base.GetName()} - ");
        Console.Write($"Domains:{base.GetDomains()} - ");
        Console.Write($"Quantity of Mailboxes:{_mailboxesQuantity} - ");
        Console.Write($"Base Price:{base.GetBasePrice()} - ");
        Console.WriteLine($"Price First Year:{base.GetPriceFirstYear()}");
        Console.WriteLine($"Description:{base.GetDescription()} ");
    }




}