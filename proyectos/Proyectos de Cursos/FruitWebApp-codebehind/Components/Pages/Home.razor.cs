using Microsoft.AspNetCore.Components;
using FruitWebApp.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Web;

namespace FruitWebApp.Components.Pages;

public partial class Home : ComponentBase
{
    // IHttpClientFactory set using dependency injection 
    [Inject]
    public required IHttpClientFactory HttpClientFactory { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    /* Add the data model, enumerable since an array is expected as a response */
    private IEnumerable<FruitModel>? _fruitList;

    // Begin GET operation code

    protected override async Task OnInitializedAsync()
    {
        //Create the HttpClient using the name "FruitApi"
        var httpClient = HttpClientFactory.CreateClient("FruitApi");
        // Make a GET request and store the response, the parameter in GetAsync specifies to the /fruits endpoint in the API
        var HttpResponseMessage = await httpClient.GetAsync("/fruits");

        //GetAsync sents an HTTP GET request to the specified URI and returns the response message.
        //using USING statement to ensure the response is disposed of properly after use.
    using HttpResponseMessage response = await httpClient.GetAsync("/fruits");

        // Check if the response is successful
        if (response.IsSuccessStatusCode)
        {
            // If the response is successful, read the content as a stream and deserialize it into the collection of FruitModel
            using var contentStream = await response.Content.ReadAsStreamAsync();
            // Deserialize the JSON content into the _fruitList collection
            // JsonSerializer.DeserializeAsync is used to deserialize the JSON data from the stream into the specified type
            // The type is specified as IEnumerable<FruitModel> to match the expected structure of
            _fruitList = await JsonSerializer.DeserializeAsync<IEnumerable<FruitModel>>(contentStream);
        }
        else
        { 
            Console.WriteLine($"Failed to load fruits. Status code: {response.StatusCode}");
            // Handle the error as needed, e.g., log it or show a message to the user 
        }

    }

    // End GET operation code

    private void DeleteButton(int id) => NavigationManager!.NavigateTo($"/delete/{id}");
    private void EditButton(int id) => NavigationManager!.NavigateTo($"/edit/{id}");

}