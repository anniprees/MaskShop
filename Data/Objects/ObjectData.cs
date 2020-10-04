using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Objects
{
    public abstract class ObjectData : DefinedEntityData
    {
        public string FileLocation { get; set; }

        public string ObjectTypeId { get; set; }
    }
}
