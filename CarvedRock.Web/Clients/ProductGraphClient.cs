using CarvedRock.Web.Models;
using GraphQL.Client;
using GraphQL.Common.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.Web.Clients
{
    public class ProductGraphClient
    {
        private readonly GraphQLClient _client;

        public ProductGraphClient(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<Product> GetProduct(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @"query productQuery($productId:ID!) {
                          product(id:$productId) {
                            id name price rating photoFileName description stock introducedAt
                            reviews { title review }
                          }
                        }",
                Variables = new {productId = id}
            };

            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<Product>("product");
        }
    }
}
