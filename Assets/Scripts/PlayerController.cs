using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //Speed of the player
    public float speed = 0;

    public TextMeshProUGUI countText;

    //Rigid body of the playeer
    private Rigidbody rb;

    private int count;

    //Movement along x and y axis
    private float movementX;
    private float movementY;

    //Start is called before the first frame update    
    void Start()
    {   //Get and store the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

    }
//Function is called when a move input is detected
void OnMove(InputValue movementValue){
    //Convert the input value into a Vector2 for movement
    Vector2 movementVector = movementValue.Get<Vector2>();

    //Store the x and y components of the movement
    movementX = movementVector.x;
    movementY = movementVector.y;
}

void SetCountText(){
    countText.text = "Count: " + count.ToString();
}
//Fixed Update is called once per fixed frame-rate frame
void FixedUpdate(){
    //Create a 3D movement vecture using the x and y inputs
    Vector3 movement = new Vector3(movementX, 0.0f, movementY);

    //Add force to the Rigidbody to move the player
    rb.AddForce(movement * speed);
}

void OnTriggerEnter(Collider other){

    //Check if the object the player collided with is the "PickUp"
    if(other.gameObject.CompareTag("PickUp")){
    
    //Deactivate the collided object
    other.gameObject.SetActive(false);

    count = count + 1;

    SetCountText();
    }
    
}
    
}
