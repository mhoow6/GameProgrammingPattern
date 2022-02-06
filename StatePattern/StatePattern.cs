using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class FSMExample
    {
        #region FSM 설명
        /*
         * 1. 정의
            * Finite State Machine
            * 인공지능을 작성하는 방법 중 하나
            * 유한한 갯수의 상태를 정의하고, 상태 사이의 전이를 제어함으로써 반응하는 기계
         * 2. 특징
            * 가질 수 있는 상태가 한정됨
            * 한 번에 한 가지 상태만 가능
            * 입력이나 이벤트가 기계에 전달
            * 입력에 따라 다음 상태로 바뀌는 전이가 있음
         */
        #endregion

        #region FSM 예시
        State m_state;
        // 열거형은 상태기계를 구현하는 가장 간단한 방법이다.
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
                    // if IDLE상태에서 JUMP로 갈 수 있는 입력을 했다면
                    m_state = State.E_JUMP;

                    // if IDLE상태에서 DUCK로 갈 수 있는 입력을 했다면

                    #region 문제점 1-2
                    // 다른 상태에서 DUCK 상태로 변할때 m_chargeTime은 초기화해야하므로
                    // 역시나 HandleInput에도 코드를 작성해야 한다.
                    // 이런 방식보단 밑에서 소개하는 상태패턴을 활용하면 조금 더 우아하게
                    // 문제 해결 가능!
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
            #region 문제점 1-1
            // 그러나 특정 상태일때 Update문에서 뭔가 하고 싶은 경우라면
            // 이런식으로 코드를 추가해야 할 것이다.
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
        #region 열거형을 통해 FSM을 구현할 때와의 차이점
        // -> switch문이 아닌 상태별로 클래스를 정의하여 문제해결
        #endregion

        // 1. 상태 인터페이스 정의
        abstract class State
        {
            #region 객체할당 방법 1
            //정적 인스턴스에서 가져와서 m_state에 객체 할당
            public static DuckState duck;
            public static IdleState idle;
            public static JumpState jump;
            public static DiveState dive;
            #endregion
            public abstract void HandleInput();
            public abstract void Update();
        }

        // 2. 상태별 클래스 만들기
        // 이렇게 하면 특정 상태에서 예외적으로 행동해야 할 일을
        // 하나의 클래스에 담을 수 있다!
        class DuckState : State
        {
            public override void HandleInput()
            {
                // if IDLE상태에서 DUCK로 갈 수 있는 입력을 했다면
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

        // 3. 원하는 곳에 상태 클래스 사용
        class Player
        {
            // 상태를 바꿀려면 m_state에 다른 객체를 할당하면 끝!
            // 그렇다면 객체를 어떻게 할당할까?
            State m_state;

            void HandleInput()
            {
                m_state.HandleInput();
            }

            void Update()
            {
                // if 점프에 해당하는 입력을 했다면
                // ps. 이 코드는 여기보단 State에 Player를 넘겨서 IdleState에서 해결하는게 더 깔끔하다.

                #region 객체할당 방법 1 문제점
                // 만약 필드가 있는 상태라면 이렇게 정적 객체를 사용해선 안된다.
                // 왜냐하면 상태를 사용하는 객체들이 전부 다 같은 필드 값을 사용해버리기 때문
                #endregion

                #region 객체할당 방법 1 문제점 해결방법
                // 그냥 m_state에 새로운 상태 겍체를 할당하는 수 밖에 없다.
                // C++이면 메모리 누수에 주의하고
                #endregion
                m_state = State.jump;

                m_state.Update();
            }
        }
    }
}

