using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoViagem.ViewModel
{
    public class InfoViagemViewModel : INotifyPropertyChanged
    {
        string origem, destino;

        public string Origem
        {
            get
            {
                return origem;
            }
            set
            {
                if (origem != value)
                {
                    origem = value;
                    OnPropertyChanged("Origem");
                }
            }
        }
        public string Destino
        {
            get
            {
                return destino;
            }
            set
            {
                if (destino != value)
                {
                    destino = value;
                    OnPropertyChanged("Destino");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
