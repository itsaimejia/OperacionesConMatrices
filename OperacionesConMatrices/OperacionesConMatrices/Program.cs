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
			bool Continuar = true;
			Write("Cantidad de matrices a capturar: ");
			int CantMat = int.Parse(ReadLine());
			InsertarMatrices(CantMat);
			Clear();
			while (Continuar)
			{
				Clear();
				WriteLine("Qué harás con las matrices: ");
				Write("1.- Sumar\n2.- Restar\n3.- Dividir\n4.- Multiplicar\n...: ");
				int op = int.Parse(ReadLine());
				switch (op)
				{
					case 1:
						Sumar();
						break;
					case 2:
						Restar();
						break;
					case 3:
						Dividir();
						break;
					case 4:
						Multiplicar();
						break;
					default:
						Write("No existe esta opción");
						break;
				}
				WriteLine("\n\nPresiona cualquier tecla para continuar\nPresiona ESC para salir");
				if (ReadKey().Key == ConsoleKey.Escape)
					Continuar = false;
			}
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
			WriteLine("\nResultado: ");
			for (int i = 0; i < DimensionI; i++)
			{
				Write("\t");
				for (int j = 0; j < DimensionJ; j++)
				{
					Write($"{Matriz[i, j]:0.00} ");
				}
				WriteLine();
			}
		}

		static void Sumar()
		{
			double[,] MatrizResultado = new double[DimensionI, DimensionJ];
			foreach (var Matr in Matrices)
			{
				for (int i = 0; i < DimensionI; i++)
				{
					for (int j = 0; j < DimensionJ; j++)
					{
						MatrizResultado[i, j] += Matr[i, j];
					}
				}
			}
			ImprimirMatriz(MatrizResultado);
		}

		static void Restar()
		{
			double[,] MatrizResultado = new double[DimensionI, DimensionJ];
			int x = 0;
			foreach (var Matr in Matrices)
			{
				for (int i = 0; i < DimensionI; i++)
				{
					for (int j = 0; j < DimensionJ; j++)
					{
						if (x == 0)
						{
							MatrizResultado[i, j] = Matr[i, j];
						}
						else
						{
							MatrizResultado[i,j] -= Matr[i, j];
						}
					}
				}
				x++;
			}
			ImprimirMatriz(MatrizResultado);
		}

		static void Multiplicar()
		{
			double[,] MatrizResultado = new double[DimensionI, DimensionJ];
			int x = 0;
			foreach (var Matr in Matrices)
			{
				for (int i = 0; i < DimensionI; i++)
				{
					for (int j = 0; j < DimensionJ; j++)
					{
						if (x == 0)
						{
							MatrizResultado[i, j] = Matr[i, j];
						}
						else
						{
							MatrizResultado[i, j] *= Matr[i, j];
						}
					}
				}
				x++;
			}
			ImprimirMatriz(MatrizResultado);
		}

		static void Dividir()
		{
			double[,] MatrizResultado = new double[DimensionI, DimensionJ];
			int x = 0;
			foreach (var Matr in Matrices)
			{
				for (int i = 0; i < DimensionI; i++)
				{
					for (int j = 0; j < DimensionJ; j++)
					{
						if (x == 0)
						{
							MatrizResultado[i, j] = Matr[i, j];
						}
						else
						{
							MatrizResultado[i, j] /= Matr[i, j];
						}
					}
				}
				x++;
			}
			ImprimirMatriz(MatrizResultado);
		}
	}
}
