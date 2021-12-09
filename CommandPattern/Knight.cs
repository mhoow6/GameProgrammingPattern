using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class Knight : Actor
    {
        public override void Jump()
        {
            Debug.Log("기사답게 점프!");
        }
    }
}

