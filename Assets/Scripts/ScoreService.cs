using System;

public class ScoreService
{
    public int Score { get; private set; }
    public void AddPoints(int points)
    {

        Score += points;
    }

    public void Reset()
    {
        Score = 0;
    }
}
