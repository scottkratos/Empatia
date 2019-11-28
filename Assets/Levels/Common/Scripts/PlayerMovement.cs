
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Shoot, Targets;
    public float MaxSpeed = 5f;
    public float JumpForce;
    public float move;
    public bool FacingRight = true;
    private float GroundRadius = 0.2f, BoxMovement;
    private bool Grounded = false, fade = false;
    public Transform CheckGround;
    public Vector3 CheckIfIsMoving, LRot, RRot, PixelScale;
    public Rigidbody2D rb;
    private Animator anim;
    public LayerMask WhatIsGround;
    public int Level;
    private GameObject david;
    private CompanionMovement script;
    public bool IsGod = false, IsImpulso = false, IsLevering = false, CanMove = true, IsMoving = false, IsCarring = false, CanInteract = false, IsInteracting = false, HaveObjective = false, IsAlive = true, IsInCutscene = false, IsAiming = false, HaveCompanion = false, IsInLadder = false;
    public static PlayerMovement control;
    public Vector2 offset;
    private Vector3 screenPoint;
    private Vector3 mouse;
    private Vector3 CamMed;
    public AudioSource Gun;

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
    public void AddCompanion(bool add)
    {
        HaveCompanion = add;
        if (GameObject.FindWithTag("David") != null)
        {
            david = GameObject.FindWithTag("David");
            script = david.GetComponent<CompanionMovement>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("David") != null)
        {
            david = GameObject.FindWithTag("David");
            script = david.GetComponent<CompanionMovement>();
        }
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        CheckIfIsMoving = transform.position;
        GameObject.Find("IK/LArm IK").transform.position = LRot;
        GameObject.Find("IK/RArm IK").transform.position = RRot;
        BackToTheFuture();
    }

    // Update is called once per frame
    void Update()
    {
        PixelScale = Camera.main.WorldToScreenPoint(this.transform.position);
        mouse = Input.mousePosition;
        screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        if (offset.x > 65)
        {
            offset.x = 65;
        }
        else if (offset.x < -65)
        {
            offset.x = -65;
        }
        if (offset.y > 160)
        {
            offset.y = 160;
        }
        else if (offset.y < -14)
        {
            offset.y = -14;
        }
        if (Input.GetButtonDown("GodMode"))
        {
            print(IsGod);
            IsGod = !IsGod;
        }
        if (IsAlive && !IsAiming && !IsInLadder && CanMove)
        {
            RaycastHit2D GroundRay = Physics2D.Raycast(transform.position, Vector2.down, 100, WhatIsGround);
            if (GroundRay.distance < 3)
            {
                anim.SetFloat("vSpeed", GroundRay.distance);
            }
            else
            {
                anim.SetFloat("vSpeed", 3);
            }
            move = Input.GetAxis("Horizontal");
        }
        if (IsInLadder && CanMove)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * MaxSpeed);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
        try
        {
            if (HaveObjective)
            {
                script.GetComponent<CompanionMovement>().Distance = 0.5f;
            }
            else
            {
                script.GetComponent<CompanionMovement>().Distance = 1.8f;
            }
        }
        catch
        {
        }
        if (!IsCarring)
        {
            MaxSpeed = 5f;
        }
        else
        {
            MaxSpeed = 5 - (5 * BoxMovement);
        }
        if (CheckIfIsMoving == transform.position)
        {
            IsMoving = false;
        }
        else
        {
            IsMoving = true;
        }
        CheckIfIsMoving = transform.position;
        if (Grounded && Input.GetButtonDown("Jump") && IsAlive && !IsAiming && CanMove)
        {
            IsInLadder = false;
            anim.SetBool("Ground", false);
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
        if (Input.GetButtonDown("Interact") && !IsAiming && CanMove)
        {
            if (IsAlive)
            {
                if (!CanInteract)
                {
                    IsInteracting = false;
                    if (script != null)
                    {
                        if (script.NearPlayer)
                        {
                            if (script.NearY)
                            {
                                if (HaveObjective)
                                {
                                    script.CanInteract = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (HaveObjective)
                    {
                        IsInteracting = !IsInteracting;
                    }
                    else
                    {
                        IsInteracting = true;
                    }
                }
            }
        }
        if (Input.GetButtonDown("Fire1") && IsAlive && IsAiming && !IsInLadder && CanMove)
        {
            Vector2 direction = new Vector2((Input.mousePosition.x - Camera.main.pixelWidth / 2) - (Camera.main.WorldToScreenPoint(transform.position).x - Camera.main.WorldToScreenPoint(Targets.transform.position).x), ((Input.mousePosition.y - Camera.main.pixelHeight / 2) + 50/*110*/) - (Camera.main.WorldToScreenPoint(transform.position).y - Camera.main.WorldToScreenPoint(Targets.transform.position).y));
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            GameObject projectile = (GameObject)Instantiate(Shoot, GameObject.Find("Hips/Spine1/Spine2/Spine3/LOmbro/Cotovelo/Gun/GunPlaceholder").transform.position, rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectile.GetComponent<shoot>().velocidade;
            Gun.Play();
        }
        if (Input.GetButtonDown("Fire2") && Grounded && CanMove)
        {
            IsAiming = true;
            move = 0;
            anim.SetFloat("Speed", 0);
            GameObject.Find("Hips/Spine1/Spine2/Spine3/LOmbro/Cotovelo/Gun").GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            IsAiming = false;
            GameObject.Find("IK/LArm IK").transform.position = new Vector3(LRot.x, LRot.y, LRot.z);
            GameObject.Find("IK/RArm IK").transform.position = new Vector3(RRot.x, RRot.y, RRot.z);
            GameObject.Find("Hips/Spine1/Spine2/Spine3/LOmbro/Cotovelo/Gun").GetComponent<SpriteRenderer>().enabled = false;
        }
        if (IsAiming && CanMove)
        {
            if (Input.mousePosition.x < PixelScale.x)
            {
                if (FacingRight)
                {
                    Flip();
                }
            }
            else
            {
                if (!FacingRight)
                {
                    Flip();
                }
            }
        }
        SetAnims();
    }
    private void LateUpdate()
    {
        if (IsAiming && CanMove)
        {
            GameObject.Find("IK/LArm IK").transform.position = new Vector3(this.gameObject.transform.position.x + (offset.x / 25) * 0.49f, this.gameObject.transform.position.y + (offset.y / 25) * 0.49f, 0);
            if (offset.x < 65 || offset.x > -65)
            {
                GameObject.Find("IK/RArm IK").transform.position = new Vector3(GameObject.Find("IK/LArm IK").transform.position.x, GameObject.Find("IK/LArm IK").transform.position.y, GameObject.Find("IK/LArm IK").transform.position.z);
            }
            if (offset.x >= 65) 
            {
                GameObject.Find("IK/RArm IK").transform.position = new Vector3(this.gameObject.transform.position.x + (65 / 25) * 0.49f - 0.5f, GameObject.Find("IK/LArm IK").transform.position.y, GameObject.Find("IK/LArm IK").transform.position.z);
            }
            if (offset.x <= -65)
            {
                GameObject.Find("IK/RArm IK").transform.position = new Vector3(this.gameObject.transform.position.x + (-65 / 25) * 0.49f + 0.5f, GameObject.Find("IK/LArm IK").transform.position.y, GameObject.Find("IK/LArm IK").transform.position.z);
            }
        }
    }
    public void CarringSpeed(float value)
    {
        value *= 0.20f;
        BoxMovement = value;
    }
    private void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(CheckGround.position, GroundRadius, WhatIsGround);
        rb.velocity = new Vector2(move * MaxSpeed, rb.velocity.y);
        if (IsLevering)
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (move > 0 && !FacingRight)
        {
            Flip();
        }
        else if (move < 0 && FacingRight)
        {
            Flip();
        }
    }

    public void Flip()
    {
        if (!IsCarring)
        {
            if (FacingRight)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            FacingRight = !FacingRight;
        }
    }
    public void Damage()
    {
        if (!IsGod)
        {
            if (transform.parent == null)
            {
                if (fade)
                {
                    ScreenChange.control.ScreenFadeIn();
                }
                IsAlive = false;
                if (script != null)
                {
                    CompanionMovement.control.Distance = 1.8f;
                    CompanionMovement.control.CanMove = true;
                    CompanionMovement.control.IsCarring = false;
                    CompanionMovement.control.IsFollowing = true;
                    CompanionMovement.control.IsDetectingPlataforms = true;
                    CompanionMovement.control.CanInteract = false;
                    CompanionMovement.control.NearPlayer = false;
                    CompanionMovement.control.NearY = false;
                    CompanionMovement.control.transform.SetParent(null);
                }
                IsMoving = false;
                IsCarring = false;
                CanInteract = false;
                IsInteracting = false;
                HaveObjective = false;
                Invoke("CameraFade", 1);
                fade = true;
            }
            else
            {
                transform.SetParent(null);
                if (fade)
                {
                    ScreenChange.control.ScreenFadeIn();
                }
                IsAlive = false;
                if (script != null)
                {
                    CompanionMovement.control.Distance = 1.8f;
                    CompanionMovement.control.CanMove = true;
                    CompanionMovement.control.IsCarring = false;
                    CompanionMovement.control.IsFollowing = true;
                    CompanionMovement.control.IsDetectingPlataforms = true;
                    CompanionMovement.control.CanInteract = false;
                    CompanionMovement.control.NearPlayer = false;
                    CompanionMovement.control.NearY = false;
                    CompanionMovement.control.transform.SetParent(null);
                }
                IsMoving = false;
                IsCarring = false;
                CanInteract = false;
                IsInteracting = false;
                HaveObjective = false;
                Invoke("CameraFade", 1);
                fade = true;
            }
        }
    }
    public void CameraFade()
    {
        SaveSystem.control.Load();
    }
    public void BackToTheFuture()
    {
        if (File.Exists(Application.persistentDataPath + "/playerinfo.scott"))
        {
            Damage();
        }
        else
        {
            ScreenChange.control.ScreenFadeOut();
            fade = true;
        }
    }
    public void ResetAnim()
    {
        IsLevering = false;
        CanMove = true;
    }
    private void SetAnims()
    {
        if (FacingRight)
        {
            anim.SetFloat("NotAbsSpeed", move * MaxSpeed);
        }
        else
        {
            anim.SetFloat("NotAbsSpeed", move * MaxSpeed * -1);
        }
        anim.SetBool("Ground", Grounded);
        anim.SetFloat("Speed", Mathf.Abs(move * MaxSpeed));
        anim.SetBool("Carring", IsCarring);
        anim.SetFloat("W", BoxMovement);
        anim.SetBool("Lever", IsLevering);
        //anim.SetBool("Impulse", IsImpulso);
    }
}
