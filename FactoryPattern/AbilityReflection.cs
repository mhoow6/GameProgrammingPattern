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
        // 어빌리티의 이름
        public abstract string Name { get; }

        // 어빌리티는 무언가를 해야한다.
        public abstract void Process();
    }

    public class StartFireAbility : Ability
    {
        public override string Name => "fire";

        public override void Process()
        {
            // 불 뿜기
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
            // Ability로 된 모든 타입들을 가져온다.
            var abilityTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes()
                // 조건
                .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(Ability)));

            abilitiesByName = new Dictionary<string, Type>();

            // 키: Name, 값: 클래스
            foreach (var type in abilityTypes)
            {
                var temp = Activator.CreateInstance(type) as Ability;

                // temp를 생성하고, 해당 인스턴스의 이름만 키값으로 넣는다.
                // 값은 type 자체를 기입
                abilitiesByName.Add(temp.Name, type);
            }
        }

        public Ability GetAbility(string abilityType)
        {
            if (abilitiesByName.ContainsKey(abilityType))
            {
                // 해당 이름의 타입을 가져온다.
                Type type = abilitiesByName[abilityType];

                // 인스턴스를 만든다
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

