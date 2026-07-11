using System.Net;
using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 6: POST Create Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts
//
// Your task:
// 1. Create a JSON body string: { "title": "Great Pasta!", "body": "Loved this recipe", "userId": 1 }
// 2. Wrap it in StringContent with media type "application/json"
// 3. Send a POST request to the URL
// 4. Assert status code is 201 Created
// 5. Parse the response JSON and assert it contains an "id" field
//
// Hint: Use await client.PostAsync(url, content)
// Hint: Use new StringContent(json, Encoding.UTF8, "application/json")

public static class CreateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Create JSON string with title, body, and userId
        // TODO: Create StringContent with the JSON and Content-Type "application/json"
        // TODO: Send POST request to https://jsonplaceholder.typicode.com/posts
        // TODO: Assert status code is 201 Created
        // TODO: Parse the response JSON
        // TODO: Assert the response has an "id" field with a value

        string json = @"{
            ""title"": ""Great Pasta!"",
            ""body"": ""Loved this recipe"",
            ""userId"": 1
        }";

        // Create StringContent
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Send POST request
        var response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", content);

        // Assert status code is 201 Created
        if (response.StatusCode != HttpStatusCode.Created)
            throw new Exception("Expected status code 201 Created.");

        // Read and parse the response JSON
        var body = await response.Content.ReadAsStringAsync();
        using var document = JsonDocument.Parse(body);

        // Assert the response contains an "id" field
        if (!document.RootElement.TryGetProperty("id", out var id) || id.GetInt32() <= 0)
            throw new Exception("Response does not contain a valid id.");
    }
}
