namespace CannonGame.Interfaces;

public interface IInputValidator
{
    bool ValidateAngle(int angle);
    bool ValidateVelocity(int velocity);
}
