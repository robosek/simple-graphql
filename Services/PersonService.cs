using System.Collections.Generic;
using FirstGraphQL.Models;
using GenFu;
using System.Linq;

namespace FirstGraphQL.Services
{
    public class PersonService : IPersonService
    {
        private IList<Person> _persons = A.ListOf<Person>(100);

        public IEnumerable<Person> Get()
        {
            return _persons;
        }

        public Person Get(string name)
        {
            return _persons
                    .Where(person => string.Equals(person.Name, name))
                    .FirstOrDefault();
        }
    }
}