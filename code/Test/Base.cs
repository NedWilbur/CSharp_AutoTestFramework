using NUnit.Framework;
using WebFramework;
using AutoTestBase;
using System;

[assembly: LevelOfParallelism(5)]

namespace Test
{
    public class Base
    {
        private WebDriver Driver { get; set; }
        internal WebFramework.Views.Views View { get; private set; }

        [OneTimeSetUp]
        public void SetupOneTimeSetUp()
        {

        }

        [SetUp]
        public void SetUp()
        {
            Log.Info($"Starting {TestContext.CurrentContext.Test.Name} - {TestContext.CurrentContext.Test.Properties.Get("Description")}");
            (Driver, View) = Util.NewBrowser();
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Actions.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

        }
    }
}