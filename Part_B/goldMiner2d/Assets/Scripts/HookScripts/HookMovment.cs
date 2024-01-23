using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HookMovment : MonoBehaviour
{
    //rotate hook angles
    [SerializeField] float min_Z = -55f, max_Z = 55f;
    [SerializeField] float rotateSpeed = 5f;
    [SerializeField] float rotate_angle = 5f;
    private bool rotateRight;
    private bool canRotate;
    [SerializeField] float moveSpeed;
    private float inital_Move_Speed;
    [SerializeField] float min_Y = -2.5f;
    [SerializeField] float inital_Y;
    private bool moveDown;
    [SerializeField] protected InputAction hookButton = new InputAction(type: InputActionType.Button);


    private RopeRenderer ropeRenderer;

    private void Awake()
    {
        ropeRenderer = GetComponent<RopeRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        inital_Y = transform.position.y;
        inital_Move_Speed = moveSpeed;
        canRotate = true;

    }
    void Rotate()
    {
        if (!canRotate) return;
        //change rotation sides
        if (rotateRight)
        {
            rotate_angle += rotateSpeed * Time.deltaTime;
        }
        else
        {
            rotate_angle -= rotateSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotate_angle, Vector3.forward);
        if (rotate_angle >= max_Z) rotateRight = false;
        else if (rotate_angle <= min_Z) rotateRight = true;
    }


    void moveRope()
    {
        if (canRotate) return;

        if (!canRotate)
        {
            //SoundManager.instance.RopStretch(True);
            //hook por
            Vector3 pos = transform.position;
            // moves the hook to the object

            if (moveDown)
            {
                pos -= transform.up * Time.deltaTime * moveSpeed;
                Debug.Log("move down ");
            }
            else pos += transform.up * Time.deltaTime * moveSpeed;

            transform.position = pos;

            if (pos.y <= min_Y)
            {
                moveDown = false;
            }
            if (pos.y >= inital_Y)
            {
                canRotate = true;
                moveSpeed = inital_Move_Speed;
            }
            //resets the speed

            ropeRenderer.RenderLine(pos, true);
        }    //SoundManager.instance.RopeStretch(false);


     

    }
    void getInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("button press");
            if (canRotate)
            {
                canRotate = false;
                moveDown = true;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        Rotate();
        getInput();

        //if (hookButton.WasPressedThisFrame())
        //{
        //    Debug.Log("button pree");
        //    if (canRotate)
        //    {
        //        canRotate = false;
        //        moveDown = true;
        //    }
        //}
        moveRope();



    }
}
