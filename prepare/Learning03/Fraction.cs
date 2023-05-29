using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Fraction
{
    //Member variables
    private int _top_num;
    private int _bottom_num;


    //Constaructors
    public Fraction(){
        _top_num = 1;
        _bottom_num = 1;
    }
    public Fraction(int numerator){
        _top_num = numerator;
        _bottom_num = 1;
    }
    public Fraction(int numerator, int denominator){
        _top_num = numerator;
        _bottom_num = denominator;
    }

    
    //Setters-getters
    public int GetNumerator(){
        return _top_num;
    }
    public int GetDenominator(){
        return _bottom_num;
    }
    public int SetNumerator(int numerator){
        return _top_num = numerator;
    }
    public int SetDenominator(int denominator){
        return _bottom_num = denominator;
    }


    //Behaviors
    public string GetFractionString (){
        return _top_num.ToString()+"/"+_bottom_num.ToString();
    } 

    public double GetDecimalValue (){
        return _top_num/_bottom_num;
    } 

}
