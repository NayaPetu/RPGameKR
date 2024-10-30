////Код по новой системе взаимодействие с предметом
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;


//public class Player : MonoBehaviour
//{
//    private int _strenght;
//    private int _health;

//    public InputAction _interactionAction;
//    private bool _isPressed = false;

//    // Start is called before the first frame update
//    void Start()
//    {
//        _interactionAction = InputSystem.actions.FindAction("Interaction");
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
//        Debug.DrawRay(ray.origin, ray.direction * 20f, Color.red);

//        Vector3 moveValue = _interactionAction.ReadValue<Vector2>();

//        if (_interactionAction.IsPressed())
//        {
//            if (!_isPressed)
//            {
//                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//                if (Physics.Raycast(ray, 100))
//                {
//                    //rb.isKinematic = true;
//                    //rb.MovePosition(pos.position); //Ошибка не определят pos
//                }

//                _isPressed = true;
//            }
//        }
//        else
//        {
//            _isPressed = false;
//        }

//    }
//}


//Код по старой системе взаимодействие с предметом
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //private int _strenght;
    //private int _health;

    public InputAction _interactionAction;
    private bool _isPressed = false;
    [SerializeField] private Slider slider;

    public Slider healthSliderP;
    public Transform target;
    public GameObject batt;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); //Красный луч видно fot exampol
        //Debug.DrawRay(ray.origin, ray.direction * 20f, Color.red);



        if (Input.GetButtonDown("Fire1"))
        {
            if (!_isPressed)
            {
                //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    //rb.isKinematic = true;   Наверное сдесь прописать захват предметов
                    //rb.MovePosition(pos.position); //Ошибка не определят pos


                    if (hit.collider.gameObject.tag == "Baat")
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    healthSliderP.value = healthSliderP.value + 1;
                }

                _isPressed = true;
            }

            else
            {
                _isPressed = false;
            }
        }
    }
}



