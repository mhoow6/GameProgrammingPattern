using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DITutorial
{

    #region Dependency Inversion Principle 원칙을 따르지 않는 코드
    // Motor는 Ship를 움직이고 회전시키는 책임만 가지고 있다.
    /*public class ShipMotor : MonoBehaviour
    {
        [SerializeField] float turnSpeed = 15f;
        [SerializeField] float moveSpeed = 10f;

        void Update()
        {
            // 1. Motor가 horizontal, vertical 입력을 직접 받는 코드 또한 작성되어있어, Single Responsibility Principle 또한 어기고 있다.
            // 2. 또한 Input 클래스에서만 rotation과 thurst 값을 수정하기 때문에, AI로부터 입력을 받든, 네트워크에서 입력받을 수도 없다. (Input 클래스에 의존되고 있다)
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
            // Unity가 아닌 환경에선 생성자를 통해서 받는다.
            shipInput = GetComponent<ControllerInput>();
        }

        void Update()
        {
            // 다른 형태로 구현된 ShipInput 클래스를 받아도 이 코드는 작동한다.
            float rotation = shipInput.Rotation;
            float thrust = shipInput.Thrust;

            transform.Rotate(Vector3.up * rotation * Time.deltaTime * turnSpeed);
            transform.position += transform.forward * thrust * Time.deltaTime * moveSpeed;
        }
    }
}

