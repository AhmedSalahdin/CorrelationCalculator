using System;
using System.Linq;
using ConsoleTables;
class program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Correlation Calculator");
        Console.WriteLine("please state the leanght of the data Set");
        var temp = Console.ReadLine();
        int temp2, n = 0;
        double temp3 = 0;
        if (int.TryParse(temp, out temp2))
        {
            n = temp2;
        }
        else
        {
            Console.WriteLine("The Value must be integer number");
            while (!int.TryParse(Console.ReadLine(), out temp2))
                Console.WriteLine("The Value must be integer number");
            n = temp2;
        }
        double[] x = new double[n];
        double[] y = new double[n];
        double[] a = new double[n];
        double[] b = new double[n];
        double[] ab = new double[n];
        double[] a2 = new double[n];
        double[] b2 = new double[n];
        Console.WriteLine("Enter the set of data :");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"enter the {i + 1}'s value in the data Set of x");
            temp = Console.ReadLine();
            if (double.TryParse(temp, out temp3))
            {
                x[i] = temp3;
            }
            else
            {
                Console.WriteLine("The Value must be number");
                while (!double.TryParse(Console.ReadLine(), out temp3))
                    Console.WriteLine("The Value must be number");
                x[i] = temp3;
            }
            Console.WriteLine($"enter the {i + 1}'s value in the data Set of y");
            temp = Console.ReadLine();
            if (double.TryParse(temp, out temp3))
            {
                y[i] = temp3;
            }
            else
            {
                Console.WriteLine("The Value must be number");
                while (!double.TryParse(Console.ReadLine(), out temp3))
                    Console.WriteLine("The Value must be number");
                y[i] = temp3;
            }
        }
        double meanOFx = Enumerable.Sum(x) / x.Length;
        double meanOFy = Enumerable.Sum(y) / y.Length;
        for (int i = 0; i < n; i++)
        {
            a[i] = meanOFx - x[i];
            b[i] = meanOFy - y[i];
            ab[i] = a[i] * b[i];
            a2[i] = Math.Pow(a[i], 2);
            b2[i] = Math.Pow(b[i], 2);
        }
        var sumOfx = Enumerable.Sum(x);
        var sumOfy = Enumerable.Sum(y);
        var sumOfa = Enumerable.Sum(a);
        var sumOfb = Enumerable.Sum(b);
        var sumOfab = Enumerable.Sum(ab);
        var sumOfa2 = Enumerable.Sum(a2);
        var sumOfb2 = Enumerable.Sum(b2);
        Console.WriteLine("Your set of data is :");
        var table = new ConsoleTable("X", "Y", "A", "B", "AB", "A^2", "B^2");
        for (int i = 0; i < n; i++)
        {
            table.AddRow(x[i], y[i], a[i], b[i], ab[i], a2[i], b2[i]);
        }
        table.AddRow($"Σ{sumOfx:0.00}", $"Σ{sumOfy:0.00}", $"Σ{sumOfa:0.00}", $"Σ{sumOfb:0.00}", $"Σ{sumOfab:0.00}", $"Σ{sumOfa2:0.00}", $"Σ{sumOfb2:0.00}");
        table.Write();
        Console.WriteLine("------------------------------------------------------------------");
        Console.WriteLine($"The Mean of x is {meanOFx:0.000} and the Mean of y is {meanOFy:0.000}");
        double s = sumOfa2 * sumOfb2;
        double Corr = sumOfab / Math.Sqrt(s);
        Console.WriteLine($"The Correlation of your data is {Corr:0.000}");
    }
}
