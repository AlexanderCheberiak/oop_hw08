using System;

class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }
    public int GetRectangleArea()
    {
        return Width * Height;
    }
}

//квадрат наслідується від прямокутника!!!
//Тут порушений принцип Лісков, за яким підклас повинен бути
//взаємозамінним із базовим класом без порушення коректності програми.


class Square : Rectangle
{
    public override int Width
    {
        get { return base.Width; }
        set
        {
            base.Height = value;
            base.Width = value;
        }
    }
    public override int Height
    {
        get { return base.Height; }
        set
        {
            base.Height = value;
            base.Width = value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Square();
            rect.Width = 5;
            rect.Height = 10;

            Console.WriteLine(rect.GetRectangleArea());
            //Відповідь 100? Що не так???

            //Відповідь: квадрат намагається підтримувати рівність сторін,
            //хоча базовий клас прямокутника й дозволяє
            //встановлювати сторонам різні значення

            Console.ReadKey();
        }
    }
}