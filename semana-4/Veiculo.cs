using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeiculoNamespace
{
    public class Veiculo
    {
        private string? _modelo;
        public string? Modelo {
            get {return _modelo;}
            set {_modelo = value;}
        }
        private int _ano;
         public int Ano {
            get {return _ano;}
            set {_ano = value;}
        }
        private string? _cor;
          public string? Cor {
            get {return _cor;}
            set {_cor = value;}
        }

        private int _idadeVeiculo;
        public int IdadeVeiculo{
            get {
                int anoAtual = DateTime.Now.Year;
                int idade = anoAtual - this.Ano;
                return idade;
            }
        }
    }
}