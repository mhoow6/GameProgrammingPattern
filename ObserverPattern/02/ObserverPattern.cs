using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 연결리스트로 구현한 옵저버 패턴 설명
// ObserverPattern1에서 구현한 옵저버 패턴과는 다르게
// 대상 객체에 관찰자 객체를 추가/제거하지 않고
// 대상에 한 관찰자 객체만 추가/제거할 수 있다.

// 이러한 특징때문에 대상객체가 조금 더 가벼워진다는 장점은 있지만,
// 보통 한 대상에 여러 관찰자가 붙는게 일반적이기 때문에 한계점이 있다.
#endregion
namespace ObserverPattern2
{
    // TEST
    public enum EventType
    {
        KILL,
        DEAD,
        FALL_DOWN
    }

    /// <summary>
    /// 관찰자의 대상이 되고 싶음 상속받자 (연결리스트로 구현) 
    /// </summary>
    public class Subject
    {
        IObservable m_head;

        public void AddObserver(IObservable ob)
        {
            #region 설명
            // LinkedList 로직과 동일
            // 간결함을 위해 tail 노드가 없이 구현
            // 이렇게 하면 맨 나중에 추가한 관찰자가
            // 먼저 알림을 받게 되는 단점이 있다.
            #endregion

            // 관찰자의 다음 노드를 대상의 헤드 노드로 지정하고
            ob.Next = m_head;
            // 헤드 노드는 관찰자를 가리키게하여 서로 연결한다.
            m_head = ob;
        }

        public void RemoveObserver(IObservable ob)
        {
            // 지우려는게 첫 노드인경우
            if (m_head == ob)
            {
                m_head = ob.Next;
                ob.Next = null;
                return;
            }

            IObservable current = m_head;
            while (current != null)
            {
                if (current.Next == ob)
                {
                    current.Next = ob.Next;
                    ob.Next = null;
                    return;
                }
                // 계속해서 다음 노드를 탐색
                current = current.Next;
            }

            
        }

        public void Notify(EventType type)
        {
            IObservable ob = m_head;
            while (ob != null)
            {
                ob.OnNotify(type);
                ob = ob.Next;
            }
        }
    }

    public interface IObservable
    {
        public IObservable Next { get; set; }

        void OnNotify(EventType type);
    }
}

