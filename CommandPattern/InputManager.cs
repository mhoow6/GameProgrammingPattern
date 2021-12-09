using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class InputManager : MonoBehaviour
    {
        public Actor player;

        // Ű:����� �ϱ� ���� KeyCode, ��:�Է¿� �ش��ϴ� ���
        Dictionary<KeyCode, Command> _keyBind = new Dictionary<KeyCode, Command>();

        #region ��ɵ�
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

        // ��ɿ� ���� �⺻�� ����
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
            // ������ �Էµ��� ���ӿ��� ������ �ߴ��� �����ϰ�, �Է¿� �´� ��� ����
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

        // ���ϴ� Ű �Է� ����
        public void ChangeKey(KeyCode keyCode, Command command)
        {
            bool overlapped = false;
            // 1. �Ű������� ���� KeyCode�� �̹� Ű ������ �����ϴ� �Է��ΰ�?
            overlapped = !RegisterInput(keyCode, command);

            // 2. TODO: �̹� �ִ� �Ÿ� ��� �޽���â ���
            if (overlapped == true)
            {
                //  YES(�ٲٰڴ�) -> ���ο� ������� �ٲ�ġ�� -> �޽���â �ݱ�
                _keyBind.Remove(keyCode);
                _keyBind.Add(keyCode, command);
                Debug.Log("�Է¿� ���� ����� �ٲ���ϴ�");

                //  NO(�� �ٲٰڴ�) -> �޽��� â �ݱ�
            }

            // 3. TODO: �޽��� â �ݱ�
        }
    }
}
