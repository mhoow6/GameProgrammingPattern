using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 프로토타입 패턴 설명
/*
 * 어떤 객체가 자기와 비슷한 객체를 스폰할 수 있게 하는게 프로토타입 패턴
 * 제너릭, 리플렉션을 활용하면 우아하게 타입에 맞는
 * 객체를 생성시킬 수 있다.
 */
#endregion
namespace PrototypePattern
{
    #region 몬스터
    public abstract class Monster
    {
        protected int m_hp;
        protected string m_name;

        public Monster(){}

        public Monster(int _hp, string _name)
        {
            m_hp = _hp;
            m_name = _name;
        }

        public abstract void Yell();

        // 프로토타입 패턴을 이렇게 할 수도 있다.
        // Clone()에서 타입에 맞는 객체를 생성시키도록
        // 자식클래스가 구현하게 한다.
        // 여기서 상태복제가 가능하게 할 수도 있다.
        public abstract Monster Clone();

        public void TellMe()
        {
            Debug.Log($"체력: {m_hp}");
            Debug.Log($"이름: {m_name}");
        }
    }

    public class Ghost : Monster
    {
        public Ghost(){}
        public Ghost(int _hp, string _name) : base(_hp, _name){}

        public override Monster Clone()
        {
            return new Ghost(m_hp, m_name);
        }

        public override void Yell()
        {
            Debug.Log("으흐흐흐흐..");
        }
    }

    public class Goblin : Monster
    {
        public Goblin(){}
        public Goblin(int _hp, string _name) : base(_hp, _name) { }

        public override Monster Clone()
        {
            return new Goblin(m_hp, m_name);
        }

        public override void Yell()
        {
            Debug.Log("캬오오오!!");
        }
    }
    #endregion

    #region 스포너
    public abstract class Spawner
    {
        public abstract Monster Clone { get; }
    }

    // 프로토타입을 활용하지 않으면 이렇게 타입마다
    // 객체를 만들어줘야 할 것이다..
    public class GhostSpawner : Spawner
    {
        public override Monster Clone => new Ghost(1, "이상한 유령");
    }

    // 템플릿 응용
    public class GenericSpawner<T> : Spawner where T : Monster
    {
        Type m_type = typeof(T);

        public override Monster Clone => Activator.CreateInstance(m_type) as Monster;
    }

    // 객체의 상태 복제 가능
    public class AdvancedSpawner : Spawner
    {
        Monster m_prototype;
        public AdvancedSpawner(Monster _clone){ m_prototype = _clone; }

        public override Monster Clone => m_prototype.Clone();
    }
    #endregion
}