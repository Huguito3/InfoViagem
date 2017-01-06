using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InfoViagem
{
	public partial class Detalhes 
	{
		Cidades cidadeIni, cidadeFim;
		float valorMoeda;
		string climaCidade;
		public string randomText { get; set; }
		public string cielo { get; set; }
		public string titulo { get; set; }
		public string temperatura { get; set; }
		public string textoMoeda { get; set; }
		public Detalhes(Cidades origem, Cidades destino, float valor,string clima)
		{
			this.cidadeIni = origem;
			this.cidadeFim = destino;
			this.valorMoeda = valor;
			this.climaCidade = clima;
			randomText = cidadeIni.c;

			InitializeComponent();

			List<string> temp = new List<string>(climaCidade.Split(','));
			temp.Reverse();

			titulo = "Clima e temperatura na cidade de " + cidadeFim.name;
			temperatura = temp[2];
			if (temp[1].IndexOf("Cloud") > 0 || temp[1].IndexOf("Cloudy") > 0 || temp[1].IndexOf("Rain") > 0 || temp[1].IndexOf("Storm") > 0)
			{
				cielo = "storm.png";
			}
			else {cielo = "sol.png"; }
			textoMoeda = "1"+verificarCidade(origem.c)+" equivale a "+valorMoeda.ToString()+verificarCidade(destino.c);
			BindingContext = this;
			
		}

		private string verificarCidade(string pais)
		{
			string moeda = "USD";
			if (pais == "BR")
			{
				moeda = "BRL";
			}
			else if (pais == "US")
			{
				moeda = "USD";
			}
			else if (pais == "FR" || pais == "ES" || pais == "IT" || pais == "PT")
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



