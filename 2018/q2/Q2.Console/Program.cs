using Q2.Logic;

namespace Q2.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("CAH");
            System.Console.WriteLine("SPS");
            string input = System.Console.ReadLine();
            if (input.ToLowerInvariant() == "partb")
            {
                System.Console.WriteLine(new DecoderRing(1000000000).FirstSix);
            }
            else if (input.ToLowerInvariant() == "partd")
            {
                System.Console.WriteLine(DecoderRing.Cycler(System.Console.ReadLine()));
            }

            System.Console.ReadKey();            
        }
    }
}
