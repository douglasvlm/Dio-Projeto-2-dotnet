using System;

namespace CRUDCar
{
    public class Automoveis : IdClasseAbstrata
    {
        public Automoveis(string modelo, double consumo, int tanque, double aluguel) 
        {
            this.Modelo = modelo;
            this.Consumo = consumo;
            this.Tanque = tanque;
            this.Aluguel = aluguel;
               
        }
         private string Modelo { get; set; }
        private Combustivel Combustivel  { get; set; }
        private Grupo Grupo  { get; set; }
        private double Consumo { get; set; }
        private int Tanque { get; set; }   
        private double Aluguel { get; set; }
        private bool Excluido { get; set; }
    
        public Automoveis(int id, string modelo, Combustivel combustivel, Grupo grupo, double consumo, int tanque, double aluguel)
        {   
                this.Id = id;
                this.Modelo = modelo;
                this.Combustivel = combustivel;
                this.Grupo = grupo;
                this.Consumo = consumo;
                this.Tanque = tanque;
                this.Aluguel = aluguel;
                this.Excluido = false;
        }
    
        public override string ToString()
		{
            string retorno = "";
            retorno += "Grupo " + this.Grupo + Environment.NewLine;
            retorno += "Modelo " + this.Modelo + Environment.NewLine;
            retorno += "Combustível " + this.Combustivel + Environment.NewLine;
            retorno += "Consumo " + this.Consumo + " Km/l" + Environment.NewLine;
            retorno += "Tanque " + this.Tanque + " Ltrs " + Environment.NewLine;
            retorno += "Aluguel " + this.Aluguel + " R$/h" + Environment.NewLine;
            if(this.Excluido){
                retorno += "Status: Insdisponível.";    
            }else{
                retorno += "Status: Disponivel.";
            }
            return retorno;
		}

        public string retornaModelo()
        {
            return this.Modelo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {   
            if(this.Excluido == true){
                this.Excluido = false;
            }else{
                this.Excluido = true;
            }   
        }

        public bool retornaExcluido()
		{
			return this.Excluido;
		}
    
    }
}