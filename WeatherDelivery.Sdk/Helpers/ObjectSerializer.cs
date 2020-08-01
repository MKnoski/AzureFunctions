using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace WeatherDelivery.Sdk.Helpers
{
    public static class ObjectSerializer
    {
        public static byte[] ObjectToByteArray(this Object obj)
        {
            if (obj == null)
            {
                return null;
            }

            BinaryFormatter bf = new BinaryFormatter();
            using MemoryStream ms = new MemoryStream();

            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        public static Object ByteArrayToObject(this byte[] arrBytes)
        {
            using MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj;
        }
    }
}