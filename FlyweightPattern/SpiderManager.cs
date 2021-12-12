using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyWeightPattern
{
    public class SpiderManager : MonoBehaviour
    {
        SpiderSpec _spec = new SpiderSpec(10, 20);
        List<Spider> _spiders = new List<Spider>();
        Player _target; // 거미들 중 한 명이라도 타겟을 찾으면 모두 타겟을 공유함

        void Awake()
        {
            // 거미 소환
            {
                int spiderCount = 10;
                while (spiderCount != 0)
                {
                    _spiders.Add(new Spider());
                    spiderCount--;
                }
            }

            // 거미의 Hp는 각자 다름
            foreach (var spider in _spiders)
            {
                spider.hp = Random.Range(10, 20);
            }
        }

        // 거미가 플레이어랑 가까이 있어 공격하는 경우 호출
        public void Attack()
        {
            if (_target != null)
            {
                _target.hp -= _spec.Damage;
                if (_target.hp < 0)
                {
                    _target.hp = 0;
                    // TODO: 플레이어 사망처리
                }
            }
        }

        // 거미가 플레이어랑 레벨차이가 나서 받는 데미지가 감소하기 위해 호출
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

    // 거미들은 모두 같은 스펙을 지니기 때문에 SpiderSpec은 경량 패턴으로 만들어졌다.
    // 공유 객체이므로 필드는 변경불가능해야 안전하다.
    /*public class SpiderSpec
    {
        public readonly int Level;
        public readonly int PenaltyLevel; // PenaltyLevel 레벨 이하인 플레이어가 데미지를 줄 경우 패널티를 받습니다.
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

    // 어차피 스펙은 변경되지 않으므로, SpiderSpec이 힙메모리에 있는 것이 불만이다면 struct로 만들어도 상관없다.
    public struct SpiderSpec
    {
        public readonly int Level;
        public readonly int PenaltyLevel; // PenaltyLevel 레벨 이하인 플레이어가 데미지를 줄 경우 패널티를 받습니다.
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

    // 거미가 가진 스펙을 분류한 덕분에 거미는 오직 hp에 대한 변수만 가지고 있어도 된다!
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

