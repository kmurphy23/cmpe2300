using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA15_Kaitlyn
{
    abstract class Gate
    {
        //our 3 prtected variables for the 2 inputs and 1 output of 
        //our logic gate
        protected bool _input1;
        protected bool _input2;
        protected bool _output;

        //then we provide a manual get for each of the inputs and the output
        public bool input1
        {
            get { return _input1; } //will get the input value
        }

        public bool input2
        {
            get { return _input2; } //will get the input value
        }

        public bool output
        {
            get { return _output; } //will get the output value
        }

        //these getters is what the user will interact with so they dont
        //mess with the rest

        ///this method takes in two bools but doesnt return anything
        ///this will take the two bools and make the value of input1 and 2
        ///into these passed bools
        /// <param name="InVal1"> this is the first input value we will set</param>
        /// <param name="InVal2"> this is the second input value for  the logic gates</param>
        public void Set(bool InVal1, bool InVal2)
        {
            //setting the two values to the inputs
            _input1 = InVal1;
            _input2 = InVal2;
        }

        //these next four methods are for the NVI aspect of the assignement
        public void Latch()
        {
            vLatch();
        }
        //MATCHING ABSTRACT METHOD FOR THE LATCH METHOD
        public abstract void vLatch();
        
        //name method
        public string Name()
        {
            return vName();
        }
        //matching abstract method for the name method
        public abstract string vName();
    }


    //Now for the derived classes

    //first off is the NandGate derived from Gate
    class NandGate: Gate
    {
        //this override will set the value of the output to the NAND of the inputs
        public override void vLatch()
        {
            _output = _input1 ^ _input1;
        }

        //as always the name override is to return the name of the gate
        public override string vName()
        {
            return "Nand";
        }
    }

    //next is the OrGate derived from Gate 
    class OrGate: Gate
    {
        //this override will return the or of the 2 inputs
        public override void vLatch()
        {
            _output = _input1 || _input2;
        }
        //as always the name override is to return the name of the gate
        public override string vName()
        {
            return "OR";
        }
    }

    //lastly for the derived from Gate classes we have the XorGate
    class XorGate: Gate
    {
        //this override will set the output to the 2 inputs xor'ed together
        public override void vLatch()
        {
            _output = _input1 ^ _input2;
        }
        //as always the name override is to return the name of the gate
        public override string vName()
        {
            return "XOR";
        }
    }

    //this last one is derived from our previously derived 
    //NandGate cause an and gate is just the opposite of a Nand gate
    class AndGate: NandGate
    {
        //this is the overriden latch method from the NAND class 
        public override void vLatch()
        {
            //need help with this one please 
        }
        //this is the name overriden from the NAND class 
        public override string vName()
        {
            return "AND";
        }
    }
}
