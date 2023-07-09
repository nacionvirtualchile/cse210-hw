using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Email : OnlineService
{
    
//VARIABLES
    private int _mailboxesQuantity;


//CONSTRUCTORS
    public Email (int mailboxesQuantity, string name, string domain, int priceFirstYear, string description) : base (name, domain, description)
    {
        _mailboxesQuantity = mailboxesQuantity;
    }



//METHODS
    public void SetMailboxesQuantity(int mailboxesQuantity) {
        _mailboxesQuantity = mailboxesQuantity;
    }
    public int GetMailboxesQuantity() {
        return _mailboxesQuantity;
    }


    public override int CalculatePriceFirstYear() {
        int calculatedPrice = base.GetPriceFirstYear() * _mailboxesQuantity;
        base.SetPriceFirstYear(calculatedPrice);
        return calculatedPrice;
    }
    public override void DisplayInfoService() {
        Console.WriteLine("______________");
        Console.WriteLine("______________");
        Console.WriteLine("DISPLAY EMAIL SERVICE");
        Console.WriteLine($"Domain: {base.GetDomain}");
        Console.WriteLine($"Quantity of Mailboxes: {_mailboxesQuantity}");
        Console.WriteLine($"Price First Year: {base.GetPriceFirstYear}");
        Console.WriteLine($"Description: {base.GetDescription}");
        Console.WriteLine("______________");
        Console.WriteLine("______________");
    }




}