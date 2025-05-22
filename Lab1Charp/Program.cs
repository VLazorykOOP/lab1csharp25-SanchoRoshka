// See https://aka.ms/new-console-template for more information

 static void task1()
{
    Console.WriteLine("Task1 !");
    Console.Write("s= ");
    string? str = Console.ReadLine();
    float s = 0; 
    if (str != null) s = float.Parse(str);
    double p = 4 * Math.Sqrt(s);
    Console.WriteLine("p=" + p);

}
Console.WriteLine("Lab 1 !");
task1();
// continue ...

class Task1
{
    static Random rand = new Random();

    static int GeneratePoisson(double lambda)
    {
        int x = 0;
        double P = Math.Exp(-lambda), sum = P, z = rand.NextDouble();
        while (z > sum)
        {
            x++;
            P *= lambda / x;
            sum += P;
        }
        return x;
    }

    static int GenerateGeometric(double p)
    {
        double q = 1.0 - p, P = p, sum = P, z = rand.NextDouble();
        int x = 0;
        while (z > sum)
        {
            x++;
            P *= q;
            sum += P;
        }
        return x;
    }

    static int GenerateBinomial(int n, double p)
    {
        int x = 0;
        for (int i = 0; i < n; i++)
        {
            if (rand.NextDouble() < p) x++;
        }
        return x;
    }

    public static void Run()
    {
        Console.Write("Enter lambda: ");
        double lambda = double.Parse(Console.ReadLine());
        Console.WriteLine($"Poisson Distribution ({lambda})");
        for (int i = 0; i < 200; i++) Console.Write(GeneratePoisson(lambda) + " ");
        Console.WriteLine();

        Console.Write("Enter p (for geometric): ");
        double p_geom = double.Parse(Console.ReadLine());
        Console.WriteLine($"Geometric Distribution ({p_geom})");
        for (int i = 0; i < 200; i++) Console.Write(GenerateGeometric(p_geom) + " ");
        Console.WriteLine();

        Console.Write("Enter n (for binomial): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter p (for binomial): ");
        double p_bin = double.Parse(Console.ReadLine());
        Console.WriteLine($"Binomial Distribution ({n}, {p_bin})");
        for (int i = 0; i < 200; i++) Console.Write(GenerateBinomial(n, p_bin) + " ");
        Console.WriteLine();
    }
}

