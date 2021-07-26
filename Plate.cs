using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace RoseroGabriela
{
    class Plate
    {
        String plate;
        int dayPlate;
        String letterPlate;
        char[] chars = default;
        bool isValide = true;
        public bool InputPlate()
        {
            Console.Write("Enter the plate: ");
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
        public bool InputTimePlate()
        {
            Console.Write("Enter the time: ");
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