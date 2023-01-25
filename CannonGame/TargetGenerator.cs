namespace CannonGame;

public class TargetGenerator : ITargetGenerator
{
    private readonly IInputValidator _inputValidator;

    public TargetGenerator(IInputValidator inputValidator)
    {
        _inputValidator = inputValidator;
    }

    public Point GenerateTarget(int angle, int velocity)
    {
        _inputValidator.ValidateAngle(angle);
        _inputValidator.ValidateVelocity(velocity);

        return new Point();
    }
}
