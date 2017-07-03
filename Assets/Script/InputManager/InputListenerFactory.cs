using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.InputManager
{
    public class InputListenerFactory
    {
        private static IInputListener _listenerInstance;

        public static IInputListener GetInputListener()
        {
            _listenerInstance=_listenerInstance??new UnityInputListener();//キーの操作方法を変えるときは別のクラスに変更する
            return _listenerInstance;
        }

        private class UnityInputListener:IInputListener
        {

            public UnityEngine.Vector2 GetMovementVector()
            {
                return new UnityEngine.Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }

            public bool IsWeakSkillPushed
            {
                get { return Input.GetKeyDown(KeyCode.L); }
            }

            public bool IsMediumSkillPushed
            {
                get { return Input.GetKeyDown(KeyCode.K); }
            }

            public bool IsStrongSkillPushed
            {
                get { return Input.GetKeyDown(KeyCode.J); }
            }

            public bool IsJumpPushed
            {
                get { return Input.GetKeyDown(KeyCode.Z); }
            }

            public bool IsGuardPushed
            {
                get { return Input.GetKeyDown(KeyCode.C); }
            }
        }
    }
}
