using Extensions;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    public float Acceleration = 5f;
    public float Deceleration = 5f;
    public float MaxSpeed = 5f;

    private float horizontalInput;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start ()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.horizontalInput = InputManager.GetLeftThumbstick().x;
	}

    private void FixedUpdate()
    {
        this.ProcessInput();
        
    }

    private void ProcessInput()
    {
        if (Mathf.Abs(this.horizontalInput) > 0d)
        {
            this.rb.AddForce(new Vector2(this.horizontalInput * this.Acceleration, 0f));

            if (Mathf.Abs(this.rb.velocity.x) > this.MaxSpeed)
            {
                var xVelocity = this.rb.velocity.x > 0 ? this.MaxSpeed : -this.MaxSpeed;
                this.rb.velocity = new Vector2(xVelocity, this.rb.velocity.y);
            }
        }
        else
        {
            this.rb.DecelerateX(this.Deceleration);
        }
    }
}
