using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public abstract class OnlineService
{

//VARIABLES
    private string _name;
    private string _domain;
    private int _priceFirstYear;
    private string _description;


//CONSTRUCTORS
    public OnlineService (string name, string domain, string description){
        _name = name;
        _domain = domain;
        _description = description;
    }



//METHODS
    public void SetName(string name) {
        _name = name;
    }
    public void SetDomain(string domain) {
        _domain = domain;
    }
    public void SetPriceFirstYear(int priceFirstYear) {
        _priceFirstYear = priceFirstYear;
    }
    public void SetDescription(string description) {
        _description = description;
    }


    public string GetName() {
        return _name;
    }
    public string GetDomain() {
        return _domain;
    }
    public int GetPriceFirstYear() {
        return _priceFirstYear;
    }
    public string GetDescription() {
        return _description;
    }



    public abstract int CalculatePriceFirstYear();
    public abstract void DisplayInfoService();




}
