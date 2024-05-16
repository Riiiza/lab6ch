using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Lab1
{
    internal class Program
    {
        class Auto
        {
            protected string type;
            protected int volume;
            protected int power;
            public int price;   
            public Auto()
            {
                this.type = "Auto";
                this.volume = 0;
                this.power = 0;
                this.price = 0;
            }
            public Auto(string type, int price = 200)
            {
                this.type = type;
                this.price = price;
            }
            public Auto(string type = "Легковой", int volume = 50, int power = 57, int price = 100)
            {
                this.type = type;
                this.volume = volume;
                this.power = power;
                this.price = price;
            }
            [DllImport(@"DLL.dll",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Unicode)]
            public static extern bool InputStr(
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder str, int len);

            [DllImport(@"DLL.dll",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Unicode)]
            public static extern int InputInt();

            [DllImport(@"DLL.dll",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Unicode)]
            public static extern bool OutputInt(int num);

            [DllImport(@"DLL.dll",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Unicode)]
            public static extern bool OutputStr(
                [MarshalAs(UnmanagedType.LPWStr)] StringBuilder str, int length);
            public virtual void Input()
            {
                Console.WriteLine("Enter type, volume, power, price");
                StringBuilder str = new StringBuilder(10);
                InputStr(str, str.Capacity);
                type = str.ToString();
                volume = InputInt();
                power = InputInt();
                price = InputInt();
            }

            public virtual void Output()
            {
                OutputStr(new StringBuilder(type), type.Length);
                OutputInt(volume);
                OutputInt(power);
                OutputInt(price);
                Console.WriteLine("\n");
            }

            private void SetType(string type)
            {
                this.type = type;
            }

            private void SetVolume(int volume)
            {
                this.volume = volume;
            }

            private void SetPower(int power)
            {
                this.power = power;
            }

            private void SetPrice(int price)
            {
                this.price = price;
            }

            protected string Gettype()
            {
                return type;
            }

            protected int GetVolume() {
                return volume;
            }

            protected int GetPower()
            {
                return power;
            }

            protected int GetPrice()
            {
                return price;
            }
            
            ~Auto()
            {
                this.type = null;
                this.volume = 0;
                this.power = 0;
                this.price = 0;
            }
        }
        [StructLayout(
            LayoutKind.Sequential,
            CharSet = CharSet.Unicode)]

        public struct PassengerStruct
        {
            [MarshalAs(
                UnmanagedType.ByValTStr,
                SizeConst = 100)]
            public string type;
            public int volume;
            public int power;
            public int price;
            public int doors;
            public PassengerStruct(string type, int volume, int power, int price, int doors)
            {
                this.type = type;
                this.volume = volume;
                this.power = power;
                this.price = price;
                this.doors = doors;
            }
        }
        class Passenger : Auto
        {
            private int doors;
            public Passenger(string type, int volume, int power, int price, int doors) : base(type, volume, power, price)
            {
                this.doors = 0;
            }
            public Passenger()
            {
                this.type = "Passenger";
                this.doors = 0;
            }
            [DllImport(@"DLL.dll",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Unicode)]
            public static extern bool InputPassenger(
            ref PassengerStruct ptr);

            public override void Input()
            {
                PassengerStruct structure = new PassengerStruct();
                InputPassenger(ref structure);
                type = structure.type;
                volume = structure.volume;
                power = structure.power;
                price = structure.price;
                doors = structure.doors;
            }

            [DllImport(@"DLL.dll",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Unicode)]
            public static extern bool OutputPassenger(
               ref PassengerStruct ptr);

            public override void Output()
            {
                PassengerStruct structure = new PassengerStruct(type, volume, power, price, doors);
                OutputPassenger(ref structure);
                Console.WriteLine("\n");
            }
        }
        [StructLayout(
            LayoutKind.Sequential,
            CharSet = CharSet.Unicode)]
        public struct CargoStruct
        {
            [MarshalAs(
                UnmanagedType.ByValTStr,
                SizeConst = 100)]
            public string type;
            public int volume;
            public int power;
            public int price;
            public int weight;
            public CargoStruct(string type, int volume, int power, int price, int weight)
            {
                this.type = type;
                this.volume = volume;
                this.power = power;
                this.price = price;
                this.weight = weight;
            }
        }
        class Cargo : Auto
        {
            public int weight;
            public Cargo()
            {
                this.weight = 0;
                this.type = "Cargo";
            }
            public Cargo(string type, int volume, int power, int price, int weight) : base(type, volume, power, price)
            {
                this.weight = 0;
            }

            [DllImport(@"DLL.dll",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Unicode)]
            public static extern bool InputCargo(
            ref CargoStruct ptr);

            public override void Input()
            {
                CargoStruct structure = new CargoStruct();
                InputCargo(ref structure);
                type = structure.type;
                volume = structure.volume;
                power = structure.power;
                price = structure.price;
                weight = structure.weight;
            }

            [DllImport(@"DLL.dll",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Unicode)]
            public static extern bool OutputCargo(
               ref CargoStruct ptr);

            public override void Output()
            {
                CargoStruct structure = new CargoStruct(type, volume, power, price, weight);
                OutputCargo(ref structure);
                Console.WriteLine("\n");
            }
        }
        [StructLayout(
            LayoutKind.Sequential,
            CharSet = CharSet.Unicode)]
        public struct KamazStruct
        {
            [MarshalAs(
                UnmanagedType.ByValTStr,
                SizeConst = 100)]
            public string type;
            public int volume;
            public int power;
            public int price;
            public int weight;
            [MarshalAs(
                UnmanagedType.ByValTStr,
                SizeConst = 100)]
            public string model;
            public KamazStruct(string type, int volume, int power, int price, int weight, string model)
            {
                this.type = type;
                this.volume = volume;
                this.power = power;
                this.price = price;
                this.weight = weight;
                this.model = model;
            }
        }
        class Kamaz : Cargo
        {
            private string model;
            public Kamaz()
            {
                this.model = "";
                this.type = "Kamaz";
            }
            public Kamaz(string type, int volume, int power, int price, int weight, string model) : base(type, volume, power, price, weight)
            {
                this.model = model;
            }

            [DllImport(@"DLL.dll",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Unicode)]
            public static extern bool InputKamaz(
            ref KamazStruct ptr);

            public override void Input()
            {
                KamazStruct structure = new KamazStruct();
                InputKamaz(ref structure);
                type = structure.type;
                volume = structure.volume;
                power = structure.power;
                price = structure.price;
                weight = structure.weight;
                model = structure.model;
            }

            [DllImport(@"DLL.dll",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Unicode)]
            public static extern bool OutputKamaz(
               ref KamazStruct ptr);

            public override void Output()
            {
                KamazStruct structure = new KamazStruct(type, volume, power, price, weight, model);
                OutputKamaz(ref structure);
                Console.WriteLine("\n");
            }
        }

        static void Main(string[] args)
        {
            Auto auto = new Auto();
            auto.Input();
            auto.Output();

            Passenger passenger = new Passenger();
            passenger.Input();
            passenger.Output();

            Cargo cargo = new Cargo();
            cargo.Input();
            cargo.Output();

            Kamaz kamaz = new Kamaz();
            kamaz.Input();
            kamaz.Output();
        }
    }
}
