using System;

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",
            10
        ) { }

    public void Breathing()
    {
        Countdown("Breath In...");
        Countdown("Breath Out...");
        Console.WriteLine();
    }

    public override void PerformActivity()
    {
        RunActivityForDuration(Breathing);
    }
}
