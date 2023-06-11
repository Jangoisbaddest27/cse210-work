using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathingActivity = new BreathingActivity("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        
        List<string> reflectPrompts = new List<string>();
        reflectPrompts.Add("Think of a time when you did something truly selfless.");
        reflectPrompts.Add("Think of a time when you helped someone in need.");
        reflectPrompts.Add("Think of a time when you did something really difficult.");
        reflectPrompts.Add("Think of a time when you stood up for somebody else.");

        List<string> reflectQuestions = new List<string>();
        reflectQuestions.Add("How can you keep this experience in mind in the future?");
        reflectQuestions.Add("What did you learn about yourself through this experience?");
        reflectQuestions.Add("What could you learn from this experience that applies to other situations?");
        reflectQuestions.Add("What is your favorite thing about this experience?");
        reflectQuestions.Add("What made this time different than other times when you were not as successful?");
        reflectQuestions.Add("How did you feel when it was complete?");
        reflectQuestions.Add("How did you get started?");
        reflectQuestions.Add("Have you ever done anything like this before?");
        reflectQuestions.Add("Why was this experience meaningful to you?");

        ReflectingActivity reflectingActivity = new ReflectingActivity(reflectPrompts, reflectQuestions, "Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        
        List<string> listingPrompts = new List<string>();
        listingPrompts.Add("Who are some of your personal heroes?");
        listingPrompts.Add("When have you felt the Holy Ghost this month?");
        listingPrompts.Add("Who are people that you have helped this week?");
        listingPrompts.Add("What are personal strengths of yours?");
        listingPrompts.Add("Who are people that you appreciate?");

        ListingActivity listingActivity = new ListingActivity(listingPrompts, "Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        int choice = 0;
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;
        while (choice != 4)
        { 
            Console.WriteLine("Menu Options:");
            Console.WriteLine($" 1. Start breathing activity (chosen {breathingCount} times, {breathingActivity._GetActivityTotal()} seconds total)");
            Console.WriteLine($" 2. Start reflecting activity (chosen {reflectingCount} times, {reflectingActivity._GetActivityTotal()} seconds total)");
            Console.WriteLine($" 3. Start listing activity (chosen {listingCount} times, {listingActivity._GetActivityTotal()} seconds total)");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");
            string userChoice = Console.ReadLine();
            choice = int.Parse(userChoice);

            if (choice == 1)    //Breathing
            {
                breathingActivity._DisplayStart();
                breathingActivity._DisplayBreathingCountdown();
                breathingActivity._DisplayEnd();
                ++breathingCount;
            }

            else if (choice == 2)    //Reflecting
            {
                reflectingActivity._DisplayStart();
                reflectingActivity._DisplayReflectingCountdown();
                reflectingActivity._DisplayEnd();
                ++reflectingCount;
            }

            else if (choice == 3)    //Listing
            {
                listingActivity._DisplayStart();
                listingActivity._DisplayListingCountdown();
                listingActivity._DisplayEnd();
                ++listingCount;
            }


            else    //Quit
            {
                Console.WriteLine("Have a good day!");
                choice = 4;
            }
        }    
    }
}