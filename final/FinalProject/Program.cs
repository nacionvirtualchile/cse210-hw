using System;

class Program
{
    static void Main(string[] args)
    {
// THIS PROGRAM WORKS WITH 4 TXT FILES (AUTOMATICS, SO IS NOT NECESSARY WRITE THE NAME OF FILES) 
// I PREPARED THE FILES WITH SOME DATA TO TEST THE PROGRAM
// MANAGES SUBSCRIPTIONS: ABLE TO CREATE, EDIT AND LIST SUBSCRIPTIONS AND HAS 2 REPORTS ('NEXT TO COLLECT' AND 'EXPIRED SUBSCRIPTIONS') 
// BEFORE CREATE SUBSCRIPTIONS IS NECESSARY CREATE CLIENTS AND SERVICES (THERE ARE 3 KINDS: WEB, ECCOMERCE AND EMAIL) 
// PAYMENTS ARE ASSUMED TO BE IN FULL (LIKE NETFLIX FOR EXAMPLE), THERE ARE NO PARTIAL PAYMENTS.
// AND HAS THE FOLLOWING PARTS:
// - LINE 34: MAIN MENU
// - LINE 68: SERVICES MENU
// - LINE 379: CLIENTS MENU
// - LINE 515: SUBSCRIPTIONS MENU
// - LINE 732: PAYMENTS MENU
// - LINE 876: SUBSCRIPTION NEXT TO COLLECT
// - LINE 925: EXPIRED SUBSCRIPTIONS
// - LINE 1019: METHODS
// - LINE 1274: LOAD DATA WHEN PROGRAM START


        //MEMBER VARIABLES
        List<OnlineService> _listOfServices = new List<OnlineService>();
        List<Client> _listOfClients = new List<Client>();
        List<Subscription> _listOfSubscriptions = new List<Subscription>();
        List<Payment> _listOfPayments = new List<Payment>();
        int _option = 0;


        //MAIN MENU -----------------------------------
        //MAIN MENU -----------------------------------
        //MAIN MENU -----------------------------------
        Menu menu1 = new Menu();
        Console.Clear();
        Console.WriteLine("___________________");
        Console.WriteLine("___________________");
        Console.WriteLine("WELCOME TO 'SUBSCRIPTION MANAGER'");
        Console.WriteLine("By Sergio Villarroel R. ");
        Console.WriteLine("___________________");
        Console.WriteLine("___________________");
        Console.WriteLine("Press enter to start...");
        Console.ReadLine();


        //TO LOAD RECORDS (CLIENTS, SERVICES AND SUBSCRIPTION) IN MEMORY IF EXIST
        LoadData();

        while (_option != 7) //DISPLAY THE MAIN MENU
        {

            Console.Clear();
            Console.WriteLine("___________________");
            Console.WriteLine("___________________");
            Console.WriteLine("SUBSCRIPTION MANAGER - MAIN MENU");
            Console.WriteLine("___________________");
            Console.WriteLine("___________________");
            menu1.DisplayMainMenu(); 
            
            Console.WriteLine("Select an option: ");
            _option = menu1.GetChoiceFromUser(1,7);



            //SERVICES MENU -----------------------------------
            //SERVICES MENU -----------------------------------
            //SERVICES MENU -----------------------------------
            if (_option == 1) 
            {

                //SERVICES MENU - DISPLAY SERVICES MENU
                Console.Clear(); 
                Console.WriteLine("___________________");
                Console.WriteLine("SERVICES MENU");
                Console.WriteLine("___________________");           
                menu1.DisplayServicesMenu(); 
                
                Console.WriteLine("Select an option: ");
                int _optionServiceMenu = menu1.GetChoiceFromUser(1,4); 


                if (_optionServiceMenu == 1) //SERVICES MENU - CREATE A SERVICE
                {
                    Console.WriteLine("What kind of service do you want to create? (Enter a number): ");
                    Console.WriteLine("1- Web");
                    Console.WriteLine("2- Ecommerce");
                    Console.WriteLine("3- Email");
                    Console.WriteLine("Select an option: ");
                    int kindOfServiceOption = menu1.GetChoiceFromUser(1,3); 

                    if (kindOfServiceOption >= 1 || kindOfServiceOption <= 3)//COMMON INFO FOR ALL THE SEVICES
                    {
                        Console.Write("Enter the name of this service: ");
                        string nameService = menu1.GetTextFromUser();
                        Console.Write("How many domains? (1 to 99): ");
                        int howManyDomains = menu1.GetChoiceFromUser(1,99); 
                        Console.Write("Enter the Base Price for this service (the final price will be calculated later): ");
                        int basePrice = menu1.GetChoiceFromUser(1,999999999); 
                        Console.Write("Enter the description of this service: ");
                        string description = menu1.GetTextFromUser();


                        if (kindOfServiceOption == 1)//INFO FOR CREATE WEB SERVICE 
                        {
                            Console.Write("How many extra modules? (0 to 99): ");
                            int howManyExtraModules = menu1.GetChoiceFromUser(0,99); 
                            Web web1 = new Web("Web", howManyExtraModules, nameService, howManyDomains, basePrice, description);
                            web1.CalculatePriceFirstYear();
                            Console.WriteLine("___________________");
                            Console.WriteLine("Service Created with the following info:");
                            web1.DisplayInfoService();  
                            _listOfServices.Add(web1);

                        } else if (kindOfServiceOption == 2)//INFO FOR CREATE ECOMMERCE SERVICE 
                        {
                            Console.Write("How many extra modules? (0 to 99): ");
                            int howManyExtraModules = menu1.GetChoiceFromUser(0,99); 

                            Console.WriteLine("Will have Paid Methods? ");
                            Console.WriteLine("1- true");
                            Console.WriteLine("2- false");
                            Console.WriteLine("Select an option: ");
                            string paidMethods = menu1.GetChoiceFromUser(1,2).ToString();
                            Boolean paidMethods2 = false;
                            if (paidMethods == "1") 
                            {
                                paidMethods2 = true;
                            } else if (paidMethods == "2")
                            {
                                paidMethods2 = false;
                            }

                            Console.WriteLine("Will have Shipment System? ");
                            Console.WriteLine("1- true");
                            Console.WriteLine("2- false");
                            Console.WriteLine("Select an option: ");
                            string shipment = menu1.GetChoiceFromUser(1,2).ToString();
                            Boolean shipment2 = false;
                            if (shipment == "1") 
                            {
                                shipment2 = true;
                            } else if (shipment == "2")
                            {
                                shipment2 = false;
                            }

                            Ecommerce ecommerce1 = new Ecommerce("Ecommerce", howManyExtraModules, nameService, howManyDomains, basePrice, description, paidMethods2, shipment2);
                            ecommerce1.CalculatePriceFirstYear();
                            Console.WriteLine("___________________");
                            Console.WriteLine("Service Created with the following info:");
                            ecommerce1.DisplayInfoService();  
                            _listOfServices.Add(ecommerce1);        

                        } else if (kindOfServiceOption == 3)//INFO FOR CREATE EMAIL SERVICE 
                        {
                            Console.Write("How many mailboxes? (1 to 50): ");
                            int howManyMailboxes = menu1.GetChoiceFromUser(1,99); 
                            Email email = new Email("Email", howManyMailboxes, nameService, howManyDomains, basePrice, description);
                            email.CalculatePriceFirstYear();
                            Console.WriteLine("___________________");
                            Console.WriteLine("Service Created with the following info:");
                            email.DisplayInfoService();  
                            _listOfServices.Add(email);

                        }
                        
                        SaveServices();
                    }

                                 
                } else if (_optionServiceMenu == 2) //SERVICES MENU - CHANGE(EDIT) A SERVICE RECORD  
                {
                    //DISPLAY ALL SERVICES
                    int TotalOfSevices = DisplayAllServices();
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();

                    if (TotalOfSevices > 0)
                    {
                        Console.WriteLine($"Select the number of the service to edit (1 to {TotalOfSevices}): ");
                        int serviceToEdit = menu1.GetChoiceFromUser(1,TotalOfSevices); 

                        //START WITH COMMON VARIABLES
                        int count = 0;
                        foreach (OnlineService service in _listOfServices) 
                        {
                            count += 1;
                            if (count == serviceToEdit)
                            {
                                string name = service.GetName();
                                Console.WriteLine($"This is the name:{name}");
                                Console.Write("Write the new value (or Enter to keep): ");
                                name = Console.ReadLine();
                                if (name != "")
                                {
                                    service.SetName(name);
                                    Console.WriteLine("-------Successfully changed");
                                } else 
                                {
                                    Console.WriteLine("-------Nothing changed");
                                }
                                Console.WriteLine(" ");

                                int domains = service.GetDomains();
                                Console.WriteLine($"This is the quantity of domains:{domains}");
                                Console.Write("Write the new value (0 or Enter to keep): ");
                                domains = menu1.GeneralControlInputNumber();
                                if (domains != 0)
                                {
                                    service.SetDomain(domains);
                                    service.CalculatePriceFirstYear();
                                    Console.WriteLine("-------Domains (And the PriceFirstYear) Successfully changed");
                                } else 
                                {
                                    Console.WriteLine("-------Nothing changed");
                                }
                                Console.WriteLine(" ");

                                int basePrice = service.GetBasePrice();
                                Console.WriteLine($"This is the Base Price:{basePrice}");
                                Console.Write("Write the new value (0 or Enter to keep): ");
                                basePrice = menu1.GeneralControlInputNumber();
                                if (basePrice != 0)
                                {
                                    service.SetBasePrice(basePrice);
                                    service.CalculatePriceFirstYear();
                                    Console.WriteLine("-------Base Price (And the PriceFirstYear) Successfully changed");
                                } else 
                                {
                                    Console.WriteLine("-------Nothing changed");
                                }
                                Console.WriteLine(" ");

                                string description = service.GetDescription();
                                Console.WriteLine($"This is the description:{description}");
                                Console.Write("Write the new value (or Enter to keep): ");
                                description = Console.ReadLine();
                                if (description != "")
                                {
                                    service.SetDescription(description);
                                    Console.WriteLine("-------Successfully changed");
                                } else 
                                {
                                    Console.WriteLine("-------Nothing changed");
                                }
                                Console.WriteLine(" ");
                                
                                //VARIABLES ONLY FOR WEB SERVICES
                                if (service.GetTypeOfService() == "Web") 
                                {
                                    int extraModules = service.GetExtraModules();
                                    Console.WriteLine($"This is the quantity of ExtraModules:{extraModules}");
                                    Console.Write("Write the new value (0 or Enter to keep): ");
                                    extraModules = menu1.GeneralControlInputNumber();
                                    if (extraModules != 0)
                                    {
                                        service.SetExtraModules(extraModules);
                                        service.CalculatePriceFirstYear();
                                        Console.WriteLine("-------ExtraModules (And the PriceFirstYear) Successfully changed");
                                    } else 
                                    {
                                        Console.WriteLine("-------Nothing changed");
                                    }
                                    Console.WriteLine(" ");

                                //VARIABLES ONLY FOR ECOMMERCE SERVICES
                                } else if (service.GetTypeOfService() == "Ecommerce")
                                {
                                    int extraModules = service.GetExtraModules();
                                    Console.WriteLine($"This is the quantity of ExtraModules:{extraModules}");
                                    Console.Write("Write the new value (0 or Enter to keep): ");
                                    extraModules = menu1.GeneralControlInputNumber();
                                    if (extraModules != 0)
                                    {
                                        service.SetExtraModules(extraModules);
                                        service.CalculatePriceFirstYear();
                                        Console.WriteLine("-------ExtraModules (And the PriceFirstYear) Successfully changed");
                                    } else 
                                    {
                                        Console.WriteLine("-------Nothing changed");
                                    }
                                    Console.WriteLine(" ");

                                    
                                    Boolean paidMethods = service.GetPaidMethods();
                                    Console.WriteLine($"PaidMethods?:{paidMethods}");
                                    Console.WriteLine("0- or Enter to keep)");
                                    if (paidMethods)
                                    {
                                        Console.WriteLine("1- false");
                                        paidMethods = false;
                                    } else {
                                        Console.WriteLine("1- true");
                                        paidMethods = true;
                                    }
                                    int OptionPaidMethods = menu1.GeneralControlInputNumber();
                                    if (OptionPaidMethods != 0)
                                    {
                                        if (OptionPaidMethods == 1)
                                        {
                                            service.SetPaidMethods(paidMethods);
                                            service.CalculatePriceFirstYear();
                                            Console.WriteLine("-------PaidMethods (And the PriceFirstYear) Successfully changed");
                                        }
                                    } else 
                                    {
                                        Console.WriteLine("-------Nothing changed");
                                    }
                                    Console.WriteLine(" ");


                                    Boolean shipment = service.GetShipment();
                                    Console.WriteLine($"Shipment?:{shipment}");
                                    Console.WriteLine("0- or Enter to keep)");
                                    if (shipment)
                                    {
                                        Console.WriteLine("1- false");
                                        shipment = false;
                                    } else {
                                        Console.WriteLine("1- true");
                                        shipment = true;
                                    }
                                    int OptionShipment = menu1.GeneralControlInputNumber();
                                    if (OptionShipment != 0)
                                    {
                                        if (OptionShipment == 1)
                                        {
                                            service.SetShipment(shipment);
                                            service.CalculatePriceFirstYear();
                                            Console.WriteLine("-------Shipment (And the PriceFirstYear) Successfully changed");
                                        }
                                    } else 
                                    {
                                        Console.WriteLine("-------Nothing changed");
                                    }
                                    Console.WriteLine(" ");


                                } else if (service.GetTypeOfService() == "Email")
                                {
                                    int mailboxesQuantity = service.GetMailboxesQuantity();
                                    Console.WriteLine($"This is the quantity of mailboxes:{mailboxesQuantity}");
                                    Console.Write("Write the new value (0 or Enter to keep): ");
                                    mailboxesQuantity = menu1.GeneralControlInputNumber();
                                    if (mailboxesQuantity != 0)
                                    {
                                        service.SetMailboxesQuantity(mailboxesQuantity);
                                        service.CalculatePriceFirstYear();
                                        Console.WriteLine("-------MailboxesQuantity (And the PriceFirstYear) Successfully changed");
                                    } else 
                                    {
                                        Console.WriteLine("-------Nothing changed");
                                    }
                                    Console.WriteLine(" ");

                                }

                                SaveServices();

                            }
                        }

                    }


                } else if (_optionServiceMenu == 3)  //SERVICES MENU - LIST SERVICES
                {
                    int TotalOfSevices = DisplayAllServices();
                    Console.WriteLine($"Total of services: {TotalOfSevices}");
                    Console.WriteLine("Enter to continue...");
                    Console.ReadLine();
                }



                //CLIENTS MENU -----------------------------------
                //CLIENTS MENU -----------------------------------
                //CLIENTS MENU -----------------------------------
            } if (_option == 2) 
            {

                //CLIENTS MENU - DISPLAY MENU
                Console.Clear(); 
                Console.WriteLine("___________________");
                Console.WriteLine("CLIENTS MENU");
                Console.WriteLine("___________________");           
                menu1.DisplayClientsMenu(); 
                
                Console.WriteLine("Select an option: ");
                int _optionClientsMenu = menu1.GetChoiceFromUser(1,4); 

                if (_optionClientsMenu == 1) //CLIENT MENU - CREATE A CLIENT
                {
                    Console.Write("Enter the name (of the enterprise or entrepreneur): ");
                    string name = menu1.GetTextFromUser();

                    Console.Write("Enter the phone: (numbers only): ");
                    string phone = menu1.GetTextFromUser();

                    Console.Write("Enter the email: ");
                    string email = menu1.GetTextFromUser();

                    Console.Write("Enter the contact person's name: ");
                    string contactPerson = menu1.GetTextFromUser();


                    Client client = new Client(name, phone, email, contactPerson);
                    Console.WriteLine("___________________");
                    Console.WriteLine("Client Created with the following info:");
                    client.DisplayClientInfo();  
                    _listOfClients.Add(client);
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();

                    SaveClients();


                } else if (_optionClientsMenu == 2)  //CLIENT MENU - CHANGE CLIENT
                {
                    //DISPLAY ALL CLIENTS
                    int TotalOfClients = DisplayAllClients();
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();

                    if (TotalOfClients > 0)
                    {
                        Console.WriteLine($"Select the number of the client to edit (1 to {TotalOfClients}): ");
                        int clientToEdit = menu1.GetChoiceFromUser(1,TotalOfClients); 

                        int count = 0;
                        foreach (Client client in _listOfClients) 
                        {
                            count += 1;
                            if (count == clientToEdit)
                            {
                                string name = client.GetClientName();
                                Console.WriteLine($"This is the name:{name}");
                                Console.Write("Write the new value (or Enter to keep): ");
                                name = Console.ReadLine();
                                if (name != "")
                                {
                                    client.SetName(name);
                                    Console.WriteLine("-------Successfully changed");
                                } else 
                                {
                                    Console.WriteLine("-------Nothing changed");
                                }
                                Console.WriteLine(" ");

                                string phone = client.GetPhone();
                                Console.WriteLine($"This is the phone:{phone}");
                                Console.Write("Write the new value (or Enter to keep): ");
                                phone = Console.ReadLine();
                                if (phone != "")
                                {
                                    client.SetPhone(phone);
                                    Console.WriteLine("-------Successfully changed");
                                } else 
                                {
                                    Console.WriteLine("-------Nothing changed");
                                }
                                Console.WriteLine(" ");

                                string email = client.GetEmail();
                                Console.WriteLine($"This is the email:{email}");
                                Console.Write("Write the new value (or Enter to keep): ");
                                email = Console.ReadLine();
                                if (email != "")
                                {
                                    client.SetEmail(email);
                                    Console.WriteLine("-------Successfully changed");
                                } else 
                                {
                                    Console.WriteLine("-------Nothing changed");
                                }
                                Console.WriteLine(" ");

                                string contactPerson = client.GetContact();
                                Console.WriteLine($"This is the Contact Person:{contactPerson}");
                                Console.Write("Write the new value (or Enter to keep): ");
                                contactPerson = Console.ReadLine();
                                if (contactPerson != "")
                                {
                                    client.SetContact(contactPerson);
                                    Console.WriteLine("-------Successfully changed");
                                } else 
                                {
                                    Console.WriteLine("-------Nothing changed");
                                }
                                Console.WriteLine(" ");
                            
                                SaveClients();

                            }
                        }

                    }


                } else if (_optionClientsMenu == 3)  //CLIENT MENU - LIST CLIENTS
                {
                    int TotalOfClients = DisplayAllClients();
                    Console.WriteLine($"Total of clients: {TotalOfClients}");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                }





                //SUBSCRIPTIONS MENU -----------------------------------
                //SUBSCRIPTIONS MENU -----------------------------------
                //SUBSCRIPTIONS MENU -----------------------------------
            } if (_option == 3) 
            {

                //SUBSCRIPTIONS MENU - DISPLAY MENU
                Console.Clear(); 
                Console.WriteLine("___________________");
                Console.WriteLine("SUBSCRIPTION MENU");
                Console.WriteLine("___________________");           
                menu1.DisplaySubscriptionsMenu(); 
                
                Console.WriteLine("Select an option: ");
                int _optionSubscriptionMenu = menu1.GetChoiceFromUser(1,4); 

                if (_optionSubscriptionMenu == 1) //SUBSCRIPTION MENU - CREATE A SUBSCRIPTION
                {
                    
                    //CHECK IF THERE ARE CLIENTS (AT LEAST 1 IS NECESSARY TO CREATE SUBCRIPTION)
                    int countCheck1 = 0;
                    foreach (Client clientToCheck in _listOfClients)
                    {
                        countCheck1 += 1;
                    }
                    if (countCheck1 == 0){
                        Console.WriteLine("__________");
                        Console.WriteLine("__________");
                        Console.WriteLine("THERE IS NOT CLIENT YET. CREATE A CLIENT FIRST");
                        Console.WriteLine("__________");
                        Console.WriteLine("__________");
                    } 

                    //CHECK IF THERE ARE SERVICES (AT LEAST 1 IS NECESSARY TO CREATE SUBCRIPTION)
                    int countCheck2 = 0;
                    foreach (OnlineService service in _listOfServices)
                    {
                        countCheck2 += 1;
                    }
                    if (countCheck2 == 0){
                        Console.WriteLine("__________");
                        Console.WriteLine("__________");
                        Console.WriteLine("THERE IS NOT SERVICE YET. CREATE A SERVICE FIRST");
                        Console.WriteLine("__________");
                        Console.WriteLine("__________");
                    }

                    //IF THERE ARE CLIENTS AND SERVICES, IT IS ABLE TO CREATE SUBSCRIPTIONS
                    if (countCheck1 !=0 && countCheck2 != 0)
                    {
                        
                        //TO CREATE AN AUTOMATIC ID
                        int NextID = 1;
                        foreach (Subscription SubscriptionToCheck in _listOfSubscriptions) 
                        {
                            NextID += 1;
                        }                        
                        
                        
                        //TO SELECT THE CLIENT FOR THE SUBSCRIPTION
                        Console.WriteLine("Select a Client for this subscription:");
                        int TotalOfClients = DisplayAllClients();
                        Console.WriteLine($"Enter the number of the client to select (1 to {TotalOfClients}): ");
                        int clientForSubscription = menu1.GetChoiceFromUser(1,TotalOfClients); 
                        string nameClientForSubscription = "";
                        
                        int count1 = 0;
                        foreach (Client clientToCheck in _listOfClients) 
                        {
                            count1 += 1;
                            if (count1 == clientForSubscription)
                            { 
                                nameClientForSubscription = clientToCheck.GetClientName(); 
                            }
                        }

                        //TO SELECT THE SERVICE name FOR THE SUBSCRIPTION AND ITS amountFirstYear
                        Console.WriteLine("Select a Service for this subscription:");
                        int TotalOfServices = DisplayAllServices();
                        Console.WriteLine($"Enter the number of the Service to select (1 to {TotalOfServices}): ");
                        int serviceForSubscription = menu1.GetChoiceFromUser(1,TotalOfServices); 
                        string nameServiceForSubscription = "";
                        int amountFirstYearServiceForSubscription = 0;
                        
                        int count2 = 0;
                        foreach (OnlineService ServiceToCheck in _listOfServices) 
                        {
                            count2 += 1;
                            if (count2 == serviceForSubscription)
                            { 
                                nameServiceForSubscription = ServiceToCheck.GetName(); 
                                amountFirstYearServiceForSubscription = ServiceToCheck.GetPriceFirstYear();
                            }
                        }


                        //TO ASK FOR THE PRICE OF NEXT YEARS
                        Console.Write("Enter the Amount for Next Years: ");
                        int amountNextYears = menu1.GeneralControlInputNumber();


                        Subscription subscription = new Subscription(NextID, nameClientForSubscription, nameServiceForSubscription, amountFirstYearServiceForSubscription, amountNextYears);
                        Console.WriteLine("___________________");
                        Console.WriteLine("Subscription Created with the following info:");
                        subscription.DisplaySubscriptionInfo();  
                        _listOfSubscriptions.Add(subscription);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();

                        SaveSubscription();

                    }
                    

                } else if (_optionSubscriptionMenu == 2)  //SUBSCRIPTION MENU - CHANGE SUBSCRIPTION
                {
                    //DISPLAY ALL SUBSCRIPTIONS
                    int TotalOfSubscriptions = DisplayAllSubscriptions();
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();

                    if (TotalOfSubscriptions > 0)
                    {
                        Console.WriteLine($"Select the number of the Subscription to edit (1 to {TotalOfSubscriptions}): ");
                        int SubsToEdit = menu1.GetChoiceFromUser(1,TotalOfSubscriptions); 

                        int count = 0;
                        foreach (Subscription subscription in _listOfSubscriptions) 
                        {
                            count += 1;
                            if (count == SubsToEdit)
                            {
                                //TO CHANGE THE CLIENT FOR THE SUBSCRIPTION
                                string client = subscription.GetClient();
                            
                                int TotalOfClients = DisplayAllClients();
                                Console.WriteLine($"(Current client:{client}) Enter the number of the client to select (1 to {TotalOfClients}): ");
                                int clientForSubscription = menu1.GetChoiceFromUser(1,TotalOfClients); 
                                string nameClientForSubscription = "";
                                
                                int count1 = 0;
                                foreach (Client clientToCheck in _listOfClients) 
                                {
                                    count1 += 1;
                                    if (count1 == clientForSubscription)
                                    { 
                                        nameClientForSubscription = clientToCheck.GetClientName(); 
                                        subscription.SetClient(nameClientForSubscription);
                                        Console.WriteLine("-------Successfully changed");
                                        Console.WriteLine(" ");
                                    }
                                }


                                //TO CHANGE THE SERVICE FOR THE SUBSCRIPTION (Name and Price Forst Year)
                                string service = subscription.GetService();
                            
                                int TotalOfService = DisplayAllServices();
                                Console.WriteLine($"(Current service:{service}) Enter the number of the service to select (1 to {TotalOfService}): ");
                                int serviceForSubscription = menu1.GetChoiceFromUser(1,TotalOfService); 
                                string nameServiceForSubscription = "";
                                int amountFirstYearServiceForSubscription = 0;
                                
                                int count2 = 0;
                                foreach (OnlineService serviceToCheck in _listOfServices) 
                                {
                                    count2 += 1;
                                    if (count2 == serviceForSubscription)
                                    { 
                                        nameServiceForSubscription = serviceToCheck.GetName(); 
                                        subscription.SetService(nameServiceForSubscription);
                                        amountFirstYearServiceForSubscription = serviceToCheck.GetPriceFirstYear();
                                        subscription.SetAmountFirstYear(amountFirstYearServiceForSubscription);
                                        Console.WriteLine("-------Successfully changed");
                                        Console.WriteLine(" ");
                                    }
                                }


                                int amountNextYears = subscription.GetAmountNextYears();
                                Console.WriteLine($"This is the Amount Next Years:{amountNextYears}");
                                Console.Write("Write the new value (or Enter to keep): ");
                                amountNextYears = menu1.GeneralControlInputNumber();
                                if (amountNextYears != 0)
                                {
                                    subscription.SetAmountNextYears(amountNextYears);
                                    Console.WriteLine("-------Successfully changed");
                                } else 
                                {
                                    Console.WriteLine("-------Nothing changed");
                                }
                                Console.WriteLine(" ");

                            
                                SaveSubscription();

                            }
                        }

                    }


                } else if (_optionSubscriptionMenu == 3)  //SUBSCRIPTION MENU - LIST SUBSCRIPTIONS
                {
                    int TotalOfSubscriptions = DisplayAllSubscriptions();
                    Console.WriteLine($"Total of Subscriptions: {TotalOfSubscriptions}");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();
                }






             

                //PAYMENTS MENU -----------------------------------
                //PAYMENTS MENU -----------------------------------
                //PAYMENTS MENU -----------------------------------
            } if (_option == 4) 
            {


                //PAYMENTS MENU - DISPLAY MENU
                Console.Clear(); 
                Console.WriteLine("___________________");
                Console.WriteLine("PAYMENTS MENU");
                Console.WriteLine("___________________");           
                menu1.DisplayPaymentsMenu(); 
                
                Console.WriteLine("Select an option: ");
                int _optionPaymentsMenu = menu1.GetChoiceFromUser(1,4); 

                if (_optionPaymentsMenu == 1) //PAYMENTS MENU - CREATE A PAYMENT
                {
                    
                    //CHECK IF THERE ARE SUBSCRIPTIONS (AT LEAST 1 IS NECESSARY TO CREATE A PAYMENT)
                    int countCheck1 = 0;
                    foreach (Subscription SubsToCheck in _listOfSubscriptions)
                    {
                        countCheck1 += 1;
                    }
                    if (countCheck1 == 0){
                        Console.WriteLine("__________");
                        Console.WriteLine("__________");
                        Console.WriteLine("THERE IS NOT SUBSCRIPTION YET. CREATE A SUBSCRIPTION FIRST");
                        Console.WriteLine("__________");
                        Console.WriteLine("__________");
                    } else {

                        //TO SELECT THE SUBSCRIPTION FOR THE PAYMENT
                        Console.WriteLine("Select a Subscription for this payment:");
                        int TotalOfSubscription = DisplayAllSubscriptions();
                        Console.WriteLine($"Enter the number of the Subscription to select (1 to {TotalOfSubscription}): ");
                        int subscriptionForPayment = menu1.GetChoiceFromUser(1,TotalOfSubscription); 
                        int subIDForPayment = 0;
                        
                        int count1 = 0;
                        foreach (Subscription SubsToCheck in _listOfSubscriptions) 
                        {
                            count1 += 1;
                            if (count1 == subscriptionForPayment)
                            { 
                                subIDForPayment = SubsToCheck.GetID(); 
                            }
                        }

                        //TO ASK FOR THE AMOUNT OF THE PAYMENT
                        Console.Write("Enter the Amount of this payment: ");
                        int amountPayment = menu1.GeneralControlInputNumber();


                        Payment payment = new Payment(subIDForPayment, amountPayment);
                        Console.WriteLine("___________________");
                        Console.WriteLine("Payment recorded with the following info:");
                        payment.DisplayPaymentInfo();  
                        _listOfPayments.Add(payment);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();

                        SavePayments();


                    }

                } else if (_optionPaymentsMenu == 2) //PAYMENTS MENU - CHANGE A PAYMENT
                {

                    //DISPLAY ALL PAYMENTS
                    int TotalOfPayments = DisplayAllPayments();
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();

                    if (TotalOfPayments > 0)
                    {
                        Console.WriteLine($"Select the number of the Payment to edit (1 to {TotalOfPayments}): ");
                        int PaymentToEdit = menu1.GetChoiceFromUser(1,TotalOfPayments); 

                        int count = 0;
                        foreach (Payment payment in _listOfPayments) 
                        {
                            count += 1;
                            if (count == PaymentToEdit)
                            {
                                //TO CHANGE THE SUBSCRIPTION FOR THE PAYMENT
                                int subscription = payment.GetID();
                                int TotalOfSubs = DisplayAllSubscriptions();
                                Console.WriteLine($"(Current Subscription:{subscription}) Enter the number of the subscription to select (1 to {TotalOfSubs}): ");
                                int SubsForPayment = menu1.GetChoiceFromUser(1,TotalOfSubs); 
                                int subIDForPayment = 0;
                                
                                int count1 = 0;
                                foreach (Subscription subsToCheck in _listOfSubscriptions) 
                                {
                                    count1 += 1;
                                    if (count1 == SubsForPayment)
                                    { 
                                        subIDForPayment = subsToCheck.GetID(); 
                                        payment.SetSubsID(subIDForPayment);
                                        Console.WriteLine("-------Successfully changed");
                                        Console.WriteLine(" ");
                                    }
                                }


                                //TO CHANGE THE AMOUNT OF PAYMENT
                                int amountPayment = payment.GetAmmount();
                                Console.WriteLine($"This is the Amount of this payment:{amountPayment}");
                                Console.Write("Write the new value (or Enter to keep): ");
                                amountPayment = menu1.GeneralControlInputNumber();
                                if (amountPayment != 0)
                                {
                                    payment.SetAmmount(amountPayment);
                                    Console.WriteLine("-------Successfully changed");
                                } else 
                                {
                                    Console.WriteLine("-------Nothing changed");
                                }
                                Console.WriteLine(" ");

                            
                                SavePayments();

                            }
                        }

                    }


                } else if (_optionPaymentsMenu == 3) //PAYMENTS MENU - LIST PAYMENTS
                {
                    int TotalOfPayments = DisplayAllPayments();
                    Console.WriteLine($"Total of Paymentss: {TotalOfPayments}");
                    Console.WriteLine("Enter to continue");
                    Console.ReadLine();

                }



                //SUBSCRIPTION NEXT TO COLLECT -----------------------------------
                //SUBSCRIPTION NEXT TO COLLECT -----------------------------------
                //SUBSCRIPTION NEXT TO COLLECT -----------------------------------
            } if (_option == 5) 
            {

                Console.WriteLine("__________");
                Console.WriteLine("__________");
                Console.WriteLine("NEXT SUBSCRIPTIONS TO COLLECT");
                Console.WriteLine("The following Subscriptions expire in the next 60 days:");
                Console.WriteLine("__________");
                
                int count = 0;
                
                foreach (Subscription subscription in _listOfSubscriptions)
                {

                    //ORIGINAL DATE WHEN SUBSCRIPTION STARTED
                    DateTime dateSubscription = subscription.GetDate();

                    //DATE OF THE PRESENT YEAR WHEN SUBSCRIPTION MUST BE COLLECTED
                    DateTime dateToCollect = DateTime.Parse($"{dateSubscription.Day}-{dateSubscription.Month}-{DateTime.Now.Year}");
                    
                    //IF DAY TO COLLECT IS BIGGER THAN TODAY, IS ON TIME 
                    if (dateToCollect > DateTime.Now)
                    {
                        var timeToCollect = (dateToCollect - DateTime.Now).TotalDays;
                        
                        //IF DAY TO COLLECT IS NEXT 60 DAYS, THE PROGRAM ALERTS SHOWING THE SUSBCRIPTION 
                        if (timeToCollect < 60)
                        {
                            subscription.DisplaySubscriptionInfo();
                            Console.WriteLine($"The ammount to collect is: {subscription.GetAmountNextYears()}");
                            Console.WriteLine("__________");
                            count += 1;
                        }
                    }

                }

                if (count == 0)
                {
                    Console.WriteLine("None");
                }   

                Console.ReadLine();



                //EXPIRED SUBSCRIPTIONS -----------------------------------
                //EXPIRED SUBSCRIPTIONS -----------------------------------
                //EXPIRED SUBSCRIPTIONS -----------------------------------
            } if (_option == 6) 
            {
                

                Console.WriteLine("__________");
                Console.WriteLine("__________");
                Console.WriteLine("EXPIRED SUBSCRIPTIONS");
                Console.WriteLine("The following Subscriptions already expired this year");
                Console.WriteLine("or have a year without payment");
                Console.WriteLine("__________");

                int count = 0;

                foreach (Subscription subscription in _listOfSubscriptions)
                {
                    Boolean pendingDebt = true;

                    //ORIGINAL DATE WHEN SUBSCRIPTION STARTED
                    DateTime dateSubscription = subscription.GetDate();

                    //DATE OF THE PRESENT YEAR WHEN SUBSCRIPTION MUST BE COLLECTED
                    DateTime dateToCheck = DateTime.Parse($"{dateSubscription.Day}-{dateSubscription.Month}-{DateTime.Now.Year}");
                    

                    var allTheDays = (DateTime.Now - dateSubscription).TotalDays;
                    double allTheYears = Math.Truncate(allTheDays/365);
                    double countPayments = 0;

                    //IF DAY TO COLLECT IS SMALLER THAN TODAY, COULD BE EXPIRED 
                    if (dateToCheck < DateTime.Now)
                    {

                        //I CHECK ITS PAYMENTS
                        foreach (Payment payment in _listOfPayments)
                        {
                            if (payment.GetID() == subscription.GetID())
                            {
                                countPayments += 1;
                                if (payment.GetDate() > dateToCheck)
                                {
                                    pendingDebt = false;
                                }

                            }
                            
                        }


                    } else 
                    {
                        pendingDebt = false;
                    }

                    if (pendingDebt == true)
                    {
                        subscription.DisplaySubscriptionInfo();
                        Console.WriteLine($"The ammount to collect is: {subscription.GetAmountNextYears()}");
                        Console.WriteLine("__________");
                        count += 1;
                    }

                    if (allTheYears > countPayments)
                    {
                        subscription.DisplaySubscriptionInfo();
                        Console.WriteLine($"Years of this subscription: {allTheYears}");
                        Console.WriteLine($"Years Paid: {countPayments}");
                        count += 1;
                    }


                }   

                if (count == 0)
                {
                    Console.WriteLine("None");
                }   

                Console.ReadLine();



            } 




        }




        //METHODS ----------------------------------------------------------------------
        //METHODS ----------------------------------------------------------------------
        //METHODS ----------------------------------------------------------------------

        //PREPARE LIST OF SERVICES IN MEMORY TO SAVE IN A FILE
        List<String> GenerateListOfServicesToSAVE()
        {
            List<String> listOfSevicesNow = new List<String>();

            string type = "";
            string name = "";
            int domains = 0;
            int basePrice = 0;
            int priceFirstYear = 0;
            string description = "";
            int extraModules = 0;
            int mailboxesQuantity = 0;
            Boolean paidMethods, shipment;
            foreach (OnlineService service in _listOfServices){
                type = service.GetTypeOfService();
                name = service.GetName();
                domains = service.GetDomains();
                basePrice = service.GetBasePrice();
                priceFirstYear = service.GetPriceFirstYear();
                description = service.GetDescription();
            

                if (type == "Web") {
                    extraModules = service.GetExtraModules();
                    listOfSevicesNow.Add($"{type}|{extraModules}|{name}|{domains}|{basePrice}|{description}|{priceFirstYear}"); 
                } else if (type == "Ecommerce")  {
                    extraModules = service.GetExtraModules();
                    paidMethods = service.GetPaidMethods();
                    shipment = service.GetShipment();
                    listOfSevicesNow.Add($"{type}|{extraModules}|{name}|{domains}|{basePrice}|{description}|{priceFirstYear}|{paidMethods}|{shipment}");
                } else if (type == "Email")  {
                    mailboxesQuantity = service.GetMailboxesQuantity();
                    listOfSevicesNow.Add($"{type}|{mailboxesQuantity}|{name}|{domains}|{basePrice}|{description}|{priceFirstYear}");
                }

            }
            
            return listOfSevicesNow;

        }


        //SAVE SERVICES - New or changes
        void SaveServices()
        {
            List<String> ListOfServicesNow = GenerateListOfServicesToSAVE();

            int count = 0;
            foreach (String serviceNow in ListOfServicesNow)
            {
                count += 1;
            }
            if (count == 0){
                Console.WriteLine("__________");
                Console.WriteLine("__________");
                Console.WriteLine("THERE IS NOT SERVICES YET. CREATE A SERVICE FIRST");
                Console.WriteLine("__________");
                Console.WriteLine("__________");
            }

            using (StreamWriter outputFile = new StreamWriter("ListOfServices.txt"))
            {
                foreach (String serviceNow in ListOfServicesNow)
                {
                    outputFile.WriteLine(serviceNow);   
                }     

            }

        }

        //DISPLAY ALL THE SERVICES 
        int DisplayAllServices()
        {
            
            int count = 0;
            foreach (OnlineService service in _listOfServices)
            {
                count += 1;
            }
            if (count == 0){
                Console.WriteLine("__________");
                Console.WriteLine("__________");
                Console.WriteLine("THERE IS NOT SERVICES YET. CREATE A SERVICE FIRST");
                Console.WriteLine("__________");
                Console.WriteLine("__________");
            } else {
                int count2 = 0;
                foreach (OnlineService service in _listOfServices)
                {
                    count2 += 1;
                    Console.WriteLine("______________");
                    Console.Write(count2 + " - ");
                    service.DisplayInfoService();
                }  
            }
            Console.WriteLine("__________");
            return count;
        }



        //SAVE SERVICES - New or changes
        void SaveClients()
        {
            using (StreamWriter outputFile = new StreamWriter("ListOfClients.txt"))
            {
                foreach (Client client in _listOfClients)
                {
                    string clientName = client.GetClientName();
                    string clientPhone = client.GetPhone();
                    string clientEmail = client.GetEmail();
                    string contactPerson = client.GetContact();

                    outputFile.WriteLine(($"{clientName}|{clientPhone}|{clientEmail}|{contactPerson}"));   
                }     

            }

        }

        //DISPLAY ALL THE CLIENTS 
        int DisplayAllClients()
        {
            int count = 0;
            foreach (Client client in _listOfClients)
            {
                count += 1;
            }
            if (count == 0){
                Console.WriteLine("__________");
                Console.WriteLine("__________");
                Console.WriteLine("THERE IS NOT CLIENTS YET. CREATE A CLIENT FIRST");
                Console.WriteLine("__________");
                Console.WriteLine("__________");
            } else {
                int count2 = 0;
                foreach (Client client in _listOfClients)
                {
                    count2 += 1;
                    Console.WriteLine("______________");
                    Console.Write(count2 + " - ");
                    client.DisplayClientInfo();
                }  
            }
            Console.WriteLine("__________");
            return count;
        }



        //SAVE SUBSCRIPTIONS - New or changes
        void SaveSubscription()
        {
            using (StreamWriter outputFile = new StreamWriter("ListOfSubscriptions.txt"))
            {
                foreach (Subscription subscription in _listOfSubscriptions)
                {
                    int subID = subscription.GetID();
                    string subClient = subscription.GetClient();
                    string subService = subscription.GetService();
                    int subPriceFirstYear = subscription.GetAmountFirstYear();
                    int subPriceNextYears = subscription.GetAmountNextYears();
                    DateTime dateSubscription = subscription.GetDate();

                    outputFile.WriteLine(($"{subID}|{subClient}|{subService}|{subPriceFirstYear}|{subPriceNextYears}|{dateSubscription}"));   
                }     

            }

        }

        //DISPLAY ALL THE CLIENTS 
        int DisplayAllSubscriptions()
        {
            int count = 0;
            foreach (Subscription subscription in _listOfSubscriptions)
            {
                count += 1;
            }
            if (count == 0){
                Console.WriteLine("__________");
                Console.WriteLine("__________");
                Console.WriteLine("THERE IS NOT SUBSCRIPTION YET.");
                Console.WriteLine("__________");
                Console.WriteLine("__________");
            } else {
                int count2 = 0;
                foreach (Subscription subscription in _listOfSubscriptions)
                {
                    count2 += 1;
                    Console.WriteLine("______________");
                    Console.Write(count2 + " - ");
                    subscription.DisplaySubscriptionInfo();
                }  
            }
            Console.WriteLine("__________");
            return count;
        }



        //SAVE PAYMENTS - New or changes
        void SavePayments()
        {
            using (StreamWriter outputFile = new StreamWriter("ListOfPayments.txt"))
            {
                foreach (Payment payment in _listOfPayments)
                {
                    int IdSubs = payment.GetID();
                    DateTime date = payment.GetDate();
                    int amount = payment.GetAmmount();

                    outputFile.WriteLine(($"{IdSubs}|{date}|{amount}"));   
                }     

            }

        }

        //DISPLAY ALL THE PAYMENTS
        int DisplayAllPayments()
        {
            int count = 0;
            foreach (Payment payment in _listOfPayments)
            {
                count += 1;
            }
            if (count == 0){
                Console.WriteLine("__________");
                Console.WriteLine("__________");
                Console.WriteLine("THERE IS NOT PAYMENT YET.");
                Console.WriteLine("__________");
                Console.WriteLine("__________");
            } else {
                int count2 = 0;
                foreach (Payment payment  in _listOfPayments)
                {
                    count2 += 1;
                    Console.WriteLine("______________");
                    Console.Write(count2 + " - ");
                    payment.DisplayPaymentInfo();
                }  
            }
            Console.WriteLine("__________");
            return count;
        }



        //LOAD DATA WHEN PROGRAM START ---------------------------------------
        //LOAD DATA WHEN PROGRAM START ---------------------------------------
        //LOAD DATA WHEN PROGRAM START ---------------------------------------
        void LoadData()
        { 
            //SERVICES - LOAD FROM FILE
            string filename1 = "ListOfServices.txt";
            string[] lines1 = System.IO.File.ReadAllLines(filename1);
            int countOfRegisters1 = 0;

            _listOfServices.Clear();
            foreach (string line in lines1)
            {
                countOfRegisters1 += 1;
                string[] parts = line.Split("|");

                if (parts[0] == "Web"){
                    Web web = new Web(parts[0], int.Parse(parts[1]), parts[2], int.Parse(parts[3]), int.Parse(parts[4]), parts[5]);
                    web.SetPriceFirstYear(int.Parse(parts[6]));
                    _listOfServices.Add(web);

                } else if (parts[0] == "Ecommerce"){
                    Ecommerce ecommerce = new Ecommerce(parts[0], int.Parse(parts[1]), parts[2], int.Parse(parts[3]), int.Parse(parts[4]), parts[5], Boolean.Parse(parts[7]), Boolean.Parse(parts[8]));
                    ecommerce.SetPriceFirstYear(int.Parse(parts[6]));
                    _listOfServices.Add(ecommerce);

                } else if (parts[0] == "Email"){
                    Email email = new Email(parts[0], int.Parse(parts[1]), parts[2], int.Parse(parts[3]), int.Parse(parts[4]), parts[5]);
                    email.SetPriceFirstYear(int.Parse(parts[6]));
                    _listOfServices.Add(email);
                }

            }
            if (countOfRegisters1 == 0)
            {
                Console.WriteLine("__________");
                Console.WriteLine("WARNING: You don't have SERVICES records yet. You need one to create a subscription");
                Console.WriteLine("__________");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                
            }

            //CLIENTS - LOAD FROM FILE
            string filename2 = "ListOfClients.txt";
            string[] lines2 = System.IO.File.ReadAllLines(filename2);

            _listOfClients.Clear();
            int countOfRegisters2 = 0;
            foreach (string line in lines2)
            {
                countOfRegisters2 += 1;
                string[] parts = line.Split("|");

                Client client = new Client(parts[0], parts[1], parts[2], parts[3]);
                _listOfClients.Add(client);

            }
            if (countOfRegisters2 == 0)
            {
                Console.WriteLine("__________");
                Console.WriteLine("WARNING: You don't have CLIENTS records yet. You need one to create a subscription");
                Console.WriteLine("__________");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                
            }        


            //SUBSCRIPTION - LOAD FROM FILE
            string filename3 = "ListOfSubscriptions.txt";
            string[] lines3 = System.IO.File.ReadAllLines(filename3);

            _listOfSubscriptions.Clear();
            int countOfRegisters3 = 0;
            foreach (string line in lines3)
            {
                countOfRegisters3 += 1;
                string[] parts = line.Split("|");

                Subscription subscription = new Subscription(int.Parse(parts[0]), parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]));
                subscription.SetDate(DateTime.Parse(parts[5]));
                _listOfSubscriptions.Add(subscription);

            }


            //PAYMENT - LOAD FROM FILE
            string filename4 = "ListOfPayments.txt";
            string[] lines4 = System.IO.File.ReadAllLines(filename4);

            _listOfPayments.Clear();
            int countOfRegisters4 = 0;
            foreach (string line in lines4)
            {
                countOfRegisters4 += 1;
                string[] parts = line.Split("|");

                Payment payment = new Payment(int.Parse(parts[0]), int.Parse(parts[2]));
                payment.SetDate(DateTime.Parse(parts[1]));
                _listOfPayments.Add(payment);

            }


        }



    }

}