using System;
namespace BackEnd
{
    public class CustomAttribute
    {
        public readonly bool ContainsAttribute;
        public readonly bool Mandatory;

        public CustomAttribute(bool containsAttribute, bool mandatory)
        {
            ContainsAttribute = containsAttribute;
            Mandatory = mandatory;
        }
    }
}

