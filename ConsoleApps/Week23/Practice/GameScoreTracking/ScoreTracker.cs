using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.GameScoreTracking;

/// <summary>
/// Tracks scores for a simple game, including high scores.
/// </summary>
public sealed class ScoreTracker
{
    public int CurrentScore { get; private set; }
    public int HighScore { get; private set; }
    public int GamesPlayed { get; private set; }

    public void AddPoints(int points)
    {
        if (points < 0)
            throw new ArgumentException("Points cannot be negative.");

        CurrentScore += points;
        Console.WriteLine($"Points added: {points}, Current Score: {CurrentScore}");
    }

    public void ResetScore()
    {
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            Console.WriteLine("New High Score Achieved!");
        }

        CurrentScore = 0;
        GamesPlayed++;
        Console.WriteLine("Score reset. Game over.");
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Games Played: {GamesPlayed}, High Score: {HighScore}");
    }
}
