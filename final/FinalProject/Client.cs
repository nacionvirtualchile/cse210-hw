using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Client
{

//VARIABLES
    private string _name;
    private int _phone;
    private string _email;
    private string _contactPerson;



//CONSTRUCTORS
    public Client (string name, int phone, string email, string contactPerson){
        _name = name;
        _phone = phone;
        _email = email;
        _contactPerson = contactPerson;
    }


//METHODS
    public void SetName(string name) {
        _name = name;
    }

    public void SetPhone(int phone) {
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

    public int GetPhone() {
        return _phone;
    }

    public string GetEmail() {
        return _email;
    }

    public string GetContact() {
        return _contactPerson;
    }


    public void DisplayClientInfo(){
        
    }



}
