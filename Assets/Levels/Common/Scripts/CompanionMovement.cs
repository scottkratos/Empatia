using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement script;
    public float MaxSpeed, move, Distance = 1.8f;
    public Rigidbody2D rb;
    public float JumpForce;
    public bool FacingRight = true;
    private Animator anim;
    private float GroundRadius = 0.2f, BoxMovement;
    private bool Grounded = false, IsJumping = false;
    private Vector3 PlayerPos;
    public Vector3 GotoLoc;
    public bool IsImpulso = false, IsLevering = false, CanMove = true, IsCarring = false, IsFollowing = true, IsDetectingPlataforms = true, CanInteract = false, NearPlayer = false, NearY = false;
    public LayerMask WhatIsGround, WhatIsDanger;
    public Transform CheckGround, NearGroundDetect, FarGroundDetect, WallDetect, HighWallDetect, DangerDetect;
    private RaycastHit2D hit;
    public static CompanionMovement control;

    private void Awake()
    {
        DontDestroy();
    }
    public void DontDestroy()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        script = player.GetComponent<PlayerMovement>();
        MaxSpeed = script.MaxSpeed * 0.75f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), player.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = player.transform.position;
        if (!IsCarring)
        {
            MaxSpeed = script.MaxSpeed * 0.75f;
        }
        else
        {
            if ((script.MaxSpeed * 0.75f) - ((script.MaxSpeed * 0.75f) * BoxMovement) <= 0)
            {
                MaxSpeed = 0;
            }
            else
            {
                MaxSpeed = script.MaxSpeed * 0.75f - ((script.MaxSpeed * 0.75f) * BoxMovement);
            }
        }
    }
    public void CarringSpeed(float value)
    {
        value *= 0.50f;
        BoxMovement = value;
    }
    private void FixedUpdate()
    {
        if (IsFollowing)
        {
            move = script.move;
            Follow();
            if (!IsCarring)
            {
                DetectPlataforms();
            }
            if (PlayerPos.x - this.transform.position.x > 0 && !FacingRight)
            {
                Flip();
            }
            else if (PlayerPos.x - this.transform.position.x < 0 && FacingRight)
            {
                Flip();
            }
        }
        else
        {
            GotoLocation();
            if (!IsCarring)
            {
                DetectPlataforms();
            }
            if (GotoLoc.x - this.transform.position.x > 0 && !FacingRight)
            {
                Flip();
            }
            else if (GotoLoc.x - this.transform.position.x < 0 && FacingRight)
            {
                Flip();
            }
        }
        Grounded = Physics2D.OverlapCircle(CheckGround.position, GroundRadius, WhatIsGround);
        SetAnims();
    }

    public void Flip()
    {
        if (Grounded && !NearPlayer)
        {
            if (FacingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            FacingRight = !FacingRight;
            RaycastHit2D NearGroundInfo = Physics2D.Raycast(NearGroundDetect.position, Vector2.down, 10);
            RaycastHit2D FarGroundInfo = Physics2D.Raycast(FarGroundDetect.position, Vector2.down, 10);
            RaycastHit2D FarGroundDanger = Physics2D.Raycast(FarGroundDetect.position, Vector2.down, 10, WhatIsDanger);
            if (FarGroundDanger == false)
            {
                if (NearGroundInfo.collider == false && FarGroundInfo.collider == false)
                {
                    CanMove = false;
                }
                else
                {
                    CanMove = true;
                }
            }
            else
            {
                if (NearGroundInfo.collider == true)
                {
                    CanMove = true;
                }
                else
                {
                    CanMove = false;
                }
            }
        }
    }

    public void Jumpo()
    {
        if (!IsJumping && !IsCarring)
        {
            IsJumping = true;
            anim.SetBool("Grounded", false);
            Grounded = false;
            rb.velocity = new Vector2(rb.velocity.x * 2f, JumpForce);
        }
    }

    private void Follow()
    {
        if (Grounded) {
            IsJumping = false;
            if (PlayerPos.x - this.transform.position.x < Distance && PlayerPos.x - this.transform.position.x > -Distance)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                NearPlayer = true;
                if (PlayerPos.y - this.transform.position.y < Distance && PlayerPos.y - this.transform.position.y > -Distance)
                {
                    NearY = true;
                }
                else
                {
                    NearY = false;
                }
            }
            else
            {
                NearPlayer = false;
                if (PlayerPos.y - this.transform.position.y < Distance && PlayerPos.y - this.transform.position.y > -Distance)
                {
                    NearY = true;
                }
                else
                {
                    NearY = false;
                }
                if (CanMove)
                {
                    if (FacingRight)
                    {
                        rb.velocity = new Vector2(1 * MaxSpeed, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(-1 * MaxSpeed, rb.velocity.y);
                    }
                }
            }
        }
        else
        {
            if (FacingRight)
            {
                rb.velocity = new Vector2(1 * MaxSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-1 * MaxSpeed, rb.velocity.y);
            }
        }
    }

    private void DetectPlataforms()
    {
        RaycastHit2D NearGroundInfo = Physics2D.Raycast(NearGroundDetect.position, Vector2.down, 10, WhatIsGround);
        RaycastHit2D NearGroundDanger = Physics2D.Raycast(DangerDetect.position, Vector2.down, 10, WhatIsDanger);
        RaycastHit2D FarGroundDanger = Physics2D.Raycast(FarGroundDetect.position, Vector2.down, 10, WhatIsDanger);
        RaycastHit2D FarGroundInfo = Physics2D.Raycast(FarGroundDetect.position, Vector2.down, 10, WhatIsGround);
        if (FarGroundDanger.distance < FarGroundInfo.distance)
        {
            if (NearGroundInfo.collider == false)
            {
                if (FarGroundInfo.collider == false)
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    CanMove = false;
                }
                else
                {
                    if (!NearPlayer)
                    {
                        Jumpo();
                    }
                }
            }
            else
            {
                if (NearGroundDanger.collider == true)
                {
                    if (FarGroundDanger.collider == false)
                    {
                        if (FarGroundInfo.collider == false)
                        {
                            rb.velocity = new Vector2(0, rb.velocity.y);
                            CanMove = false;
                        }
                        else
                        {
                            if (!NearPlayer)
                            {
                                Jumpo();
                            }
                        }
                    }
                    else
                    {
                        rb.velocity = new Vector2(0, rb.velocity.y);
                        CanMove = false;
                    }
                }
            }
        }
        RaycastHit2D TileAhead = Physics2D.Raycast(WallDetect.position, Vector2.left, 0.1f, WhatIsGround);
        RaycastHit2D HighTileAhead = Physics2D.Raycast(HighWallDetect.position, Vector2.left, 0.1f, WhatIsGround);
        if (TileAhead.collider)
        {
            if (!HighTileAhead.collider) {
                if (IsDetectingPlataforms)
                {
                    Jumpo();
                }
            }
        }
    }

    private void GotoLocation()
    {
        if (Grounded)
        {
            IsJumping = false;
            if (GotoLoc.x - this.transform.position.x < Distance && GotoLoc.x - this.transform.position.x > -Distance)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                NearPlayer = true;
            }
            else
            {
                NearPlayer = false;
                if (CanMove)
                {
                    if (FacingRight)
                    {
                        rb.velocity = new Vector2(1 * MaxSpeed, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(-1 * MaxSpeed, rb.velocity.y);
                    }
                }
            }
        }
        else
        {
            if (FacingRight)
            {
                rb.velocity = new Vector2(1 * MaxSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-1 * MaxSpeed, rb.velocity.y);
            }
        }
    }
    public void ResetAnim()
    {
        CanMove = true;
        IsLevering = false;
    }
    private void SetAnims()
    {
        anim.SetBool("Grounded", Grounded);
        anim.SetFloat("vSpeed", rb.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Lever", IsLevering);
        anim.SetFloat("NoAbsSpeed", Mathf.Clamp(rb.velocity.x * -1, -1, 1));
        anim.SetBool("IsCarring", IsCarring);
        anim.SetBool("Impulse", IsImpulso);
    }
}
