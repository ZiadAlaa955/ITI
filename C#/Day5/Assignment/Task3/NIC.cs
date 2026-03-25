using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public enum Type
    {
        Ethernet, Token
    }
    internal class NIC
    {
        public string manufacture { get; }
        public string MAC { get; }
        public Type NIC_Type { get; }

        NIC(string _Manufacture, string _MAC, Type _NIC_Type)
        {
            manufacture = _Manufacture;
            MAC = _MAC;
            NIC_Type = _NIC_Type;
        }

        public static NIC SingleTon { get; } = new NIC("Intel","123456",Type.Ethernet);

    }
}
