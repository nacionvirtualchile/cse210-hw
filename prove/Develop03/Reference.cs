using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Reference
{
    private string _book;
    private string _chapter;
    private string _verse;
    private string _finalVerse = "";

//CONSTRUCTOR
    public Reference (string scripture){
        string[] parts = scripture.Split("|");
        _book = parts[0];
        _chapter = parts[1];
        _verse = parts[2];
        
    }

    public Reference (string scripture, string finalVerse){
        string[] parts = scripture.Split("|");
        _book = parts[0];
        _chapter = parts[1];
        _verse = parts[2];
        _finalVerse = finalVerse;
        
    }
    
//GETTER
    public string GetFormatName()
    {
        string FormatName;
        if (_finalVerse != "") {
            FormatName = $"{_book}{_chapter} {_verse}-{_finalVerse}";
        } else {
            FormatName = $"{_book}{_chapter} {_verse}";
        }
        return FormatName;
    }

}