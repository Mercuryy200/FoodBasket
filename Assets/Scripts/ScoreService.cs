using System;

public class ScoreService
{
    public int Score { get; private set; }

    public void AddPoints(int points)
    {
        if (points == 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(points),
                "Les points ajoutés ne peuvent pas être nul."
            );
        }

        Score += points;
    }

    public void Reset()
    {
        Score = 0;
    }
}
