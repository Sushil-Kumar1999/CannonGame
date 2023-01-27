namespace CannonGame;

public class InputValidator : IInputValidator
{
    public bool ValidateAngle(int angle)
    {
        return angle >= 1 && angle <= 90;   
    }

    public bool ValidateVelocity(int velocity)
    {
        return velocity >= 1 && velocity <= 20;    
    }
}
