using System;
using System.Collections.Generic;
using CondoBike.Model;
using Bogus;
using Bogus.Extensions.Brazil;
using System.Linq;

namespace CondoBike.Tests.Fixtures
{
    public class OwnerFixture
    {
        public Owner GetCorrectOwnerForBicycle(Bicycle b)
        {   
            var fakeContact = new Faker<Contact>()
                .RuleFor(c => c.ContactID, set => set.Random.Number(100,200))
                .RuleFor(c => c.ContactTelefone, set => set.Phone.PhoneNumber())
                .Generate();

            var correctOwner  = new Faker<Owner>()
                .RuleFor( o => o.OwnerID, set => set.Random.Number(1,50))
                .RuleFor( o => o.OwnerContact, set => new List<Contact>(){fakeContact})
                .RuleFor( o => o.OwnerResidence, set => new Residence(set.Random.Number(101,504), set.Random.Number(1,15)))
                .RuleFor( o => o.OwnerCPF, set => set.Person.Cpf())
                .RuleFor( o => o.OwnerBicycle, set=> new List<Bicycle>(){b})
                .Generate();

            return correctOwner;   
        }

        public List<Owner> GetCorrectOwners()
        {
            throw new NotImplementedException();
        }
        public List<Owner> GetOwnerWithoutContact()
        {
            throw new NotImplementedException();
        }

        public List<Owner> GetOwnerWithoutResidence()
        {
            throw new NotImplementedException();
        }
    }
}