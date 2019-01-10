/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
#define HDF5_VER1_10

using System;
using SharpHDF.Library.Structs;

namespace SharpHDF.Library.Helpers
{
    internal static class IdHelper
    {
#if HDF5_VER1_10
        public static Hdf5Identifier ToId(this long _value)
#else
        public static Hdf5Identifier ToId(this int _value)
#endif
        {
            var id = new Hdf5Identifier(_value);
            return id;
        }
    }
}
