using System;

namespace D02
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Value Types
            int X;
            ///C# Keyword
            ///4 uninitialized Bytes in Stack ;
            X = 7;

            ///BCL Struct System.Int32
            Int32 Y;

            Y = X;

            X++;

            Console.WriteLine(X);
            Console.WriteLine(Y);

            #endregion

            #region Reference Types
            //object O1;
            /////Zero Bytes have been allocated in Heap
            //O1 = new object();
            /////1. Allocate Bytes ( Size + Overhead )\
            /////2. Initialize allocated Object
            /////3. Call ctor if exists
            /////4. Assign Reference

            //Object O2 = new();
            /////Compiler : Object O2 = new Object();

            //Console.WriteLine(O1.GetHashCode());
            //Console.WriteLine(O2.GetHashCode());

            //O2 = O1;
            /////O1 , O2 Sharing the same Identity 
            /////O1 , O2 two References to the Same Object
            //Console.WriteLine("After = ");
            //Console.WriteLine(O1.GetHashCode());
            //Console.WriteLine(O2.GetHashCode());





            #endregion

            #region string Formatting

            //int X, Y;

            //X = int.Parse(Console.ReadLine());
            //Y = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine(X + Y);

            /////Before C# 6.0
            ////string Msg = string.Format("Equation: {0} + {1} = {2}", X, Y, X + Y);
            ////Console.WriteLine(Msg);

            ////Console.WriteLine("Equation: {0} + {1} = {2}", X, Y, X + Y);

            ////C# 6.0 and Higher , 
            ////$ : String manipulation Operator
            ////string Msg = string.Format($"Equation: {X} + {Y} = {X + Y}");
            ////Console.WriteLine(Msg);

            //Console.WriteLine($"Equation: {X} + {Y} = {X + Y}"); 
            #endregion

            #region If / Else
            //int X = 5;

            /////Not Valid 
            ////if (X) ;
            ////if (1) ;
            ////if (X = 7) ;

            //if (X == 0)
            //    Console.WriteLine("Zero");
            //else
            //    Console.WriteLine("Non Zero");

            //bool Falg = false;

            //if (Falg) //Flag == True
            //    Console.WriteLine("True");
            //else
            //    Console.WriteLine("False"); 
            #endregion

            #region Block Scope
            // double X;

            ///block statement 
            //{
            //    int X = 20; ///Block Scope
            //    ++X;
            //    Console.WriteLine(X);
            //} //end of Block Scope


            //{
            //    string X = "hello";

            //    Console.WriteLine(X.ToUpper());
            //}


            //Console.WriteLine(X); ///not defined 


            //for (int i=0;i<10 ;i++ )
            //{
            //    //Block Statement
            //}

            #endregion

            #region Single Dim Array
            ///Array is an Object , Reference Type 
            ///C++ Style int Arr[5]
            //int[] Arr;  ///Declare array Reference 
            /// Zero Bytes have been allocated in Heap

            //Arr = new int[5];
            ///Allocate an Array Object in Heap , of Size 5 , initialized with default values

            //Arr = new int[5] { 3, 4, 5, 6, 7 };

            //int[] Arr =  { 3, 4, 5, 6, 7 };

            //for ( int i = 0; i < Arr.Length; i++ )
            //    Console.WriteLine(Arr[i]);

            //Console.WriteLine($"Number of Dim {Arr.Rank} , Array Lenght :{Arr.Length}");

            //Arr[5] = 20; ///Exceed Upper Bound , Run Time Error

            //int[] Arr1 = { 1, 2, 3, 4, 5 ,6,7,8};
            //int[] Arr2 = { 9, 10 };

            //Console.WriteLine($"Arr1 {Arr1.GetHashCode()}");
            //Console.WriteLine($"Arr2 {Arr2.GetHashCode()}");

            /////Arr1 , Arr2 Same Object , Same identity , same state
            ////Arr2 = Arr1;
            ////Console.WriteLine("Arr2 = Arr1");
            ////Console.WriteLine($"Arr1 {Arr1.GetHashCode()}");
            ////Console.WriteLine($"Arr2 {Arr2.GetHashCode()}");


            /////Arr2 New Object with New identity , same state as Arr1 
            /////Deep Copy 
            //Arr2 = (int[])Arr1.Clone(); ///explicit Casting
            /////Ref to Derived = Base Object
            //Console.WriteLine($"Arr1 {Arr1.GetHashCode()}");
            //Console.WriteLine($"Arr2 {Arr2.GetHashCode()}");


            int[] Arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            #endregion

            #region Index
            //Console.WriteLine($"Lenght {Arr.Length}");

            //Console.WriteLine(Arr[0]); //First

            //Console.WriteLine(Arr[Arr.Length-1]); //last

            ////Console.WriteLine(Arr[Arr.Length]); /// Exception


            ////^0 : Arr.lenght
            ////^1: Arr.lenght -1 : last element
            //Console.WriteLine(Arr[^1]);
            //Console.WriteLine(Arr[^3]);
            //Console.WriteLine(Arr[^9]);
            //int n = 5;
            //Console.WriteLine(Arr[^n]);

            //Index MyIndex = ^7;
            //Console.WriteLine(Arr[MyIndex]);


            #endregion

            #region MyRegion
            ////int[] MyArr = new int[10]; Array.Copy(Arr,4, MyArr,0 ,3);

            //int[] MyArr;

            ////MyArr = Arr;///reference Equality , Shallow Copy
            //MyArr = Arr[0..3]; ///Start : included , End : Excluded
            //MyArr = Arr[..3]; ///Start from index 0
            //MyArr = Arr[5..]; ///Till last element (included)
            //MyArr = Arr[3..^2];
            //MyArr = Arr[^4..^2];

            //Range MyRange = ..^3;
            //MyArr = Arr[MyRange];

            //for ( int i = 0; i < MyArr.Length; i++ )
            //    Console.WriteLine(MyArr[i]);

            //Console.WriteLine(Arr.GetHashCode());
            //Console.WriteLine(MyArr.GetHashCode()); 
            #endregion

            #region Two Dim Array
            /////C++ int Marks[3][5];
            //int[,] Marks = new int[3, 5] { { 1, 2, 3, 4, 5 }, { 7, 8, 9, 10, 11 }, { 10, 10, 10, 10, 10 } };

            //Console.WriteLine(Marks.Length);
            //Console.WriteLine(Marks.Rank); //2


            //for (int i = 0; i < Marks.GetLength(0); i++) //Rows
            //    for( int j =0; j < Marks.GetLength(1); j++) //Columns
            //        Console.WriteLine(Marks[i,j]); 
            #endregion

            ///Jagged Array
            //int[][] Marks = new int[3][];

            //Marks[0] = new int[10];
            //Marks[1] = new int[3];
            //Marks[2] = new int[7];

            //Marks[0][0] = 11;

        }
    }
}
