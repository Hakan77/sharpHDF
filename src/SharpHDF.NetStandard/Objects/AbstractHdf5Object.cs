﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using SharpHDF.Library.Structs;

namespace SharpHDF.Library.Objects
{
    public abstract class AbstractHdf5Object
    {
        /// <summary>
        /// Identifier of the object in the HDF5 file
        /// </summary>
        internal Hdf5Identifier Id { get; set; }

        /// <summary>
        /// Identifier of the file level node in the HDF5 file
        /// </summary>
        internal Hdf5Identifier FileId { get; set; }

        /// <summary>
        /// Path object that parses name and stores full path.
        /// </summary>
        internal Hdf5Path Path { get; set; }
    }
}
