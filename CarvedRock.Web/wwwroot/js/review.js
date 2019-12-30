const apolloClient = new Apollo.lib.ApolloClient({
    networkInterface: Apollo.lib.createNetworkInterface({
        uri: 'http://localhost:5000/graphql'
    })
});

function renderReviews(productId) {
    const query = Apollo.gql`
        query reviewsForProduct($productId: ID!)
        {
            reviews(productId: $productId) 
            {
                title
                review
            }
        }
    `;

    apolloClient
        .query({
            query: query,
            variables: { productId: productId }
        }).then(result => {
            const div = document.getElementById("reviews");
            result.data.reviews.forEach(review => {
                div.innerHTML += `
                    <div class="row">
                        <div class="col-12"><h5>${review.title}</h5></div>
                    </div>
                    <div class="row mb-2">
                        <div class="col-12"><h5>${review.review}</h5></div>
                    </div>
                `
            });
        });
}