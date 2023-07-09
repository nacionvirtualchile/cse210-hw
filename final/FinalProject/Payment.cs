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
        DateTime currentDateTime = DateTime.Now;
        _date = currentDateTime;
        _amount = amount;
    }


//METHODS


   public void SetAmmount(int amount) {
        _amount = amount;
    }


    public int GetAmmount() {
        return _amount;
    }
    public DateTime GetDate() {
        return _date;
    }
    public int GetID() {
        return _amount;
    }
}
