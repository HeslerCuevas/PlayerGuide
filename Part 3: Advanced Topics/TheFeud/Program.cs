using IField;
using McDroid;
using Animals;
using IPig = IField.Pig;
using McPig = McDroid.Pig;

//IFields
Sheep ISheep = new();
IPig IPig = new();

//McDroid
Cow McCow = new();
McPig McPig = new();

ISheep.Sound();
IPig.Sound();
McCow.Sound();
McPig.Sound();

namespace IField
{
    public class Sheep : Animal
    {
        public override void Sound()
        {
            Console.WriteLine("IMeeeeeeh IMeeeeh");
        }
    }

    public class Pig : Animal
    {
        public override void Sound()
        {
            Console.WriteLine("IOink IOink");
        }
    }
}

namespace McDroid
{
    public class Cow : Animal
    {
        public override void Sound()
        {
            Console.WriteLine("McMoooh McMoooh");
        }
    }

    public class Pig : Animal
    {
        public override void Sound()
        {
            Console.WriteLine("McOink McOink");
        }
    }
}

namespace Animals
{
    public abstract class Animal
    {
        public static void Eat()
        {
            Console.WriteLine("Eating...");
        }

        public static void Drinking()
        {
            Console.WriteLine("Drinking...");
        }

        public virtual void Sound() {}
    }
}