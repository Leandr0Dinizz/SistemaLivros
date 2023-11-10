using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLivros
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace VendaDeLivrosProjeto
    {
        class Program
        {


            static void Main(string[] args)
            {
                ControlPessoa controle = new ControlPessoa();
                ControlLivro controleLivro = new ControlLivro();
                controle.Acesso();
                Console.ReadLine(); // Manter o prompt aberto 
            }
        }

        class ControlPessoa
        {
            ModelPessoa modelo;
            ControlLivro controleLivro;
            int opcao;

            public ControlPessoa()
            {
                modelo = new ModelPessoa();
                controleLivro = new ControlLivro();
                opcao = -1;
            }

            public void Menu()
            {
                Console.WriteLine("\nEscolha uma das opções abaixo: \n" +
                                  "0. Sair\n" +
                                  "1. Login\n" +
                                  "2. Cadastro");
                opcao = Convert.ToInt32(Console.ReadLine());
            }

            public void Acesso()
            {
                do
                {
                    Menu();
                    Console.Clear();
                    switch (opcao)
                    {
                        case 0:
                            Console.WriteLine("Obrigado!");
                            break;
                        case 1:
                            Console.Write("Login: ");
                            string login = Console.ReadLine();
                            Console.Write("Senha: ");
                            string senha = Console.ReadLine();
                            if (modelo.Validacao(login, senha))
                            {
                                Console.Clear();
                                controleLivro.MenuLivro();
                            }
                            else
                                Console.WriteLine("Login inválido ou inexistente");
                            break;
                        case 2:
                            int dia;
                            int mes;
                            int ano;
                            Console.Write("Nome:");
                            string nome = Console.ReadLine();
                            Console.Write("Endereço:");
                            string endereco = Console.ReadLine();
                            Console.Write("Telefone:");
                            int telefone = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Data de Nascimento: ");
                            do
                            {
                                Console.Write("Dia: ");
                                dia = Convert.ToInt32(Console.ReadLine());
                                if (dia < 1 || dia > 31)
                                {
                                    Console.WriteLine("Informa um dia válido");
                                }
                            } while (dia < 1 || dia > 31);
                            do
                            {
                                Console.Write("Mês: ");
                                mes = Convert.ToInt32(Console.ReadLine());
                                if (mes < 1 || mes > 12)
                                {
                                    Console.WriteLine("Informa um mês válido");
                                }
                            } while (mes < 1 || mes > 12);
                            do
                            {
                                Console.Write("Ano: ");
                                ano = Convert.ToInt32(Console.ReadLine());
                                if (ano < 0)
                                {
                                    Console.WriteLine("Informa um ano válido");
                                }
                            } while (ano < 0);
                            Console.Write("Login:");
                            login = Console.ReadLine();
                            Console.Write("Senha:");
                            senha = Console.ReadLine();
                            modelo.Preenchimento(login, senha, nome, endereco, telefone, dia, mes, ano);
                            break;
                        case 3:
                            modelo.MostrarVetor();
                            break;
                        default:
                            Console.WriteLine("Opção selecionada não é válida");
                            break;
                    }
                } while (opcao != 0);
            }
        }

        class ModelPessoa
        {
            int[] id;
            string[] login;
            string[] senha;
            string[] nome;
            string[] endereco;
            int[] telefone;
            int[] dia;
            int[] mes;
            int[] ano;
            int i;
            // método construtor
            public ModelPessoa()
            {
                id = new int[2];
                nome = new string[2];
                endereco = new string[2];
                telefone = new int[2];
                dia = new int[2];
                mes = new int[2];
                ano = new int[2];
                login = new string[2];
                senha = new string[2];
                i = 0;
            } // fim do construtor

            public void Preenchimento(string login2, string senha2, string nome2, string endereco2, int telefone2, int dia2, int mes2, int ano2)
            {
                for (i = 0; i < 2; i++)
                {
                    if (login[i] == null && senha[i] == null)
                    {
                        id[i] = i;
                        nome[i] = nome2;
                        endereco[i] = endereco2;
                        telefone[i] = telefone2;
                        dia[i] = dia2;
                        mes[i] = mes2;
                        ano[i] = ano2;
                        login[i] = login2;
                        senha[i] = senha2;
                        break;
                    }
                }
            }

            public bool Validacao(string login2, string senha2)
            {
                for (i = 0; i < 2; i++)
                {
                    if (login2 == login[i] && senha2 == senha[i])
                    {
                        return true;
                    }
                }
                return false;
            }

            public void MostrarVetor()
            {
                for (i = 0; i < 2; i++)
                {
                    Console.WriteLine("\nID: " + id[i]);
                    Console.WriteLine("Nome: " + nome[i]);
                    Console.WriteLine("Endereco: " + endereco[i]);
                    Console.WriteLine("Telefone: " + telefone[i]);
                    Console.WriteLine("Dia: " + dia[i]);
                    Console.WriteLine("Mês: " + mes[i]);
                    Console.WriteLine("Ano: " + ano[i]);
                    Console.WriteLine("Login: " + login[i]);
                    Console.WriteLine("Senha: " + senha[i]);
                }
            }
        }

        class ModelLivro
        {
            double soma;

            public ModelLivro()
            {
                soma = 0;
            }

            public double Compra(double ValorLivro)
            {
                soma = soma + ValorLivro;
                return soma;
            }
        }

        class ControlLivro
        {
            int opcao;
            int livro;
            int livro2;
            int livro3;
            int livro4;
            double ValorLivro;
            double ValorLivro2;
            double ValorLivro3;
            double ValorLivro4;
            ModelLivro modeloLivro;
            ModelReserva modeloReserva;
            ModelPessoa modeloPessoa;

            public ControlLivro()
            {
                opcao = -1;
                livro = 2;
                livro2 = 0;
                livro3 = 2;
                livro4 = 2;
                ValorLivro = 10;
                ValorLivro2 = 10.50;
                ValorLivro3 = 11.50;
                ValorLivro4 = 25;
                modeloLivro = new ModelLivro();
                modeloReserva = new ModelReserva(4); // 4 é a quantidade total de livros no sistema
                modeloPessoa = new ModelPessoa();
            }

            public void Escolha()
            {
                Console.WriteLine("Escolha um dos livros abaixo: \n" +
                                  "0. Introdução ao C# - R$10,00\n" +
                                  "1. Introdução ao Python - R$10,50\n" +
                                  "2. Introdução ao VisualG - R$11,50\n" +
                                  "3. Introdução a Banco de Dados - R$25,00");
                opcao = Convert.ToInt32(Console.ReadLine());
            }

            public void Reserva()
            {
                Console.WriteLine("Livro indisponível para compra, gostaria de realizar a reserva?\n" +
                                  "0. Sim\n" +
                                  "1. Não");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Escolha o livro para reservar: ");
                        int livroReserva = Convert.ToInt32(Console.ReadLine());
                        if (modeloReserva.ReservarLivro(livroReserva))
                        {
                            Console.WriteLine("Livro reservado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível reservar o livro.");
                        }
                        break;
                    case 1:
                        Console.WriteLine("Tenha um ótimo dia");
                        break;
                    default:
                        Console.WriteLine("Informe um opção válida");
                        break;
                }
            }

            public void MaisCompra()
            {
                Console.WriteLine("Gostaria de comprar mais um livro?\n" +
                                  "0. Sim\n" +
                                  "1. Não");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        MenuLivro();
                        break;
                    case 1:
                        Console.WriteLine("Compra realizada");
                        break;
                    default:
                        Console.WriteLine("Informe um opção válida");
                        break;
                }
            }

            public void MenuLivro()
            {
                Escolha();
                Console.Clear();
                switch (opcao)
                {
                    case 0:
                        if (livro > 0)
                        {
                            Console.WriteLine("Total: R$" + modeloLivro.Compra(ValorLivro));
                            livro = livro - 1;
                            MaisCompra();
                        }
                        else
                        {
                            Reserva();
                        }
                        break;
                    case 1:
                        if (livro2 > 0)
                        {
                            Console.WriteLine("Total: R$" + modeloLivro.Compra(ValorLivro2));
                            livro2 = livro2 - 1;
                            MaisCompra();
                        }
                        else
                        {
                            Reserva();
                        }
                        break;
                    case 2:
                        if (livro3 > 0)
                        {
                            Console.WriteLine("Total: R$" + modeloLivro.Compra(ValorLivro3));
                            livro3 = livro3 - 1;
                            MaisCompra();
                        }
                        else
                        {
                            Reserva();
                        }
                        break;
                    case 3:
                        if (livro4 > 0)
                        {
                            Console.WriteLine("Total: R$" + modeloLivro.Compra(ValorLivro4));
                            livro4 = livro4 - 1;
                            MaisCompra();
                        }
                        else
                        {
                            Reserva();
                        }
                        break;
                    default:
                        Console.WriteLine("Escolha uma das opções disponíveis");
                        break;
                }
            }
        }

        class ModelReserva
        {
            bool[] reservas;

            public ModelReserva(int quantidadeLivros)
            {
                reservas = new bool[quantidadeLivros];
                for (int i = 0; i < quantidadeLivros; i++)
                {
                    reservas[i] = false;
                }
            }

            public bool ReservarLivro(int livro)
            {                                                                   // livro < reservas.Length -> garantir que não ultrapasse o tamanho total do array 'reservas'
                if (livro >= 0 && livro < reservas.Length && !reservas[livro]) //verifica três condições antes de permitir a reserva, 
                                                                               //verifica se o índice do livro é maior ou igual a zero -> array smp começa em 0                                                                     //Em seguida, verifica se o índice do livro é menor que o comprimento do array reservas, para evitar um erro de índice
                {
                    reservas[livro] = true;                                      // se todas as condições foram atendidas o livro é reservado, define o valor correspondente no array de reservas como true
                    Console.WriteLine($"Livro {livro} reservado com sucesso!"); //interpolação - > coloco a variável direto dentro das chaves ao invés de concatenar com o +
                    return true;
                }
                else
                {
                    Console.WriteLine($"Livro {livro} indisponível para reserva."); //Se alguma das condições não for atendida, o bloco else é acionado, indicando que o livro não está disponível para reserva. Nesse caso,
                                                                                    //uma mensagem é exibida no console informando que o livro está indisponível para reserva, e o método retorna false
                    return false;
                }
            }
        }
    }

}
