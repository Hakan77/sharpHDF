﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using SharpHDF.Library.Interfaces;

namespace SharpHDF.Library.Objects
{
    /// <summary>
    /// Contains HDF5 Attribures
    /// </summary>
    public class Hdf5Attribute : AbstractHdf5Object, IHasName
    {
        /// <summary>
        /// Name of the Attribute
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// String value of the Attribute.
        /// </summary>
        public object Value { get; set; }
    }
}
