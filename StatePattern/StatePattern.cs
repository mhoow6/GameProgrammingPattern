using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class FSMExample
    {
        #region FSM ����
        /*
         * 1. ����
            * Finite State Machine
            * �ΰ������� �ۼ��ϴ� ��� �� �ϳ�
            * ������ ������ ���¸� �����ϰ�, ���� ������ ���̸� ���������ν� �����ϴ� ���
         * 2. Ư¡
            * ���� �� �ִ� ���°� ������
            * �� ���� �� ���� ���¸� ����
            * �Է��̳� �̺�Ʈ�� ��迡 ����
            * �Է¿� ���� ���� ���·� �ٲ�� ���̰� ����
         */
        #endregion

        #region FSM ����
        State m_state;
        // �������� ���±�踦 �����ϴ� ���� ������ ����̴�.
        enum State
        {
            E_IDLE,
            E_JUMP,
            E_DUCK,
            E_DIVE
        }

        void HandleInput()
        {
            switch (m_state)
            {
                case State.E_IDLE:
                    // if IDLE���¿��� JUMP�� �� �� �ִ� �Է��� �ߴٸ�
                    m_state = State.E_JUMP;

                    // if IDLE���¿��� DUCK�� �� �� �ִ� �Է��� �ߴٸ�

                    #region ������ 1-2
                    // �ٸ� ���¿��� DUCK ���·� ���Ҷ� m_chargeTime�� �ʱ�ȭ�ؾ��ϹǷ�
                    // ���ó� HandleInput���� �ڵ带 �ۼ��ؾ� �Ѵ�.
                    // �̷� ��ĺ��� �ؿ��� �Ұ��ϴ� ���������� Ȱ���ϸ� ���� �� ����ϰ�
                    // ���� �ذ� ����!
                    #endregion
                    m_state = State.E_DUCK;
                    m_chargeTime = 0;
                    break;
                case State.E_JUMP:
                    // ...
                    break;
                case State.E_DUCK:
                    // ...
                    break;
                case State.E_DIVE:
                    // ...
                    break;
            }
        }

        int m_chargeTime;
        void Update()
        {
            #region ������ 1-1
            // �׷��� Ư�� �����϶� Update������ ���� �ϰ� ���� �����
            // �̷������� �ڵ带 �߰��ؾ� �� ���̴�.
            #endregion
            if (m_state == State.E_DUCK)
            {
                m_chargeTime++;
                if (m_chargeTime > 3)
                {
                    // FIRE!
                }
            }
        }
        #endregion
    }

    public class StatePatternExample
    {
        #region �������� ���� FSM�� ������ ������ ������
        // -> switch���� �ƴ� ���º��� Ŭ������ �����Ͽ� �����ذ�
        #endregion

        // 1. ���� �������̽� ����
        abstract class State
        {
            #region ��ü�Ҵ� ��� 1
            //���� �ν��Ͻ����� �����ͼ� m_state�� ��ü �Ҵ�
            public static DuckState duck;
            public static IdleState idle;
            public static JumpState jump;
            public static DiveState dive;
            #endregion
            public abstract void HandleInput();
            public abstract void Update();
        }

        // 2. ���º� Ŭ���� �����
        // �̷��� �ϸ� Ư�� ���¿��� ���������� �ൿ�ؾ� �� ����
        // �ϳ��� Ŭ������ ���� �� �ִ�!
        class DuckState : State
        {
            public override void HandleInput()
            {
                // if IDLE���¿��� DUCK�� �� �� �ִ� �Է��� �ߴٸ�
                // ...
            }

            int m_chargeTime;
            public override void Update()
            {
                m_chargeTime++;
                if (m_chargeTime > 3)
                {
                    // FIRE!
                }
            }
        }

        class IdleState : State
        {
            public override void HandleInput()
            {
                throw new System.NotImplementedException();
            }

            public override void Update()
            {
            }
        }

        class JumpState : State
        {
            public override void HandleInput()
            {
                throw new System.NotImplementedException();
            }

            public override void Update()
            {
                throw new System.NotImplementedException();
            }
        }

        class DiveState : State
        {
            public override void HandleInput()
            {
                throw new System.NotImplementedException();
            }

            public override void Update()
            {
                throw new System.NotImplementedException();
            }
        }

        // 3. ���ϴ� ���� ���� Ŭ���� ���
        class Player
        {
            // ���¸� �ٲܷ��� m_state�� �ٸ� ��ü�� �Ҵ��ϸ� ��!
            // �׷��ٸ� ��ü�� ��� �Ҵ��ұ�?
            State m_state;

            void HandleInput()
            {
                m_state.HandleInput();
            }

            void Update()
            {
                // if ������ �ش��ϴ� �Է��� �ߴٸ�
                // ps. �� �ڵ�� ���⺸�� State�� Player�� �Ѱܼ� IdleState���� �ذ��ϴ°� �� ����ϴ�.

                #region ��ü�Ҵ� ��� 1 ������
                // ���� �ʵ尡 �ִ� ���¶�� �̷��� ���� ��ü�� ����ؼ� �ȵȴ�.
                // �ֳ��ϸ� ���¸� ����ϴ� ��ü���� ���� �� ���� �ʵ� ���� ����ع����� ����
                #endregion

                #region ��ü�Ҵ� ��� 1 ������ �ذ���
                // �׳� m_state�� ���ο� ���� ��ü�� �Ҵ��ϴ� �� �ۿ� ����.
                // C++�̸� �޸� ������ �����ϰ�
                #endregion
                m_state = State.jump;

                m_state.Update();
            }
        }
    }
}

