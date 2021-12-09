using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // 키:명령을 하기 위한 입력(반환값 bool), 값:입력에 해당하는 명령
    Dictionary<Func<bool>, Command> _commandMap = new Dictionary<Func<bool>, Command>();

    #region 명령들
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

    // 명령에 대한 기본값 설정
    void Awake()
    {
        _commandMap.Add(() => { return Input.GetKeyDown(KeyCode.Space); }, new CommandJump());
        _commandMap.Add(() => { return Input.GetKeyDown(KeyCode.Mouse0); }, new CommandAttack());
        _commandMap.Add(() => { return Input.GetKeyDown(KeyCode.LeftControl); }, new CommandCrouch());
    }

    void Update()
    {
        // 지정된 입력들을 게임에서 실제로 했는지 검증하고, 입력에 맞는 명령 수행
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

    // 원하는 키 입력 변경
    public void ChangeKey(KeyCode keyCode, Command command)
    {
        bool overlapped = false;
        Func<bool> inputMethod = () =>
        {
            return Input.GetKeyDown(keyCode);
        };

        // 1. 매개변수로 받은 KeyCode가 이미 키 설정에 존재하는 입력인가?
        foreach (var key in _commandMap.Keys)
        {
            
        }

        // 2. 이미 있는 거면 경고 메시지 출력
        if (overlapped == true)
        {
            //  YES -> 새로운 입력방식으로 명령처리
            //  NO  -> 무시
        }
        // 3. 아니면 그냥 추가
        else
        {
            _commandMap.Add(inputMethod, command);
        }
    }
}