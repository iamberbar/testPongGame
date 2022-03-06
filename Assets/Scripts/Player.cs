using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public float speed = 30f;
    public float maxBounceAngle = 75f;
    private Vector3 offset;
    private Vector3 screenPoint;
    private Vector3 lastDragPosition = Vector3.zero;
    private void Awake()
    {

        this.rigidbody = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.direction = Vector2.right;
        }
        else { this.direction = Vector2.zero; }




    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, this.transform.position.y, this.transform.position.z));

    }


    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, this.transform.position.y, this.transform.position.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;


        if (lastDragPosition != cursorPosition)
        {
            lastDragPosition = cursorPosition;
            //this.transform.position = cursorPosition;
            if (this.transform.position.x - cursorPosition.x > 0)
            {
                this.direction = Vector2.left;

            }
            else if (this.transform.position.x - cursorPosition.x < 0)
            {
                this.direction = Vector2.right;
            }
            FixedUpdateOnDrag();

        }
    }

    private void FixedUpdateOnDrag()
    {
        if (this.direction != Vector2.zero)
        {
            this.rigidbody.AddForce(this.direction * (this.speed * 1.5f));
        }

    }


    private void FixedUpdate()
    {
        if (this.direction != Vector2.zero)
        {
            this.rigidbody.AddForce(this.direction * this.speed);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector3 playerPosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;
            float offset = playerPosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;
            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            float bounceAngle = (offset / width) * this.maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;

        }
    }
    public void ResetPosition()
    {
        this.transform.position = new Vector2(0f, this.transform.position.y);
        this.rigidbody.velocity = Vector2.zero;
    }
}
