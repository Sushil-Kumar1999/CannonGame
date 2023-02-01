using CannonGame.Interfaces;

namespace CannonGame;

public class InputValidator : IInputValidator
{
    public bool ValidateAngle(int angle, ShotType shotType)
    {
        bool isInValidRange = angle >= 1 && angle <= 90;

        return shotType switch
        {
            ShotType.Shot => isInValidRange,
            ShotType.Mortar => isInValidRange && angle % 5 == 0,
            _ => false,
        };
    }

    public bool ValidateVelocity(int velocity)
    {
        return velocity >= 1 && velocity <= 20;    
    }
}
