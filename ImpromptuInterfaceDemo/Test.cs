using System;
using Dynamitey;
using ImpromptuInterface;
using Xunit;

namespace ImpromptuInterfaceDemo
{

    public interface IMyInterface
    {

        string Prop1 { get; }

        long Prop2 { get; }

        Guid Prop3 { get; }

        bool Meth1(int x);
    }
    public class Test
    {
        [Fact]
        public void NormalUsage()
        {
            var anon = new
            {
                Prop1 = "Test",
                Prop2 = 42L,
                Prop3 = Guid.NewGuid(),
                Meth1 = Return<bool>.Arguments<int>(it => it > 5)
            };

            var myInterface = anon.ActLike<IMyInterface>();


            Assert.Equal(myInterface.Prop1, anon.Prop1);
        }
    }
}
