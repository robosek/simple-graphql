using FirstGraphQL.Models;
using GraphQL.Types;

namespace FirstGraphQL.GraphQl.Types
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {   
            Field(x=>x.Name).Description("Person name");
            Field(x=>x.LastName).Description("Person last name");
            Field(x=>x.SecondName).Description("Person second name");
            Field(x=>x.Age).Description("Age");
            Field(x=>x.Gender).Description("Person gender");
        }
    }
}