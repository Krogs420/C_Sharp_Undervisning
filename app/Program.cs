using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

public class CSVReader
{
    static void Main(string[] args)
    {
        string filePath1 = "setup.csv";
        string filePath2 = "teams.csv";

        Console.WriteLine("Reading setup.csv:");
        ReadCsvFile(filePath1);

        Console.WriteLine("\nReading teams.csv:");
        ReadCsvFile(filePath2);
    }

    static void ReadCsvFile(string filePath)
    {
        try
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var records = csv.GetRecords<dynamic>();

                foreach (var record in records)
                {
                    foreach (var property in record)
                    {
                        Console.Write(property.Value + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
