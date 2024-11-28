using System;
using System.Collections.Generic;

class Forca {
    static void Main() {
        // Lista de palavras disponíveis para o jogo
        string[] palavras = {
            "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "BACABA", "BACURI",
            "BANANA", "CAJÁ", "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA",
            "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ",
            "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU",
            "UVA", "UVAIA"
        };

        // Seleciona uma palavra aleatória
        Random random = new Random();
        string palavraEscolhida = palavras[random.Next(palavras.Length)].ToUpper();

        // Cria uma lista para armazenar as letras corretas descobertas (inicialmente com underscores)
        char[] palavraOculta = new string('_', palavraEscolhida.Length).ToCharArray();

        int tentativasRestantes = 5;
        List<char> letrasErradas = new List<char>();

        Console.WriteLine("Bem-vindo ao Jogo da Forca!");
        Console.WriteLine($"A palavra tem {palavraEscolhida.Length} letras.");
        Console.WriteLine(string.Join(" ", palavraOculta));

        while (tentativasRestantes > 0) {
            // Solicita ao jogador que insira uma letra
            Console.Write("\nDigite uma letra: ");
            char letra = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            // Verifica se a letra já foi tentada
            if (letrasErradas.Contains(letra) || Array.Exists(palavraOculta, c => c == letra)) {
                Console.WriteLine("Você já tentou essa letra. Tente outra.");
                continue;
            }

            // Verifica se a letra está na palavra
            if (palavraEscolhida.Contains(letra)) {
                for (int i = 0; i < palavraEscolhida.Length; i++) {
                    if (palavraEscolhida[i] == letra) {
                        palavraOculta[i] = letra;
                    }
                }
            }
            else {
                tentativasRestantes--;
                letrasErradas.Add(letra);
                Console.WriteLine($"Letra errada! Tentativas restantes: {tentativasRestantes}");
            }

            // Mostra o progresso da palavra
            Console.WriteLine(string.Join(" ", palavraOculta));

            // Verifica se o jogador adivinhou toda a palavra
            if (!new string(palavraOculta).Contains('_')) {
                Console.WriteLine("\nParabéns! Você adivinhou a palavra!");
                break;
            }
        }

        // Se o jogador ficar sem tentativas, ele perde
        if (tentativasRestantes == 0) {
            Console.WriteLine($"\nFim de jogo! Você perdeu. A palavra era: {palavraEscolhida}");
        }
    }
}

