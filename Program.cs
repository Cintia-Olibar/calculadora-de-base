
using System;
using System.Linq;

namespace CalculadoraDeBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CALCULADORA DE BASE";
            Calculadora();
        }

        static void Calculadora()
        {
            int opcao = 1;

            while (opcao != 0)
            {
                Console.Clear();

                Console.WriteLine("\n        CALCULADORA DE BASE");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("            MENU DE CONVERSÃO");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" 1  - Decimal -> Binário");
                Console.WriteLine(" 2  - Binário -> Decimal");
                Console.WriteLine(" 3  - Decimal -> Octal");
                Console.WriteLine(" 4  - Octal   -> Decimal");
                Console.WriteLine(" 5  - Decimal -> Hexadecimal");
                Console.WriteLine(" 6  - Hexa    -> Decimal");
                Console.WriteLine(" 7  - Binário -> Octal");
                Console.WriteLine(" 8  - Octal   -> Binário");
                Console.WriteLine(" 9  - Binário -> Hexa");
                Console.WriteLine("10  - Hexa    -> Binário");
                Console.WriteLine("11  - Octal   -> Hexa");
                Console.WriteLine("12  - Hexa    -> Octal");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" 0  - Encerrar");
                Console.WriteLine("------------------------------------------------");

                do
                {
                    Console.Write("Informe a opção: ");
                    string escolha = Console.ReadLine();

                    if (int.TryParse(escolha, out opcao) && opcao >= 0 && opcao <= 12)
                        break;

                    Console.WriteLine("ATENÇÃO: Opção inválida! Tente novamente.");
                } while (true);

                if (opcao == 0)
                {
                    Console.WriteLine("Calculadora encerrada.");
                    break;
                }

                Console.Clear();

                switch (opcao)
                {
                    case 1:  Console.WriteLine("Decimal -> Binário");            DecBin();   break;
                    case 2:  Console.WriteLine("Binário -> Decimal");            BinDec();   break;
                    case 3:  Console.WriteLine("Decimal -> Octal");              DecOctal(); break;
                    case 4:  Console.WriteLine("Octal -> Decimal");              OctalDec(); break;
                    case 5:  Console.WriteLine("Decimal -> Hexadecimal");        DecHexa();  break;
                    case 6:  Console.WriteLine("Hexadecimal -> Decimal");        HexaDec();  break;
                    case 7:  Console.WriteLine("Binário -> Octal");              BinOctal(); break;
                    case 8:  Console.WriteLine("Octal -> Binário");              OctalBin(); break;
                    case 9:  Console.WriteLine("Binário -> Hexadecimal");        BinHexa();  break;
                    case 10: Console.WriteLine("Hexadecimal -> Binário");        HexaBin();  break;
                    case 11: Console.WriteLine("Octal -> Hexadecimal");          OctalHexa();break;
                    case 12: Console.WriteLine("Hexadecimal -> Octal");          HexaOctal();break;
                    default: Console.WriteLine("ATENÇÃO: Opção inválida!");                  break;
                }
            }
        }

        static void DecBin()
        {
            while (true)
            {
                Console.Write("Informe um número decimal: ");
                string dec = Console.ReadLine().Trim();

                if (int.TryParse(dec, out int num))
                {
                    if (num < 0)
                    {
                        Console.WriteLine("Número inválido.\n");
                        continue;
                    }

                    string binario = "";
                    int decNum = num;

                    if (num == 0)
                    {
                        binario = "0";
                        Console.WriteLine($"{num} / 2 = 0 (resto 0)");
                    }
                    else
                    {
                        while (num > 0)
                        {
                            int resto = num % 2;
                            int quociente = num / 2;
                            Console.WriteLine($"{num} / 2 = {quociente} (resto {resto})");
                            binario = resto + binario;
                            num = quociente;
                        }
                    }

                    Console.WriteLine($"\nO valor binário do número {decNum} é: {binario}\n");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Número inválido.\n");
                }
            }
        }

        static void BinDec()
        {
            while (true)
            {
                Console.Write("Informe um número binário: ");
                string binario = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(binario) || !binario.All(c => c == '0' || c == '1'))
                {
                    Console.WriteLine("Número inválido.\n");
                    continue;
                }

                double somadec = 0;
                for (int i = 0; i < binario.Length; i++)
                {
                    int bit = binario[binario.Length - 1 - i] - '0';
                    double dec = bit * Math.Pow(2, i);
                    Console.WriteLine($"{bit} * 2 ^ {i} = {dec}");
                    somadec += dec;
                }

                Console.WriteLine($"\nO valor decimal é: {somadec}\n");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                break;
            }
        }

        static void DecOctal()
        {
            while (true)
            {
                Console.Write("Informe um número decimal: ");
                string dec = Console.ReadLine().Trim();

                if (int.TryParse(dec, out int num))
                {
                    if (num < 0) { Console.WriteLine("Número inválido.\n"); continue; }

                    int resto;
                    string octal = "";
                    int decNum = num;

                    if (num == 0)
                    {
                        octal = "0";
                        Console.WriteLine($"{num} / 8 = 0 (resto 0)");
                    }
                    else
                    {
                        do
                        {
                            resto = num % 8;
                            int quociente = num / 8;
                            Console.WriteLine($"{num} / 8 = {quociente} (resto {resto})");
                            num = quociente;
                            octal = resto + octal;
                        } while (num != 0);
                    }

                    Console.WriteLine($"\nO valor octal do número {decNum} é: {octal}\n");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Número inválido.\n");
                }
            }
        }

        static void OctalDec()
        {
            while (true)
            {
                Console.Write("Informe um número octal: ");
                string octal = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(octal) || !octal.All(c => c >= '0' && c <= '7'))
                {
                    Console.WriteLine("Número inválido.");
                    continue;
                }

                double somadec = 0;
                string somaDetalhada = "";

                for (int i = 0; i < octal.Length; i++)
                {
                    int digito = Convert.ToInt32(octal[octal.Length - 1 - i].ToString());
                    double valor = digito * Math.Pow(8, i);
                    Console.WriteLine($"{digito} * 8 ^ {i} = {valor}");
                    somadec += valor;
                    somaDetalhada += valor + " + ";
                }

                if (somaDetalhada.EndsWith(" + "))
                    somaDetalhada = somaDetalhada.Substring(0, somaDetalhada.Length - 3);

                Console.WriteLine($"\n{somaDetalhada} = {somadec}");
                Console.WriteLine($"\nO valor decimal do número octal {octal} é: {somadec}\n");

                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                break;
            }
        }

        static void DecHexa()
        {
            while (true)
            {
                Console.Write("Informe um número decimal: ");
                string dec = Console.ReadLine().Trim();

                if (int.TryParse(dec, out int num))
                {
                    if (num < 0) { Console.WriteLine("Número inválido.\n"); continue; }

                    int div;
                    int resto;
                    string hexa = "";
                    int decNum = num;

                    if (num == 0)
                    {
                        hexa = "0";
                        Console.WriteLine($"{num} / 16 = 0 (resto 0)");
                    }
                    else
                    {
                        do
                        {
                            resto = num % 16;
                            div = num / 16;
                            string letra = resto switch
                            {
                                10 => "A",
                                11 => "B",
                                12 => "C",
                                13 => "D",
                                14 => "E",
                                15 => "F",
                                _  => resto.ToString()
                            };

                            Console.WriteLine($"{num} / 16 = {div} (resto {letra})");
                            hexa = letra + hexa;
                            num = div;

                        } while (num != 0);
                    }

                    Console.WriteLine($"\nO valor hexadecimal do número {decNum} é: {hexa}\n");
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Número inválido.");
                }
            }
        }

        static void HexaDec()
        {
            while (true)
            {
                Console.Write("Informe um número hexadecimal: ");
                string hexa = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrEmpty(hexa) || !hexa.All(c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F')))
                {
                    Console.WriteLine("Número inválido.");
                    continue;
                }

                double somadec = 0;
                string valoresMultiplicacao = "";

                for (int i = 0; i < hexa.Length; i++)
                {
                    char hexaChar = hexa[hexa.Length - 1 - i];
                    int numDec = hexaChar switch
                    {
                        'A' => 10,
                        'B' => 11,
                        'C' => 12,
                        'D' => 13,
                        'E' => 14,
                        'F' => 15,
                        _   => Convert.ToInt32(hexaChar.ToString())
                    };

                    double valorMultiplicado = numDec * Math.Pow(16, i);
                    Console.WriteLine($"{numDec} * 16 ^ {i} = {valorMultiplicado}");
                    somadec += valorMultiplicado;

                    valoresMultiplicacao += valorMultiplicado;
                    if (i < hexa.Length - 1) valoresMultiplicacao += " + ";
                }

                Console.WriteLine($"\n{valoresMultiplicacao} = {somadec}");
                Console.WriteLine($"\nO valor decimal do número hexadecimal {hexa} é: {somadec}\n");

                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                break;
            }
        }

        static void BinOctal()
        {
            while (true)
            {
                Console.Write("Informe o número binário: ");
                string binario = Console.ReadLine();

                if (binario == "0") break;

                if (string.IsNullOrEmpty(binario) || !binario.All(c => c == '0' || c == '1'))
                {
                    Console.WriteLine("Número inválido.");
                    continue;
                }

                double valorDec = 0;
                string somaDetalhada = "";
                Console.WriteLine("\nConversão de Binário para Decimal:");

                for (int i = 0; i < binario.Length; i++)
                {
                    int bin = Convert.ToInt32(binario[binario.Length - 1 - i].ToString());
                    double valor = bin * Math.Pow(2, i);
                    Console.WriteLine($"{bin} * 2 ^ {i} = {valor}");
                    valorDec += valor;
                    somaDetalhada += valor;
                    if (i < binario.Length - 1) somaDetalhada += " + ";
                }

                Console.WriteLine($"\n{somaDetalhada} = {valorDec}");
                Console.WriteLine($"\nO valor decimal é: {valorDec}");

                int num = (int)valorDec;
                int resto;
                string octal = "";

                do
                {
                    resto = num % 8;
                    int quociente = num / 8;
                    Console.WriteLine($"{num} / 8 = {quociente} (resto {resto})");
                    octal = resto + octal;
                    num = quociente;

                } while (num != 0);

                Console.WriteLine($"\nO valor octal do número binário {binario} é: {octal}");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                break;
            }
        }

        static void OctalBin()
        {
            while (true)
            {
                Console.Write("Informe um número octal: ");
                string octal = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(octal) || !octal.All(c => c >= '0' && c <= '7'))
                {
                    Console.WriteLine("Número inválido.");
                    continue;
                }

                int valorDec = 0;
                Console.WriteLine("\nConversão de Octal para Decimal:");

                for (int i = 0; i < octal.Length; i++)
                {
                    int digitoOctal = Convert.ToInt32(octal[octal.Length - 1 - i].ToString());
                    int valorDecimal = digitoOctal * (int)Math.Pow(8, i);
                    valorDec += valorDecimal;
                    Console.WriteLine($"{digitoOctal} * 8 ^ {i} = {valorDecimal}");
                }

                Console.WriteLine($"\nO valor decimal do número octal {octal} é: {valorDec}");

                string binario = "";
                int tempDecimal = valorDec;
                Console.WriteLine("\nConversão de Decimal para Binário:");

                if (tempDecimal == 0)
                {
                    binario = "0";
                    Console.WriteLine($"{tempDecimal} / 2 = 0 (resto 0)");
                }
                else
                {
                    while (tempDecimal > 0)
                    {
                        int quociente = tempDecimal / 2;
                        int resto = tempDecimal % 2;
                        binario = resto + binario;
                        Console.WriteLine($"{tempDecimal} / 2 = {quociente} (resto {resto})");
                        tempDecimal = quociente;
                    }
                }

                Console.WriteLine($"\nO valor binário do número octal {octal} é: {binario}\n");

                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                break;
            }
        }

        static void BinHexa()
        {
            while (true)
            {
                Console.Write("Informe um número binário: ");
                string binario = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(binario) || !binario.All(c => c == '0' || c == '1'))
                {
                    Console.WriteLine("Número inválido.");
                    continue;
                }

                string hexa = "";
                int valorDec = 0;
                int potencia = 0;

                Console.WriteLine("\nConversão de Binário para Decimal:");
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    int bit = binario[i] - '0';
                    int valorBit = bit * (int)Math.Pow(2, potencia);
                    valorDec += valorBit;
                    Console.WriteLine($"{bit} * 2 ^ {potencia} = {valorBit}");
                    potencia++;
                }

                Console.WriteLine($"\nO valor decimal do número binário {binario} é: {valorDec}\n");

                Console.WriteLine("Conversão de Decimal para Hexadecimal:");
                if (valorDec == 0)
                {
                    hexa = "0";
                    Console.WriteLine("0 / 16 = 0 (resto 0)");
                }
                else
                {
                    while (valorDec > 0)
                    {
                        int resto = valorDec % 16;
                        int quociente = valorDec / 16;
                        string numHexa = resto < 10 ? resto.ToString() : ((char)('A' + resto - 10)).ToString();

                        hexa = numHexa + hexa;
                        Console.WriteLine($"{valorDec * 16 + resto} / 16 = {quociente} (resto {numHexa})");
                        valorDec = quociente;
                    }
                }

                if (hexa == "") hexa = "0";

                Console.WriteLine($"\nO valor hexadecimal do número binário {binario} é: {hexa}\n");

                Console.WriteLine("Pressione qualquer tecla para sair...");
                Console.ReadKey();
                break;
            }
        }

        static void HexaBin()
        {
            while (true)
            {
                Console.Write("Informe um número hexadecimal: ");
                string hexa = Console.ReadLine().Trim().ToUpper();
                if (string.IsNullOrEmpty(hexa) || !hexa.All(c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F')))
                {
                    Console.WriteLine("Número inválido.");
                    continue;
                }

                int valorDec = 0;
                int potencia = 0;
                Console.WriteLine("\nConversão de Hexadecimal para Decimal:");

                for (int i = hexa.Length - 1; i >= 0; i--)
                {
                    char c = hexa[i];
                    int valorHexa = Convert.ToInt32(c.ToString(), 16);
                    int valorPosicional = valorHexa * (int)Math.Pow(16, potencia);
                    valorDec += valorPosicional;
                    Console.WriteLine($"{c} * 16 ^ {potencia} = {valorPosicional}");
                    potencia++;
                }

                Console.WriteLine($"\nO valor decimal do número hexadecimal {hexa} é: {valorDec}\n");

                string binario = "";
                Console.WriteLine("Conversão de Decimal para Binário:");
                if (valorDec == 0)
                {
                    binario = "0";
                    Console.WriteLine("0 / 2 = 0 (resto 0)");
                }
                else
                {
                    while (valorDec > 0)
                    {
                        int resto = valorDec % 2;
                        int quociente = valorDec / 2;
                        binario = resto + binario;
                        Console.WriteLine($"{valorDec} / 2 = {quociente} (resto {resto})");
                        valorDec = quociente;
                    }
                }

                if (binario == "") binario = "0";

                Console.WriteLine($"\nO valor binário do número hexadecimal {hexa} é: {binario}\n");

                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                break;
            }
        }

        static void OctalHexa()
        {
            while (true)
            {
                Console.Write("Informe um número octal: ");
                string octal = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(octal) || !octal.All(c => c >= '0' && c <= '7'))
                {
                    Console.WriteLine("Número inválido.");
                    continue;
                }

                int numDec = 0;
                int potencia = 0;

                Console.WriteLine("\nConversão de Octal para Decimal:");
                for (int i = octal.Length - 1; i >= 0; i--)
                {
                    int octalDec = Convert.ToInt32(octal[i].ToString());
                    int valor = octalDec * (int)Math.Pow(8, potencia);
                    numDec += valor;
                    Console.WriteLine($"{octalDec} * 8 ^ {potencia} = {valor}");
                    potencia++;
                }
                Console.WriteLine($"\nO valor decimal do número octal {octal} é: {numDec}");

                string hexa = "";
                int decHexa = numDec;
                Console.WriteLine("\nConversão de Decimal para Hexadecimal:");
                if (decHexa == 0)
                {
                    hexa = "0";
                    Console.WriteLine("0 / 16 = 0 (resto 0)");
                }
                else
                {
                    while (decHexa > 0)
                    {
                        int resto = decHexa % 16;
                        int quociente = decHexa / 16;
                        string numHexa = resto.ToString("X");

                        hexa = numHexa + hexa;
                        Console.WriteLine($"{decHexa * 16 + resto} / 16 = {quociente} (resto {numHexa})");
                        decHexa = quociente;
                    }
                }

                if (hexa == "") hexa = "0";

                Console.WriteLine($"\nO valor hexadecimal do número octal {octal} é: {hexa}\n");

                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                break;
            }
        }

        static void HexaOctal()
        {
            while (true)
            {
                Console.Write("Informe um número hexadecimal: ");
                string hexa = Console.ReadLine().Trim().ToUpper();

                if (string.IsNullOrEmpty(hexa) || !hexa.All(c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F')))
                {
                    Console.WriteLine("Número inválido.");
                    continue;
                }

                int valorDec = 0;
                Console.WriteLine("\nConversão de Hexadecimal para Decimal:");
                for (int i = 0; i < hexa.Length; i++)
                {
                    char hexaChar = hexa[hexa.Length - 1 - i];
                    int hexaDec = hexaChar switch
                    {
                        'A' => 10,
                        'B' => 11,
                        'C' => 12,
                        'D' => 13,
                        'E' => 14,
                        'F' => 15,
                        _   => Convert.ToInt32(hexaChar.ToString())
                    };

                    int valor = hexaDec * (int)Math.Pow(16, i);
                    valorDec += valor;
                    Console.WriteLine($"{hexaDec} * 16 ^ {i} = {valor}");
                }
                Console.WriteLine($"\nO valor decimal do número hexadecimal {hexa} é: {valorDec}");

                string octal = "";
                int tempDecimal = valorDec;
                Console.WriteLine("\nConversão de Decimal para Octal:");
                if (tempDecimal == 0)
                {
                    octal = "0";
                    Console.WriteLine("0 / 8 = 0 (resto 0)");
                }
                else
                {
                    while (tempDecimal > 0)
                    {
                        int resto = tempDecimal % 8;
                        int quociente = tempDecimal / 8;
                        octal = resto + octal;
                        Console.WriteLine($"{tempDecimal} / 8 = {quociente} (resto {resto})");
                        tempDecimal = quociente;
                    }
                }

                if (octal == "") octal = "0";

                Console.WriteLine($"\nO valor octal do número hexadecimal {hexa} é: {octal}");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                break;
            }
        }
    }
}
