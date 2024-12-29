Console.WriteLine("Select a number:");
Console.WriteLine("1-Custom Arrow:");
Console.WriteLine("2-The Elite Arrow:");
Console.WriteLine("3-The Beginner Arrow:");
Console.WriteLine("4-The Marksman Arrow");

string input = Console.ReadLine();

switch (input)
{
    case "1":
        Arrow arrow = GetArrow();
        Console.WriteLine($"That arrow costs {arrow.GetCost()} gold.");
        break;
    case "2":
        arrow = GetElite();
        Console.WriteLine($"That arrow costs {arrow.GetCost()} gold.");
        break;
    case "3":
        arrow = GetBeginner();
        Console.WriteLine($"That arrow costs {arrow.GetCost()} gold.");
        break;
    case "4":
        arrow = GetMarksman();
        Console.WriteLine($"That arrow costs {arrow.GetCost()} gold.");
        break;
}

Console.WriteLine("Press any key to close the program.");
Console.ReadKey();

Arrow GetArrow()
{
    Arrowhead arrowhead = GetArrowheadType();
    Fletching fletching = GetFletchingType();
    float length = GetLength();

    return new Arrow(arrowhead, fletching, length);
}

Arrow GetElite()
{
    return new Arrow(Arrowhead.Steel, Fletching.Plastic, 95);
}

Arrow GetBeginner()
{
    return new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 75);
}

Arrow GetMarksman()
{
    return new Arrow(Arrowhead.Steel, Fletching.GooseFeathers, 65);
}

Arrowhead GetArrowheadType()
{
    Console.Write("Arrowhead type (steel, wood, obsidian): ");
    string input = Console.ReadLine();
    return input switch
    {
        "steel" => Arrowhead.Steel,
        "wood" => Arrowhead.Wood,
        "obsidian" => Arrowhead.Obsidian
    };
}

Fletching GetFletchingType()
{
    Console.Write("Fletching type (plastic, turkey feather, goose feather): ");
    string input = Console.ReadLine();
    return input switch
    {
        "plastic" => Fletching.Plastic,
        "turkey feather" => Fletching.TurkeyFeathers,
        "goose feather" => Fletching.GooseFeathers
    };
}

float GetLength()
{
    float length = 0;

    while (length < 60 || length > 100)
    {
        Console.Write("Arrow length (between 60 and 100): ");
        length = Convert.ToSingle(Console.ReadLine());
    }

    return length;
}

class Arrow
{
    private Arrowhead _arrowhead;
    private Fletching _fletching;
    private float _length;

    public Arrowhead GetArrowhead() => _arrowhead;
    public Fletching GetFletching() => _fletching;
    public float GetLength() => _length;

    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;
    }

    public float GetCost()
    {
        float arrowheadCost = _arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5
        };

        float fletchingCost = _fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3
        };

        float shaftCost = 0.05f * _length;

        return arrowheadCost + fletchingCost + shaftCost;
    }
}

enum Arrowhead { Steel, Wood, Obsidian }
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }