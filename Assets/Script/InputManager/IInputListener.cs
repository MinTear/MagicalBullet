using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.InputManager
{
    public interface IInputListener
    {
        Vector2 GetMovementVector();

        bool IsWeakSkillPushed { get; }

        bool IsMediumSkillPushed { get; }

        bool IsStrongSkillPushed { get; }

        bool IsJumpPushed { get; }

        bool IsGuardPushed { get; }
    }
}
