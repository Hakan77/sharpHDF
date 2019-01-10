/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.IO;

namespace SharpHDF.Library.Tests.Objects
{
    public abstract class BaseTest
    {
        protected string DirectoryName { get; set; }
        
        public void CleanDirectory()
        {
            if (!Directory.Exists(DirectoryName))
            {
                Directory.CreateDirectory(DirectoryName);
            }

            var files = Directory.GetFiles(DirectoryName);
            foreach (var file in files)
            {
                File.Delete(file);
            }
        }

        protected string GetFilename(string _file)
        {
            return Path.Combine(DirectoryName, _file);
        }
    }
}
