using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning05 World!");
        Square square = new Square("green", 4);
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea());     

        Rectangle rectangle = new Rectangle("blue", 4, 5);
        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.GetArea());     

        Circle circle = new Circle("black", 5);
        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.GetArea());    

        List<Shape> listOfShapes1 = new List<Shape>();
        listOfShapes1.Add(square);
        listOfShapes1.Add(rectangle);
        listOfShapes1.Add(circle);

        Console.WriteLine("----");
        Console.WriteLine("Iteration");
        Console.WriteLine("----");
        foreach (Shape shape in listOfShapes1){
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());             
        }
        Console.WriteLine("----");
        Console.WriteLine("End iteration");
        Console.WriteLine("----");

    }
}