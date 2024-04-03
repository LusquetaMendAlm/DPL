using System;
class HelloWorld
{
    internal class Conta
    {
        public string Nome;
        public string Email;
        public string Senha;
        public string Filmes;
    public void setNome(string nome)
      {
        this.setNome = nome;
      }
    public void setEmail(string email)
      {
        this.setEmail = email;
      }
    public void setSenha(string senha)
      {
        this.setSenha = senha;
      }
    }
        static void Main()
    {

        string cadastro, senha2;
        Console.WriteLine("Bem vindo(a)!");
        Console.WriteLine("Você já possui cadastro? ");
        cadastro = Console.ReadLine();
        switch (cadastro)
        {
            case "sim":
                //log in
                Console.WriteLine("Digite seu nome de usuário: ");
                conta1.setNome(Console.ReadLine());
                Console.WriteLine("Digite sua senha: ");
                conta1.setSenha(Console.ReadLine());
                break;
            case "não":
                //sign in
                Conta conta1 = new Conta();
                Console.WriteLine("Digite seu nome de usuário: ");
                conta1.setNome(Console.ReadLine());
                Console.WriteLine("Digite seu e-mail: ");
                conta1.setEmail(Console.ReadLine());
                do
                {
                    Console.WriteLine("Digite sua senha: ");
                    conta1.setSenha(Console.ReadLine());
                    Console.WriteLine("Digite novamente para confirmar sua senha: ");
                    senha2 = Console.ReadLine();
                    if (senha2 != Senha)
                    {
                        Console.WriteLine("senhas incoerentes. ");
                    }

                } while (senha2 != Senha);
                break;
        }
    }
}