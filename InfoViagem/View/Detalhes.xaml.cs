using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InfoViagem
{
	public partial class Detalhes 
	{
		Cidades cidadeIni, cidadeFim;
		string[] moedas = { "BRL","USD","EUR"};
		public Detalhes(Cidades origem, Cidades destino)
		{
			this.cidadeIni = origem;
			this.cidadeFim = destino;
			InitializeComponent();

			RestService service = new RestService();
			var resultado =  service.getWeatherAsync(cidadeFim.lat, cidadeFim.lon);
			DisplayAlert("Teste", resultado.ToString(), "Cancel");
			
		}




	}
}



