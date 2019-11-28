using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : InteractBase
{
    public float HorizontalTiles, VerticalTiles, Speed;
    private int PositiveX, PositiveY;
    private Vector3 poosition;

    public override void Activate()
    {
        poosition.x = transform.position.x;
        poosition.y = transform.position.y;
        poosition.z = transform.position.z;

        if (HorizontalTiles != 0)
        {
            if (HorizontalTiles > 0)
            {
                PositiveX = 1;
            }
            else
            {
                PositiveX = -1;
            }
        }
        else
        {
            PositiveX = 0;
        }
        if (VerticalTiles != 0)
        {
            if (VerticalTiles > 0)
            {
                PositiveY = 1;
            }
            else
            {
                PositiveY = -1;
            }
        }
        else
        {
            PositiveY = 0;
        }
        Move();
    }

    private void Move()
    {
        if (Speed != 0)
        {
            if (PositiveX != 0)
            {
                transform.position = new Vector3(transform.position.x + PositiveX * 0.01f * Speed, transform.position.y, 2);
            }
            if (PositiveY != 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + PositiveY * 0.01f * Speed, 2);
            }
        }
        if (PositiveX > 0)
        {
            if (transform.position.x < poosition.x + HorizontalTiles)
            {
                Invoke("Move", 0.03f);
            }
        }
        else
        {
            if (transform.position.x > poosition.x + HorizontalTiles)
            {
                Invoke("Move", 0.03f);
            }
        }
        if (PositiveY > 0)
        {
            if (transform.position.y < poosition.y + VerticalTiles)
            {
                Invoke("Move", 0.03f);
            }
        }
        else
        {
            if (transform.position.y > poosition.y + VerticalTiles)
            {
                Invoke("Move", 0.03f);
            }
        }
    }
}
