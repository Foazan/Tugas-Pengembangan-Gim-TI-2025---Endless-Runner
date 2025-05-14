using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float _jumpForce = 10f;
    [SerializeField]
    private LayerMask _groundLayer;
    [SerializeField]
    private Transform _feetPos;
    [SerializeField]
    private float _groundDistance = 0.25f;
    [SerializeField]
    private float _jumpTime = 0.3f;
    [SerializeField] 
    private Animator animator;

    private bool _isGround = false;
    private bool _isJumping = false;
    private float _jumpTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.onPlay.AddListener(ActivatePlayer);
    }

    // Update is called once per frame
    void Update()
    {
        _isGround = Physics2D.OverlapCircle(_feetPos.position, _groundDistance, _groundLayer);

        if (_isGround && Input.GetButtonDown("Jump"))
        {
            _isJumping = true;
            rb.linearVelocity = Vector2.up * _jumpForce;
            animator.Play("Jump");
        }

        if (_isJumping && Input.GetButton("Jump"))
        {
            if (_jumpTimer < _jumpTime)
            {
                rb.linearVelocity = Vector2.up * _jumpForce;
                _jumpTimer += Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            _isJumping = false;
            _jumpTimer = 0;
        }

        if (_isGround && !_isJumping)
        {
            animator.Play("Run");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
            GameManager.instance.GameOver();
        }
    }

    private void ActivatePlayer()
    {
        this.gameObject.SetActive(true);
    }
}
