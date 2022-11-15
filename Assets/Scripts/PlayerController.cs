using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public const string HORIZONTAL = "Horizontal", VERTICAL = "Vertical";

    public static bool playerCreated;

    public Vector2 lastDirection;

    public string nextUuid;

    private float inputTol = 0.2f;
    private float xInput, yInput;

    private bool isWalking;
    private bool isAttacking;

    public bool canMove = true;

    private Animator _animator;

    [SerializeField] private float attackTime;
    private float attackTimeCounter;

    private Rigidbody2D _playerRigidbody;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        playerCreated = true;
        lastDirection = Vector2.down;
    }
    private void Update()
    {
        xInput = Input.GetAxisRaw(HORIZONTAL);
        yInput = Input.GetAxisRaw(VERTICAL);
        isWalking = false;

        if (!canMove)
        {
            return;
        }

        if (isAttacking)
        {
            attackTimeCounter -= Time.deltaTime;
            if(attackTimeCounter < 0)
            {
                isAttacking = false;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
            attackTimeCounter = attackTime;
        }
        else
        {
            Movement();
        }
    }

    private void LateUpdate()
    {
        _animator.SetFloat(HORIZONTAL, xInput);
        _animator.SetFloat(VERTICAL, yInput);
        _animator.SetFloat("LastHorizontal", lastDirection.x);
        _animator.SetFloat("LastVertical", lastDirection.y);
        _animator.SetBool("IsWalking", isWalking);
        _animator.SetBool("IsAttacking", isAttacking);

        if (!isWalking || isAttacking)
        {
            _playerRigidbody.velocity = Vector2.zero;
        }
    }

    private void Movement()
    {
        if (Mathf.Abs(xInput) > inputTol)
        {
            _playerRigidbody.velocity = new Vector2(xInput * speed, 0);
            isWalking = true;
            lastDirection = new Vector2(xInput, 0);
        }

        if (Mathf.Abs(yInput) > inputTol)
        {
            _playerRigidbody.velocity = new Vector2(0, yInput * speed);
            isWalking = true;
            lastDirection = new Vector2(0, yInput);
        }
    }
}
