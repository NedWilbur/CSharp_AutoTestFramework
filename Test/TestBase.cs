using NUnit.Framework;
using _WebFramework;
using _ATB;
using System;

[assembly: LevelOfParallelism(5)]

namespace Test
{
    public class TestBase
    {
        internal WebDriver Driver { get; private set; }
        internal _WebFramework.Views.Views View { get; private set; }

        [OneTimeSetUp]
        public void SetupOneTimeSetUp()
        {

        }

        [SetUp]
        public void SetUp()
        {
            (Driver, View) = Util.NewBrowser();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }
    }
}