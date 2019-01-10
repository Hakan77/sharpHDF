/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Collections;
using NUnit.Framework;
using SharpHDF.Library.Objects;

namespace SharpHDF.Library.Tests.Objects
{
    [TestFixture]
    public class ReadonlyListTests : BaseTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            DirectoryName = @"c:\temp\hdf5tests\readonlylist";

            CleanDirectory();
        }

        [Test]
        public void ContainsTest()
        {
            var fileName = GetFilename("contains.h5");

            var file = Hdf5File.Create(fileName);
            var group1 = file.Groups.Add("group1");
            var group2 = file.Groups.Add("group2");
            var group3 = file.Groups.Add("group3");
            var group4 = file.Groups.Add("group4");
            var group5 = file.Groups.Add("group5");

            Assert.IsTrue(file.Groups.Contains(group1));
            Assert.IsTrue(file.Groups.Contains(group2));
            Assert.IsTrue(file.Groups.Contains(group3));
            Assert.IsTrue(file.Groups.Contains(group4));
            Assert.IsTrue(file.Groups.Contains(group5));
        }

        [Test]
        public void CopyToTest()
        {
            var fileName = GetFilename("copyto.h5");

            var file = Hdf5File.Create(fileName);
            var group1 = file.Groups.Add("group1");
            var group2 = file.Groups.Add("group2");
            var group3 = file.Groups.Add("group3");
            var group4 = file.Groups.Add("group4");
            var group5 = file.Groups.Add("group5");

            var groups = new Hdf5Group[5];
            file.Groups.CopyTo(groups, 0);
        }

        [Test]
        public void GetEnumeratorTest()
        {
            var fileName = GetFilename("getenumerator.h5");

            var file = Hdf5File.Create(fileName);
            var group1 = file.Groups.Add("group1");
            var group2 = file.Groups.Add("group2");
            var group3 = file.Groups.Add("group3");
            var group4 = file.Groups.Add("group4");
            var group5 = file.Groups.Add("group5");

            var groups = file.Groups;
            var test = groups as IEnumerable;
            var i = 0;
            foreach (var testGroup in test)
            {
                i++;
            }

            Assert.AreEqual(5, i);
        }

    }
}
