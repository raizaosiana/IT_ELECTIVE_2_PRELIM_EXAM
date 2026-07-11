using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 4: GET List Categories
// TheMealDB API: https://themealdb.com/api/json/v1/1/categories.php
//
// Your task:
// 1. Use the HttpClient to fetch all meal categories
// 2. Assert status code is 200 OK
// 3. Parse the JSON and assert the "categories" array has more than 0 items
//
// Response format: { "categories": [{ "strCategory": "Beef", ... }, ...] }

public static class GetCategories
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Send GET request to https://themealdb.com/api/json/v1/1/categories.php
        // TODO: Assert status code is 200 OK
        // TODO: Parse the response JSON
        // TODO: Assert the "categories" array has more than 0 items

        // Send GET request
        var response = await client.GetAsync("https://themealdb.com/api/json/v1/1/categories.php");

        // Assert status code is 200 OK
        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Expected status code 200 OK.");

        // Read and parse the response JSON
        var body = await response.Content.ReadAsStringAsync();
        using var document = JsonDocument.Parse(body);

        // Get the categories array
        var categories = document.RootElement.GetProperty("categories");

        // Assert the array has more than 0 items
        if (categories.ValueKind == JsonValueKind.Null || categories.GetArrayLength() == 0)
            throw new Exception("No categories found.");
    }
}
