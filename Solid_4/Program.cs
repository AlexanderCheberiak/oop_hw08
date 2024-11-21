using System;

/*Даний інтерфейс поганий тим, що він включає занадто багато методів.
 А що, якщо наш клас товарів не може мати знижок або промокодом, або для нього немає сенсу встановлювати матеріал з 
 якого зроблений (наприклад, для книг). Таким чином, щоб не реалізовувати в кожному класі невикористовувані в ньому методи, краще 
розбити інтерфейс на кілька дрібних і кожним конкретним класом реалізовувати потрібні інтерфейси.
Перепишіть, розбивши інтерфейс на декілька інтерфейсів, керуючись принципом розділення інтерфейсу. 
Опишіть класи книжки (розмір та колір не потрібні, але потрібна ціна та знижки) та верхній одяг (колір, розмір, ціна знижка),
які реалізують притаманні їм інтерфейси.*/


// Інтерфейс для встановлення ціни
interface IPriceable
{
    void SetPrice(double price);
}

// Інтерфейс для знижок та промокодів
interface IDiscountable
{
    void ApplyDiscount(string discount);
    void ApplyPromocode(string promocode);
}

// Інтерфейс для товарів із кольором та розміром
interface IStylable
{
    void SetColor(byte color);
    void SetSize(byte size);
}

// Клас для книг
class Book : IPriceable, IDiscountable
{
    public double Price { get; private set; }
    public string Discount { get; private set; }
    public string Promocode { get; private set; }

    public void SetPrice(double price)
    {
        Price = price;
        Console.WriteLine($"Book price set to: {price}");
    }

    public void ApplyDiscount(string discount)
    {
        Discount = discount;
        Console.WriteLine($"Book discount applied: {discount}");
    }

    public void ApplyPromocode(string promocode)
    {
        Promocode = promocode;
        Console.WriteLine($"Book promocode applied: {promocode}");
    }
}

// Клас для верхнього одягу
class Outerwear : IPriceable, IDiscountable, IStylable
{
    public double Price { get; private set; }
    public string Discount { get; private set; }
    public string Promocode { get; private set; }
    public byte Color { get; private set; }
    public byte Size { get; private set; }

    public void SetPrice(double price)
    {
        Price = price;
        Console.WriteLine($"Outerwear price set to: {price}");
    }

    public void ApplyDiscount(string discount)
    {
        Discount = discount;
        Console.WriteLine($"Outerwear discount applied: {discount}");
    }

    public void ApplyPromocode(string promocode)
    {
        Promocode = promocode;
        Console.WriteLine($"Outerwear promocode applied: {promocode}");
    }

    public void SetColor(byte color)
    {
        Color = color;
        Console.WriteLine($"Outerwear color set to: {color}");
    }

    public void SetSize(byte size)
    {
        Size = size;
        Console.WriteLine($"Outerwear size set to: {size}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book = new Book();
        book.SetPrice(20.99);
        book.ApplyDiscount("10%");
        book.ApplyPromocode("BOOKSALE");

        Outerwear jacket = new Outerwear();
        jacket.SetPrice(99.99);
        jacket.SetColor(5);
        jacket.SetSize(42);
        jacket.ApplyDiscount("20%");
        jacket.ApplyPromocode("WINTER2024");

        Console.ReadKey();
    }
}
