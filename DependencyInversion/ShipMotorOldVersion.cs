using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DITutorial
{

    #region Dependency Inversion Principle ��Ģ�� ������ �ʴ� �ڵ�
    // Motor�� Ship�� �����̰� ȸ����Ű�� å�Ӹ� ������ �ִ�.
    /*public class ShipMotor : MonoBehaviour
    {
        [SerializeField] float turnSpeed = 15f;
        [SerializeField] float moveSpeed = 10f;

        void Update()
        {
            // 1. Motor�� horizontal, vertical �Է��� ���� �޴� �ڵ� ���� �ۼ��Ǿ��־�, Single Responsibility Principle ���� ���� �ִ�.
            // 2. ���� Input Ŭ���������� rotation�� thurst ���� �����ϱ� ������, AI�κ��� �Է��� �޵�, ��Ʈ��ũ���� �Է¹��� ���� ����. (Input Ŭ������ �����ǰ� �ִ�)
            float rotation = Input.GetAxis("Horizontal");
            float thrust = Input.GetAxis("Vertical");

            transform.Rotate(Vector3.up * rotation * Time.deltaTime * turnSpeed);
            transform.position += transform.forward * thrust * Time.deltaTime * moveSpeed;
        }
    }*/
    #endregion

    public class ShipMotorOldVersion : MonoBehaviour
    {
        [SerializeField] float turnSpeed = 15f;
        [SerializeField] float moveSpeed = 10f;

        ControllerInput shipInput;

        void Awake()
        {
            // Unity�� �ƴ� ȯ�濡�� �����ڸ� ���ؼ� �޴´�.
            shipInput = GetComponent<ControllerInput>();
        }

        void Update()
        {
            // �ٸ� ���·� ������ ShipInput Ŭ������ �޾Ƶ� �� �ڵ�� �۵��Ѵ�.
            float rotation = shipInput.Rotation;
            float thrust = shipInput.Thrust;

            transform.Rotate(Vector3.up * rotation * Time.deltaTime * turnSpeed);
            transform.position += transform.forward * thrust * Time.deltaTime * moveSpeed;
        }
    }
}

