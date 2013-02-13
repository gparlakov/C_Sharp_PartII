//Write a method that asks the user for his name and prints “Hello, <name>” 
//(for example, “Hello, Peter!”). Write a program to test this method.

using System;


class HelloMetho
{
    static void Hello(string name)
    {
        Console.WriteLine("Hello, {0} ", name);
    }

    static void Main(string[] args)
    {
        string name;
        Console.WriteLine("What's your name?");
        name = Console.ReadLine();
        Hello(name);
    }
}

