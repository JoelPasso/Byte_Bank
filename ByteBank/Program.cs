using System.Runtime.CompilerServices;

namespace ByteBank
{
    public class Program
    {
        static void MostrarMenu()
        {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Apagar um usuário");
            Console.WriteLine("3 - Listar todas as contas");
            Console.WriteLine("4 - Informações do Cliente");
            Console.WriteLine("5 - Valor em conta");
            Console.WriteLine("6 - Manipular conta");
            Console.WriteLine("0 - Para encerrar acesso");
            Console.WriteLine("Digite a opção desejada");

        }

        static void CadastrarNovoUsuario(List<string> cpf, 
            List<string> titular, List<string> senha, List<double> saldo)
        {
            //CPF do cliente
            Console.Write("Informe o número do CPF: ");
            cpf.Add(Console.ReadLine());

            //nome do cliente titular da conta
            Console.Write("Informe seu nome:");
            titular.Add(Console.ReadLine());

            //campo para digitar a senha do cliente
            Console.Write("Entre com sua senha");
            senha.Add(Console.ReadLine());

            //inicio da conta com saldo zero
            saldo.Add(0);
        }

        static void DeletarDadosUsuario(List<string> cpf, List<string> titular,
            List<string> senha, List<double> saldo)
        {
            //dados que serão apagados após informar o cpf
            Console.Write("Informe o número do CPF para o qual " +
                "deseja encerrar a conta");
            string cpfContaEncerrar = Console.ReadLine();
            
            //localizar o cpf para apagar
            int indexCpfDeletar = cpf.FindIndex(cpf => cpf == cpfContaEncerrar);

            //condição para o cpf inexitente
            if (indexCpfDeletar== -1)
            {
                Console.WriteLine("Conta não localizada");
            }

            //cpf encontrado proceder a exclusão dos dados
            cpf.Remove(cpfContaEncerrar);

            //remover pelo indice da lista encontrado no indexCpfDeletar
            titular.RemoveAt(indexCpfDeletar);
            senha.RemoveAt(indexCpfDeletar);
            saldo.RemoveAt(indexCpfDeletar);

            Console.WriteLine("Conta encerrada com sucesso");

        }

        //Listar toda as contas
        static void ListarTodasContas(List<string> cpf, List<string> titular
            , List<double> saldo)
        {
            for(int i = 0; i < cpf.Count; i++)
            {
                ApresentarConta(i, cpf, titular, saldo);
            }
        }

        //mostrar os usuários cadastrado
        static void ApresentarUsuario(List<string> cpf, List<string> titular,
            List<double> saldo)
        {
            // solicitar o número do cpf do usuário que deseja apresentar
            Console.Write("Informe o número do CPF do cliente que deseja consultar");
            string cpfCliente = Console.ReadLine();
            int indexDoCliente = cpf.FindIndex(cpf => cpf == cpfCliente);

            //condição para cpf inexistente
            if(indexDoCliente == -1)
            {
                Console.WriteLine("Conta não encontrada");
            }

            //mostrar conta do cliente
            ApresentarConta(indexDoCliente, cpf, titular, saldo);
        }

        // mostrar saldo em conta
        static void MostarValorAcumulado(List<double> saldo)
        {
            Console.Write($"Saldo Total em Conta : {saldo.Sum()}");
        }


        // mostra os dados da conta
        private static void ApresentarConta(int i, List<string> cpf, List<string> titular, List<double> saldo)
        {
            Console.WriteLine($"CPF = {cpf[i]} | Titular  = {titular[i]}" +
                $"| Saldo {saldo[i]:F2}");
        }

        public static void Main(string[] args)
        {
            //variável para declar a opção do usuário
            int opção;

            //declar as variáveis do cliente
            List<string> titular = new List<string>();
            List<string> cpf = new List<string>();
            List<double> saldo = new List<double>();
            List<string> senha = new List<string>();

            do
            {
                //mostrar o menu para usuário
                MostrarMenu();

                //campo para o usuário fazer a opção
                opção = int.Parse(Console.ReadLine());

                //ações para escolha do usuário
                switch (opção)
                {
                    case 0:
                        Console.WriteLine("Acesso encerrado...");
                        break;
                    case 1:
                        CadastrarNovoUsuario(cpf, titular, senha, saldo);
                        break;
                    case 2:
                        DeletarDadosUsuario(cpf, titular, senha, saldo);
                        break;
                    case 3:
                        ListarTodasContas(cpf, titular, saldo);
                        break;
                    case 4:
                        ApresentarUsuario(cpf, titular, saldo);
                        break;
                    case 5:
                        Console.WriteLine("Saldo em conta não implementado");
                        break;
                }
            } while (opção != 0);

        }
    }
}
