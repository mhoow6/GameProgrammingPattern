using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ObserverPattern
{
    /// <summary>
    /// 다른 객체를 관찰하는 경우 구현
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
    /// 자신이 관찰받는 대상이 될 경우 상속받습니다
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

