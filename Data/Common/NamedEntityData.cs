using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Common
{
    public abstract class NamedEntityData : UniqueEntityData
    {
        public string Name { get; set; }
    }
}
