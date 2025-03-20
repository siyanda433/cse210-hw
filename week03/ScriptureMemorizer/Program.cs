using System;

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Welcome to the ScriptureMemorizer Project.");

        string[] sentences = new string[]
        {
            "Philippians 4:13 - I can do all things through Christ who strengthens me.",
            "John 3:16 - For God so loved the world that He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life.",
            "Romans 8:28 - And we know that all things work together for good to those who love God, to those who are the called according to His purpose."
        };

        Random random = new Random();
        int sentenceIndex = random.Next(0, sentences.Length);
        string sentence = sentences[sentenceIndex];

        Console.WriteLine("Memorize this sentence:");
        Console.WriteLine(sentence);

        Console.WriteLine("Press Enter to start...");
        Console.ReadLine();

        string[] words = sentence.Split(' ');
        string[] displayedWords = new string[words.Length];

        for (int i = 0; i < words.Length; i++)
        {
            displayedWords[i] = words[i];
        }

        int revealCount = 0;
        bool allHidden = false;

        while (!allHidden)
        {
            Console.WriteLine("Press Enter to remove the next word or 'q' to exit...");
            string input = Console.ReadLine();

            if (input.ToLower() == "q")
            {
                break;
            }

            bool wordHidden = false;

            int randomIndex = random.Next(0, words.Length);

            if (displayedWords[randomIndex] != new string('_', words[randomIndex].Length))
            {
                displayedWords[randomIndex] = new string('_', words[randomIndex].Length);
                revealCount++;
                wordHidden = true;
            }

            Console.WriteLine(string.Join(" ", displayedWords));

            if (revealCount >= words.Length)
            {
                allHidden = true;
            }
        }

        Console.WriteLine("Game over!");




        // Createve work.
        //  I have three differnt scriputes.
        //  The code randomly selects one of the three scriptures and displays it randomly for the user to memorise. 

    }
}
