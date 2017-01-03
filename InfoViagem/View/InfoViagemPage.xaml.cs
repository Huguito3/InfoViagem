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

		async void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			string teste = e.NewTextValue;
			if (teste.Length > 2)
			{
				//DisplayAlert("Alert", teste, "OK");
				RestService service = new RestService();
				Cidades cidades = await service.getCidadeAsync(teste);
				System.Diagnostics.Debug.WriteLine("Cidade: " + cidades.name);
				

			}


		}


	}
}