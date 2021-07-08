using System;

namespace CRUDCar
{
    class Program
    {   
        static AutomoveisRepositorio repositorio = new AutomoveisRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarAutomovel();
						break;
					case "2":
						InserirAutomovel();
						break;
					case "3":
						AtualizarAutomovel();
						break;
					case "4":
						AlterarStatusExcluido();
						break;
                  			case "5":
						VisualizarAutmovel();
						break;    
				    	case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}
			
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}
        
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Sistema de inserção de veículos a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar veículos");
            Console.WriteLine("2- Inserir veículo");
            Console.WriteLine("3- Atualizar veículo");
            Console.WriteLine("4- Excluir Locação ou Modificar Status");
            Console.WriteLine("5- Visualizar veículo");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarAutomovel()
        {
            Console.WriteLine("Lista de veículos:");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma veículo cadastrado!");
                return;
            }
            
            foreach (var veiculo in lista)
            {
                
                var excluido = veiculo.retornaExcluido();

                                
                Console.WriteLine("#ID {0}: - {1} {2}", veiculo.retornaId(), veiculo.retornaModelo(), (excluido ? "*Indisponível para locação*" : "*Disponivel para locação*"));
            }
        }

        private static void InserirAutomovel()
        {
            Console.WriteLine("Inserir novo veículo");

            foreach (int i in Enum.GetValues(typeof(Grupo)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Grupo), i));
            }
            Console.Write("Digite o grupo entre as opções acima: ");
            int entradaGrupo = int.Parse(Console.ReadLine());

            Console.WriteLine(" ");
            
            foreach (int i in Enum.GetValues(typeof(Combustivel)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Combustivel), i));
            }
            Console.Write("Digite o tipo de combustivel entre as opções acima: ");
            int entradaCombustivel = int.Parse(Console.ReadLine());

            Console.WriteLine(" ");

            Console.Write("Digite o modelo do veículo: ");
            string entradaModelo = Console.ReadLine();

            Console.Write($"Digite o consumo km/l : ");
            double entradaConsumo = double.Parse(Console.ReadLine());

            Console.Write("Digite a capacidade do tanque em litros: ");
            int entradaTanque = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de 1h de aluguel em R$: ");
            double entradaAluguel = double.Parse(Console.ReadLine());

            Automoveis novoAutomovel = new Automoveis(id: repositorio.ProximoId(),
                                        combustivel: (Combustivel)entradaCombustivel,
                                        grupo : (Grupo)entradaGrupo,
                                        modelo: entradaModelo,
                                        consumo: entradaConsumo,
                                        tanque: entradaTanque,
                                        aluguel: entradaAluguel);

            repositorio.Insere(novoAutomovel);
            
        }

        private static void AtualizarAutomovel()
        {
            Console.WriteLine("Atualizar veículo");
            Console.Write("Digite o id do veículo: ");
            int indiceAutomoveis = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Grupo)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Grupo), i));
            }
            Console.Write("Digite o grupo entre as opções acima: ");
            int entradaGrupo = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Combustivel)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Combustivel), i));
            }
            Console.Write("Digite o tipo de combustivel entre as opções acima: ");
            int entradaCombustivel = int.Parse(Console.ReadLine());

            Console.Write("Digite o modelo do veículo: ");
            string entradaModelo = Console.ReadLine();

            Console.Write($"Digite o consumo km/l : ");
            double entradaConsumo = double.Parse(Console.ReadLine());

            Console.Write("Digite a capacidade do tanque em litros: ");
            int entradaTanque = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de 1h de aluguel em R$: ");
            double entradaAluguel = double.Parse(Console.ReadLine());

            Automoveis atualizaAutomovel = new Automoveis(id: indiceAutomoveis,
                                        combustivel: (Combustivel)entradaCombustivel,
                                        grupo : (Grupo)entradaGrupo,
                                        modelo: entradaModelo,
                                        consumo: entradaConsumo,
                                        tanque: entradaTanque,
                                        aluguel: entradaAluguel);

            repositorio.Atualiza(indiceAutomoveis, atualizaAutomovel);
        }

        private static void VisualizarAutmovel()
        {
            Console.Write("Digite o id da veículo: ");
            int indiceAutomoveis = int.Parse(Console.ReadLine());

            var automovel = repositorio.RetornaPorId(indiceAutomoveis);

            Console.WriteLine(automovel);
        }

            private static void AlterarStatusExcluido()
        {   
            //No curso é apresentado Excluir com método de retorno tipo bool.
            //Como os dados continuam na lista, resolvi reverter o status caso seja modificado errado ou alugado.
            //Considerando indisponível um carro alugado e excluído temporariamente da possibilidade de locação.
            Console.Write("Digite o id da veículo: ");
            int indiceAutomoveis = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceAutomoveis);
        }

    }
}
