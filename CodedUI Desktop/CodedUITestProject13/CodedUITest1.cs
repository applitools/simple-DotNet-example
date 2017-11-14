using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Applitools.CodedUI;

namespace CodedUINotepadTest
{


    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {

            ApplicationUnderTest application = ApplicationUnderTest.Launch("C:\\Windows\\notepad.exe");

            WpfWindow mainWindow = new WpfWindow();
            mainWindow.SearchProperties.Add(WpfWindow.PropertyNames.Name, "Notepad App");
            mainWindow.WindowTitles.Add("Notepad App");

            Eyes eyes = new Eyes();
            eyes.ApiKey = "your-applitools-key";
            eyes.Open(application, "Notepad", "Visual Check");

            eyes.CheckWindow("notepad - normal");

            application.Maximized = true;

            eyes.CheckWindow("notepad - maximized");

            eyes.Close();

        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
