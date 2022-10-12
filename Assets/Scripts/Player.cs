using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashAnimation))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private TMP_Text _walletView;

    private bool _isFacingRight = true;
    private bool _isGround;
    private int _wallet = 0;

    private HashAnimation _hashAnimation;
    private Ground _ground;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _hashAnimation = GetComponent<HashAnimation>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ground>())
            _isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ground>())
            _isGround = false;
    }

    public void ApplyCoins(int money)
    {
        _wallet += money;
        _walletView.text = _wallet.ToString();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            _animator.SetTrigger(_hashAnimation.Jump);
        }
    }

    private void Move()
    {
        float move = Input.GetAxis("Horizontal");

        _rigidbody2D.velocity = new Vector2(move * _speed, _rigidbody2D.velocity.y);
        _animator.SetFloat(_hashAnimation.Speed, Mathf.Abs(move));

        if (move > 0 && !_isFacingRight)
            FlipOver();
        else if (move < 0 && _isFacingRight)
            FlipOver();
    }

    public void FlipOver()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
