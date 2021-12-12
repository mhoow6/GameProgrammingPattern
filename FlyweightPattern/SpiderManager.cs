using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyWeightPattern
{
    public class SpiderManager : MonoBehaviour
    {
        SpiderSpec _spec = new SpiderSpec(10, 20);
        List<Spider> _spiders = new List<Spider>();
        Player _target; // �Ź̵� �� �� ���̶� Ÿ���� ã���� ��� Ÿ���� ������

        void Awake()
        {
            // �Ź� ��ȯ
            {
                int spiderCount = 10;
                while (spiderCount != 0)
                {
                    _spiders.Add(new Spider());
                    spiderCount--;
                }
            }

            // �Ź��� Hp�� ���� �ٸ�
            foreach (var spider in _spiders)
            {
                spider.hp = Random.Range(10, 20);
            }
        }

        // �Ź̰� �÷��̾�� ������ �־� �����ϴ� ��� ȣ��
        public void Attack()
        {
            if (_target != null)
            {
                _target.hp -= _spec.Damage;
                if (_target.hp < 0)
                {
                    _target.hp = 0;
                    // TODO: �÷��̾� ���ó��
                }
            }
        }

        // �Ź̰� �÷��̾�� �������̰� ���� �޴� �������� �����ϱ� ���� ȣ��
        public void Damaged(Player attacker, Spider spider)
        {
            if (attacker.level < _spec.PenaltyLevel)
            {
                float damage = attacker.damage * _spec.ReduceDamageRatio;
                spider.hp -= (int)damage;
            }
            else
            {
                spider.hp -= attacker.damage;
            }
        }
    }

    // �Ź̵��� ��� ���� ������ ���ϱ� ������ SpiderSpec�� �淮 �������� ���������.
    // ���� ��ü�̹Ƿ� �ʵ�� ����Ұ����ؾ� �����ϴ�.
    /*public class SpiderSpec
    {
        public readonly int Level;
        public readonly int PenaltyLevel; // PenaltyLevel ���� ������ �÷��̾ �������� �� ��� �г�Ƽ�� �޽��ϴ�.
        public readonly float ReduceDamageRatio; 
        public readonly int Damage;
        
        public SpiderSpec(int level, int damage)
        {
            Level = level;
            PenaltyLevel = level - 10;
            ReduceDamageRatio = 0.5f;

            Damage = damage;
        }
    }*/

    // ������ ������ ������� �����Ƿ�, SpiderSpec�� ���޸𸮿� �ִ� ���� �Ҹ��̴ٸ� struct�� ���� �������.
    public struct SpiderSpec
    {
        public readonly int Level;
        public readonly int PenaltyLevel; // PenaltyLevel ���� ������ �÷��̾ �������� �� ��� �г�Ƽ�� �޽��ϴ�.
        public readonly float ReduceDamageRatio;
        public readonly int Damage;

        public SpiderSpec(int level, int damage)
        {
            Level = level;
            PenaltyLevel = level - 10;
            ReduceDamageRatio = 0.5f;

            Damage = damage;
        }
    }

    // �Ź̰� ���� ������ �з��� ���п� �Ź̴� ���� hp�� ���� ������ ������ �־ �ȴ�!
    public class Spider
    {
        public int hp;
    }

    public class Player
    {
        public int hp;
        public int level;
        public int damage;
    }
}

