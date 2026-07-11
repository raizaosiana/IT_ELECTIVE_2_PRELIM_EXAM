using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 10: GET Deserialize Multiple Meals
// TheMealDB API: https://themealdb.com/api/json/v1/1/search.php?f=a
//
// This endpoint returns ALL meals starting with the letter "a".
//
// Your task:
// 1. Use the HttpClient to fetch meals starting with letter "a"
// 2. Assert status code is 200 OK
// 3. Parse the JSON and get the "meals" array
// 4. Assert the array has more than 0 items
// 5. Loop through each meal and print its name (strMeal)
//
// Response format:
// {
//   "meals": [
//     { "idMeal": "52772", "strMeal": "Arrabiata", ... },
//     { "idMeal": "52781", "strMeal": "Ayam Percik", ... },
//     ...
//   ]
// }

public static class DeserializeMeals
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        // TODO: Send GET request to https://themealdb.com/api/json/v1/1/search.php?f=a
        // TODO: Assert status code is 200 OK
        // TODO: Parse the response JSON
        // TODO: Get the "meals" array
        // TODO: Assert the array has more than 0 items
        // TODO: Loop through and print each meal's strMeal

        var response = await client.GetAsync("https://themealdb.com/api/json/v1/1/search.php?f=a");

        // Assert status code is 200 OK
        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Expected status code 200 OK.");

        // Read and parse the response JSON
        var body = await response.Content.ReadAsStringAsync();
        using var document = JsonDocument.Parse(body);

        // Get the meals array
        var meals = document.RootElement.GetProperty("meals");

        // Assert the array has more than 0 items
        if (meals.ValueKind == JsonValueKind.Null || meals.GetArrayLength() == 0)
            throw new Exception("No meals found.");

        // Loop through and print each meal's name
        foreach (var meal in meals.EnumerateArray())
        {
            Console.WriteLine(meal.GetProperty("strMeal").GetString());
        }
    }
}
