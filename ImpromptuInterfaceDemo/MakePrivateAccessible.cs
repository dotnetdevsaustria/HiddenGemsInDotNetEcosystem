using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpromptuInterface;
using Xunit;

namespace ImpromptuInterfaceDemo
{
    class PrivateClass
    {
        private string PrivateMethod()
        {
            return "I am not public";
        }
    }

    interface IMakePrivatePublic
    {
        string PrivateMethod();
    }


    public class MakePrivateAccessible
    {
        [Fact]
        public void CanIMakePrivateStuffPublic()
        {
            var privateInstance = new PrivateClass();

            var andNotItIsPublic = privateInstance.ActLike<IMakePrivatePublic>();

            Assert.Equal("I am not public", andNotItIsPublic.PrivateMethod());
        }
        
    }
}
