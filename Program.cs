using System;
using System.Collections.Generic;
using System.Linq.Expressions;

class Program
{
    static void Main()
    {
        // Dicionário para armazenar nomes e animais correspondentes
        var membrosSecretos = new Dictionary<string, string>
        {
            { "Alice", "Fenix" },
            { "Bruno", "Lobo" },
            { "Carla", "Pantera" },
            { "Diego", "Aguia" },
            { "Evelyn", "Tigre" },
            { "Fabio", "Dragao" }
        };

        // Adicionando novos membros de forma segura
        AdicionarOuAtualizar(membrosSecretos, "Gustavo", "Leao");
        AdicionarOuAtualizar(membrosSecretos, "Helena", "Coruja");

        // Tentando adicionar uma entrada duplicada
        if (!AdicionarOuAtualizar(membrosSecretos, "Alice", "Unicornio"))
        {
            Console.WriteLine("Aviso: 'Alice' já está presente no dicionário. O valor não foi atualizado.");
        }

        // Exibindo todos os membros e seus animais
        Console.WriteLine("\nMembros do secreto e seus animais:");
        if (membrosSecretos.Count == 0)
        {
            Console.WriteLine("Não existem membros");
        }
        else
        {
            foreach (var entry in membrosSecretos)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }

        // Expressão Lambda para exibir a quantidade de membros no grupo secreto
        Expression<Func<int>> contarMembros = () => membrosSecretos.Count;
        Console.WriteLine($"\nTotal de membros no grupo secreto: {contarMembros.Compile().Invoke()}");
    }

    // Método para adicionar ou atualizar membros de forma segura
    static bool AdicionarOuAtualizar(Dictionary<string, string> dict, string chave, string valor)
    {
        if (dict.ContainsKey(chave))
        {
            return false; // Não adicionar se a chave já existe
        }
        dict[chave] = valor;
        return true;
    }
}
