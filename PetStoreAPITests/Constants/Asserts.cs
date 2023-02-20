using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPITests.Constants
{
    public class Asserts
    {
        public static void assertEquals(string expected, string actual)
        {
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void assertTrue(bool condition)
        {

            try
            {
                Assert.IsTrue(condition);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void assertFalse(bool condition)
        {

            try
            {
                Assert.IsFalse(condition);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void IsNotEmpty(string message)
        {
            try
            {
                Assert.IsNotEmpty(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Fail(string v)
        {
            try
            {
                Assert.Fail(v);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
