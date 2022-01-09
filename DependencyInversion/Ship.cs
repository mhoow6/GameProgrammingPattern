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
            // �������̽� Ÿ������ �޾Ҵ�.
            input = settings.UseAI ?
                new AiInput() as IShipInput :
                new ControllerInput();

            motor = new ShipMotor(input, transform, settings);
        }

        void Update()
        {
            // ���ϴ� �Է���ġ�κ��� Input�� �޴´�.
            input.ReadInput();

            // motor�� �۵��Ͽ� �����̰� �Ѵ�.
            motor.Tick();
        }

    }
}

