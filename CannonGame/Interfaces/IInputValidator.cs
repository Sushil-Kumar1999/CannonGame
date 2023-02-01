namespace CannonGame.Interfaces;

public interface IInputValidator
{
    bool ValidateAngle(int angle, ShotType shotType);
    bool ValidateVelocity(int velocity);
}
