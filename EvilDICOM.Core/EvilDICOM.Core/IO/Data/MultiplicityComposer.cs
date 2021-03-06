﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvilDICOM.Core.IO.Data
{
    public class MultiplicityComposer
    {
        /// <summary>
        /// Writes the multiple binary data objects as one string of bytes
        /// </summary>
        /// <typeparam name="T">the type of data</typeparam>
        /// <param name="data">the data to be converted to binary</param>
        /// <param name="writeSingleFunc">the function that can convert a single data item into bytes</param>
        /// <returns>the concated array of bytes that contains all data items</returns>
        public static byte[] ComposeMultipleBinary<T>(DICOMData<T> data, Func<T, byte[]> writeSingleFunc)
        {
            if (data != null)
            {
                List<byte> bytes = new List<byte>();
                foreach (var datum in data.MultipicityValue)
                {
                    //Write one data item
                    var single = writeSingleFunc(datum);
                    foreach (var byt in single)
                    {
                        bytes.Add(byt);
                    }
                }
                return bytes.ToArray();
            }
            return new byte[0];
        }
    }
}
