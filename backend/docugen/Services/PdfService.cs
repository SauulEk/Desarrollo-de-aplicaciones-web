using System.Text;
using System.Text.Json;
using HandlebarsDotNet;
using docugen.Models;
using DotNetEnv;

namespace docugen;

//Inserta los datos del usuario al html y hace una peticion 
//a una api que realiza la conversion de html a pdf
public class PdfService
{
    private HttpClient httpClient;

    public PdfService()
    {
        this.httpClient = new HttpClient();
        Env.Load();

        string? apiKey = Environment.GetEnvironmentVariable("API_KEY");

        httpClient.DefaultRequestHeaders.Add("x-api-key", "AHUEVO");
    }

    public async Task<Stream> RetrievePdf(string html, CvData data)
    {
        StringContent jsonContent = new(JsonSerializer.Serialize(new
        {
            html = GenerateCvHtml(html, data)
        }),
    Encoding.UTF8,
    "application/json");

        HttpResponseMessage response = await httpClient.PostAsync("http://172.17.0.1:1234/convert", jsonContent);
        response.EnsureSuccessStatusCode();
        Stream stream = await response.Content.ReadAsStreamAsync();

        return stream;
    }

    public string GenerateCvHtml(string html, CvData data)
    {
        var template = Handlebars.Compile(html);
        string finalHtml = template(data);
        return finalHtml;
    }
}
