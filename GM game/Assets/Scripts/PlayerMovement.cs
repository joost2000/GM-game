using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum State
    {
        normal,
        rolling
    }

    private State state;
    private float _rollSpeed;
    [SerializeField] private float moveSpeed = 5f;

    Rigidbody2D rb;
    Animator animator;

    Vector2 movement;
    private Vector2 oldPosition;

    bool slide = false;

    private void Awake()
    {
        state = State.normal;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rollSpeed = 20f;
            slide = true;
            state = State.rolling;
        }


        switch (state)
        {
            case State.normal:
                slide = false;
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
                break;
            case State.rolling:
                float rollSpeedDropMultiplier = 5f;
                _rollSpeed -= _rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

                float rollSpeedMinimum = 5f;
                if (_rollSpeed < rollSpeedMinimum)
                {
                    state = State.normal;
                }
                break;
        }
        if (movement.x != 0f || movement.y != 0)
        {
            oldPosition = movement;
        }

        animator.SetBool("isRolling", slide);
        animator.SetFloat("HorizontalSpeed", oldPosition.x);
        animator.SetFloat("VerticalSpeed", oldPosition.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case State.normal:
                rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
                break;
            case State.rolling:
                rb.velocity = movement.normalized * _rollSpeed;
                break;
        }

    }
}
