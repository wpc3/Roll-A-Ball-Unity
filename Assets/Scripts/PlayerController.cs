using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponet<Rigidbody>();
    }
void OnMove(InputValue movementValue){
    //Function body
    Vector2 movementVector = movementValue.Get<Vector2>();
}
void FixedUpdate(){
    
}
    
}
