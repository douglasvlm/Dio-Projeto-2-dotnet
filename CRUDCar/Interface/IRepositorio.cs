using System.Collections.Generic;

namespace CRUDCar.Interface
{
     public interface IRepositorio<A>
    {
        List<A> Lista();
        A RetornaPorId(int id);        
        void Insere(A entidade);        
        void Exclui(int id);        
        void Atualiza(int id, A entidade);
        int ProximoId();
    }
}