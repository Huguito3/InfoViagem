using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace InfoViagem
{
	public partial class InfoViagemPage : ContentPage
	{
		Cidades ciudadOrigem;
		Cidades ciudadDestino;
		public string Origem{get; set;}
		public string Destino { get; set;}
		private string origem;
		public InfoViagemPage()
		{
			InitializeComponent();
			BindingContext = this;

		}

		async void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{

			string teste = e.NewTextValue;
			if (teste.Length > 4)
			{
				//string[] arstri;
				List<string> arstri = new List<string>();
				//var action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null,arstri);

				RestService service = new RestService();
				ResultadosLista listaCidades = await service.getCidadeAsync(teste);
				foreach (Cidades cidade in listaCidades.Results)
				{
					arstri.Add(cidade.name + "-" + cidade.c);
				}
				var action = await DisplayActionSheet("Escolha sua cidade", "Cancel", null, arstri.ToArray());
				string[] busqueda = action.Split('-');
				foreach (Cidades cidade in listaCidades.Results)
				{
					if ((cidade.name.Contains(busqueda[0])) && (cidade.c.Contains(busqueda[1])))
					{
						ciudadOrigem = cidade;
						Origem = cidade.name;

					}
				}
			}


		}

		async void Destino_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{

			string teste = e.NewTextValue;
			if (teste.Length > 4)
			{
				//string[] arstri;
				List<string> arstri = new List<string>();
				//var action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null,arstri);

				RestService service = new RestService();
				ResultadosLista listaCidades = await service.getCidadeAsync(teste);
				foreach (Cidades cidade in listaCidades.Results)
				{
					arstri.Add(cidade.name + "-" + cidade.c);
				}
				var action = await DisplayActionSheet("Escolha sua cidade", "Cancel", null, arstri.ToArray());
				string[] busqueda = action.Split('-');
				foreach (Cidades cidade in listaCidades.Results)
				{
					if ((cidade.name.Contains(busqueda[0])) && (cidade.c.Contains(busqueda[1])))
					{
						ciudadDestino = cidade;

					}
				}
			}


		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			RestService service = new RestService();
			var resultado = await service.getWeatherAsync(ciudadDestino.lat, ciudadDestino.lon);

			var resul = await service.convertToCurrencyAsync(verificarCidade(ciudadDestino.c), 1, verificarCidade(ciudadOrigem.c));

			//await DisplayAlert("Teste", resultado.ToString(), "Cancel");
			await Navigation.PushAsync(new Detalhes(ciudadOrigem,ciudadDestino,resul.to_amount,resultado));

		}

		private string verificarCidade(string pais)
		{
			string moeda="USD";
			if (pais == "BR")
			{
				moeda = "BRL";
			}
			else if (pais == "US")
			{
				moeda = "USD";
			}
			else if (pais == "FR" || pais == "ES" || pais == "IT"|| pais == "PT")
			{
				moeda = "EUR";
			}
			else if (pais == "GB")
			{
				moeda = "GBP";
			}


			return moeda;

		}


	}
}