using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO; 


public class Scripture
{
    private string[] _scriptures;
    private string _name;
    private string _text;


//CONSTRUCTOR
    public Scripture (){

        _scriptures = System.IO.File.ReadAllLines("Scriptures.txt");
        int _randomNumber = new Random().Next(_scriptures.Length);
        //Console.WriteLine($"_randomNumber {_randomNumber}");

        int Count = 0;
        foreach (String scripture in _scriptures)
        {
            if (Count == _randomNumber)
            {
                Reference reference = new Reference(scripture);
                _name = reference.GetFormatName();
                string[] parts = scripture.Split("|");
                _text = parts[3];

                //Console.WriteLine($"{_name} {_text}");
            
            }
            Count += 1;

        }

    }


    public string GetNameScripture()
    {
        return _name;
    }

    public string GetTextScripture()
    {
        return _text;
    }



}
