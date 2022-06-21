using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Program
{
    public static void Main(string[] args)
    {
        bool menu = true;
        while (menu)
        {
            menu = kalkylator();
        }
    }
    static bool kalkylator()
    {
        Console.Clear();
        Console.WriteLine("Choose the operation you want to run. \n 1: Addition \n 2: Subtraction \n 3: Multiplication \n 4: Division \n 0: Close");
        switch (Console.ReadLine())
        {
            case "1":
                addition();
                return true;
            case "2":
                subtraction();
                return true;
            case "3":
                multiplication();
                return true;
            case "4":
                division();
                return true;
            case "0":
                return false;
            default:
                return true;
        }
    }
    static void addition()
    {
        Console.Clear();
        Console.Write("Insert the number you want to add to: ");
        int num1 = getInt();
        Console.Write("Insert the number you want to add: ");
        int num2 = getInt();
        Console.Write($"{num1} + {num2} = {num1 + num2}");
        Console.ReadLine();
    }
    static void subtraction()
    {
        Console.Clear();
        Console.Write("Insert the number you want to subtract from: ");
        int num1 = getInt();
        Console.Write("Insert the number you want to subtract: ");
        int num2 = getInt();
        Console.Write($"{num1} - {num2} = {num1 - num2}");
        Console.ReadLine();

    }
    static void multiplication()
    {
        Console.Clear();
        Console.Write("Insert the number you want to multiplicate: ");
        int num1 = getInt();
        Console.Write("Insert the number of times you want to multiply: ");
        int num2 = getInt();
        Console.Write($"{num1} x {num2} = {num1 * num2}");
        Console.ReadLine();

    }
    static void division()
    {
        Console.Clear();
        Console.Write("Insert the number you want to divide: ");
        int num1 = getInt();
        Console.Write("Insert the number of times you want to divide the number: ");
        int num2 = getInt();
        if (num2 == 0)
        {
            Console.WriteLine("\n !) The dividing number cannot be 0.");
            Console.ReadLine();
        }
        else
        {
            Console.Write($"{num1} / {num2} = {num1 / num2}");
            Console.ReadLine();
        }


    }
    static int getInt()
    {
        return Convert.ToInt32(Console.ReadLine());
    }
}
