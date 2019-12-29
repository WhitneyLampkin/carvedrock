using CarvedRock.API.Data.Entities;
using CarvedRock.API.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarvedRock.API.GraphQL.Types
{
    public class ProductType: ObjectGraphType<Product>
    {
        public ProductType(ProductReviewRepository reviewRepository)
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("The name of the product");
            Field(t => t.Description);
            Field(t => t.IntroducedAt).Description("When the product was first introduced");
            Field(t => t.PhotoFileName).Description("The file name of the product's photo");
            Field(t => t.Price);
            Field(t => t.Rating).Description("The (max 5) star customer rating");
            Field(t => t.Stock);
            Field<ProductTypeEnumType>("Type", "The type of product");
            Field<ListGraphType<ProductReviewType>>(
                "reviews",
                resolve: context => reviewRepository.GetForProduct(context.Source.Id)
            );
        }
    }
}
