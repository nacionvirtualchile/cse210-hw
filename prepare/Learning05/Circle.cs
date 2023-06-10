using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Circle : Shape
{ 
    private float _radio;
    public Circle(string color, float radio) : base (color)
    {
        _radio = radio;
    }

    public override float GetArea() {
        return float.Pi*(_radio * _radio);
    }


}
