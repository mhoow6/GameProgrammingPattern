using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 간단한 팩토리 패턴 예제
namespace FactoryPattern
{
    public abstract class Ability
    {
        // 어빌리티는 무언가를 해야한다.
        public abstract void Process();
    }

    public class StartFireAbility : Ability
    {
        public override void Process()
        {
            // 불 뿜기
        }
    }

    public class HealSelfAbility : Ability
    {
        public override void Process()
        {
            // self.health++
        }
    }

    public class AbilityFactory
    {
        public Ability GetAbility(string abilityType)
        {
            switch (abilityType)
            {
                case "fire":
                    return new StartFireAbility();
                case "heal":
                    return new HealSelfAbility();
                default:
                    return null;
            }
        }
    }
}

