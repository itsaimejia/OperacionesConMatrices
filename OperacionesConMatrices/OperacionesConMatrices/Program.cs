using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesConMatrices
{
	class Program
	{
		static List<double[,]> Matrices = new List<double[,]>();
		static string Dimension;
		static int DimensionI;
		static int DimensionJ;
		static void Main(string[] args)
		{

			Write("Cantidad de matrices a capturar: ");
			int CantMat = int.Parse(ReadLine());
			InsertarMatrices(CantMat);
			Clear();
			WriteLine("Qué harás con las matrices: ");
			Write("1.- Sumar\n2.-Restar\n3.-Dividir\n4.-Multiplicar\n...: ");
			int op = int.Parse(ReadLine());
			switch (op)
			{
				case 1:
					Sumar();
					break;
				case 2:
					break;
				case 3:
					break;
				case 4:
					break;
				default:
					Write("No existe esta opción");
					break;
			}
			ReadKey();
		}

		static void InsertarMatrices(int tam)
		{
			WriteLine("Ingresa el tamaño de las matrices con el formato I,J");
			Write("Dimensión: ");
			Dimension = ReadLine();
			DimensionI = Convert.ToInt32(Dimension.Split(',')[0]);
			DimensionJ = Convert.ToInt32(Dimension.Split(',')[1]);
			for (int x = 0; x < tam; x++)
			{
				WriteLine($"Matriz: {x + 1}");
				double[,] Matriz = new double[DimensionI, DimensionJ];
				for(int i = 0; i < DimensionI; i++)
				{
					WriteLine($"Escribe el renglón {i + 1} con el formato A,B,C,...Z");
					Write("Renglón: ");
					string Renglon = ReadLine();
					for (int j = 0; j < DimensionJ; j++)
					{
						Matriz[i, j] = Convert.ToInt32(Renglon.Split(',')[j]);
					}
				}
				Matrices.Add(Matriz);
			}
		}

		static void ImprimirMatriz(double[,] Matriz)
		{
			for (int i = 0; i < DimensionI; i++)
			{
				for (int j = 0; j < DimensionJ; j++)
				{
					Write(Matriz[i, j] + " ");
				}
				WriteLine();
			}
		}

		static void Sumar()
		{
			double[,] Matriz= new double[DimensionI,DimensionJ];
			foreach (var Matr in Matrices)
			{
				for (int i = 0; i < DimensionI; i++)
				{
					for (int j = 0; j < DimensionJ; j++)
					{
						Matriz[i, j] += Matr[i, j];
					}
				}
			}
			ImprimirMatriz(Matriz);
		}


	}
}
