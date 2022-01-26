using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region ������Ÿ�� ���� ����
/*
 * � ��ü�� �ڱ�� ����� ��ü�� ������ �� �ְ� �ϴ°� ������Ÿ�� ����
 * ���ʸ�, ���÷����� Ȱ���ϸ� ����ϰ� Ÿ�Կ� �´�
 * ��ü�� ������ų �� �ִ�.
 */
#endregion
namespace PrototypePattern
{
    #region ����
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

        // ������Ÿ�� ������ �̷��� �� ���� �ִ�.
        // Clone()���� Ÿ�Կ� �´� ��ü�� ������Ű����
        // �ڽ�Ŭ������ �����ϰ� �Ѵ�.
        // ���⼭ ���º����� �����ϰ� �� ���� �ִ�.
        public abstract Monster Clone();

        public void TellMe()
        {
            Debug.Log($"ü��: {m_hp}");
            Debug.Log($"�̸�: {m_name}");
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
            Debug.Log("����������..");
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
            Debug.Log("ļ������!!");
        }
    }
    #endregion

    #region ������
    public abstract class Spawner
    {
        public abstract Monster Clone { get; }
    }

    // ������Ÿ���� Ȱ������ ������ �̷��� Ÿ�Ը���
    // ��ü�� �������� �� ���̴�..
    public class GhostSpawner : Spawner
    {
        public override Monster Clone => new Ghost(1, "�̻��� ����");
    }

    // ���ø� ����
    public class GenericSpawner<T> : Spawner where T : Monster
    {
        Type m_type = typeof(T);

        public override Monster Clone => Activator.CreateInstance(m_type) as Monster;
    }

    // ��ü�� ���� ���� ����
    public class AdvancedSpawner : Spawner
    {
        Monster m_prototype;
        public AdvancedSpawner(Monster _clone){ m_prototype = _clone; }

        public override Monster Clone => m_prototype.Clone();
    }
    #endregion
}