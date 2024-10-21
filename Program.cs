using System;

namespace RadixSort
{
    class Program
    {
        static int[] radixSort(int[] data)
        {
            int max = getMax(data);

            // Passa pelos dígitos um por um, começando do menos significativo
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                data = countSortByDigit(data, exp);
            }

            return data;
        }

        // Função para encontrar o valor máximo no array
        static int getMax(int[] data)
        {
            int max = data[0];
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > max)
                    max = data[i];
            }
            return max;
        }

        // Função de ordenação que organiza os números com base no dígito específico
        static int[] countSortByDigit(int[] data, int exp)
        {
            int[] output = new int[data.Length]; // Array de saída
            int[] count = new int[10]; // Armazena contagem dos dígitos (0-9)

            // Inicializa o array de contagem
            for (int i = 0; i < data.Length; i++)
            {
                int digit = (data[i] / exp) % 10;
                count[digit]++;
            }

            // Modifica count[] para ter a posição correta de cada dígito
            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            // Constroi o array de saída
            for (int i = data.Length - 1; i >= 0; i--)
            {
                int digit = (data[i] / exp) % 10;
                output[count[digit] - 1] = data[i];
                count[digit]--;
            }

            return output;
        }

        static void Main(string[] args)
        {
            int[] data = { 170, 45, 75, 90, 802, 24, 2, 66 };
            int[] sortedData = radixSort(data);

            Console.WriteLine("Sorted Data: " + string.Join(", ", sortedData));
        }
    }
}
