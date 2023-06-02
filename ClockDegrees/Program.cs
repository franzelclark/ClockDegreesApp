using System;

namespace ClockDegrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            Console.WriteLine("Clock Degrees App");

            pr.clockDegreeCalc();
        }

        public void clockDegreeCalc()
        {
            string restartProgram = "y"; 

            while (restartProgram == "y")
            {
                String inputHour;
                int intHour = 12;
                bool isValidHour = false;

                String inputMinute;
                int intMinute = 0;
                bool isValidMinute = false;

                double hourAngle;
                double minuteAngle;
                double diffAngle;

                while (!isValidHour)                       // Get hour. Keep having the user retry if the user gave an invalid input
                {
                    Console.WriteLine("Input hour (1-12): ");
                    inputHour = Console.ReadLine();
                    try
                    {
                        intHour = Int32.Parse(inputHour);
                        if (intHour > 0 && intHour < 13)
                        {
                            isValidHour = true;
                            if (intHour == 12)
                            {
                                intHour = 0;               // Same value, an hour in a clock goes 1-12
                                break;
                            }
                        }

                        if (!(intHour > 0 && intHour < 13))
                        {
                            isValidHour = false;
                            throw new FormatException();
                        }


                        // Console.WriteLine($"You put {intHour}");     // Check int user input
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"{inputHour} is not a valid input. Please try again.");
                    }
                }

                while (!isValidMinute)                       // Get minute. Keep having the user retry if the user gave an invalid input
                {
                    Console.WriteLine("Input minute (0-60): ");
                    inputMinute = Console.ReadLine();
                    try
                    {
                        intMinute = Int32.Parse(inputMinute);
                        if (intMinute >= 0 && intMinute < 60)
                        {
                            isValidMinute = true;
                            if (intHour == 60)
                            {
                                intHour = 0;               // Same value, a minute in a clock goes 0 - 60
                                break;
                            }
                        }

                        if (!(intMinute >= 0 && intMinute < 60))
                        {
                            isValidMinute = false;
                            throw new FormatException();
                        }


                        // Console.WriteLine($"You put {intMinute}");     // Check int user input
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"{inputMinute} is not a valid input. Please try again.");
                    }
                }
                //Console.WriteLine($"Input time is {intHour}:{intMinute}");    // Just to check inputted time

                hourAngle = intHour * 30 + intMinute * 0.5;                     // There are 360 degrees in a circle. There are 12 hours in an analog clock. 360 / 12 = 30 degrees per hour. Hour hand also moves per minute, (30 degrees / 60 minutes)) = 0.5 degrees per minute for the short arrow
                minuteAngle = intMinute * 6;                                    // The minute hand takes 60 minutes to do a full circle (360 degrees) so 360 / 60 = 6 degrees per minute. 
                diffAngle = Math.Abs(hourAngle - minuteAngle);                  // To get the smaller portion                     
                if (diffAngle > 180)                                            // If bigger than 180, just subtract to get the smaller portion
                    diffAngle = 360 - diffAngle;


                Console.WriteLine($"The lesser angle is {diffAngle}°");
                Console.WriteLine("Press y to restart program");
                if (!(Console.ReadLine() == "y"))
                {
                    break;
                }
            }
        }
    }
}