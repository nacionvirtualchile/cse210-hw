using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public abstract class OnlineService
{

//VARIABLES
    private string _type;
    private string _name;
    private int _domains;
    private int _basePrice;
    private int _priceFirstYear;
    private string _description;


//CONSTRUCTORS
    public OnlineService (string type, string name, int domains, int basePrice, string description){
        _type = type;
        _name = name;
        _domains = domains;
        _description = description;
        _basePrice = basePrice;
    }



//METHODS
    public void SetType(string type) {
        _type = type;
    }
    public void SetName(string name) {
        _name = name;
    }
    public void SetDomain(int domains) {
        _domains = domains;
    }
    public void SetBasePrice(int basePrice) {
        _basePrice = basePrice;
    }
    public void SetPriceFirstYear(int priceFirstYear) {
        _priceFirstYear = priceFirstYear;
    }
    public void SetDescription(string description) {
        _description = description;
    }



    public string GetTypeOfService() {
        return _type;
    }
    public string GetName() {
        return _name;
    }
    public int GetDomains() {
        return _domains;
    }
    public int GetBasePrice() {
        return _basePrice;
    }
    public int GetPriceFirstYear() {
        return _priceFirstYear;
    }
    public string GetDescription() {
        return _description;
    }



    public abstract int CalculatePriceFirstYear();
    public abstract void DisplayInfoService();
    public virtual int GetExtraModules() {
        return -1;
    }
    public virtual void SetExtraModules(int extraModules) {
    }
    public virtual int GetMailboxesQuantity() {
        return -1;
    }
    public virtual void SetMailboxesQuantity(int mailboxesQuantity) {
    }
    public virtual Boolean GetShipment() {
        return false;
    }
    public virtual void SetShipment(Boolean shipment) {
    }
    public virtual Boolean GetPaidMethods() {
        return false;
    }
    public virtual void SetPaidMethods(Boolean paidMethods) {
    }

}
