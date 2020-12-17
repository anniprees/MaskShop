using System;
using MaskShop.Data.Parties;

namespace MaskShop.Domain.Parties
{
    public sealed class PartyName: PartyAttribute<PartyNameData>
    {
        public PartyName() : this(null) { }

        public PartyName(PartyNameData d) : base(d) { }
        
        public string FirstName => Data?.FirstName ?? Unspecified;
        public string MiddleName => Data?.MiddleName ?? Unspecified;
        public string LastName => Data?.LastName ?? Unspecified;

        public string Name
        {
            get
            {
                var a = name().Trim();
                if (IsUnspecified(a)) return Unspecified;
                return a;
            }
        }

        private string name() => Add(middleName, LastName);
        private string middleName() => Add(firstName, MiddleName);
        private string firstName() => (IsUnspecified(FirstName) ? string.Empty : FirstName).Trim();

        private static string Add(Func<string> head, string tail) =>
            (IsUnspecified(tail) ? head() : $"{head()} {tail}").Trim();
        public override string ToString() => Name;
    }
}

