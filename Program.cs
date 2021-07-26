using System;

namespace RoseroGabriela
{
    class Program
    {

        static void Main(string[] args)
        {
            Plate plateNew = new Plate();
            Console.WriteLine("******Hello! Welcome to 'Pico & Placa' Predictor******\n");
            while (true)
            {
                while (plateNew.InputPlate().Equals(true) && plateNew.InputDatePlate().Equals(true) && plateNew.InputTimePlate().Equals(true))
                {
                    if (plateNew.PicoPlacaPredictor().Equals(true))
                        Console.WriteLine("You can be on the road!");
                    else
                        Console.WriteLine("You cannot be on the road!");
                }
                Console.WriteLine("Invalid format!");
            }
            
        }


       

    }
}
