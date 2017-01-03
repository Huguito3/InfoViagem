using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using InfoViagem;

public class RestService
{
    HttpClient client;
    public List<Currency> currencies { get; set; }
    public CurrencyConvertResponse currencyConvert { get; set; }
    public CidadesResponse cidadesResponse { get; set; }
    public List<Cidades> cidadesLista { get; set;}
	public Cidades cidadeUnica { get; set; }

    public RestService()
    {
        client = new HttpClient();
        client.MaxResponseContentBufferSize = 256000;
        client.DefaultRequestHeaders.Add("X-Mashape-Key", "tOsmZXLhTJmshLLhcddGCqFYUUvgp16UbZdjsnzmyvpD5KNYIj");
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<List<Currency>> getAvailableCurrenciesAsync()
    {
        var uri = new Uri(string.Format("https://currencyconverter.p.mashape.com/availablecurrencies", string.Empty));
        var response = await client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(content);
            currencies = JsonConvert.DeserializeObject<List<Currency>>(content);
        }
        return currencies;
    }

    public async Task<CurrencyConvertResponse> convertToCurrencyAsync(string from, float from_amount, string to)
    {
        var uri = new Uri(string.Format("https://currencyconverter.p.mashape.com?from=" + from + "&from_amount=" + from_amount.ToString() +"&to=" + to, string.Empty));
        var response = await client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(content);
            currencyConvert = JsonConvert.DeserializeObject<CurrencyConvertResponse>(content);
        }
        return currencyConvert;
    }


	public async Task<List<Cidades>> getCidadesAsync(string cidade)
	{
		var uri = new Uri(string.Format("https://devru-latitude-longitude-find-v1.p.mashape.com/latlon.php?location=" +cidade, string.Empty));
		var response = await client.GetAsync(uri);
		if (response.IsSuccessStatusCode)
		{
			var content = await response.Content.ReadAsStringAsync();
			Debug.WriteLine(content);
			cidadesResponse = JsonConvert.DeserializeObject<CidadesResponse>(content);
		}
		return cidadesResponse.Results;
	}

	public async Task<Cidades> getCidadeAsync(string cidade)
	{
		var uri = new Uri(string.Format("https://devru-latitude-longitude-find-v1.p.mashape.com/latlon.php?location=" + cidade, string.Empty));
		var response = await client.GetAsync(uri);
		if (response.IsSuccessStatusCode)
		{
			var content = await response.Content.ReadAsStringAsync();
			Debug.WriteLine(content);
			cidadesResponse = JsonConvert.DeserializeObject<CidadesResponse>(content);
				
		}
		return cidadesResponse.Results.First();
	}
}
