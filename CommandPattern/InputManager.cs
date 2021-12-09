using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class InputManager : MonoBehaviour
    {
        public Actor player;

        // 키:명령을 하기 위한 KeyCode, 값:입력에 해당하는 명령
        Dictionary<KeyCode, Command> _keyBind = new Dictionary<KeyCode, Command>();

        #region 명령들
        abstract public class Command
        {
            public abstract void Execute(Actor actor);
        }

        public class CommandNull : Command
        {
            public override void Execute(Actor actor)
            {
                
            }
        }

        public class CommandJump : Command
        {
            public override void Execute(Actor actor)
            {
                actor.Jump();
            }
        }

        public class CommandAttack : Command
        {
            public override void Execute(Actor actor)
            {
                actor.Attack();
            }
        }

        public class CommandCrouch : Command
        {
            public override void Execute(Actor actor)
            {
                actor.Crouch();
            }
        }
        #endregion

        // 명령에 대한 기본값 설정
        void Awake()
        {
            RegisterInput(
                KeyCode.Space
                , new CommandJump()
            );
            RegisterInput(
                KeyCode.Mouse0
                , new CommandAttack()
            );
            RegisterInput(
                KeyCode.LeftControl
                , new CommandCrouch()
            );
        }

        // O(N)
        void Update()
        {
            // 지정된 입력들을 게임에서 실제로 했는지 검증하고, 입력에 맞는 명령 수행
            foreach (var kvp in _keyBind)
            {
                if (Input.GetKeyDown(kvp.Key))
                {
                    kvp.Value.Execute(player);
                }
            }
        }

        bool RegisterInput(KeyCode keyCode, Command command)
        {
            if (_keyBind.TryGetValue(keyCode, out _) == false)
            {
                _keyBind.Add(keyCode, command);
                return true;
            }
            return false;
        }

        // 원하는 키 입력 변경
        public void ChangeKey(KeyCode keyCode, Command command)
        {
            bool overlapped = false;
            // 1. 매개변수로 받은 KeyCode가 이미 키 설정에 존재하는 입력인가?
            overlapped = !RegisterInput(keyCode, command);

            // 2. TODO: 이미 있는 거면 경고 메시지창 출력
            if (overlapped == true)
            {
                //  YES(바꾸겠다) -> 새로운 명령으로 바꿔치기 -> 메시지창 닫기
                _keyBind.Remove(keyCode);
                _keyBind.Add(keyCode, command);
                Debug.Log("입력에 따른 명령을 바꿨습니다");

                //  NO(안 바꾸겠다) -> 메시지 창 닫기
            }

            // 3. TODO: 메시지 창 닫기
        }
    }
}
