using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Welcome to Hash Table****");
            //UC1:-Ability to find Frequency of words in a sentence 
            MyMapNode<string, string> node = new MyMapNode<string, string>(5);
            node.Add("0", "To");
            node.Add("1", "Be");
            node.Add("2", "Or");
            node.Add("3", "Not");
            node.Add("4", "To");
            node.Add("5", "Be");
            string node0 = node.Get("0");
            Console.WriteLine("1st index value: " + node0);
            string node1 = node.Get("1");
            Console.WriteLine("2nd index value: " +node1);
            Console.WriteLine("3rd index value: "+node.Get("2"));
        }
    }
}
