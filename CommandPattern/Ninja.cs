using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class Ninja : Actor
    {
        public override void Jump()
        {
            Debug.Log("닌자답게 점프!");
        }
    }
}
