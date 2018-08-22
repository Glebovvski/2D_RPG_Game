using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;


public class SerializationHelper {

	public static byte[] Serialise<T>(T input)
    {
        byte[] output = null;

        var serializer = new XmlSerializer(typeof(T));
        try
        {
            using(var stream= new MemoryStream())
            {
                serializer.Serialize(stream, input);
                output = stream.GetBuffer();
            }
        }
        catch { }

        return output;
    }

    public static T Deserialise<T>(Stream input)
    {
        T output = default(T);
        var serialiser = new XmlSerializer(typeof(T));
        try
        {
            output = (T)serialiser.Deserialize(input);
        }
        catch { }

        return output;
    }
}
