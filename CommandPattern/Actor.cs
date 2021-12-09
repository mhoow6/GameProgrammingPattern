using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class Actor : MonoBehaviour
    {
        public virtual void Jump() { }
        public virtual void Attack() { }
        public virtual void Crouch() { }
    }
}