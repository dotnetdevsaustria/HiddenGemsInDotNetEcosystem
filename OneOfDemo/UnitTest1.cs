using System;
using Xunit;
using OneOf;

namespace OneOfDemo
{
    public class Fruit
    {

    }

    public class Vegetable
    {

    }

    public class UnitTest1
    {
        public OneOf<Fruit, Vegetable> GetSomethingHealthyToEat()
        {
            return new Fruit();
        }



        [Fact]
        public void SwitchDemo()
        {

            var food = GetSomethingHealthyToEat();

            food.Switch(
                fruit =>
                {
                    Assert.IsType<Fruit>(fruit);
                }, 
                vegetable =>
                {
                    throw new Exception("This should not happen. Error in Library");
                });
        }

        [Fact]
        public void MatchDemo()
        {

            var food = GetSomethingHealthyToEat();

            var result = food.Match(
                fruit =>
                {
                    return "fruit";
                },
                vegetable =>
                {
                    return "vegetable";
                });

            Assert.Equal("fruit", result);
        }
    }
}
