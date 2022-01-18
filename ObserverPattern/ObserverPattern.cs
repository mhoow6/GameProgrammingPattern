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
            // IEventObservable을 구현한 클래스의 OnNotify에서
            // AddObserver 혹은 RemoveObserver 하여 observers에서 해당 클래스가 빠져도
            // 여기서 새롭게 리스트를 만들기 때문에 for문에서 안전하게 순회하게 한다.
            List<IEventObservable> copied = new List<IEventObservable>();
            copied.AddRange(observers);

            foreach (var ob in copied)
            {
                ob.OnNotify(type);
            }
        }
    }
}

