using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tester_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHashcode()
        {
            int i = 3;

            Hashcode_Vergleich vergleich = new Hashcode_Vergleich();
            Hashcode_Vergleich vergleich2 = new Hashcode_Vergleich();
            
        }
        [TestMethod]
        public void TestXML()
        {
            XML_Auslesen xML = new XML_Auslesen();

        }
    }
}
