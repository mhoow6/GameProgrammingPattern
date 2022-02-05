using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SingleTon 클래스 제작 (Genereic방식)
// 단일체 패턴
// 프로젝트 전역에서 하나의 인스턴스만 생성할 수 있게 한다.
// where는 T의 제약조건을 의미함 : class는 참조형식이어야 한다, new는 매개변수가 없는 생성자를 의미

public class SingleTon<T> where T: class, new()
{
    private static T inst = null;

    public SingleTon()
    {

    }

    public static T instance
    {
        get
        {
            if (inst == null)
                inst = new T();
            return inst;
        }
    }
}
