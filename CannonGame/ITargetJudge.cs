﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonGame;

public interface ITargetJudge
{
    bool JudgeShotHitsTarget(Point target, Point shot);
}
