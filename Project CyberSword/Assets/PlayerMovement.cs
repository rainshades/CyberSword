using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalEntity : MonoBehaviour
{
    protected CharacterController Controller;

    protected static float Gravity = 1;

    protected Vector3 GravityForce = new Vector3(0, Gravity);

    public virtual void FixedUpdate()
    {
        if (!Controller.isGrounded)
        {
            Controller.Move(GravityForce * Time.deltaTime * -1);
        }
        else
        {
            GravityForce.y = Gravity;
        }
    }
}

public class PlayerMovement : GravitationalEntity
{
    PlayerControls input;
    Vector3 MovementVector;

    [SerializeField]
    float Speed;

    float sprintSpeed;
    float speedHolder;

    [SerializeField]
    float JumpForce;
    [SerializeField]
    float JumpTime; 

    public bool InBattle { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        Controller = GetComponent<CharacterController>(); 

        input = new PlayerControls();

        input.Movement.Move.performed += Move_performed;
        input.Movement.Move.canceled += Move_canceled;

        input.Movement.Sprint.performed += Sprint_performed;
        input.Movement.Jump.performed += Jump_performed;

        sprintSpeed = Speed * 1.5f;
        speedHolder = Speed;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        StartCoroutine(JumpAction(JumpTime)); 
    }

    IEnumerator JumpAction(float time)
    {
        //Debug.Log("Jump Started");
        GravityForce *= -JumpForce; 
        yield return new WaitForSecondsRealtime(time);
        GravityForce.y = Gravity;
        //Debug.Log("Jump Ended");
    }

    private void Sprint_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Speed = sprintSpeed; 
    }

    private void Move_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        MovementVector = Vector3.zero;
        Speed = speedHolder; 
    }

    private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Vector3 MovementForce = obj.ReadValue<Vector2>();
        if (!InBattle)
        {
            if (obj.ReadValue<Vector2>().x > 0)
            {
                transform.eulerAngles = new Vector3(0, 90);
            }
            else if (obj.ReadValue<Vector2>().y > 0)
            {
                transform.eulerAngles = Vector3.zero;
            }
            else if (obj.ReadValue<Vector2>().y < 0)
            {
                transform.eulerAngles = new Vector3(0, 180);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -90);
            }
            //Debug.Log(MovementForce); 
        }
        MovementVector = new Vector3(MovementForce.x, 
            0, MovementForce.y); 
    }

    public override void FixedUpdate()
    {
        if (!InBattle)
        {
            base.FixedUpdate();
            Controller.Move(MovementVector * Time.deltaTime * Speed);
        }
    }

    private void OnEnable()
    {
        input.Enable(); 
    }

    private void OnDisable()
    {
        input.Disable(); 
    }
}
