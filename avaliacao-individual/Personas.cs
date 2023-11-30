using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personas
{

    public abstract class Pessoa {
        public string? nome;
        public DateTime dataNascimento;
        protected string? _cpf;
         public string? Cpf {
            get{return _cpf;}
            set{
                try{
                    if(value?.Length > 11){
                    _cpf = value;
                    } else {
                        throw new("CPF somente deve ter 11 dígitos.");
                    }
                }catch (Exception err){
                    Console.WriteLine($"Erro: {err.Message}");
                }
            }
        }

    }
    public class Advogado : Pessoa{
     
        private string? _cna;

        public string? cna {
            get{return _cna;}
            set{_cna = value;}
        }
    }

     public class Cliente : Pessoa{

        public string? estadoCivil;
        public string? profissao;
    }
}