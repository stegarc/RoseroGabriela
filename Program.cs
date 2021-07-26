using System;

namespace RoseroGabriela
{
    public class Program
    {

        private static void Main(string[] args)
        {
            Plate plateNew = new Plate();
            Console.WriteLine("******Hello! Welcome to 'Pico & Placa' Predictor******\n");
            while (true)
            {
                while (plateNew.InputPlate().Equals(true) && plateNew.InputDatePlate().Equals(true) && plateNew.InputTimePlate().Equals(true))
                {
                    if (plateNew.PicoPlacaPredictor().Equals(true))
                        Console.WriteLine("You can be on the road!\n");
                    else
                        Console.WriteLine("You cannot be on the road!\n");
                }
                Console.WriteLine("Invalid format!");
            }
            
        }


       

    }
}
