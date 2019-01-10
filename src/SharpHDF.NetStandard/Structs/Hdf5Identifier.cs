/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
#define HDF5_VER1_10

using System;

namespace SharpHDF.Library.Structs
{
    public struct Hdf5Identifier
    {

#if HDF5_VER1_10
        public Hdf5Identifier(long _value)
        {
            Value = _value;
        }

        public Int64 Value;
#else
        public Hdf5Identifier(int _value)
        {
            Value = _value;
        }
 
        public readonly int Value;
#endif

        public bool Equals(Hdf5Identifier _other)
        {
            return Value == _other.Value;
        }
 
         public override int GetHashCode()
        {
            return Value.GetHashCode();
        } 
    }
}
