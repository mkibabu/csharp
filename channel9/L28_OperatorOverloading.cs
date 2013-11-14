using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// One can overload operators, or create new ones, and use them in much the same
// way default operators are used. The format to overload an operator is:
// public static ClassName operator % (ClassName param0[, OtherClassName param1, ...])
// where % is the operator being overloaded, ClassName is the class of the objects
// the operator is to work on, and param0, param1, etc are the values the operator
// is to act upon. Note that at least one of the parameters must be of the same
// class as ClassName (i.e. class where the operator is overloaded). You must implement
// the overload in the class that will use it. Also, convention dictates that, if
// they exist, matching operators must be overridden as well (even though not used).
namespace L28_OperatorOverloading
{
    // Class that implements a matrix. Likely to include pre .Net 4.5 conventions.
    class Matrix
    {
        // const -> constant, can only be initialized at declaration, and is a 
        // compile-time constant. On the other hand, readonly -> initialized at
        // declaration or within a constructor, and can be used rof runtime
        // constants, e.g. readonly val = DateTime.Now

        public const int Dimension = 3;
        private int[,] matrix = new int[Dimension, Dimension];

        // allow callers to initialize. Figure out whgat this is, and how.
        public int this[int x, int y]
        {
            get { return matrix[x, y]; }
            set { matrix[x, y] = value; }
        }

        // let users add matrices
        public static Matrix operator + (Matrix mat1, Matrix mat2)
        {
            Matrix newMatrix = new Matrix();

            for (int x = 0; x < Dimension; x++)
            {
                for (int y = 0; y < Dimension; y++)
                {
                    newMatrix[x, y] = mat1[x, y] + mat2[x, y];
                }
            }

            return newMatrix;
        }
    }

    class MatrixTest
    {
        // used in InitMatrix method
        public static Random rand = new Random();

        // initialize matrix with rrandom values
        public static void InitMatrix(Matrix mat)
        {
            for (int x = 0; x < Matrix.Dimension; x++)
            {
                for (int y = 0; y < Matrix.Dimension; y++)
                {
                    mat[x, y] = rand.Next(100);
                }
            }
        }

        // print matrix to console
        public static void PrintMatrix(Matrix mat)
        {
            for (int x = 0; x < Matrix.Dimension; x++)
            {
                Console.Write("[");
                for (int y = 0; y < Matrix.Dimension; y++)
                {
                    Console.Write( mat[x, y].ToString().PadLeft(3) );

                    if ( (y + 1) < Matrix.Dimension )
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine(" ]");
            }

        }

        // test the Matrix class
        static void Main(string[] args)
        {
            Matrix mat1 = new Matrix();
            InitMatrix(mat1);
            Console.WriteLine("\nMatrix 1");
            PrintMatrix(mat1);
            
            Matrix mat2 = new Matrix();
            InitMatrix(mat2);
            Console.WriteLine("\nMatrix 2:");
            PrintMatrix(mat2);

            Matrix mat3 = mat1 + mat2;
            Console.WriteLine("\nMatrix 1 + Matrix 2:");
            PrintMatrix(mat3);
            

            Console.ReadLine();
        }
    }
}
