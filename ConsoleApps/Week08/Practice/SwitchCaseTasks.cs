using System;

namespace Practice
{
    class SwitchCaseTasks
    {
        public static void Run()
        {
            // --- Task 1: Fruit Price Checker ---
            /*
             * Description:
             * Write a program that takes the name of a fruit (e.g., apple, banana, orange) as input 
             * and prints the price per kilogram of that fruit.
             * Use a switch statement with these prices:
             * - Apple: $3 per kg
             * - Banana: $2 per kg
             * - Orange: $4 per kg
             * - Default: Fruit not available
             *
             * Example Input and Output:
             *   Enter a fruit name: Apple
             *   Output: The price of Apple is $3 per kg.
             *
             *   Enter a fruit name: Mango
             *   Output: Fruit not available.
             */
            Console.Write("Enter a fruit name: ");
            string fruit = Console.ReadLine().ToLower();
            switch (fruit)
            {
                case "apple":
                    Console.WriteLine("The price of Apple is $3 per kg.");
                    break;
                case "banana":
                    Console.WriteLine("The price of Banana is $2 per kg.");
                    break;
                case "orange":
                    Console.WriteLine("The price of Orange is $4 per kg.");
                    break;
                default:
                    Console.WriteLine("Fruit not available.");
                    break;
            }
            Console.WriteLine();

            // --- Task 2: Traffic Light Actions ---
            /*
             * Description:
             * Write a program that takes a traffic light color (Red, Yellow, Green) as input
             * and prints the action for each color.
             * - Red: Stop
             * - Yellow: Get Ready
             * - Green: Go
             *
             * Example Input and Output:
             *   Enter the traffic light color (Red, Yellow, Green): Green
             *   Output: Go
             *
             *   Enter the traffic light color (Red, Yellow, Green): Blue
             *   Output: Invalid color.
             */
            Console.Write("Enter the traffic light color (Red, Yellow, Green): ");
            string light = Console.ReadLine().ToLower();
            switch (light)
            {
                case "red":
                    Console.WriteLine("Stop");
                    break;
                case "yellow":
                    Console.WriteLine("Get Ready");
                    break;
                case "green":
                    Console.WriteLine("Go");
                    break;
                default:
                    Console.WriteLine("Invalid color.");
                    break;
            }
            Console.WriteLine();

            // --- Task 3: Zodiac Sign by Month ---
            /*
             * Description:
             * Write a program that takes a month (1–12) as input and prints the corresponding Zodiac signs.
             * - January: Capricorn, Aquarius
             * - February: Aquarius, Pisces
             * - March: Pisces, Aries
             * - April: Aries, Taurus
             * - May: Taurus, Gemini
             * - June: Gemini, Cancer
             * - July: Cancer, Leo
             * - August: Leo, Virgo
             * - September: Virgo, Libra
             * - October: Libra, Scorpio
             * - November: Scorpio, Sagittarius
             * - December: Sagittarius, Capricorn
             *
             * Example Input and Output:
             *   Enter a month number (1-12): 5
             *   Output: Taurus, Gemini
             */
            Console.Write("Enter a month number (1-12): ");

            string monthStr = Console.ReadLine();

            bool validMonthParsing = byte.TryParse(monthStr, out byte month);

            if (validMonthParsing == false)
            {
                   Console.WriteLine("Please enter a valid number for month (1–12)");  
            }

            switch (month)
            {
                case 1:
                    Console.WriteLine("Capricorn, Aquarius");
                    break;
                case 2:
                    Console.WriteLine("Aquarius, Pisces");
                    break;
                case 3:
                    Console.WriteLine("Pisces, Aries");
                    break;
                case 4:
                    Console.WriteLine("Aries, Taurus");
                    break;
                case 5:
                    Console.WriteLine("Taurus, Gemini");
                    break;
                case 6:
                    Console.WriteLine("Gemini, Cancer");
                    break;
                case 7:
                    Console.WriteLine("Cancer, Leo");
                    break;
                case 8:
                    Console.WriteLine("Leo, Virgo");
                    break;
                case 9:
                    Console.WriteLine("Virgo, Libra");
                    break;
                case 10:
                    Console.WriteLine("Libra, Scorpio");
                    break;
                case 11:
                    Console.WriteLine("Scorpio, Sagittarius");
                    break;
                case 12:
                    Console.WriteLine("Sagittarius, Capricorn");
                    break;
                default:
                    Console.WriteLine("Invalid month.");
                    break;
            }
            Console.WriteLine();

            // --- Task 4: Movie Rating System ---
            /*
             * Description:
             * Write a program that takes a rating (1–5) as input and prints feedback for each rating.
             * - 5: Excellent
             * - 4: Good
             * - 3: Average
             * - 2: Poor
             * - 1: Very Poor
             * - Default: Invalid rating
             *
             * Example Input and Output:
             *   Enter the movie rating (1-5): 4
             *   Output: Good
             */
            Console.Write("Enter the movie rating (1-5): ");

            string ratingStr = Console.ReadLine();

            bool validRatingParsing = byte.TryParse(ratingStr, out byte rating);

            if (validRatingParsing == false)
            {
                Console.WriteLine("Please enter a valid number for rating (1–5)");
            }

            switch (rating)
            {
                case 5:
                    Console.WriteLine("Excellent");
                    break;
                case 4:
                    Console.WriteLine("Good");
                    break;
                case 3:
                    Console.WriteLine("Average");
                    break;
                case 2:
                    Console.WriteLine("Poor");
                    break;
                case 1:
                    Console.WriteLine("Very Poor");
                    break;
                default:
                    Console.WriteLine("Invalid rating");
                    break;
            }
            Console.WriteLine();

            // --- Task 5: Meal Type by Time of Day ---
            /*
             * Description:
             * Write a program that takes an hour (0–23) as input and determines which meal is typical for that time.
             * - 5–10: Breakfast
             * - 11–15: Lunch
             * - 16–20: Dinner
             * - 21–4: Late Snack
             * - Default: Invalid time
             *
             * Example Input and Output:
             *   Enter the hour (0-23): 9
             *   Output: Breakfast
             */
            Console.Write("Enter the hour (0-23): ");

            string hourStr= Console.ReadLine();

            bool validHourParsing = byte.TryParse(hourStr, out byte hour);

            if (validHourParsing == false)
            {
                Console.WriteLine("Please valid number for hour (0–23)");
            }

            switch (hour)
            {
                case byte h when (h >= 5 && h <= 10):
                    Console.WriteLine("Breakfast");
                    break;
                case byte h when (h >= 11 && h <= 15):
                    Console.WriteLine("Lunch");
                    break;
                case byte h when (h >= 16 && h <= 20):
                    Console.WriteLine("Dinner");
                    break;
                case byte h when ((h >= 21 && h <= 23) || (h >= 0 && h <= 4)):
                    Console.WriteLine("Late Snack");
                    break;
                default:
                    Console.WriteLine("Invalid time");
                    break;
            }
            Console.WriteLine();

            // --- Task 6: Water Temperature State ---
            /*
             * Description:
             * Write a program that takes a temperature in Celsius as input and determines the state of water.
             * - Less than 0: Solid (Ice)
             * - 0–99: Liquid
             * - 100 or above: Gas (Steam)
             *
             * Example Input and Output:
             *   Enter the temperature in Celsius: 25
             *   Output: Liquid
             *
             *   Enter the temperature in Celsius: 105
             *   Output: Gas (Steam)
             */
            Console.Write("Enter the temperature in Celsius: ");

            string tempStr = Console.ReadLine();
            
            bool validTempParsing = int.TryParse(tempStr, out int temp);

            if (validTempParsing == false)
            {
                Console.WriteLine("Please enter a valid number for temperature");
            }

            switch (temp)
            {
                case int t when (t < 0):
                    Console.WriteLine("Solid (Ice)");
                    break;
                case int t when (t >= 0 && t < 100):
                    Console.WriteLine("Liquid");
                    break;
                case int t when (t >= 100):
                    Console.WriteLine("Gas (Steam)");
                    break;
            }
            Console.WriteLine();

            // --- Task 7: Day Part of the Week ---
            /*
             * Description:
             * Write a program that takes an hour of the day (0–23) as input and outputs the part of the day:
             * - 0–5: Midnight to Early Morning
             * - 6–11: Morning
             * - 12–17: Afternoon
             * - 18–21: Evening
             * - 22–23: Night
             *
             * Example Input and Output:
             *   Enter the hour (0-23): 14
             *   Output: Afternoon
             */
            Console.Write("Enter the hour (0-23): ");
            
            string hourStr2 = Console.ReadLine();

            bool validHourParsing2 = byte.TryParse(hourStr2, out byte hour2);

            if (validHourParsing2 == false)
            {
                Console.WriteLine("Please enter a valid number for hour (0–23)");
            }


            switch (hour2)
            {
                // Midnight to Early Morning: 0–5
                case byte h when (h >= 0 && h <= 5):
                    Console.WriteLine("Midnight to Early Morning");
                    break;
                // Morning: 6–11
                case byte h when (h >= 6 && h <= 11):
                    Console.WriteLine("Morning");
                    break;
                // Afternoon: 12–17
                case byte h when (h >= 12 && h <= 17):
                    Console.WriteLine("Afternoon");
                    break;
                // Evening: 18–21
                case byte h when (h >= 18 && h <= 21):
                    Console.WriteLine("Evening");
                    break;
                // Night: 22–23
                case byte h when (h >= 22 && h <= 23):
                    Console.WriteLine("Night");
                    break;
                // Invalid hour
                default:
                    Console.WriteLine("Invalid hour.");
                    break;
            }

            Console.WriteLine();

            // --- Task 8: Coffee Order Size ---
            /*
             * Description:
             * Write a program that takes a coffee size (S, M, L) as input and prints the volume in milliliters:
             * - S: 250 ml
             * - M: 350 ml
             * - L: 500 ml
             * - Default: Invalid size
             *
             * Example Input and Output:
             *   Enter the coffee size (S, M, L): M
             *   Output: 350 ml
             */
            Console.Write("Enter the coffee size (S, M, L): ");

            char size = char.ToUpper(Console.ReadLine()[0]);

            switch (size)
            {
                case 'S':
                    Console.WriteLine("250 ml");
                    break;
                case 'M':
                    Console.WriteLine("350 ml");
                    break;
                case 'L':
                    Console.WriteLine("500 ml");
                    break;
                default:
                    Console.WriteLine("Invalid size");
                    break;
            }

            Console.WriteLine();

            // --- Task 9: Planet Order from the Sun ---
            /*
             * Description:
             * Write a program that takes the planet's order from the sun (1-8) as input and prints the planet name.
             * 1. Mercury
             * 2. Venus
             * 3. Earth
             * 4. Mars
             * 5. Jupiter
             * 6. Saturn
             * 7. Uranus
             * 8. Neptune
             *
             * Example Input and Output:
             *   Enter the planet's order from the sun (1-8): 3
             *   Output: Earth
             */
            Console.Write("Enter the planet's order from the sun (1-8): ");
            
            string planetOrderStr = Console.ReadLine();

            bool validPlanetOrderParsing = byte.TryParse(planetOrderStr, out byte planetOrder);

            if (validPlanetOrderParsing == false)
            {
                Console.WriteLine("Please enter a valid number for planet order (1–8)");
            }

            switch (planetOrder)
            {
                case 1:
                    Console.WriteLine("Mercury");
                    break;
                case 2:
                    Console.WriteLine("Venus");
                    break;
                case 3:
                    Console.WriteLine("Earth");
                    break;
                case 4:
                    Console.WriteLine("Mars");
                    break;
                case 5:
                    Console.WriteLine("Jupiter");
                    break;
                case 6:
                    Console.WriteLine("Saturn");
                    break;
                case 7:
                    Console.WriteLine("Uranus");
                    break;
                case 8:
                    Console.WriteLine("Neptune");
                    break;
                default:
                    Console.WriteLine("Invalid planet order.");
                    break;
            }
            Console.WriteLine();

            // --- Task 10: Type of Triangle by Sides ---
            /*
             * Description:
             * Write a program that takes three side lengths of a triangle as input and identifies the type of triangle.
             * - Equilateral: All three sides are equal.
             * - Isosceles: Exactly two sides are equal.
             * - Scalene: All three sides are different.
             *
             * Example Input and Output:
             *   Enter side 1: 5
             *   Enter side 2: 5
             *   Enter side 3: 5
             *   Output: Equilateral triangle
             *
             *   Enter side 1: 5
             *   Enter side 2: 5
             *   Enter side 3: 8
             *   Output: Isosceles triangle
             */
            Console.Write("Enter side 1: ");

            bool validSide1 = int.TryParse(Console.ReadLine(), out int side1);

            Console.Write("Enter side 2: ");

            bool validSide2 = int.TryParse(Console.ReadLine(), out int side2);

            Console.Write("Enter side 3: ");

            bool validSide3 = int.TryParse(Console.ReadLine(), out int side3);

            if (!validSide1 || !validSide2 || !validSide3)
            {
                Console.WriteLine("Please enter valid numbers for all sides.");
            }
            else if (side1 == side2 && side2 == side3)
            {
                Console.WriteLine("Equilateral triangle");
            }
            else if (side1 == side2 || side1 == side3 || side2 == side3)
            {
                Console.WriteLine("Isosceles triangle");
            }
            else
            {
                Console.WriteLine("Scalene triangle");
            }
            Console.WriteLine();


            // --- Task 11: Season by Hemisphere and Month ---
            /*
             * Description:
             * Write a program that takes a hemisphere (North, South) and a month number (1-12) as input and outputs the season.
             * - Northern Hemisphere:
             *   - Winter: December, January, February
             *   - Spring: March, April, May
             *   - Summer: June, July, August
             *   - Autumn: September, October, November
             * - Southern Hemisphere:
             *   - Summer: December, January, February
             *   - Autumn: March, April, May
             *   - Winter: June, July, August
             *   - Spring: September, October, November
             *
             * Example Input and Output:
             *   Enter hemisphere (North/South): North
             *   Enter month (1-12): 3
             *   Output: Spring
             *
             *   Enter hemisphere (North/South): South
             *   Enter month (1-12): 3
             *   Output: Autumn
             */
            Console.Write("Enter hemisphere (North/South): ");

            string hemisphere = Console.ReadLine().ToLower();

            Console.Write("Enter month (1-12): ");

            string monthStr2 = Console.ReadLine();

            bool validMonthParsing2 = byte.TryParse(monthStr2, out byte month2);

            if (validMonthParsing2 == false)
            {
                Console.WriteLine("Please enter a valid number for month (1–12)");
            }

            switch (hemisphere)
            {
                case "north":
                    switch (month2)
                    {
                        case 12:
                        case 1:
                        case 2:
                            Console.WriteLine("Winter");
                            break;
                        case 3:
                        case 4:
                        case 5:
                            Console.WriteLine("Spring");
                            break;
                        case 6:
                        case 7:
                        case 8:
                            Console.WriteLine("Summer");
                            break;
                        case 9:
                        case 10:
                        case 11:
                            Console.WriteLine("Autumn");
                            break;
                        default:
                            Console.WriteLine("Invalid month.");
                            break;
                    }
                    break;
                case "south":
                    switch (month2)
                    {
                        case 12:
                        case 1:
                        case 2:
                            Console.WriteLine("Summer");
                            break;
                        case 3:
                        case 4:
                        case 5:
                            Console.WriteLine("Autumn");
                            break;
                        case 6:
                        case 7:
                        case 8:
                            Console.WriteLine("Winter");
                            break;
                        case 9:
                        case 10:
                        case 11:
                            Console.WriteLine("Spring");
                            break;
                        default:
                            Console.WriteLine("Invalid month.");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid hemisphere.");
                    break;
            }
            Console.WriteLine();

            // --- Task 12: Greeting Based on Time and Language ---
            /*
             * Description:
             * Write a program that takes an hour (0-23) and a language code (EN, ES, FR) as input and provides a greeting.
             * - EN: Good Morning, Good Afternoon, Good Evening
             * - ES: Buenos Días, Buenas Tardes, Buenas Noches
             * - FR: Bonjour, Bon Après-midi, Bonsoir
             *   - Morning: 0–11
             *   - Afternoon: 12–17
             *   - Evening: 18–23
             *
             * Example Input and Output:
             *   Enter hour (0-23): 10
             *   Enter language code (EN, ES, FR): ES
             *   Output: Buenos Días
             */
            Console.Write("Enter hour (0-23): ");
            
            string hourStr3 = Console.ReadLine();

            bool validHourParsing3 = byte.TryParse(hourStr3, out byte hour3);

            if (validHourParsing3 == false)
            {
                Console.WriteLine("Please enter a valid number for hour (0–23)");
            }

            Console.Write("Enter language code (EN, ES, FR): ");

            string lang = Console.ReadLine().ToUpper();

            // Determine the greeting based on the language code and hour
            switch (lang)
            {
                case "EN":
                    // English greetings
                    if (hour2 >= 0 && hour2 < 12)
                        Console.WriteLine("Good Morning");
                    else if (hour2 >= 12 && hour2 < 18)
                        Console.WriteLine("Good Afternoon");
                    else
                        Console.WriteLine("Good Evening");
                    break;
                case "ES":
                    // Spanish greetings
                    if (hour2 >= 0 && hour2 < 12)
                        Console.WriteLine("Buenos Días");
                    else if (hour2 >= 12 && hour2 < 18)
                        Console.WriteLine("Buenas Tardes");
                    else
                        Console.WriteLine("Buenas Noches");
                    break;
                case "FR":
                    // French greetings
                    if (hour2 >= 0 && hour2 < 12)
                        Console.WriteLine("Bonjour");
                    else if (hour2 >= 12 && hour2 < 18)
                        Console.WriteLine("Bon Après-midi");
                    else
                        Console.WriteLine("Bonsoir");
                    break;
                default:
                    // Invalid language code
                    Console.WriteLine("Invalid language code.");
                    break;
            }
            Console.WriteLine();


            // Determine the greeting based on the language code and hour
            if (lang == "EN")
            {
                // English greetings
                if (hour2 >= 0 && hour2 < 12)
                    Console.WriteLine("Good Morning");
                else if (hour2 >= 12 && hour2 < 18)
                    Console.WriteLine("Good Afternoon");
                else
                    Console.WriteLine("Good Evening");
            }
            else if (lang == "ES")
            {
                // Spanish greetings
                if (hour2 >= 0 && hour2 < 12)
                    Console.WriteLine("Buenos Días");
                else if (hour2 >= 12 && hour2 < 18)
                    Console.WriteLine("Buenas Tardes");
                else
                    Console.WriteLine("Buenas Noches");
            }
            else if (lang == "FR")
            {
                // French greetings
                if (hour2 >= 0 && hour2 < 12)
                    Console.WriteLine("Bonjour");
                else if (hour2 >= 12 && hour2 < 18)
                    Console.WriteLine("Bon Après-midi");
                else
                    Console.WriteLine("Bonsoir");
            }
            else
            {
                // Invalid language code
                Console.WriteLine("Invalid language code.");
            }

            // --- Task 13: Age Group Classification ---
            /*
             * Description:
             * Write a program that takes an age as input and categorizes it as:
             * - Infant (0–2)
             * - Child (3–12)
             * - Teen (13–19)
             * - Adult (20–64)
             * - Senior (65 and above)
             *
             * Example Input and Output:
             *   Enter age: 15
             *   Output: Teen
             */
            Console.Write("Enter age: ");
            
            string ageStr = Console.ReadLine();

            bool validAgeParsing = int.TryParse(ageStr, out int age);

            if (validAgeParsing == false)
            {
                Console.WriteLine("Please enter a valid number for age");
            }

            switch (age)
            {
                case int n when (n >= 0 && n <= 2):
                    Console.WriteLine("Infant");
                    break;
                case int n when (n >= 3 && n <= 12):
                    Console.WriteLine("Child");
                    break;
                case int n when (n >= 13 && n <= 19):
                    Console.WriteLine("Teen");
                    break;
                case int n when (n >= 20 && n <= 64):
                    Console.WriteLine("Adult");
                    break;
                case int n when (n >= 65):
                    Console.WriteLine("Senior");
                    break;
                default:
                    Console.WriteLine("Invalid age.");
                    break;
            }
            Console.WriteLine();

            // --- Task 14: Bank Transaction Type ---
            /*
             * Description:
             * Write a program that takes a transaction code (D for Deposit, W for Withdrawal, T for Transfer) 
             * and prints a message confirming the transaction type.
             *
             * Example Input and Output:
             *   Enter transaction code (D, W, T): W
             *   Output: Withdrawal confirmed.
             */
            Console.Write("Enter transaction code (D, W, T): ");
            char transactionCode = char.ToUpper(Console.ReadLine()[0]);
            switch (transactionCode)
            {
                case 'D':
                    Console.WriteLine("Deposit confirmed.");
                    break;
                case 'W':
                    Console.WriteLine("Withdrawal confirmed.");
                    break;
                case 'T':
                    Console.WriteLine("Transfer confirmed.");
                    break;
                default:
                    Console.WriteLine("Invalid transaction code.");
                    break;
            }
            Console.WriteLine();

            // --- Task 15: Book Genre Description ---
            /*
             * Description:
             * Write a program that takes a book genre code (F for Fiction, NF for Non-Fiction, M for Mystery, SF for Sci-Fi) 
             * and outputs a description.
             *
             * Example Input and Output:
             *   Enter genre code (F, NF, M, SF): M
             *   Output: Mystery - a genre that involves solving a crime or uncovering secrets.
             */
            Console.Write("Enter genre code (F, NF, M, SF): ");
            string genreCode = Console.ReadLine().ToUpper();
            switch (genreCode)
            {
                case "F":
                    Console.WriteLine("Fiction - a literary work based on the imagination and not necessarily on fact.");
                    break;
                case "NF":
                    Console.WriteLine("Non-Fiction - prose writing that is informative or factual rather than fictional.");
                    break;
                case "M":
                    Console.WriteLine("Mystery - a genre that involves solving a crime or uncovering secrets.");
                    break;
                case "SF":
                    Console.WriteLine("Sci-Fi - a genre dealing with imaginative concepts such as futuristic science.");
                    break;
                default:
                    Console.WriteLine("Invalid genre code.");
                    break;
            }
            Console.WriteLine();
        }
    }
}
