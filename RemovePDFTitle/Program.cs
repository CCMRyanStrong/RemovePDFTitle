using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Mail;
using System.Threading;
using System.Text.RegularExpressions;

namespace RemovePDFTitle
{
    //Add multithreading some day
    class Program
    {
        static string SOURCE_PATH = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path to the source file folder:");
            SOURCE_PATH = Console.ReadLine();
            string[] contents = Directory.GetFiles(SOURCE_PATH);
            
            string command = @"cd C:\Users\rstrong\Downloads\exiftool-12.39";
            Console.WriteLine(command);
            ProcessStartInfo psi;
            Process process;
            foreach (string file in contents)
            {
                if (Path.GetExtension(file) == ".pdf" && File.Exists(file))
                {
                    command = "/C C:\\Users\\rstrong\\Downloads\\exiftool-12.39\\exiftool.exe -Title=\"\" " +"\""+ file + "\"";
                    Console.WriteLine(command);
                    
                    psi = new ProcessStartInfo("cmd.exe")
                    {
                        UseShellExecute = false,
                        Arguments = command
                    };
                    process = Process.Start(psi);
                    process.WaitForExit();
                    command = "/C del \"" + file + "_original\"";
                    psi = new ProcessStartInfo("cmd.exe")
                    {
                        UseShellExecute = false,
                        Arguments = command
                    };
                    process = Process.Start(psi);
                    process.WaitForExit();
                }
            }
            Console.WriteLine("Process complete! Press any key to exit");
            Console.ReadKey();
        }
    }
}
