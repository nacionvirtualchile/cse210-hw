using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Shape
{
    private string _color;

    public Shape(string color){
        _color = color;
    }

    public void SetColor(string color){
        _color = color;
    } 
    public string GetColor(){
        return _color;
    } 



    public virtual float GetArea() {
        return -1;
    }



}
