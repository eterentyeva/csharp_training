using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        private GroupData newData;

        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("l");
            newData.Header = "l";
            newData.Footer = "l";

            app.Group.Modify(1, newData);
        }
    }
}
