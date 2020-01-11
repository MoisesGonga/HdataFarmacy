using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class ProdutoItemVenda : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public produto Produto { get; set; }




        private string codigoBarra_;
        public string CodigoBarra
        {
            get { return codigoBarra_; }
            set
            {
                codigoBarra_ = value;
                OnPropertyChanged("CodigoBarra");
            }
        }

        private string descricao_;
        public string Descricao
        {
            get { return descricao_; }
            set
            {
                descricao_ = value;
                OnPropertyChanged("Descricao");
            }
        }

        private string lote_;
        public string Lote
        {
            get { return lote_; }
            set
            {
                lote_ = value;
                OnPropertyChanged("Lote");
            }
        }

        private DateTime validade_;
        public DateTime Validade
        {
            get { return validade_; }
            set
            {
                validade_ = value;
                OnPropertyChanged("Validade");
            }
        }

        private int quant_;
        public int Quant
        {
            get { return quant_; }
            set
            {
                quant_ = value;
                OnPropertyChanged("Quant");
            }
        }

        private string unidade_;
        public string Unidade
        {
            get { return unidade_; }
            set
            {
                unidade_ = value;
                OnPropertyChanged("Unidade");
            }
        }

        private double precoUnit_;
        public double PrecoUnit
        {
            get { return precoUnit_; }
            set
            {
                precoUnit_ = value;
                OnPropertyChanged("PrecoUnit");
            }
        }

        private double valorTotal_;
        public double ValorTotal
        {
            get { return valorTotal_; }
            set {
                valorTotal_ = value;
                OnPropertyChanged("ValorTotal");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
