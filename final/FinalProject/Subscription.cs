using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Subscription
{

//VARIABLES
    private int _ID;
    private string _client;
    private string _service;
    private DateTime _date;
    private int _amountFirstYear;
    private int _amountNextYears;
    private int _pendingDebt;


//CONSTRUCTORS
    public Subscription (int ID, string client, string service, int amountFirstYear, int amountNextYears)
    {
        _client = client;
        _service = service;
        _amountFirstYear = amountFirstYear;
        _amountNextYears = amountNextYears;
        _date = DateTime.Now;
        _ID = ID;


    }

//METHODS
    public void SetID(int id) {
        _ID = id;
    }
    public void SetClient(string client) {
        _client = client;
    }
    public void SetService(string service) {
        _service = service;
    }
   public void SetDate(DateTime date) {
        _date = date;
    }
   public void SetAmountFirstYear(int amount) {
        _amountFirstYear = amount;
    }
   public void SetAmountNextYears(int amount) {
        _amountNextYears = amount;
    }
   public void SetPendingDebt(int amount) {
        _pendingDebt = amount;
    }


    public int GetID() {
        return _ID;
    }
    public string GetClient() {
        return _client;
    }
    public string GetService() {
        return _service;
    }
    public DateTime GetDate() {
        return _date;
    }
    public int GetAmountFirstYear() {
        return _amountFirstYear;
    }
    public int GetAmountNextYears() {
        return _amountNextYears;
    }
    public int GetPendingDebt() {
        return _pendingDebt;
    }


    public void DisplaySubscriptionInfo() {
        Console.Write($"ID:{_ID} - ");
        Console.Write($"Client:{_client} - ");
        Console.Write($"Service:{_service} - ");
        Console.Write($"Date:{_date} - ");
        Console.Write($"Price First Year:{_amountFirstYear} - ");
        Console.WriteLine($"Price Next Years:{_amountNextYears}");

    }


    public int CheckTotalPayment() {
        return -1;
    }


}
