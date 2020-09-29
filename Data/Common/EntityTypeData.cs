using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaskShop.Data.Common
{
    public abstract class EntityTypeData : DefinedEntityData
    {
        public string BaseTypeId { get; set; }
    }
}
