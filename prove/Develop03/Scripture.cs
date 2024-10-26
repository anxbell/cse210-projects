using System;
class Scripture
{
    private Random _randomGenerator;
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _randomGenerator = new Random();

        string[] splitWords = text.Split(' '); // split text into list of words
        List<Word> wordsList = new List<Word>(); //holdss words

        for (int i = 0; i < splitWords.Length; i++)
        {
            Word newWord = new Word(splitWords[i]); //new word
            wordsList.Add(newWord); //adds it to the new list
        }

        _words = wordsList;
    }

    public void ShowScripture()
    {
        Console.WriteLine(_reference.DisplayReference());
        foreach (Word word in _words)
        {
            Console.Write(word.GetText() + " ");
        }
        Console.WriteLine();
    }

    public void HideWords(int numWords)
    { //declaring not specifying type
        var availableWords = _words.Where(word => !word.IsWordHidden()).ToList();

        // fewer or equal words, hides all of them
        if (availableWords.Count <= numWords)
        {
            foreach (var word in availableWords)
            {
                word.Hide();
            }
        }
        else
        {
            for (int i = 0; i < numWords; i++)
            {
                int index = _randomGenerator.Next(availableWords.Count);
                availableWords[index].Hide();
                // removes hidden word from avl list
                availableWords.RemoveAt(index);
            }
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsWordHidden());
    }

    public void ClearConsole()
    {
        Console.Clear();
    }
    //added library for showing creativity
    public static List<Scripture> InitializeScriptureLibrary()
    {
        List<Scripture> library = new List<Scripture>();
        //adding references and verses
        library.Add(
            new Scripture( //(book, chapter, verse, finalverse if applicable)
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            )
        );

        library.Add(
            new Scripture(
                new Reference("John", 1, 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            )
        );

        library.Add(
            new Scripture(
                new Reference("Psalm", 23, 1, 3),
                "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters."
            )
        );

        library.Add(
            new Scripture(
                new Reference("1 Nephi", 8, 28),
                "And after they had tasted of the fruit they were ashamed, because of those that were scoffing at them; and they fell away into forbidden paths and were lost."
            )
        );

        return library;
    }

    public static Scripture GetRandomScripture(List<Scripture> library)
    { //added to get scripture random (changed it to be in scripture class)
        Random random = new Random();
        int index = random.Next(library.Count);
        return library[index];
    }
}
