﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using SharpHDF.Library.Structs;

namespace SharpHDF.Library.Objects
{
    /// <summary>
    /// Information regarding the shape of a HDF5 Dataset
    /// </summary>
    public class Hdf5Dataspace
    {
        public Hdf5Dataspace()
        {
            DimensionProperties = new ReadonlyList<Hdf5DimensionProperty>();
        }

        /// <summary>
        /// Identifier of the dataset in the HDF5 file
        /// </summary>
        internal Hdf5Identifier Id { get; set; }

        /// <summary>
        /// Number of dimension that the dataset contains.
        /// </summary>
        public int NumberOfDimensions { get; set; }

        /// <summary>
        /// Properties of the dimensions in the dataset.
        /// </summary>
        public ReadonlyList<Hdf5DimensionProperty> DimensionProperties { get; set; }
    }
}
