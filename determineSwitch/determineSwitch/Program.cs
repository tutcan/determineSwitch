using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace determineSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program tells us the previous state of a light switch knowing the initial state and the number of clicks that were needed to reach that current state\n");
            Boolean myCurrentState = currentStateOfSwitch();
            int myNumberOfClicks = takeNumberOfClicks();
            
            String val;           
            if (myCurrentState == true)
                val = "ON";
            else
                val = "OFF";

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("The previous state of the switch after " + myNumberOfClicks + " click(s) and " + val + " current state:");
            Console.WriteLine(previousStateOfSwitch(myCurrentState, myNumberOfClicks));

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadLine();
            }
        }

        /* FUNCTION TO ACCEPT CURRENT STATE OF SWITCH */
        static Boolean currentStateOfSwitch()
        {
            Console.WriteLine("What is the current state of your switch ? \n 1.On\n 2.Off");
            
            int switchState = Convert.ToInt16(Console.ReadLine());

            switch (switchState)
            {
                case 1:
                    return true;
                    
                case 2:
                    return false;
                    
                default:
                    Console.WriteLine("\nERROR!!! You made a wrong selection. Please try again.\n");
                    return currentStateOfSwitch();         
            }       
        }

        /* FUNCTION TO COMPUTE PREVIOUS STATE OF SWITCH */
        static String previousStateOfSwitch(bool current, int switchClicks)
        {
            int[] variableState = new int[switchClicks + 1];

            for (int i = switchClicks; i > 0; i--)
            {
                if (current == true)
                {
                    variableState[switchClicks] = 1;

                    if (variableState[i] == 1)
                    {
                        variableState[i - 1] = 0;
                    }
                    else
                    {
                        variableState[i - 1] = 1;
                    }
                }
                if (current == false)
                {
                    variableState[switchClicks] = 0;

                    if (variableState[i] == 0)
                    {
                        variableState[i - 1] = 1;
                    }
                    else
                    {
                        variableState[i - 1] = 0;
                    }
                }
            }
            if (variableState[0] == 1)
            {
                return "ON";
            }
            else
            {
                return "OFF";
            }
        }

        /* FUNCTION TO ACCEPT NUMBER OF CLICKS ON SWITCH TO REACH CURRENT STATE */
        static int takeNumberOfClicks()
        {
            Console.WriteLine("\nHow many clicks were needed to get to this current state ?");

            int numberOfClicks = Convert.ToInt16(Console.ReadLine());

            return numberOfClicks;
        }
    }
}


