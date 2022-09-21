using Newtonsoft.Json.Linq;
using TranslatorApp;

var sourceLanguage = Language.SelectSourceLanguage();
var targetLanguage = Language.SelectTargetLanguage();

Console.WriteLine("enter a word or phrase to translate");
var phrase = Console.ReadLine();

var client = new HttpClient();
var request = new HttpRequestMessage
{
	Method = HttpMethod.Post,
	RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
	Headers =
	{
		{ "X-RapidAPI-Key", "fe96c29976msh7164fa7f072bef1p19efc6jsn0ad83cbe2bb2" },
		{ "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
	},
	Content = new FormUrlEncodedContent(new Dictionary<string, string>
	{
		{ "q", phrase },
		{ "target", targetLanguage },
		{ "source", sourceLanguage },
	}),
};
using (var response = await client.SendAsync(request))
{
	response.EnsureSuccessStatusCode();
	var body = await response.Content.ReadAsStringAsync();
	Console.WriteLine(body);
}


