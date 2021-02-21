using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Xunit;

namespace CsvHelperDemo
{

    public class Email
    {
        //Login email;Identifier;First name;Last name
        [Name("Login email")]
        public string Loginemail { get; set; }
        public string Identifier { get; set; }

        [Name("First name")]
        public string Firstname { get; set; }

        [Name("Last name")]
        public string Lastname { get; set; }
    }

    public class UnitTest1
    {
        [Fact]
        public void ReadCSV()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
                Delimiter = ";",
                HasHeaderRecord = true
            };

            using var reader = new StreamReader("email.csv");
            using var csv = new CsvReader(reader, config);

            var records = csv.GetRecords<Email>();

            Assert.Equal(4, records.Count());
        }

        [Fact]
        public void WriteCSV()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
                Delimiter = ";",
                HasHeaderRecord = true
            };

            using var streamWriter = new StreamWriter("email2.csv");
            using var csv = new CsvWriter(streamWriter, config);

            csv.WriteHeader<Email>();
            csv.NextRecord();
            csv.WriteRecord(new Email()
            {
                Loginemail = "something@example.org",
                Firstname = "fn",
                Lastname = "ln",
                Identifier = "id"
            });

            
            
        }
    }
}
