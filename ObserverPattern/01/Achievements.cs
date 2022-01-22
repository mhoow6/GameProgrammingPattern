using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public struct Achievement
    {
        public int index;
        public EventType condition;
        public int purposeCount;
    }

    public enum EventType
    {
        KILL,
        DEAD,
        FALL_DOWN
    }

    public class Achievements : IEventObservable
    {
        List<Achievement> achievements = new List<Achievement>();
        Dictionary<EventType, int> achievementCounter = new Dictionary<EventType, int>();

        public Achievements()
        {
            // TEST
            achievements.Add(new Achievement()
            {
                index = 0,
                condition = EventType.FALL_DOWN,
                purposeCount = 10
            });
        }

        public void OnNotify(EventType type)
        {
            if (achievementCounter.TryGetValue(type, out int count) == false)
            {
                achievementCounter.Add(type, 1);
            }
            else
            {
                achievementCounter[type] = count++;
            }

            var datas = achievements.FindAll(a => a.condition == type);
            foreach (var d in datas)
            {
                if (d.purposeCount == count)
                {
                    Debug.Log($"{d.index} 업적 완료!");
                }
                else
                {
                    Debug.Log($"업적 완료까지 {d.purposeCount - count}번 남았습니다.");
                }
            }
        }
    }
}

