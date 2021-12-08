using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Ű:����� �ϱ� ���� �Է�(��ȯ�� bool), ��:�Է¿� �ش��ϴ� ���
    Dictionary<Func<bool>, Command> _commandMap = new Dictionary<Func<bool>, Command>();

    #region ��ɵ�
    abstract public class Command
    {
        public abstract void exectue();
    }

    public class CommandJump : Command
    {
        public override void exectue()
        {
            Debug.Log("Jump");
        }
    }

    public class CommandAttack : Command
    {
        public override void exectue()
        {
            Debug.Log("Attack");
        }
    }

    public class CommandCrouch : Command
    {
        public override void exectue()
        {
            Debug.Log("Crouch");
        }
    }
    #endregion

    // ��ɿ� ���� �⺻�� ����
    void Awake()
    {
        _commandMap.Add(() => { return Input.GetKeyDown(KeyCode.Space); }, new CommandJump());
        _commandMap.Add(() => { return Input.GetKeyDown(KeyCode.Mouse0); }, new CommandAttack());
        _commandMap.Add(() => { return Input.GetKeyDown(KeyCode.LeftControl); }, new CommandCrouch());
    }

    void Update()
    {
        // ������ �Էµ��� ���ӿ��� ������ �ߴ��� �����ϰ�, �Է¿� �´� ��� ����
        foreach (var kvp in _commandMap)
        {
            if (kvp.Key.Invoke() == true)
            {
                kvp.Value.exectue();
            }
        }

        // TEST
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeKey(KeyCode.Space, new CommandAttack());
        }
    }

    // ���ϴ� Ű �Է� ����
    public void ChangeKey(KeyCode keyCode, Command command)
    {
        bool overlapped = false;
        Func<bool> inputMethod = () =>
        {
            return Input.GetKeyDown(keyCode);
        };

        // 1. �Ű������� ���� KeyCode�� �̹� Ű ������ �����ϴ� �Է��ΰ�?
        foreach (var key in _commandMap.Keys)
        {
            
        }

        // 2. �̹� �ִ� �Ÿ� ��� �޽��� ���
        if (overlapped == true)
        {
            //  YES -> ���ο� �Է¹������ ���ó��
            //  NO  -> ����
        }
        // 3. �ƴϸ� �׳� �߰�
        else
        {
            _commandMap.Add(inputMethod, command);
        }
    }
}