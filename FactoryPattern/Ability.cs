using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���丮 ���� ����
namespace FactoryPattern
{
    public abstract class Ability
    {
        // �����Ƽ�� ���𰡸� �ؾ��Ѵ�.
        public abstract void Process();
    }

    public class StartFireAbility : Ability
    {
        public override void Process()
        {
            // �� �ձ�
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

