using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAB_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(2, 5);
            Square square = new Square(4);
            Circle circle = new Circle(4);

            Console.WriteLine("\nArrayList");
            ArrayList arrayList = new ArrayList();
            arrayList.Add(circle);
            arrayList.Add(rectangle);
            arrayList.Add(square);
            foreach (GeomFigure o in arrayList)
            {
                Console.WriteLine(o.ToString());
            }

            Console.WriteLine("\nSORTED ArrayList");
            arrayList.Sort();
            foreach (GeomFigure o in arrayList)
            {
                Console.WriteLine(o.ToString());
            }

            Console.WriteLine("\nList");
            List<GeomFigure> FiguresList = new List<GeomFigure>();
            FiguresList.Add(circle);
            FiguresList.Add(rectangle);
            FiguresList.Add(square);
            foreach (GeomFigure o in FiguresList)
            {
                Console.WriteLine(o.ToString());
            }

            Console.WriteLine("\nSORTED List");
            FiguresList.Sort();
            foreach (GeomFigure o in FiguresList)
            {
                Console.WriteLine(o.ToString());
            }

            Console.WriteLine("\nMATRIX");
            Matrix<GeomFigure> matrix = new Matrix<GeomFigure>(3, 3, 3, new GeomFigureMatrixCheckEmpty());

            matrix[0, 0, 0] = rectangle;
            matrix[1, 1, 1] = square;
            matrix[2, 2, 2] = circle;
            Console.WriteLine(matrix.ToString());

            Console.WriteLine("\nSimpleList");
            SimpleList<GeomFigure> simpleList = new SimpleList<GeomFigure>();

            simpleList.Add(circle);
            simpleList.Add(rectangle);
            simpleList.Add(square);

            foreach (var x in simpleList)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nSORTED SimpleList");
            simpleList.Sort();
            foreach (var x in simpleList)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nSimpleStack");
            SimpleStack<GeomFigure> simplestack = new SimpleStack<GeomFigure>();

            simplestack.push(circle);
            simplestack.push(rectangle);
            simplestack.push(square);

            foreach (var x in simplestack)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nSimpleStack popping out");

            while (simplestack.Count > 0)
            {
                GeomFigure f = simplestack.pop();
                Console.WriteLine(f);
            }
            Console.ReadLine();
        }
    }
}

