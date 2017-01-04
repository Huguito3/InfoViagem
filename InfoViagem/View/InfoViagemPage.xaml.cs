using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace InfoViagem
{
	public  partial class InfoViagemPage : ContentPage
	{
		public InfoViagemPage()
		{
			InitializeComponent();

		}
		Cidades ciudadOrigem;
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

					}
				}
			}


		}

		void Termino(object sender, EventArgs e)
		{
			DisplayAlert("", "", "cancel");
		}
	}
}