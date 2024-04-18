using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace locadora2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conta conta1 = new Conta();
            string cadastro, nome, senha, email;
            string redefin;
            int escolhaF, contador = 1;
            bool FilmeMais = true;
            bool existe = true;
            string desejo, mais;
            Console.WriteLine("Bem vindo(a)!");
            do
            {
                Console.WriteLine("Você já possui cadastro? ");
                cadastro = Console.ReadLine();
                switch (cadastro)
                {
                    case "não":
                        Console.WriteLine("OK, digite seu nome de usuário:");
                        conta1.getNome();
                        Console.WriteLine("OK, digite seu e-mail:");
                        conta1.getEmail();
                        Console.WriteLine("OK, digite sua senha:");
                        conta1.getSenha();
                        break;
                    case "sim":

                        Console.WriteLine("OK, digite seu nome de usuário:");
                        nome = Console.ReadLine();
                        Console.WriteLine("Ok, digite sua senha: ");
                        senha = Console.ReadLine();
                        if (nome == conta1.Nome && senha == conta1.Senha)
                        {
                            existe = true;
                            Console.WriteLine("Deseja redefinir sua senha?");
                            redefin = Console.ReadLine();
                            switch (redefin)
                            {
                                case "não":
                                    Console.WriteLine("Ok senhor(a)!");
                                    break;
                                case "sim":
                                    Console.WriteLine("Digite o e-mail que será mandada a nova senha:");
                                    email = Console.ReadLine();
                                    if (email == conta1.Email)
                                    {
                                        string novaSenha = NovaSenha();
                                        conta1.RedefinirSenha(novaSenha);
                                        Console.WriteLine($"Nova senha gerada: {novaSenha}");
                                        Console.WriteLine("A redefinição da sua senha foram salvas em um arquivo de texto.");
                                        Console.WriteLine("Você terá acesso a ela após o fechamento do programa.");
                                        Intrucoes(email, novaSenha);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Email não encontrado.");
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            existe = false;
                            Console.WriteLine("Nome e senha incorretas.");
                        }
                        break;
                }
            } while (cadastro != "sim" || existe == false);
            Console.WriteLine("\r\nBem vindo(a) a locadora! ");
            Console.WriteLine("A lista de filmes :");
            Console.WriteLine("1)Gente grande ");
            Console.WriteLine("2)Gente grande 2");
            Console.WriteLine("3)Vingadores");
            Console.WriteLine("4)Vingadores 2");
            Console.WriteLine("5)Vingadores Guerra Infinita");
            Console.WriteLine("6)Vingadores Ultimato");
            Console.WriteLine("7)Homem Aranha");
            Console.WriteLine("8)Homem Aranha 2");
            Console.WriteLine("9)Homem Aranha 3");
            Console.WriteLine("10)O bicho vai pegar ");
            Console.WriteLine("11)O bicho vai pegar 2");
            Console.WriteLine("O(A) senhor(a) deseja um filme?");
            do
            {
                desejo = Console.ReadLine();
                switch (desejo)
                {
                    case "sim":
                        Console.WriteLine("Qual filme?");
                        escolhaF = int.Parse(Console.ReadLine());

                        if (escolhaF < 0 || escolhaF > 11)
                        {
                            Console.WriteLine("O número não é correspondente com um filme.");
                        }
                        else
                        {
                            Console.WriteLine("O filme escolhido foi: " + primeiroF(escolhaF));
                            Console.WriteLine("Ele só voltará a ficar disponível após a sua devolução.\r\n");
                            while (FilmeMais == true)

                            {
                                Console.WriteLine("O(A) senhor(a) deseja mais alguma coisa?");
                                mais = Console.ReadLine();
                                switch (mais)
                                {

                                    case "sim":
                                        Console.WriteLine("Digite o filme que o(a) senhor(a) quer:");
                                        escolhaF = int.Parse(Console.ReadLine());
                                        Console.WriteLine("O filme escolhido foi: " + primeiroF(escolhaF));
                                        Console.WriteLine("Ele só voltará a ficar disponível após a sua devolução.\r\n");
                                        contador++;

                                        break;
                                    case "não":
                                        double preco = contador * 6.50;
                                        Console.Write("Ok senhor(a), o valor do(s) filme(s) foi de: ");
                                        FilmeMais = false;
                                        DateTime thisDay = DateTime.Today;
                                        Console.WriteLine(preco + "R$");
                                        Console.WriteLine("dia alugado:");
                                        Console.WriteLine(thisDay.ToString());
                                        DateTime dataFinal = thisDay.AddDays(2);
                                        Console.WriteLine("dia de devolução:");
                                        Console.WriteLine("" + dataFinal);
                                        Console.WriteLine("Tenha um ótimo dia!!!");
                                        break;
                                }

                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Ok senhor(a), tenha um ótimo dia!");
                        break;
                }
            } while (desejo == "sim");

        }
        static private string NovaSenha()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        static private void Intrucoes(string email, string novaSenha)
        {
            string path = $"{email}_instrucoes_redefinicao_senha.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine($"A sua senha foi redefinida com sucesso para o email {email}.");
                writer.WriteLine($"A nova senha é: {novaSenha}");
            }
        }

        static string primeiroF(int escolha)
        {
            string[] filme =
              { "Não existe este filme, tente novamente com outro digito",
                "Gente grande",
                "Gente grande 2",
                "Vingadores",
                "Vingadores 2",
                "Vingadores Guerra Infinita",
                "Vingadores Ultimato",
                "Homem Aranha",
                "Homem Aranha 2",
                "Homem Aranha 3",
                "O bicho vai pegar",
                "O bicho vai pegar 2"
            };

            return filme[escolha];
        }
    }
    public class Conta
    {
        public string Nome;
        public string Email;
        public string Senha;
        public string SenhaHash;
        public void getNome()
        {
            Nome = Console.ReadLine();
        }
        public void getEmail()
        {
            Email = Console.ReadLine();
        }
        public void getSenha()
        {
            Senha = Console.ReadLine();
        }
        public string HashSenha(string Senha)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Senha));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public void RedefinirSenha(string novaSenha)
        {
            Senha = novaSenha;
            SenhaHash = HashSenha(novaSenha);
        }
    }
}