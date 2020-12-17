using System;
using MaskShop.Data.Parties;
using MaskShop.Domain.Common;

namespace MaskShop.Domain.Parties
{
    public sealed class ContactMechanism: UniqueEntity<ContactMechanismData>
    {
       public ContactMechanism(ContactMechanismData d) : base(d) { }

       public string Street => Data?.Street ?? Unspecified;
       public string City => Data?.City ?? Unspecified;
       public string State => Data?.State ?? Unspecified;
       public string ZipCode => Data?.ZipCode ?? Unspecified;
       public string Country => Data?.Country ?? Unspecified;

       public string Address
       {
           get
           {
               var a = address().Trim();
               if (IsUnspecified(a)) return Unspecified;
               return a;
           }
       }

       private string address() => Add(zipCode, Country);
       private string zipCode() => Add(state, ZipCode);
       private string state() => Add(city, State);
       private string city() => Add(street, City);
       private string street() => (IsUnspecified(Street) ? string.Empty : Street).Trim();
       private static string Add(Func<string> head, string tail) =>
           (IsUnspecified(tail) ? head() : $"{head()} {tail}").Trim();
       public override string ToString() => Address;

       public string ElectronicMail => Data?.ElectronicMail ?? Unspecified;
    }
}

