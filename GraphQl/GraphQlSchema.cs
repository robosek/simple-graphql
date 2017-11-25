using System;
using GraphQL.Types;

namespace FirstGraphQL.GraphQl
{
    public class GraphQlSchema : Schema
    {
         public GraphQlSchema(Func<Type, GraphType> resolveType): base(resolveType)
        {
            Query = (GraphQlQuery)resolveType(typeof(GraphQlQuery));
        }
    }
}