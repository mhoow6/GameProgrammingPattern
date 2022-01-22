using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonoSingleton;

namespace ObserverPattern
{
    public class GameManager : MonoSingleton<GameManager>
    {
        Achievements achievementSystem;
        public Achievements AchievementSystem => achievementSystem;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);

            achievementSystem = new Achievements();
        }
    }
}

