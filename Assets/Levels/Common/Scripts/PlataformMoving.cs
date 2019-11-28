using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMoving : InteractBase
{
    
    public int HorizontalTiles, VerticalTiles;
    public bool IsX, IsPositive, IsLeverBased = false;
    public float Speed = 5, WaitSeconds;
    public Material On, Off;
    private float Delay;
    private bool Negative, IsLeverActive;
    private float x, y;
    private Vector3 poosition;
    
    // Start is called before the first frame update
    private void Start()
    {
        poosition.x = transform.position.x;
        poosition.y = transform.position.y;
        poosition.z = transform.position.z;
        UpdatePosition();
        x += HorizontalTiles;
        y += VerticalTiles;
        if (!IsLeverBased)
        {
            MovePositive();
        }
        else
        {
            Negative = !IsPositive;
            Delay = WaitSeconds;
            IsLeverActive = false;
        }
    }

    private void Update()
    {
        Material[] matarray = new Material[1];
        if (IsLeverBased)
        {
            if (IsLeverActive)
            {
                if (!Negative)
                {
                    MovePositiveByLever();
                }
                else
                {
                    MoveNegativeByLever();
                }
                matarray[0] = On;
            }
            else
            {
                matarray[0] = Off;
            }
        }
        else
        {
            matarray[0] = On;
        }
        GetComponent<Renderer>().materials = matarray;
    }

    private void ChangeInstance()
    {
        if (Delay > 0)
        {
            Delay -= Time.deltaTime;
        }
        else
        {
            Negative = !Negative;
            Delay = WaitSeconds;
            if (Negative)
            {
                x -= HorizontalTiles;
                y -= VerticalTiles;
            }
            else
            {
                x += HorizontalTiles;
                y += VerticalTiles;
            }
        }
    }

    public override void Activate()
    {
        IsLeverActive = !IsLeverActive;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
        if (collision.tag == "David")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.SetParent(null);
            PlayerMovement.control = null;
            collision.GetComponent<PlayerMovement>().DontDestroy();
        }
        if (collision.tag == "David")
        {
            collision.transform.SetParent(null);
            CompanionMovement.control = null;
            collision.GetComponent<CompanionMovement>().DontDestroy();
        }
    }

    private void UpdatePosition()
    {
        x = transform.position.x;
        y = transform.position.y;
    }
    private void MovePositive()
    {
        if (IsPositive)
        {
            if (x <= poosition.x && IsX)
            {
                UpdatePosition();
                x -= HorizontalTiles;
                y -= VerticalTiles;
                Invoke("MoveNegative", WaitSeconds);
            }
            else
            {
                if (IsX)
                {
                    poosition.x += 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                    Invoke("MovePositive", 0.03f);
                }
            }
            if (y <= poosition.y && !IsX)
            {
                UpdatePosition();
                x -= HorizontalTiles;
                y -= VerticalTiles;
                Invoke("MoveNegative", WaitSeconds);
            }
            else
            {
                if (!IsX)
                {
                    poosition.y += 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                    Invoke("MovePositive", 0.03f);
                }
            }
        }
        else
        {
            if (x >= poosition.x && IsX)
            {
                UpdatePosition();
                x -= HorizontalTiles;
                y -= VerticalTiles;
                Invoke("MoveNegative", WaitSeconds);
            }
            else
            {
                if (IsX)
                {
                    poosition.x -= 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                    Invoke("MovePositive", 0.03f);
                }
            }
            if (y >= poosition.y && !IsX)
            {
                UpdatePosition();
                x -= HorizontalTiles;
                y -= VerticalTiles;
                Invoke("MoveNegative", WaitSeconds);
            }
            else
            {
                if (!IsX)
                {
                    poosition.y -= 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                    Invoke("MovePositive", 0.03f);
                }
            }
        }
    }

    private void MoveNegative()
    {
        if (IsPositive)
        {
            if (x >= poosition.x && IsX)
            {
                UpdatePosition();
                x += HorizontalTiles;
                y += VerticalTiles;
                Invoke("MovePositive", WaitSeconds);
            }
            else
            {
                if (IsX)
                {
                    poosition.x -= 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                    Invoke("MoveNegative", 0.03f);
                }
            }
            if (y >= poosition.y && !IsX)
            {
                UpdatePosition();
                x += HorizontalTiles;
                y += VerticalTiles;
                Invoke("MovePositive", WaitSeconds);
            }
            else
            {
                if (!IsX)
                {
                    poosition.y -= 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                    Invoke("MoveNegative", 0.03f);
                }
            }
        } else
        {
            if (x <= poosition.x && IsX)
            {
                UpdatePosition();
                x += HorizontalTiles;
                y += VerticalTiles;
                Invoke("MovePositive", WaitSeconds);
            }
            else
            {
                if (IsX)
                {
                    poosition.x += 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                    Invoke("MoveNegative", 0.03f);
                }
            }
            if (y <= poosition.y && !IsX)
            {
                UpdatePosition();
                x += HorizontalTiles;
                y += VerticalTiles;
                Invoke("MovePositive", WaitSeconds);
            }
            else
            {
                if (!IsX)
                {
                    poosition.y += 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                    Invoke("MoveNegative", 0.03f);
                }
            }
        }
    }

    private void MovePositiveByLever()
    {
        if (IsPositive)
        {
            if (x <= poosition.x && IsX)
            {
                UpdatePosition();
                ChangeInstance();
            }
            else
            {
                if (IsX)
                {
                    poosition.x += 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                }
            }
            if (y <= poosition.y && !IsX)
            {
                UpdatePosition();
                ChangeInstance();
            }
            else
            {
                if (!IsX)
                {
                    poosition.y += 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                }
            }
        }
        else
        {
            if (x >= poosition.x && IsX)
            {
                UpdatePosition();
                ChangeInstance();
            }
            else
            {
                if (IsX)
                {
                    poosition.x -= 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                }
            }
            if (y >= poosition.y && !IsX)
            {
                UpdatePosition();
                ChangeInstance();
            }
            else
            {
                if (!IsX)
                {
                    poosition.y -= 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                }
            }
        }
    }

    private void MoveNegativeByLever ()
    {
        if (IsPositive)
        {
            if (x >= poosition.x && IsX)
            {
                UpdatePosition();
                ChangeInstance();
            }
            else
            {
                if (IsX)
                {
                    poosition.x -= 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                }
            }
            if (y >= poosition.y && !IsX)
            {
                UpdatePosition();
                ChangeInstance();
            }
            else
            {
                if (!IsX)
                {
                    poosition.y -= 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                }
            }
        }
        else
        {
            if (x <= poosition.x && IsX)
            {
                UpdatePosition();
                ChangeInstance();
            }
            else
            {
                if (IsX)
                {
                    poosition.x += 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                }
            }
            if (y <= poosition.y && !IsX)
            {
                UpdatePosition();
                ChangeInstance();
            }
            else
            {
                if (!IsX)
                {
                    poosition.y += 0.01f * Speed;
                    transform.position = new Vector2(poosition.x, poosition.y);
                }
            }
        }
    }
}
