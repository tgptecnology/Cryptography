﻿using System.Security.Cryptography;

namespace RsaLibrary
{
    public static class Utils
    {
        public static string FromRsaParametersXML(this RSAParameters rsaParams)
        {
            //we need some buffer
            var sw = new System.IO.StringWriter();
            //we need a serializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //serialize the key into the stream
            xs.Serialize(sw, rsaParams);
            //get the string from the stream
            return sw.ToString();
        }

        public static RSAParameters ToRsaParametersXML(this string key)
        {
            //get a stream from the string
            var sr = new System.IO.StringReader(key);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            return (RSAParameters)xs.Deserialize(sr);
        }
    }
}
