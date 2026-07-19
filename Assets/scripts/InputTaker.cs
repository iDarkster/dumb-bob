using UnityEngine;
using UnityEngine.InputSystem;
public class InputTaker : MonoBehaviour
{
    private UniversalInput controls;

    [SerializeField] BobBrain bob;
    void Awake()
    {
        controls = new UniversalInput();
    }
    void OnEnable()
    {
        controls.Allthings.Enable();
        controls.Allthings.Whistle.performed += OnWhistle;
    }
    private void OnWhistle(InputAction.CallbackContext context)
    {
        bob.GotWhistle();
    }
    void OnDisable()
    {   
        controls.Allthings.Whistle.performed -= OnWhistle;
        controls.Allthings.Disable();
    }
    void Update()
    {
        Vector2 vector = controls.Allthings.Move.ReadValue<Vector2>();
        Debug.Log(vector.x);
        Debug.Log(vector.y);
    }














    // //    Start is called once before the first execution of Update after the MonoBehaviour is created
    // private float x = 0;
    // private float y = 0;
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     x = 0;
    //     y = 0;

    //     if (Keyboard.current != null)
    //     {
    //         if (Keyboard.current.wKey.isPressed)
    //         {
    //             y += 1;
    //             Debug.Log("W key pressed");

    //         }
    //         if (Keyboard.current.sKey.isPressed)
    //         {
    //             y -= 1;
    //             Debug.Log("S key pressed");
    //         }
    //         if (Keyboard.current.aKey.isPressed)
    //         {
    //             x -= 1;
    //             Debug.Log("A key pressed");
    //         }
    //         if (Keyboard.current.dKey.isPressed)
    //         {
    //             x += 1;
    //             Debug.Log("d key pressed");
    //         }
    //     }
    //     ;
    // }
}
