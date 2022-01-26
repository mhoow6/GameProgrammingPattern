using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypePattern
{
    public class SpawnerObject : MonoBehaviour
    {
        GenericSpawner<Ghost> ghostSpawner = new GenericSpawner<Ghost>();
        GenericSpawner<Goblin> goblinSpawner = new GenericSpawner<Goblin>();
        AdvancedSpawner advancedSpawner;

        void Awake()
        {
            Ghost ghost = new Ghost(100, "°í½ºÆ®");
            advancedSpawner = new AdvancedSpawner(ghost);
        }

        void Start()
        {
            ghostSpawner.Clone.Yell();
            goblinSpawner.Clone.Yell();
            advancedSpawner.Clone.TellMe();
        }

    }
}

