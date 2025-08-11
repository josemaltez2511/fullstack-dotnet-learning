using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using FruitWebApp.Models;
using System.Text.Json;
using System.Text;

namespace FruitWebApp.Components.Pages;

public partial class Add : ComponentBase
{
    // IHttpClientFactory set using dependency injection 
    [Inject]
    public required IHttpClientFactory HttpClientFactory { get; set; }

    // NavigationManager set using dependency injection
    [Inject]
    private NavigationManager? NavigationManager { get; set; }

    // Add the data model and bind the form data to it
    [SupplyParameterFromForm]
    private FruitModel? _fruitList { get; set; }

    protected override void OnInitialized() => _fruitList ??= new();

    // Begin POST operation code
    private async Task Submit()
    {
        // Serializing the information to submit 
        var jsonContent = new StringContent(JsonSerializer.Serialize(_fruitList),
        Encoding.UTF8,
        "application/json");

        // CREATING a http client using the FruitApi named factory
        var httpClient = HttpClientFactory.CreateClient("FruitApi");

        //     // Execute the POST request and store the response. The response will contain the new record's ID
        using HttpResponseMessage response = await httpClient.PostAsync("/fruits", jsonContent);

        if (response.IsSuccessStatusCode)
        {
            NavigationManager?.NavigateTo("/");
        }
        else
        {
            Console.WriteLine($"FAILED to add fruit. Status Code: {response.StatusCode}");
        }

    }
    // End POST operation code
}