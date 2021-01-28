using System;


namespace WybierzLiczbe
{
   
    class Program
    {
       
        static void Main(string[] args)
        {
            GetAppInfo(); 

            GreetUser(); 

            while (true)
            {

               
                
                Random random = new Random();

                
                int correctNumber = random.Next(1, 10);

                
                int guess = 0;

                
                Console.WriteLine("Zgadnij liczbę od 1 do 10");

                
                while (guess != correctNumber)
                {
                    
                    string input = Console.ReadLine();

                   
                    if (!int.TryParse(input, out guess))
                    {
                        
                        PrintColorMessage(ConsoleColor.Red, "Użyj rzeczywistej liczby");

                        
                        continue;
                    }

                    
                    guess = Int32.Parse(input);

                    
                    if (guess != correctNumber)
                    {
                        
                        PrintColorMessage(ConsoleColor.Red, "Błędny numer, spróbuj ponownie");
                    }
                }

                
                PrintColorMessage(ConsoleColor.Yellow, "POPRAWNY!! Zgadłeś!");

                
                Console.WriteLine("Zagrasz ponownie? [Y or N]");

                
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y") {
                    continue;
                }
                else if (answer == "N") {
                    return;
                }
                else
                {
                    return;
                }
            }           

        }

        
        static void GetAppInfo() {
            
            string appName = "Wybierz liczbę";
            
            string appAuthor = "Karol Sroka";

            
            Console.ForegroundColor = ConsoleColor.Green;

            
            Console.WriteLine(appName, appAuthor);

            
            Console.ResetColor();
        }

        
        static void GreetUser() {
            
            Console.WriteLine("Jak masz na imię?");

            
            string inputName = Console.ReadLine();

            Console.WriteLine("Cześć {0}, Zagrajmy w grę...", inputName);
        }

        
        static void PrintColorMessage(ConsoleColor color, string message) {
            
            Console.ForegroundColor = color;

            
            Console.WriteLine(message);

            
            Console.ResetColor();
        }
    }
}
