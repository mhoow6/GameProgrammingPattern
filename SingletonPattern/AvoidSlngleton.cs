using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 싱글턴 패턴을 사용하지 않고 한 개의 클래스 인스턴스만 갖도록 보장하기
 * 1. assert문 활용
 * 2. 매개변수로 넘겨주기
 * 3. 상위 클래스로부터 얻기
 * 4. 이미 싱긑턴인 클래스로부터 얻기
 */

namespace AvoidSingleton
{
    // 1. assert문 활용
    public class GameManager
    {
        public GameManager()
        {
            // 이미 인스턴싱이 되어있으면 Assert가 되어 코드 중지시킴
            if (instantiated)
                Debug.Assert(instantiated);

            instantiated = true;
        }

        static bool instantiated = false;
    }

    // 2. 매개변수로 넘겨주기
    public class Monster
    {
        protected GameManager gm;
        public Monster(GameManager gm)
        {
            this.gm = gm;
        }
    }

    // 3. 상위 클래스로부터 얻기
    public class RangeMonster : Monster
    {
        public RangeMonster(GameManager gm) : base(gm)
        {

        }
    }

    // 4. 싱글턴 클래스로부터 얻기
    public class Singleton
    {
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }
        static Singleton instance;

        // 마치 싱글턴인거 마냥 하게 할 수 있다.
        public LogSystem LogSystem { get; private set; }

        public Singleton()
        {
            LogSystem = new LogSystem();
        }
    }

    public class LogSystem
    {

    }
}

