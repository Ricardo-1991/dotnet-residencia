using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Personas
{

    public abstract class Pessoa {
        public string? nome;
        public DateTime dataNascimento;

        public Pessoa(string _nome, DateTime _dataNascimento){
            nome = _nome;
            dataNascimento = _dataNascimento;
        }
        protected string? _cpf;
         public string? Cpf {
            get{return _cpf;}
            set{
                try{
                    if (string.IsNullOrEmpty(value)){
                        _cpf = null;
                        return;
                    }
                    string cpfNumerico = Regex.Replace(value, @"[^\d]", "");

                    if (cpfNumerico.Length == 11){
                        _cpf = cpfNumerico;
                    }
                    else{
                        throw new ArgumentException("O CPF deve ter exatamente 11 dígitos.");
                    }
                }catch (Exception err){
                    Console.WriteLine($"Erro: {err.Message}");
                }
            }
        }

    }
    public class Advogado : Pessoa{
        
        public Advogado(string _nome, DateTime _dataNascimento) :base( _nome, _dataNascimento){}
        private string? _cna;

        public string? Cna {
            get{return _cna;}
            set{_cna = value;}
        }
    }

     public class Cliente : Pessoa{
        public string? estadoCivil;
        public string? profissao;

        public Cliente(string _nome, DateTime _dataNascimento, string estadoCivil, string profissao) :base(_nome, _dataNascimento){}
    }
}