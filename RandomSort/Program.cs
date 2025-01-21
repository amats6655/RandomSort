using System.Diagnostics;
using System.Text;
using System.Text.Json;
using RandomSort; 

public static class Program
{
    public static async Task Main()
    { 
		string serverUrl = "";
		try
		{
        var configText = File.ReadAllText("appsettings.json");
        var jsonDoc = JsonDocument.Parse(configText);
			serverUrl = jsonDoc.RootElement.GetProperty("ServerName").GetString();
		}
		catch (FileNotFoundException)
		{
			Console.WriteLine("Файл appsettings.json не найден");
			Console.ReadKey();
			return;
		}
		catch (JsonException)
		{
			Console.WriteLine("Не удалось распарсить файл appsettings.json.");
			Console.ReadKey();
			return;
		}
		catch (KeyNotFoundException)
		{
			Console.WriteLine("Не удалось найти ServerName в appsettings.json");
			Console.ReadKey();
			return;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Console.ReadKey();
			return;
		}


        if (string.IsNullOrEmpty(serverUrl))
        {
			Console.WriteLine("Не удалось найти ServerName в appsettings.json");
			Console.ReadKey();
            return;
        }

        var numbers = RandomService.GenerateNumbers();
        var sortType = RandomService.GenerateSortType();

        var watcher = Stopwatch.StartNew();
        var result = SortService.Sort(sortType, numbers);
        watcher.Stop();

        ViewService.Print(watcher, numbers, result, sortType);

        await SendToApiAsync(serverUrl, result);
    }

    private static async Task SendToApiAsync(string url, int[] data)
    {
        try
        {
            var jsonData = JsonSerializer.Serialize(data);
            using var client = new HttpClient();

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
                Console.WriteLine("Данные успешно отправлены на сервер!");
            else
                Console.WriteLine($"Ошибка при отправке: {response.StatusCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Исключение при отправке данных: {ex.Message}");
        }
    }
}