﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using NUnit.Framework;
using SharpHDF.Library.Helpers;
using SharpHDF.Library.Objects;

namespace SharpHDF.Library.Tests.Objects
{
    [TestFixture]
    public class Hdf5PathTests : BaseTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            DirectoryName = @"c:\temp\hdf5tests\pathtests";

            CleanDirectory();
        }

        [Test]
        public void AppendNull()
        {
            try
            {
                var path = new Hdf5Path("thepath");

                path.Append(null);

                Assert.Fail("Should have caused an exception");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ArgumentNullException>(ex);
            }            
        }

        [Test]
        public void Append()
        {
            try
            {
                var path = new Hdf5Path("thepath");

                var newpath = path.Append("isstraight");

                Assert.AreEqual(newpath.FullPath, "thepath/isstraight");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ArgumentNullException>(ex);
            }
        }

        [Test]
        public void AppendToSlash()
        {
            try
            {
                var path = new Hdf5Path("thepath/");

                var newpath = path.Append("isclear");

                Assert.AreEqual(newpath.FullPath, "thepath/isclear");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ArgumentNullException>(ex);
            }
        }

        [Test]
        public void AppendToRoot()
        {
            try
            {
                var path = new Hdf5Path("/");

                var newpath = path.Append("addthis");

                Assert.AreEqual(newpath.FullPath, "addthis");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ArgumentNullException>(ex);
            }
        }
    }
}
