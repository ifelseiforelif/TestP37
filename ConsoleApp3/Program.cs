using Newtonsoft.Json;
using System.Net.Http;
using System.Text.RegularExpressions;

/*
 * Додати до вивода курс валюти. Зберегти всі дані у файл
 * Запитати у користувача кількість гривень та перевести 
 * їх у долари відповідно до курса
 */
class Currency
{
    public int r030 { get; set; }
    public string txt { get; set; }

    public decimal rate { get; set; }
}
class Program
{
    public static async void GetData()
    {
        string url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url);
        if(response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<Currency>>(jsonContent);
            foreach (Currency item in data)
            {
                Console.WriteLine($"Code: {item.r030}, Name: {item.txt}, Rate: {item.rate}");
            }
        }

    }
   
    static void Main()
    {
        string input = "Мій email: user@example.com і ще один: admin@test.com";
        string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b"; //
        MatchCollection matches = Regex.Matches(input, pattern);
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
        Console.WriteLine("Hello World!");
    }
}

