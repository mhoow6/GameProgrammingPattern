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

    // �ڽ��� Ŭ������ �ٸ� �������� �ν��Ͻ�ȭ �Ǵ� ���� ��ġ �ʰ�,
    // ���� ������ ���Զ��� �ʿ���ٸ�? -> static class���� ����
    public static class AbilityFactory
    {
        static Dictionary<string, Type> abilitiesByName;
        static bool IsInitialized => abilitiesByName != null;

        static void InitializeFactory()
        {
            if (IsInitialized)
                return;

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

        static Ability GetAbility(string abilityType)
        {
            InitializeFactory();

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

        internal static IEnumerable<string> GetAbilityNames()
        {
            Debug.Log("Test");
            InitializeFactory();
            return abilitiesByName.Keys;
        }
    }
}

