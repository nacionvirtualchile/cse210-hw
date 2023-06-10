using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Square : Shape
{
    private float _side; 

    public Square (string color, float side) : base (color)
    {
        _side = side;
    }

    public override float GetArea() {
        return _side*_side;
    }



}
