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
    public Reference (){
        _book = "";
        _chapter = "";
        _verse = "";
        
    }

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
    
//GETTER to format the name of the reference
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

//To format the name of the reference to save the scripture to the file
    public string GetFormatNameToSave()
    {
        return $"{_book}|{_chapter}|{_verse}|";
    }

    public void SetBook(string InputBook)
    {
        _book = InputBook;
    }

    public void SetChapter(string InputChapter)
    {
        _chapter = InputChapter;
    }

        public void SetVerse(string InputVerse)
    {
        _verse = InputVerse;
    }




}