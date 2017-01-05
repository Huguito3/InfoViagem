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
		public string Origem { 
			get { return origem;}
			set
			{
				origem = value;

			}
		}
		public string destino { get; set;}
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
						origem = cidade.name;

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
			await DisplayAlert("Teste", resultado.ToString(), "Cancel");
			//await Navigation.PushAsync(new Detalhes(ciudadOrigem,ciudadDestino));

		}
	}
}