using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace ReflectionFactory
{
    public abstract class Ability
    {
        // �����Ƽ�� �̸�
        public abstract string Name { get; }

        // �����Ƽ�� ���𰡸� �ؾ��Ѵ�.
        public abstract void Process();
    }

    public class StartFireAbility : Ability
    {
        public override string Name => "fire";

        public override void Process()
        {
            // �� �ձ�
        }
    }

    public class HealSelfAbility : Ability
    {
        public override string Name => "heal";

        public override void Process()
        {
            // self.health++
        }
    }

    public class AbilityFactory
    {
        Dictionary<string, Type> abilitiesByName;

        public AbilityFactory()
        {
            // Ability�� �� ��� Ÿ�Ե��� �����´�.
            var abilityTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes()
                // ����
                .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(Ability)));

            abilitiesByName = new Dictionary<string, Type>();

            // Ű: Name, ��: Ŭ����
            foreach (var type in abilityTypes)
            {
                var temp = Activator.CreateInstance(type) as Ability;

                // temp�� �����ϰ�, �ش� �ν��Ͻ��� �̸��� Ű������ �ִ´�.
                // ���� type ��ü�� ����
                abilitiesByName.Add(temp.Name, type);
            }
        }

        public Ability GetAbility(string abilityType)
        {
            if (abilitiesByName.ContainsKey(abilityType))
            {
                // �ش� �̸��� Ÿ���� �����´�.
                Type type = abilitiesByName[abilityType];

                // �ν��Ͻ��� �����
                var ability = Activator.CreateInstance(type) as Ability;
                return ability;
            }

            return null;
        }

        internal IEnumerable<string> GetAbilityNames()
        {
            return abilitiesByName.Keys;
        }
    }
}

