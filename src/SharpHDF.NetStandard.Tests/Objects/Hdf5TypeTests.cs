/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using NUnit.Framework;
using SharpHDF.Library.Exceptions;
using SharpHDF.Library.Objects;

namespace SharpHDF.Library.Tests.Objects
{
    [TestFixture]
    public class Hdf5TypeTests :BaseTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            DirectoryName = @"c:\temp\hdf5tests\typetests";

            CleanDirectory();
        }

        [Test]
        public void AttemptMoney()
        {
            var filename = GetFilename("attemptmoney.hdf5");

            var file = Hdf5File.Create(filename);

            try
            {
                var money = 123.33m;

                file.Attributes.Add("moneyvalue", money);

                Assert.Fail("Exception was expected");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<Hdf5UnsupportedDataTypeException>(ex);
            }

            file.Close();
        }
    }
}
