using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA15_Kaitlyn
{
    class Program
    {
        
    static void Main(string[] args)
        {
            //make an array of gates
            Gate[] gates = { new AndGate(), new NandGate(), new OrGate(), new XorGate()};

            //foreach gate in the gate array
            foreach(Gate g in gates)
            {
                //write to the console in the nice pretty table
                Console.WriteLine(ToTable(g));
            }
            Console.ReadLine();
            Console.Clear();

            //create a new string builder
            StringBuilder write2 = new StringBuilder();
            write2.AppendLine($"A B C D O");

            //make 10 gates one for each gate in the diagram given
            AndGate gate1 = new AndGate();
            OrGate gate2 = new OrGate();
            NandGate gate3 = new NandGate();
            XorGate gate4 = new XorGate();
            NandGate gate5 = new NandGate();
            OrGate gate6 = new OrGate();
            AndGate gate7 = new AndGate();
            XorGate gate8 = new XorGate();
            AndGate gate9 = new AndGate();
            OrGate gate10 = new OrGate();


            //4 nested for loops to iterate trhough each gate
            for (int a = 0; a < 2; a++)
            {
                for (int b = 0; b < 2; b++)
                {
                    for (int c = 0; c < 2; c++)
                    {
                        for (int d = 0; d < 2; d++)
                        {
                            //1
                            gate1.Set(a == 1, a == 1);
                            gate1.Latch();
                            //2
                            gate2.Set(a == 1, b == 1);
                            gate2.Latch();
                            //3
                            gate3.Set(b == 1, c == 1);
                            gate3.Latch();
                            //4
                            gate4.Set(gate3.output, c == 1);
                            gate4.Latch();
                            //5
                            gate5.Set(gate1.output, gate2.output);
                            gate5.Latch();
                            //6
                            gate6.Set(gate1.output, gate5.output);
                            gate6.Latch();
                            //7
                            gate7.Set(gate2.output, gate4.output);
                            gate7.Latch();
                            //8
                            gate8.Set(gate4.output,d==1);
                            gate8.Latch();
                            //9
                            gate9.Set(gate6.output, gate7.output);
                            gate9.Latch();
                            //10
                            gate10.Set(gate9.output, gate8.output);
                            gate10.Latch();

                            write2.AppendLine($"{a} {b} {c} {d} {Convert.ToInt32(gate10.output)}");
                        }
                    }
                }
            }
            //write them all to the console based on what we have in our stringbuilder
            Console.WriteLine(write2.ToString());
            Console.ReadLine();
    }



        /// this method will take all of our data and make a table out of it
        /// <param name="GIn">this is the gate we are passing in</param>
        /// <returns>the built string of our gate</returns>
        public static string ToTable(Gate GIn)
        {
            //initialize a new stringbuilder
            StringBuilder writer = new StringBuilder();

            //this is the top line title line
            writer.AppendLine($"A B {GIn.Name()}");

            //iterate through and set the values for both inputs
            for (int a = 0; a < 2; a++)
            {
                for (int b = 0; b < 2; b++)
                {
                    //set the values of both inputs 
                    GIn.Set(a == 1, b == 1);
                    GIn.Latch();
                    writer.AppendLine($"{a} {b} {Convert.ToInt32(GIn.output)}");
                }
            }
            //return the string we have built
            return writer.ToString();
        }
    }
}
