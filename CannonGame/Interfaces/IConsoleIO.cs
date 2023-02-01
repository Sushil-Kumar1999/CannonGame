namespace CannonGame.Interfaces;

public interface IConsoleIO
{
    int GetAngle();
    int GetVelocity();
    void ShowShot(Point shot);
    void DisplayAttempts(int attemptCount);
    void ShowTarget(Point target);
    ShotType GetShotType();
}
