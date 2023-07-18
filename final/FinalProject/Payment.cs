using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Payment
{

//VARIABLES
    private int _subscriptionID;
    private DateTime _date;
    private int _amount;


//CONSTRUCTORS
    public Payment (int subscriptionID, int amount)
    {
        _subscriptionID = subscriptionID;
        _date = DateTime.Now;
        _amount = amount;
    }


//METHODS


   public void SetSubsID(int subscriptionID) {
        _subscriptionID = subscriptionID;
    }
   public void SetAmmount(int amount) {
        _amount = amount;
    }
   public void SetDate(DateTime date) {
        _date = date;
    }

    public int GetAmmount() {
        return _amount;
    }
    public DateTime GetDate() {
        return _date;
    }
    public int GetID() {
        return _subscriptionID;
    }

    public void DisplayPaymentInfo() {
        Console.Write($"Subscripion:{_subscriptionID} - ");
        Console.Write($"Date:{_date} - ");
        Console.WriteLine($"Amount:{_amount} - ");

    }




}
