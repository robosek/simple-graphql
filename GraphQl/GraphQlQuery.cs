using FirstGraphQL.GraphQl.Types;
using FirstGraphQL.Services;
using GraphQL.Types;

namespace FirstGraphQL.GraphQl
{
    public class GraphQlQuery : ObjectGraphType
    {
        public GraphQlQuery(IPersonService personService)
        {
            Field<ListGraphType<PersonType>>(
                "persons",
                resolve: context =>
                {
                    return personService.Get();
                }
            );

            Field<PersonType>(
                "person",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "Name", Description = "Person name" }
                ),
                resolve: context =>
                {
                    string name = context.GetArgument<string>("Name");
                    return personService.Get(name);
                }
            );
        }
    }
}