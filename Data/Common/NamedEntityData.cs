namespace MaskShop.Data.Common
{
    public abstract class NamedEntityData : UniqueEntityData, IUniqueNamedData
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
