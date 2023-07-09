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
    private string _date;
    private int _amountFirstYear;
    private int _amountNextYears;
    private int _pendingDebt;


//CONSTRUCTORS
    public Subscription (string client, string service, int amountFirstYear, int amountNextYears)
    {
        _client = client;
        _service = service;
        _amountFirstYear = amountFirstYear;
        _amountNextYears = amountNextYears;
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
   public void SetDate(string date) {
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
    public string GetDate() {
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
        Console.WriteLine("______________");
        Console.WriteLine("______________");
        Console.WriteLine("DISPLAY SUSCRIPTION");
        Console.WriteLine($"ID: {_ID}");
        Console.WriteLine($"Client: {_client}");
        Console.WriteLine($"Service: {_service}");
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Price First Year: {_amountFirstYear}");
        Console.WriteLine($"Price Next Years: {_amountNextYears}");
        Console.WriteLine($"Pending Debt: {_pendingDebt}");
        Console.WriteLine("______________");
        Console.WriteLine("______________");
    }


    public int CheckTotalPayment() {
        return -1;
    }


}
