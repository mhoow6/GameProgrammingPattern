using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * �̱��� ������ ������� �ʰ� �� ���� Ŭ���� �ν��Ͻ��� ������ �����ϱ�
 * 1. assert�� Ȱ��
 * 2. �Ű������� �Ѱ��ֱ�
 * 3. ���� Ŭ�����κ��� ���
 * 4. �̹� �̃P���� Ŭ�����κ��� ���
 */

namespace AvoidSingleton
{
    // 1. assert�� Ȱ��
    public class GameManager
    {
        public GameManager()
        {
            // �̹� �ν��Ͻ��� �Ǿ������� Assert�� �Ǿ� �ڵ� ������Ŵ
            if (instantiated)
                Debug.Assert(instantiated);

            instantiated = true;
        }

        static bool instantiated = false;
    }

    // 2. �Ű������� �Ѱ��ֱ�
    public class Monster
    {
        protected GameManager gm;
        public Monster(GameManager gm)
        {
            this.gm = gm;
        }
    }

    // 3. ���� Ŭ�����κ��� ���
    public class RangeMonster : Monster
    {
        public RangeMonster(GameManager gm) : base(gm)
        {

        }
    }

    // 4. �̱��� Ŭ�����κ��� ���
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

        // ��ġ �̱����ΰ� ���� �ϰ� �� �� �ִ�.
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

