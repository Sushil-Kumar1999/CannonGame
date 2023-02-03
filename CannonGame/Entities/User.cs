namespace CannonGame.Entities;

public class User
{
    public User(string username, int score, float timeElapsed)
    {
        Username = username;
        Score = score;
        TimeElapsed = timeElapsed;
    }

    public override bool Equals(object obj)
    {
        var other = obj as User;
        if (other == null) return false;

        return Username == other.Username && Score == other.Score && TimeElapsed == other.TimeElapsed;
    }

    public string Username { get; }
    public int Score { get; }
    public float TimeElapsed { get; }
}
