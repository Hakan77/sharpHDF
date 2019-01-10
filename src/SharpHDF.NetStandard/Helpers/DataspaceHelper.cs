/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by Brian Nelson 2016.                                           *
 * See license in repo for more information                                  *
 * https://github.com/sharpHDF/sharpHDF                                      *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using HDF.PInvoke;
using SharpHDF.Library.Objects;
using SharpHDF.Library.Structs;

namespace SharpHDF.Library.Helpers
{
    internal static class DataspaceHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Hdf5Dataspace GetDataspace(Hdf5Identifier _datasetId)
        {
            var dataspaceId = H5D.get_space(_datasetId.Value).ToId();

            var rank = H5S.get_simple_extent_ndims(dataspaceId.Value);
            var dims = new ulong[rank];
            var maxDims = new ulong[rank];
            H5S.get_simple_extent_dims(dataspaceId.Value, dims, maxDims);

            var dataspace = new Hdf5Dataspace
            {
                Id = dataspaceId,
                NumberOfDimensions = rank
            };

            for (var i = 0; i < dims.Length; i++)
            {
                var property = new Hdf5DimensionProperty
                {
                    CurrentSize = dims[i],
                    //MaximumSize = maxDims[i]
                };
                dataspace.DimensionProperties.Add(property);
            }

            H5S.close(dataspaceId.Value);

            return dataspace;
        }
    }
}
