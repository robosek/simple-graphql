using System.Collections.Generic;
using FirstGraphQL.Models;

namespace FirstGraphQL.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> Get();
        Person Get(string name);
    }
}