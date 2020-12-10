using System;
using System.Collections.Generic;
using System.Text;
using MaskShop.Data.Parties;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Parties
{
    public abstract class PartyAttribute<T> : UniqueEntity<T> where T : PartyAttributeData, new()
    {
        protected internal PartyAttribute() : this(null) { }
        protected internal PartyAttribute(T d) : base(d) { }


        public string PartyId => Data?.PartyId ?? Unspecified;

        public Party Party => new GetFrom<IPartiesRepository, Party>().ById(PartyId);
    }
}



    
