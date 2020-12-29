using System;

namespace MireroTicket.ServiceBus.Attributes
{
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Struct,
        AllowMultiple = false,
        Inherited = false
    )]
    public class AliasAttribute : Attribute
    {
        public AliasAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}