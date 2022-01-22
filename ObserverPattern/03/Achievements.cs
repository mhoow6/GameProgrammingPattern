using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region ������ ���� ����
// Ŭ������ �����ϴ� ���� ������ ������ ������ �ξ� ����.
// �ֳ��ϸ� ���� � �������̽��� ������ �ʿ䵵, Ŭ������
// ��ӹ��� �ʿ���� �׳� �̺�Ʈ�� ���޸��ϸ� �ȴ�.
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

