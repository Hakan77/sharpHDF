using SharpHDF.Library.Enums;
using SharpHDF.Library.Objects;
using System;
using System.Collections.Generic;

namespace HDFExampleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var fileLocation = @"C:\temp\createdatasetinfile.h5";

            var hdf5File = Hdf5File.Create(fileLocation);

            var properties = new List<Hdf5DimensionProperty>();

            var property = new Hdf5DimensionProperty { CurrentSize = 100 };

            properties.Add(property);

            var dataset = hdf5File.Datasets.Add("dataset1", Hdf5DataTypes.Int8, properties);
            Console.WriteLine($"Dataset is null {dataset == null}");
            Console.WriteLine($"Dataset count {hdf5File.Datasets.Count}");

            hdf5File.Close();

            Console.ReadKey();
        }
    }
}
