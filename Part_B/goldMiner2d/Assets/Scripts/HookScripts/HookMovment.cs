using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HookMovement : MonoBehaviour
{
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
            Vector3 pos = transform.position;

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

            ropeRenderer.RenderLine(pos, true);
        }
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

    // Move the hook upward when this method is called
    public void MoveHookUp()
    {
        StartCoroutine(MoveHookUpCoroutine());
    }

    private IEnumerator MoveHookUpCoroutine()
    {
        canRotate = false;
        moveDown = false;

        while (transform.position.y < inital_Y)
        {
            Vector3 pos = transform.position;
            pos += transform.up * Time.deltaTime * moveSpeed;
            transform.position = pos;

            ropeRenderer.RenderLine(pos, true);

            yield return null;
        }

        canRotate = true;
        moveSpeed = inital_Move_Speed;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        getInput();
        moveRope();

    }
}
