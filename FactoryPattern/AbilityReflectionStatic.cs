using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace ReflectionFactoryStatic
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

    // 자신의 클래스가 다른 군데에서 인스턴스화 되는 것을 원치 않고,
    // 또한 의존성 주입또한 필요없다면? -> static class으로 구현
    public static class AbilityFactory
    {
        static Dictionary<string, Type> abilitiesByName;
        static bool IsInitialized => abilitiesByName != null;

        static void InitializeFactory()
        {
            if (IsInitialized)
                return;

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

        static Ability GetAbility(string abilityType)
        {
            InitializeFactory();

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

        internal static IEnumerable<string> GetAbilityNames()
        {
            Debug.Log("Test");
            InitializeFactory();
            return abilitiesByName.Keys;
        }
    }
}

