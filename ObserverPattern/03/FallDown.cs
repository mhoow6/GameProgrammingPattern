using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern3
{
    public class FallDown : MonoBehaviour
    {
        EventType Event => EventType.FALL_DOWN;

        void OnTriggerEnter(Collider other)
        {
            Achievements.Notify = Event;
        }
    }
}

