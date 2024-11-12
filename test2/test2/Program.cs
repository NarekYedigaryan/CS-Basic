using System;
using System.Diagnostics;

class A
{
    private int x;
    private int y;

    public A(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int getX() { return x; }
}

class Program
{
    static void Main(string[] args)
    {
        long beforeMemory = GC.time
        A obj = new A(3, 4);
        long afterMemory = GC.GetTotalMemory(true);

        Console.WriteLine("Approximate size of class A: " + (afterMemory - beforeMemory) + " bytes");
    }
}
