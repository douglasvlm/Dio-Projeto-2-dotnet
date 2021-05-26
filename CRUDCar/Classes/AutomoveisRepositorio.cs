using System;
using System.Collections.Generic;
using CRUDCar.Interface;

namespace CRUDCar
{
    public class AutomoveisRepositorio : IRepositorio<Automoveis>
    {   
        private List<Automoveis> listAutomoveis = new List<Automoveis>();
       public void Atualiza(int id, Automoveis objeto)
		{
			listAutomoveis[id] = objeto;
		}

		public void Exclui(int id)
		{
			listAutomoveis[id].Excluir();
		}

		public void Insere(Automoveis objeto)
		{
			listAutomoveis.Add(objeto);
		}

		public List<Automoveis> Lista()
		{
			return listAutomoveis;
		}

		public int ProximoId()
		{
			return listAutomoveis.Count;
		}

		public Automoveis RetornaPorId(int id)
		{
			return listAutomoveis[id];
		}
    }
}