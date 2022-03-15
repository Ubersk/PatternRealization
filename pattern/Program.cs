using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public abstract class Pattern
    {

        class MyProgram
        {
            public void On()
            {
                Console.WriteLine("Программа включена");
            }

            public void Off()
            {
                Console.WriteLine("Программа отключена...");
            }
        }

        class ProgramOnCommand : ICommand
        {
            MyProgram program;
            public ProgramOnCommand(MyProgram ProgramSet)
            {
                program = ProgramSet;
            }
            public void Execute()
            {
                program.On();
            }
            public void Undo()
            {
                program.Off();
            }
        }

        // Invoker - инициатор
        class InterfaceCommand
        {
            ICommand command;
            public void SetCommand(ICommand cmd)
            {
                command = cmd;
            }

            public void PressButton()
            {
                command.Execute();
            }
            public void PressUndo()
            {
                command.Undo();
            }

            public static void Main(string[] args)
            {
                InterfaceCommand pult = new InterfaceCommand();
                MyProgram tv = new MyProgram();
                pult.SetCommand(new ProgramOnCommand(tv));
                pult.PressButton();
                pult.PressUndo();

                Console.Read();
            }
        }
    }
}