using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ServerLib
{
    public class RSAManager
    {
        RSACryptoServiceProvider csp = null;
        public RSAParameters myPrivateKey { get; private set; }
        public RSAParameters myPublicKey { get; private set; }
        internal void Init()
        {
            csp = new RSACryptoServiceProvider(2048);
            myPrivateKey = csp.ExportParameters(true);
            myPublicKey = csp.ExportParameters(false);
        }

        public string ConvertRSAParameterToString()
        {
            return RSAHelper.ConvertRSAKeyToString(myPublicKey);
        }

        public RSAParameters ConvertKeyStringToRSAParameter(string pubKeyString)
        {
            return RSAHelper.ConvertStringToRSAKey(pubKeyString);
        }

        public string Encrypt(string data, string ForeignPublicKeyString)
        {
            RSAParameters ForeignPublicKey = ConvertKeyStringToRSAParameter(ForeignPublicKeyString);

            //we have a public key ... let's get a new csp and load that key
            csp.ImportParameters(ForeignPublicKey);

            //for encryption, always handle bytes...
            byte[] bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(data);

            //apply pkcs#1.5 padding and encrypt our data 
            byte[] bytesCypherText = csp.Encrypt(bytesPlainTextData, false);

            //we might want a string representation of our cypher text... base64 will do
            return Convert.ToBase64String(bytesCypherText);
        }

        public string Decrypt(string data)
        {
            //first, get our bytes back from the base64 string ...
            byte[] bytesCypherText = Convert.FromBase64String(data);

            //we want to decrypt, therefore we need a csp and load our private key
            csp.ImportParameters(myPrivateKey);

            //decrypt and strip pkcs#1.5 padding
            byte[] bytesPlainTextData = csp.Decrypt(bytesCypherText, false);

            //get our original plainText back...
            return System.Text.Encoding.Unicode.GetString(bytesPlainTextData);
        }
    }

    internal static class RSAHelper
    {
        internal static string ConvertRSAKeyToString(RSAParameters key)
        {
            //we need some buffer
            var sw = new System.IO.StringWriter();
            //we need a serializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //serialize the key into the stream
            xs.Serialize(sw, key);
            //get the string from the stream
            return sw.ToString();
        }

        internal static RSAParameters ConvertStringToRSAKey(string stringKey)
        {
            //get a stream from the string
            var sr = new System.IO.StringReader(stringKey);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            return (RSAParameters)xs.Deserialize(sr);
        }

    }

}
