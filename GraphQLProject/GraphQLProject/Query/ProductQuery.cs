using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProduct productService)
        {
            Field<ListGraphType<ProductType>>("products", resolve: context => { return productService.GetAllProducts(); });
            Field<ProductType>("product", arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                                resolve: context => 
                                {
                                    var retorno = productService.GetProductById(context.GetArgument<int>("id"));
                                    if (retorno == null)
                                        throw new ExecutionError("Valor invalido");
                                    return retorno;
                                });
        }
    }
}
