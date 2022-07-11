//Thomas Cowie - File I/O lab
using System;
using System.IO;

namespace File_IOLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File I/O Lab");
            string[] even = new string[16]; //create the array for the even numbers
            string[] odd = new string[16];  //create the array for the odd numbers
            //Get the numbers and distribute to even and odd arrays from the Numbers.txt file.
            try
            {
                using (StreamReader reader = new StreamReader("Numbers.txt"))   //I placed my numbers folder where the program could see it in the debug bin folder.
                {
                    string line;
                    //I will need iterators to make sure we store the numbers in empty indexes.
                    int evenIterator = 0;
                    int oddIterator = 0;
                    while((line = reader.ReadLine()) != null)   //While the file doesnt have any empty lines keep iterating.
                    {
                        if(Int32.Parse(line) % 2 == 0)  //Convert the string to an int and determine if even or odd using modulus.
                        {
                            even[evenIterator] = line;
                            evenIterator = evenIterator + 1;
                        }
                        else
                        {
                            odd[oddIterator] = line;
                            oddIterator = oddIterator + 1;
                        }
                        
                    }
                }
            }
            catch (Exception e) //In the event we cannot find the numbers file it will display the error.
            {
                Console.WriteLine("File cannot be found or read:");
                Console.WriteLine(e.Message);

            }
            //Now create the even and odd files and populate with data.
            string evenFilePath = @"C:\Users\thoma\Desktop\even.txt"; //This is my desktop path which will differ on someone elses.

            //Create the file and populate it (even)
            if (!File.Exists(evenFilePath))
            {
                using(StreamWriter writer = File.CreateText(evenFilePath))  //Create the even file.
                {
                    for(int i = 0; even[i] != null; i++)
                    {
                        writer.WriteLine(even[i]);  //Populating even file.
                    }
                }
            }
            //Create the file and populate it (odd)
            string oddFilePath = @"C:\Users\thoma\Desktop\odd.txt";
            if (!File.Exists(oddFilePath))
            {
                using (StreamWriter writer = File.CreateText(oddFilePath))  //Create the odd file.
                {
                    for (int i = 0; odd[i] != null; i++)
                    {
                        writer.WriteLine(odd[i]);  //Populating odd file.
                    }
                }
            }

        }
    }
}
