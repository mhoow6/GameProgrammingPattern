using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ObserverPattern
{
    /// <summary>
    /// �ٸ� ��ü�� �����ϴ� ��� ����
    /// </summary>
    public interface IObservable
    {
        void OnNotify(Action action);
    }

    public interface IEventObservable
    {
        void OnNotify(EventType type);
    }

    public class EventSubject : MonoBehaviour
    {
        List<IEventObservable> observers = new List<IEventObservable>();
        public void AddObserver(IEventObservable observer)
        {
            observers.Add(observer);
        }
        public void RemoveObserver(IEventObservable observer)
        {
            observers.Remove(observer);
        }

        protected void Notify(EventType type)
        {
            // IEventObservable�� ������ Ŭ������ OnNotify����
            // AddObserver Ȥ�� RemoveObserver �Ͽ� observers���� �ش� Ŭ������ ������
            // ���⼭ ���Ӱ� ����Ʈ�� ����� ������ for������ �����ϰ� ��ȸ�ϰ� �Ѵ�.
            List<IEventObservable> copied = new List<IEventObservable>();
            copied.AddRange(observers);

            foreach (var ob in copied)
            {
                ob.OnNotify(type);
            }
        }
    }
}

