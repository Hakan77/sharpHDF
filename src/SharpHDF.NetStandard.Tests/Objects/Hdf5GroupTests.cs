/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using NUnit.Framework;
using SharpHDF.Library.Objects;

namespace SharpHDF.Library.Tests.Objects
{
    [TestFixture]
    public class Hdf5GroupTests : BaseTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            DirectoryName = @"c:\temp\hdf5tests\grouptests";

            CleanDirectory();
        }

        [Test]
        public void CreateGroup()
        {
            var fileName = GetFilename("creategroup.h5");

            var file = Hdf5File.Create(fileName);
            var group = file.Groups.Add("group1");

            Assert.IsNotNull(group);
            Assert.AreEqual(1, file.Groups.Count);

            file.Close();
        }

        [Test]
        public void OpenGroup()
        {
            var fileName = GetFilename("opengroup.h5");

            var file = Hdf5File.Create(fileName);
            var group = file.Groups.Add("group1");

            Assert.IsNotNull(group);
            Assert.AreEqual(1, file.Groups.Count);

            file.Close();

            file = new Hdf5File(fileName);
            group = file.Groups[0];

            Assert.IsNotNull(group);
        }

        [Test]
        public void CreateGroupInGroup()
        {
            var fileName = GetFilename("creategroupingroup.h5");

            var file = Hdf5File.Create(fileName);
            var group1 = file.Groups.Add("group1");

            Assert.IsNotNull(group1);
            Assert.AreEqual(1, file.Groups.Count);

            var group2 = group1.Groups.Add("group2");
            Assert.IsNotNull(group2);
            Assert.AreEqual(1, file.Groups.Count);
            Assert.AreEqual(1, group1.Groups.Count);

            file.Close();
        }

        [Test]
        public void OpeningGroupInGroup()
        {
            var fileName = GetFilename("opengroupingroup.h5");

            var file = Hdf5File.Create(fileName);
            var group1 = file.Groups.Add("group1");

            Assert.IsNotNull(group1);
            Assert.AreEqual(1, file.Groups.Count);

            var group2 = group1.Groups.Add("group2");
            Assert.AreEqual(1, file.Groups.Count);
            Assert.AreEqual(1, group1.Groups.Count);

            file.Close();

            file = new Hdf5File(fileName);
            group1 = file.Groups[0];
            Assert.IsNotNull(group1);
            Assert.AreEqual("group1", group1.Name);

            group2 = group1.Groups[0];
            Assert.IsNotNull(group2);
            Assert.AreEqual("group2", group2.Name);
        }

        [Test]
        public void DeleteGroup()
        {
            var fileName = GetFilename("deletegroup.h5");

            var file = Hdf5File.Create(fileName);
            var group1 = file.Groups.Add("group1");
            var group2 = file.Groups.Add("group2");
            var group3 = file.Groups.Add("group3");
            var group4 = file.Groups.Add("group4");
            var group5 = file.Groups.Add("group5");

            Assert.AreEqual(5, file.Groups.Count);

            //TODO - delete
        }

        [Test]
        public void LoopThrougGroups()
        {
            var fileName = GetFilename("loopthroughgroups.h5");

            var file = Hdf5File.Create(fileName);
            var group1 = file.Groups.Add("group1");
            var group2 = file.Groups.Add("group2");
            var group3 = file.Groups.Add("group3");
            var group4 = file.Groups.Add("group4");
            var group5 = file.Groups.Add("group5");

            Assert.AreEqual(5, file.Groups.Count);

            foreach (var hdf5Group in file.Groups)
            {
                Assert.IsNotNull(hdf5Group);
            }

            for (var i = 0; i < 5; i++)
            {
                var group = file.Groups[i];
            }
            
            file.Close();
        }

    }
}
