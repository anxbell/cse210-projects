class VisualizationActivity : MindfulnessActivity
{
    public VisualizationActivity()
        : base(
            "Visualization",
            "This activity helps you calm your mind by visualizing a peaceful scene. You will focus on the details and sensations of the environment.",
            10
        ) { }

    public void Visualization()
    {
        Console.WriteLine("Imagine yourself in a peaceful garden...");
        Countdown("Picture the flowers swaying in the breeze...");
        Countdown("Feel the warmth of the sun on your skin...");
        Countdown("Listen to the gentle sounds of birds singing...");
        Console.WriteLine();
        Countdown("Imagine the soft rustling of leaves as the wind blows...");
        Countdown("Visualize the sound of a calm river flowing nearby...");
        Countdown("Picture the sky painted with vibrant hues as the sun sets...");
        Console.WriteLine();
    }

    public override void PerformActivity()
    {
        Visualization();
        Console.Clear();
        Console.WriteLine("\nNow, take some time to visualize yourself.");
        RunActivityForDuration(Animation);
    }
}
