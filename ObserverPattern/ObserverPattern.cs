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

    /// <summary>
    /// �ڽ��� �����޴� ����� �� ��� ��ӹ޽��ϴ�
    /// </summary>
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
            foreach (var ob in observers)
            {
                ob.OnNotify(type);
            }
        }
    }
}

