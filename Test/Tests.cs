using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Tests : TestBase
    {
        [Test]
        [Category]
        [Description("Checkboxes default value")]
        public void CheckboxDefaultState()
        {
            View.Home.ClickLink("Checkboxes");
            Assert.IsFalse(View.Checkboxes.Checkbox1IsSelected());
            Assert.IsTrue(View.Checkboxes.Checkbox2IsSelected());
        }
    }
}
