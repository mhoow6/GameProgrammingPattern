using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ship/Settings", fileName = "ShipData")]
public class ShipSettings : ScriptableObject
{
    [SerializeField] float turnSpeed = 25f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] bool useAI = false;

    public float TurnSpeed => turnSpeed;
    public float MoveSpeed => moveSpeed;
    public bool UseAI => useAI;
}
