using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eight_queen
{
    public class Program
    {
        //所有可行解數量
        static int sum = 0;
        //皇后排法
        static int[] Queens = new int[8];
        static void Main(string[] args)
        {
            QueenSort(0);
            Console.ReadKey();
        }
        static void QueenSort(int num)
        {
            for (int j = 1; j < 9; j++)
            {
                if (num == 8)
                {
                    sum++;
                    PrintQueen();
                    break;
                }
                if (Conflict(num, j))
                {
                    Queens[num] = j;
                    //遞迴
                    QueenSort(num + 1);
                }
            }
        }
        static bool Conflict(int row, int queen)
        {
            if (row == 0)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < row; i++)
                {
                    if (!Compare(Queens[i], row - i, queen))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        static bool Compare(int i, int row, int queen)
        {
            if ((i == queen) || ((i - queen) == row) || ((queen - i) == row))
            {
                return false;
            }
            return true;
        }
        static void PrintQueen()
        {
            Console.WriteLine($"第{sum}個皇后排列:");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (j == Queens[i])
                    {
                        Console.Write("Q");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                //换行
                Console.Write("\n");
            }
        }
    }
}
