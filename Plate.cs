using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace RoseroGabriela
{
    public class Plate
    {
        String plate;
        int dayPlate;
        String letterPlate;
        char[] chars = default;
        bool isValide = true;

        //You can enter car's plate or motorcycle's plate without hyphen.
        public bool InputPlate()
        {
            Console.Write("Enter the plate (without hyphen): ");
            plate = Console.ReadLine();
            chars = plate.ToCharArray();
            if (chars.Length >= 6 && (ValidationPlateCar().Equals(true) || ValidationPlateMoto().Equals(true)))
            {
                return isValide = true;
            }
            else
            {
                return isValide = false;
            }
        }

        //Validation to car's plate Example: AAS425 or AWR14523
        private bool ValidationPlateCar()
        {
            var commonPart = Char.IsLetter(chars[0]) && Char.IsLetter(chars[1]) && Char.IsLetter(chars[2]) && Char.IsNumber(chars[3]) && Char.IsNumber(chars[4]) && Char.IsNumber(chars[5]);
            letterPlate = plate.Substring(0, 3);
            if (chars.Length == 6)
            {
                if (commonPart)
                {
                    return isValide = true;
                }
                else
                {
                    return isValide = false;
                }
            }
            else if (chars.Length == 7)
            {
                if (commonPart && Char.IsNumber(chars[6]))
                {
                    return isValide = true;
                }
                else
                {
                    return isValide = false;
                }
            }
            return isValide = false;
        }

        //Validation to motorcycle's plate. Example: AA253A
        private bool ValidationPlateMoto()
        {
            letterPlate = plate.Substring(0, 3);
            if (chars.Length == 6)
            {
                if (Char.IsLetter(chars[0]) && Char.IsLetter(chars[1]) && Char.IsNumber(chars[2]) && Char.IsNumber(chars[3]) && Char.IsNumber(chars[4]) && Char.IsLetter(chars[5]))
                {
                    return isValide = true;
                }
                else
                {
                    return isValide = false;
                }
            }
            else
            {
                return isValide = false;
            }
        }

        //Enter & Validation Date. Example: 12/11/2020
        public bool InputDatePlate()
        {
            Console.Write("Enter the Date (dd/MM/yyyy): ");
            String dateInput = Console.ReadLine();
            DateTime date;
            if (DateTime.TryParseExact(dateInput, "dd/MM/yyyy",
                                      CultureInfo.InvariantCulture,
                                      DateTimeStyles.None, out date))
            {
                dayPlate = (int)date.DayOfWeek;
                return isValide = true;
            }
            else
            {
                Console.Write("Invalid date: ");
                return isValide = false;
            }
        }

        //Enter & Validation Time. Example: 04:00 or 15:35 or 03:35 pm
        public bool InputTimePlate()
        {
            Console.Write("Enter the time (HH:mm): ");
            string timePlate = Console.ReadLine();
            DateTime d = DateTime.Parse(timePlate);
            TimeSpan time = TimeSpan.Parse(d.ToString("HH:mm:ss"));
            if (time >= new TimeSpan(07, 00, 00) && time <= new TimeSpan(09, 30, 00) || time >= new TimeSpan(16, 00, 00) && time <= new TimeSpan(19, 30, 00))
            {

                Console.Write("Invalid time: ");
                return isValide = false;
            }
            return isValide = true;
        }

        public bool PicoPlacaPredictor()
        {
            if (ValidationPlateMoto().Equals(true) || chars.Length == 6)
            {
                return isValide = DaysCase(6);
            }
            else if (ValidationPlateMoto().Equals(false) && chars.Length == 7)
            {
                return isValide = DaysCase(7);
            }
            return isValide = false;
        }

        public bool DaysCase(int length)
        {
            switch (chars.GetValue(length - 1))
            {
                case 1:
                case 2:
                    if (dayPlate == 1)
                    {
                        return isValide = true;
                    }
                    return isValide = false;
                    break;
                case 3:
                case 4:
                    if (dayPlate == 2)
                    {
                        return isValide = true;
                    }
                    return isValide = false;
                    break;
                case 5:
                case 6:
                    if (dayPlate == 3)
                    {
                        return isValide = true;
                    }
                    return isValide = false;
                    break;
                case 7:
                case 8:
                    if (dayPlate == 4)
                    {
                        return isValide = true;
                    }
                    return isValide = false;
                    break;
                case 9:
                case 0:
                    if (dayPlate == 5)
                    {
                        return isValide = true;
                    }
                    return isValide = false;
                    break;
                default:
                    return isValide = true;
                    break;
            }
        }
    }
}