using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Pult pult = new Pult();
            TV tv = new TV();
            pult.SetCommand(new TVOnCommand(tv));
            pult.PressButton();
            pult.PressUndo();

            Car car = new Car();
            pult.SetCommand(new CarCommand(car));
            pult.PressButton();
            pult.PressUndo();


            Console.Read();
        }
        interface ICommand
        {
            void Execute();
            void Undo();
        }

        // Receiver - Получатель
        class TV
        {
            public void On()
            {
                Console.WriteLine("Телевизор включен!");
            }

            public void Off()
            {
                Console.WriteLine("Телевизор выключен...");
            }
        }
        class Car
        {
            public void On()
            {
                Console.WriteLine("Машина заведена!");
            }

            public void Off()
            {
                Console.WriteLine("Машина заглушена");
            }
            public void Open()
            {
                Console.WriteLine("Машина открыта");
            }
        }

        class TVOnCommand : ICommand
        {
            TV tv;
            public TVOnCommand(TV tvSet)
            {
                tv = tvSet;
            }
            public void Execute()
            {
                tv.On();
            }
            public void Undo()
            {
                tv.Off();
            }
        }

        class CarCommand : ICommand
        {
            Car car;
            public CarCommand(Car carSet)
            {
                car = carSet;
            }
            public void Execute()
            {
                car.On();
                car.Open();
            }
            public void Undo()
            {
                car.Off();
            }
        }

        // Invoker - инициатор
        class Pult
        {
            ICommand command;

            public Pult() { }

            public void SetCommand(ICommand com)
            {
                command = com;
            }

            public void PressButton()
            {
                command.Execute();
            }
            public void PressUndo()
            {
                command.Undo();
            }
        }
    }
}
