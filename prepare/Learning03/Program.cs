using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning03 World!");

        Fraction Fraction1 = new Fraction();
        Fraction Fraction2 = new Fraction(5);
        Fraction Fraction3 = new Fraction(5,2);

        Fraction1.SetNumerator(30);
        Fraction1.SetDenominator(5);
        
        Console.WriteLine(Fraction1.GetNumerator());
        Console.WriteLine(Fraction1.GetDenominator());

        Console.WriteLine(Fraction1.GetFractionString());
        Console.WriteLine(Fraction1.GetDecimalValue());

    }




}