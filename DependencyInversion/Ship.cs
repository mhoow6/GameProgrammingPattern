using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DITutorial
{
    public class Ship : MonoBehaviour
    {
        // Property Injection
        [SerializeField] ShipSettings settings;
        IShipInput input;
        ShipMotor motor;

        void Awake()
        {
            // 인터페이스 타입으로 받았다.
            input = settings.UseAI ?
                new AiInput() as IShipInput :
                new ControllerInput();

            motor = new ShipMotor(input, transform, settings);
        }

        void Update()
        {
            // 원하는 입력장치로부터 Input을 받는다.
            input.ReadInput();

            // motor를 작동하여 움직이게 한다.
            motor.Tick();
        }

    }
}

