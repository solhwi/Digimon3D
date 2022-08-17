using ProtobufSourceGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SDClientPacketHandlerGenerator
{
    internal class CodeGenerator
    {
        internal static void Generate()
        {
            XmlDocument Doc = PacketXmlReader.ReadPacketRaw();
            SDClientPacketHandlerGenerator.Generate(Doc);
            SDUnityPacketHandlerGenerator.Generate(Doc);
        }
    }
}
