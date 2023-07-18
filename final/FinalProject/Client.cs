using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Client
{

//VARIABLES
    private string _name;
    private string _phone;
    private string _email;
    private string _contactPerson;



//CONSTRUCTORS
    public Client (string name, string phone, string email, string contactPerson){
        _name = name;
        _phone = phone;
        _email = email;
        _contactPerson = contactPerson;
    }


//METHODS
    public void SetName(string name) {
        _name = name;
    }

    public void SetPhone(string phone) {
        _phone = phone;
    }

    public void SetEmail(string email) {
        _email = email;
    }

    public void SetContact(string person) {
        _contactPerson = person;
    }


    public string GetClientName() {
        return _name;
    }

    public string GetPhone() {
        return _phone;
    }

    public string GetEmail() {
        return _email;
    }

    public string GetContact() {
        return _contactPerson;
    }


    public void DisplayClientInfo(){
        Console.Write($"Name:{_name} - ");
        Console.Write($"Phone:{_phone} - ");
        Console.Write($"Email:{_email} - ");
        Console.WriteLine($"Contact Person:{_contactPerson}");
    }



}
