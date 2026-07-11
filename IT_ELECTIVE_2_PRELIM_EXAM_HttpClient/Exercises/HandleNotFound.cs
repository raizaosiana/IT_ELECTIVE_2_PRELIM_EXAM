using System.Net;
using System.Text.Json;
namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 9: GET Handle 404 Not Found
// TheMealDB API: https://themealdb.com/api/json/v1/1/lookup.php?i={id}
//
// Your task:
// 1. Use the HttpClient to look up a meal with an ID that doesn't exist (ID 999999)
// 2. Assert the HTTP status code is 200 OK (TheMealDB always returns 200)
// 3. Parse the JSON and assert that the "meals" field is null
//    (meaning no meal was found for that ID)
//
// This teaches: APIs can return 200 OK but still indicate "not found"
// in the response body via null data.

public static class HandleNotFound
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Send GET request to https://themealdb.com/api/json/v1/1/lookup.php?i=999999
        // TODO: Assert status code is 200 OK
        // TODO: Parse the response JSON
        // TODO: Assert that "meals" field is null (not found)

        var response = await client.GetAsync("https://themealdb.com/api/json/v1/1/lookup.php?i=999999");

        // Assert status code is 200 OK
        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Expected status code 200 OK.");

        // Read and parse the response JSON
        var body = await response.Content.ReadAsStringAsync();
        using var document = JsonDocument.Parse(body);

        // Assert that "meals" field is null
        var meals = document.RootElement.GetProperty("meals");

        if (meals.ValueKind != JsonValueKind.Null)
            throw new Exception("Expected meals to be null.");
    }
}
