using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Program
{
    public class TimeZone
    {
        public string? ZipCode { get; set; }
        public int Zone { get; set; }
        
    }

    static void Main(string[] args)
    {
        // Path to your input JSON file
        string jsonFilePath = "zipcodes.json";

        // Path to output CSV file
        string csvFilePath = "output.csv";

        // Read the JSON data from the file
        string jsonData = File.ReadAllText(jsonFilePath);

        // Deserialize the JSON data to a list of Person objects
        List<TimeZone> tz = JsonConvert.DeserializeObject<List<TimeZone>>(jsonData)!;

        // Convert the List<Person> to CSV and write to file
        WriteCsv(tz!, csvFilePath);
    }

    static void WriteCsv(List<TimeZone> zones, string csvFilePath)
    {
        using (var writer = new StreamWriter(csvFilePath))
        {
            // Write the header row (column names)
            writer.WriteLine("ZipCode, TimeZone");

            // Write each person record to CSV
            foreach (var zone in zones)
            {
                writer.WriteLine($"{zone.ZipCode},{zone.Zone}");
            }
        }

        Console.WriteLine($"CSV file written to {csvFilePath}");
    }
}

