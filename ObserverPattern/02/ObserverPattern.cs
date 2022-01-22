using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ���Ḯ��Ʈ�� ������ ������ ���� ����
// ObserverPattern1���� ������ ������ ���ϰ��� �ٸ���
// ��� ��ü�� ������ ��ü�� �߰�/�������� �ʰ�
// ��� �� ������ ��ü�� �߰�/������ �� �ִ�.

// �̷��� Ư¡������ ���ü�� ���� �� ���������ٴ� ������ ������,
// ���� �� ��� ���� �����ڰ� �ٴ°� �Ϲ����̱� ������ �Ѱ����� �ִ�.
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
    /// �������� ����� �ǰ� ���� ��ӹ��� (���Ḯ��Ʈ�� ����) 
    /// </summary>
    public class Subject
    {
        IObservable m_head;

        public void AddObserver(IObservable ob)
        {
            #region ����
            // LinkedList ������ ����
            // �������� ���� tail ��尡 ���� ����
            // �̷��� �ϸ� �� ���߿� �߰��� �����ڰ�
            // ���� �˸��� �ް� �Ǵ� ������ �ִ�.
            #endregion

            // �������� ���� ��带 ����� ��� ���� �����ϰ�
            ob.Next = m_head;
            // ��� ���� �����ڸ� ����Ű���Ͽ� ���� �����Ѵ�.
            m_head = ob;
        }

        public void RemoveObserver(IObservable ob)
        {
            // ������°� ù ����ΰ��
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
                // ����ؼ� ���� ��带 Ž��
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

