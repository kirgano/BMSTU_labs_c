using System;
using System.Reflection;

namespace Refl
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle obj = new Rectangle(3.1, 3.2);
            Type t = obj.GetType();
            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }

            //содержат ли свойства  атрибут NewAttribute
            Type t1 = typeof(Rectangle);
            Console.WriteLine("\nСвойства, помеченные атрибутом:");
            foreach (var x in t1.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(NewAttribute), out attrObj))
                {
                    NewAttribute attr = attrObj as NewAttribute;// Для приведения полученного значения типа object к требуемому типу NewAttribute
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }

            //вызов метода с использованием рефлексии
            Type t2 = typeof(Rectangle);
            Console.WriteLine("\nВызов метода:");
            //Создание объекта
            //ForInspection fi = new ForInspection();
            //Можно создать объект через рефлексию
            Rectangle fi = (Rectangle)t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });
            //Параметры вызова метода
            object[] parameters = new object[] { 3.1, 3 };
            //Вызов метода
            object Result = t2.InvokeMember("Area1", BindingFlags.InvokeMethod, null, fi, parameters);
            Console.WriteLine("Area1 (3.1 ,3)={0}", Result);
            // Метод InvokeMember принимает различные

        }

        public class Rectangle
        {

            [NewAttribute("Описание для heigth")]

            public double heigth
            {
                set
                {
                    if (value < 0)
                        Console.WriteLine("Введено некоректное значение высоты");
                    else _heigth = value;
                }
                get { return _heigth; }

            }
            private double _heigth;


            [NewAttribute(Description = "Описание для width")]
            public double width
            {
                set
                {
                    if (value < 0)
                        Console.WriteLine("Введено некоректное значение ширины");
                    else
                        _width = value;
                }
                get { return _width; }
            }
            private double _width;
            public Rectangle() { }
            public Rectangle(double width, double heigth)
            {
                this.width = width;
                this.heigth = heigth;

            }

            public double Area()
            {
                return this.heigth * this.width;
            }

            public double Area1(double heigth, double width)
            {
                return heigth * width;
            }


        }

        /// Класс атрибута
        // /// </summary>
        [AttributeUsage(AttributeTargets.Property, AllowMultiple =
       false, Inherited = false)]
        public class NewAttribute : Attribute
        {
            public NewAttribute() { }
            public NewAttribute(string DescriptionParam)
            {
                Description = DescriptionParam;
            }
            public string Description { get; set; }
        }

        public static bool GetPropertyAttribute(PropertyInfo checkType, Type// информация о проверяемом свойстве,
attributeType, out object attribute)//тип проверяемого атрибута
        {
            bool Result = false;
            attribute = null;
            //Поиск атрибутов с заданным типом
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }
            return Result;
        }


    }
}
