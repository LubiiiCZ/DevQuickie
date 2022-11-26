namespace Special001;

public static class Question10
{
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Bzzz!");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }

    public static void Print()
    {
        Animal a = new Cat();
        Dog d = (Dog)a;
        d.MakeSound();
    }
}
