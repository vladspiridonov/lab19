using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace computers
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            NumberFormatInfo ask = new NumberFormatInfo();
            //cultureInfo.CurrencySymbol = "₽";
                       
            ask.CurrencySymbol = "pуб. ";
            cultureInfo.NumberFormat = ask;
            var formatProvider = cultureInfo;
           
            List<Computrer> computrersList = new List<Computrer>()
            {
                new Computrer(){Code="12F",Name="Baikal",Ptype="R",ClockRate=1.2, RamVolume=4,SsdVolume=256,GpuVolume=1,Cost=124500,Quantity=0},
                new Computrer(){Code="CU3",Name="Elbrus",Ptype="R",ClockRate=1.3, RamVolume=8,SsdVolume=512,GpuVolume=0,Cost=700000,Quantity=0},
                new Computrer(){Code="114",Name="Gygabyte",Ptype="I",ClockRate=3.5, RamVolume=16,SsdVolume=512,GpuVolume=8,Cost=115000,Quantity=7},
                new Computrer(){Code="115",Name="Gygabyte",Ptype="I",ClockRate=4.4, RamVolume=32,SsdVolume=2048,GpuVolume=12,Cost=185000,Quantity=5},
                new Computrer(){Code="F2U",Name="HP",Ptype="A",ClockRate=3.2, RamVolume=16,SsdVolume=512,GpuVolume=4,Cost=70000,Quantity=13245},
                new Computrer(){Code="G25",Name="Lenovo",Ptype="A",ClockRate=3.5, RamVolume=32,SsdVolume=1024,GpuVolume=4,Cost=150000,Quantity=25},
                new Computrer(){Code="224",Name="Asus",Ptype="I",ClockRate=2.1, RamVolume=8,SsdVolume=512,GpuVolume=0,Cost=45000,Quantity=99},
                new Computrer(){Code="F2H",Name="HP",Ptype="A",ClockRate=5.0, RamVolume=16,SsdVolume=512,GpuVolume=2,Cost=90000,Quantity=0},
                new Computrer(){Code="768",Name="Acer",Ptype="I",ClockRate=1.2, RamVolume=4,SsdVolume=128,GpuVolume=0,Cost=30000,Quantity=300}

            };
            Console.WriteLine("Код:   Производитель:   Тип процессора:  Частота:   Объем ОЗУ:  Объем SSD:  Объем GPU:            Цена:  Кол-во:");

            foreach (Computrer a in computrersList)               
                 Console.WriteLine(string.Format(formatProvider, "{0,4}   {1,14}   {2,15}  {3,4:0.0} ГГц   {4,7} Гб  {5,7} Гб  {6,7} Гб  {7,15:c2}   {8,6}",a.Code,a.Name,a.Ptype, a.ClockRate,a.RamVolume,a.SsdVolume,a.GpuVolume,a.Cost,a.Quantity));
            try
            {
                Console.WriteLine("\nОпределить:" +
                    "\n1 - все компьютеры с указанным процессором\n" +
                    "\n2 - все компьютеры с объемом ОЗУ не ниже, чем указано\n" +
                    "\n3 - вывести весь список, отсортированный по увеличению стоимости\n" +
                    "\n4 - вывести весь список, сгруппированный по типу процессора\n" +
                    "\n5 - найти самый дорогой и самый бюджетный компьютер\n" +
                    "\n6 - есть ли хотя бы один компьютер в количестве не менее 30 штук?\n" +
                    "\n0 - Выход");
                ConsoleKeyInfo num = Console.ReadKey();
                do
                {
                    switch (num.Key)
                    {
                        case ConsoleKey.D1:
                            {
                                Console.WriteLine("\nУкажите тип процессора (регистр учитывается):");
                                string s = Console.ReadLine();
                                List<Computrer> computrers = computrersList
                                    .Where(d => d.Ptype == s)
                                    .ToList();
                                Console.WriteLine("Код:   Производитель:   Тип процессора:  Частота:   Объем ОЗУ:  Объем SSD:  Объем GPU:            Цена:  Кол-во:\n");
                                if (computrers.Count == 0)
                                    Console.WriteLine("Поиск не дал результатов");
                                foreach (Computrer a in computrers)
                                    Console.WriteLine(string.Format(formatProvider, "{0,4}   {1,14}   {2,15}  {3,4:0.0} ГГц   {4,7} Гб  {5,7} Гб  {6,7} Гб  {7,15:c2}   {8,6}", a.Code, a.Name, a.Ptype, a.ClockRate, a.RamVolume, a.SsdVolume, a.GpuVolume, a.Cost, a.Quantity));
                                break;
                            }
                        case ConsoleKey.D2:
                            {
                                Console.WriteLine("\nУкажите минимальный объем ОЗУ:");
                                int s = Convert.ToInt32(Console.ReadLine());
                                List<Computrer> computrers = computrersList
                                    .Where(d => d.RamVolume >= s)
                                    .ToList();
                                Console.WriteLine("Код:   Производитель:   Тип процессора:  Частота:   Объем ОЗУ:  Объем SSD:  Объем GPU:            Цена:  Кол-во:\n");
                                if (computrers.Count == 0)
                                    Console.WriteLine("Поиск не дал результатов");
                                foreach (Computrer a in computrers)
                                    Console.WriteLine(string.Format(formatProvider, "{0,4}   {1,14}   {2,15}  {3,4:0.0} ГГц   {4,7} Гб  {5,7} Гб  {6,7} Гб  {7,15:c2}   {8,6}", a.Code, a.Name, a.Ptype, a.ClockRate, a.RamVolume, a.SsdVolume, a.GpuVolume, a.Cost, a.Quantity));
                                break;                                
                            }
                        case ConsoleKey.D3:
                            {
                                
                                IEnumerable<Computrer> computrers = computrersList
                                    .OrderBy(d=> d.Cost)                                    
                                    .ToList();
                                Console.WriteLine("Код:   Производитель:   Тип процессора:  Частота:   Объем ОЗУ:  Объем SSD:  Объем GPU:            Цена:  Кол-во:\n");
                                foreach (Computrer a in computrers)
                                    Console.WriteLine(string.Format(formatProvider, "{0,4}   {1,14}   {2,15}  {3,4:0.0} ГГц   {4,7} Гб  {5,7} Гб  {6,7} Гб  {7,15:c2}   {8,6}", a.Code, a.Name, a.Ptype, a.ClockRate, a.RamVolume, a.SsdVolume, a.GpuVolume, a.Cost, a.Quantity));
                                break;
                            }
                        case ConsoleKey.D4:
                            {
                                IEnumerable<Computrer> computrers = computrersList
                                       .OrderBy(d => d.Ptype)
                                       .ToList();
                                Console.WriteLine("Код:   Производитель:   Тип процессора:  Частота:   Объем ОЗУ:  Объем SSD:  Объем GPU:            Цена:  Кол-во:\n");
                                foreach (Computrer a in computrers)
                                    Console.WriteLine(string.Format(formatProvider, "{0,4}   {1,14}   {2,15}  {3,4:0.0} ГГц   {4,7} Гб  {5,7} Гб  {6,7} Гб  {7,15:c2}   {8,6}", a.Code, a.Name, a.Ptype, a.ClockRate, a.RamVolume, a.SsdVolume, a.GpuVolume, a.Cost, a.Quantity));
                                break;
                            }
                        case ConsoleKey.D5:
                            {
                                List<Computrer> computrers = computrersList
                                        .OrderBy(d => d.Cost)
                                        .ToList();
                                Console.WriteLine("\nКод:   Производитель:   Тип процессора:  Частота:   Объем ОЗУ:  Объем SSD:  Объем GPU:            Цена:  Кол-во:\n");
                                Console.WriteLine(string.Format(formatProvider, "{0,4}   {1,14}   {2,15}  {3,4:0.0} ГГц   {4,7} Гб  {5,7} Гб  {6,7} Гб  {7,15:c2}   {8,6}", computrers[0].Code, computrers[0].Name, computrers[0].Ptype, computrers[0].ClockRate, computrers[0].RamVolume, computrers[0].SsdVolume, computrers[0].GpuVolume, computrers[0].Cost, computrers[0].Quantity));
                                computrers = computrersList
                                       .OrderByDescending(d => d.Cost)
                                       .ToList();
                                Console.WriteLine(string.Format(formatProvider, "{0,4}   {1,14}   {2,15}  {3,4:0.0} ГГц   {4,7} Гб  {5,7} Гб  {6,7} Гб  {7,15:c2}   {8,6}", computrers[0].Code, computrers[0].Name, computrers[0].Ptype, computrers[0].ClockRate, computrers[0].RamVolume, computrers[0].SsdVolume, computrers[0].GpuVolume, computrers[0].Cost, computrers[0].Quantity));
                                break;
                            }
                        case ConsoleKey.D6:
                            {
                                List<Computrer> computrers = computrersList
                                    .Where(d => d.Quantity >= 30)
                                    .ToList();
                                if (computrers.Count == 0)
                                    Console.WriteLine("\nНет");
                                else Console.WriteLine("\nДа");
                                break;
                            }
                        default:
                            break;
                    }

                    Console.WriteLine("\nОпределить:" +
                    "\n1 - все компьютеры с указанным процессором\n" +
                    "\n2 - все компьютеры с объемом ОЗУ не ниже, чем указано\n" +
                    "\n3 - вывести весь список, отсортированный по увеличению стоимости\n" +
                    "\n4 - вывести весь список, сгруппированный по типу процессора\n" +
                    "\n5 - найти самый дорогой и самый бюджетный компьютер\n" +
                    "\n6 - есть ли хотя бы один компьютер в количестве не менее 30 штук?\n" +
                    "\n0 - Выход");
                    num = Console.ReadKey();
                } while (num.Key != ConsoleKey.D0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
    class Computrer
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Ptype { get; set; }
        public double ClockRate { get; set; }
        public int RamVolume { get; set; }
        public int SsdVolume { get; set; }
        public int GpuVolume { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
    }    
}
