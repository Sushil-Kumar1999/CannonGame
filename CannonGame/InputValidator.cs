using CannonGame.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CannonGame;

public class InputValidator : IInputValidator
{
    public void ValidateAngle(int angle)
    {
        if (angle < 1 || angle > 90)
        {
            throw new ValidationException(ExceptionMessages.AngleOutOfRangeMessage);
        }
    }

    public void ValidateVelocity(int velocity)
    {
        if (velocity < 1 || velocity > 20)
        {
            throw new ValidationException(ExceptionMessages.VelocityOutOfRangeMessage);
        }
    }
}
