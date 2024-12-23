using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //Speed of the player
    public float speed = 0;

    // UI text component to display count of "PickUp" objects collected.
    public TextMeshProUGUI countText;
    
    // UI object to display winning text.
    public GameObject winTextObject;

    //Rigid body of the playeer
    private Rigidbody rb;

    // Variable to keep track of collected "PickUp" objects.
    private int count;

    //Movement along x and y axis
    private float movementX;
    private float movementY;

    //Start is called before the first frame update    
    void Start()
    {   //Get and store the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();

        //Initialize count to zero
        count = 0;

        //Update the count display
        SetCountText();

        //Initially set the win text to be inactive
        winTextObject.SetActive(false);

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
    //Update the count text wiwth the current count
    countText.text = "Count: " + count.ToString();

    //Check if the count has reached or exceeded the win condition
    if(count >= 12){

        //Check if the count has reached or exceeded th win condition
        winTextObject.SetActive(true);
    }
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

    //Increment the count of the pickup objects
    count = count + 1;

    //Update display count
    SetCountText();
    }
    
}
    
}
