using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DITutorial
{
    public class ShipMotor
    {
        readonly IShipInput shipInput;
        readonly Transform transformToMove;
        readonly ShipSettings shipSettings;

        public ShipMotor(IShipInput input, Transform trans, ShipSettings settings)
        {
            shipInput = input;
            transformToMove = trans;
            shipSettings = settings;
        }

        public void Tick()
        {
            transformToMove.Rotate(Vector3.up * shipInput.Rotation * Time.deltaTime * shipSettings.TurnSpeed);
            transformToMove.position += transformToMove.forward * shipInput.Thrust * Time.deltaTime * shipSettings.MoveSpeed;
        }
        
    }
}

