/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.IO;
using NUnit.Framework;
using SharpHDF.Library.Exceptions;
using SharpHDF.Library.Objects;

namespace SharpHDF.Library.Tests.Objects
{
    [TestFixture]
    public class Hdf5FileTests : BaseTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            DirectoryName = @"c:\temp\hdf5tests\filetests";

            CleanDirectory();
        }

        [Test]
        public void CreateAttemptExistingFile()
        {
            var filename = GetFilename("existingfile.h5");
            File.WriteAllText(filename, "");

            try
            {
                var file = Hdf5File.Create(filename);
                file.Close();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<Hdf5FileExistsException>(ex);
                return;
            }

            Assert.Fail("Should have caused an exception");
        }

        [Test]
        public void OpenAttemptMissingFile()
        {
            var filename = GetFilename("missingfile.h5");

            try
            {
                var file = new Hdf5File(filename);
                file.Close();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<Hdf5FileNotFoundException>(ex);
                return;
            }

            Assert.Fail("Should have caused an exception");
        }

        [Test]
        public void CreateFile()
        {
            var filename = GetFilename("createfile.h5");

            var file = Hdf5File.Create(filename);

            Assert.IsNotNull(file);

            file.Close();
        }

        [Test]
        public void OpenFile()
        {
            var filename = GetFilename("openfile.h5");
            var file = Hdf5File.Create(filename);
            Assert.IsNotNull(file);
            file.Close();

            file = new Hdf5File(filename);
            Assert.IsNotNull(file);

            file.Dispose();
        }

        [Test]
        public void OpenFileWithException()
        {
            var filename = GetFilename("openfilewithexception.h5");

            var file = Hdf5File.Create(filename);

            Assert.IsNotNull(file);

            file.Close();

            //Lock the file so can't be opened
            using (var fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                try
                {
                    //Try to open it
                    file = new Hdf5File(filename);

                    Assert.Fail("Should have thrown an exception");
                }
                catch (Exception ex)
                {
                    Assert.IsInstanceOf<Hdf5UnknownException>(ex);
                }

                fs.Close();
            }
        }

        [Test]
        public void CreateFileWithException()
        {
            //Drive that doesn't exist
            var filename = @"q:\createfilewithexception.h5";

            try
            {
                var file = Hdf5File.Create(filename);
                file.Close();
                Assert.Fail("Should have caused an exception");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<Hdf5UnknownException>(ex);
            }
        }
    }
}
