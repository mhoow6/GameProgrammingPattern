using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ResourceManager는 프로젝트내에서 존재하는 유일한 객체 클래스이다.
public class ResourceManager : SingleTon<ResourceManager>
{
    public void LoadMap(string mapname)
    {
        Debug.Log(mapname + "로드");
    }
}
