using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class FallDown : EventSubject
    {
        void Start()
        {
            AddObserver(GameManager.Instance.AchievementSystem);
        }

        void OnTriggerEnter(Collider other)
        {
            Notify(EventType.FALL_DOWN);
        }
    }
}

