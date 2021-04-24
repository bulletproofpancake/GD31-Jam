using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boss.Projectiles;
public class Anchor : Projectile
{
    public bool isNotDestructible;
    public float range;
    public LayerMask playerMask;
    private bool isMoving;
    public bool movingForward;
    private float originalHeight;
    
    protected override void Start()
    {
        originalHeight = transform.position.y;
        if(isNotDestructible)
            LoadData(data);
        else
            base.Start();
    }

    protected override void Update()
    {
       Check();
       if (isMoving)
       {
           if(movingForward)
               Move();
           else
           {
               MoveBackwards();
           }
       }
       else
       {
           transform.Translate(Vector3.zero);
       }
    }

    void Check()
    {
        var ray = new Ray(transform.position, _direction);
        Debug.DrawRay(ray.origin,ray.direction*range, Color.green);
        if (Physics.Raycast(ray, out var hit, range, playerMask))
        {
            isMoving = true;
            movingForward = true;
        }
       
    }

    protected override void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            SetStatus();
        }
    }

    void SetStatus()
    {
        if (movingForward)
            movingForward = false;
        else
        {
            movingForward = true;
        }
    }
    
    private void MoveBackwards()
    {
        transform.Translate(-_direction * (_speed * Time.deltaTime));
        if (transform.position.y >= originalHeight)
            isMoving = false;
    }

    protected override void GetDestroyed()
    {
        if(isNotDestructible)
            SetStatus();
    }
}
