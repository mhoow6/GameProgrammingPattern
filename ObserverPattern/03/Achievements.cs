using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region 옵저버 패턴 설명
// 클로저를 지원하는 언어에서 옵저버 패턴의 구현은 훨씬 쉽다.
// 왜냐하면 굳이 어떤 인터페이스를 구현할 필요도, 클래스를
// 상속받을 필요없이 그냥 이벤트를 전달만하면 된다.
#endregion
namespace ObserverPattern3
{
    public enum EventType
    {
        KILL,
        DEAD,
        FALL_DOWN
    }

    public class Achievements : MonoBehaviour
    {
        public static EventType Notify
        {
            set
            {
                m_notifyQueue.Enqueue(value);
            }
        }
        static Queue<EventType> m_notifyQueue = new Queue<EventType>();

        // 1d: [EventType][EventType][EventType]
        // 2d: [Count][Count][Count]
        int[,] m_achievmentCounter;

        void Awake()
        {
            int eventCount = System.Enum.GetValues(typeof(EventType)).Length;
            m_achievmentCounter = new int[eventCount, 2];
            for (int i = 0; i < eventCount; i++)
            {
                m_achievmentCounter[i, 0] = i;
            }
        }

        void FixedUpdate()
        {
            while (m_notifyQueue.Count != 0)
            {
                EventType curEvent = m_notifyQueue.Dequeue();
                AddAchivementCount(curEvent);
            }
        }

        void AddAchivementCount(EventType eventType)
        {
            m_achievmentCounter[(int)eventType, 1]++;
        }

        void RemoveAchivementCount(EventType eventType)
        {
            m_achievmentCounter[(int)eventType, 1]--;
        }

        int GetAchivementCount(EventType eventType)
        {
            return m_achievmentCounter[(int)eventType, 1];
        }
    }
}

