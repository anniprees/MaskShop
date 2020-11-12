using MaskShop.Data.Common;

namespace MaskShop.Data.Objects
{
    public abstract class ObjectData : DefinedEntityData
    {
        public string FileLocation { get; set; }

        public string ObjectTypeId { get; set; }
    }
}
