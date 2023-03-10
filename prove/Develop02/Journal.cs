using System;
using System.IO; 

class Journal
{
    List<WrittenResponse> written_response = new List<WrittenResponse>();

    public List<string> question_list = new List<string>{
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something you admired others did today?",
        "What scripture did I learn from today?",
        "Which class did you enjoy going to today?",
        "What is something you can improve on?",
        "What is something you can do for your wife tomorrow?"};
    public Random randomGenerator = new Random();
    
    public void write()
    {
        int num = randomGenerator.Next(1, question_list.Count());
        Console.WriteLine($"{question_list[num]}");
        string response = Console.ReadLine() ?? "";

        DateTime theCurrentTime = DateTime.Now;
        string date = theCurrentTime.ToShortDateString();

        WrittenResponse newResponse = new WrittenResponse(question_list[num], response, date);
        written_response.Add(newResponse);

        question_list.Remove(question_list[num]);
    } 

    public void Display()
    {
        int i;
        for(i = 0; i < written_response.Count(); i++){
            Console.WriteLine($"{i+1}. {written_response[i].question}");
            Console.WriteLine($"{written_response[i].write}");
            Console.WriteLine($"{written_response[i].date}");
        }
    }

    public void load(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            string firstName = parts[0];
            string lastName = parts[1];
        }
    }

    public void save(string fileName)
    {

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            int i;
            for(i = 0; i < written_response.Count(); i++){
                outputFile.WriteLine($"{i+1}. {written_response[i].question}");
                outputFile.WriteLine($"{written_response[i].write}");
                outputFile.WriteLine($"{written_response[i].date}");
            }
        }
    }
}