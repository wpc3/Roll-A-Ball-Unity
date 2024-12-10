using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
void OnMove(InputValue movementValue){
    //Function body
    Vector2 movementVector = movementValue.Get<Vector2>();

    movementX = movementVector.x;
    movementY = movementVector.y;
}
void FixedUpdate(){
    Vector3 movement = new Vector3(movementX, 0.0f, movementY);

    rb.AddForce(movement);
}
    
}
