using System;
using System.IO;
using FluentAssertions;
using Xunit;
using Utf8Json;

namespace Utf8JsonDemo
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var p = new Person { Age = 99, Name = "foobar" };

            // Object -> byte[] (UTF8)
            byte[] result = JsonSerializer.Serialize(p);

            // byte[] -> Object
            var p2 = JsonSerializer.Deserialize<Person>(result);

            p2.Should().BeEquivalentTo(p);
            
            // Object -> String
            //var json = JsonSerializer.ToJsonString(p2);

            
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
