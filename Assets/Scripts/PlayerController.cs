using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    private Vector3 xSpeed;
    private Vector3 zSpeed;
    private CharacterController player;
    public Transform Camera;
    public Vector3 moveDirection;
    private GameObject lookingAt;
    private Vector3 lookingAtPoint;
    private string lookingAtText;
    public AudioSource walkAudio;

    public float acceleration;
    public float maxSpeed;
    public float rotateSpeed;
    public float gravityScale;
    private float lastDownSpeed;

    public bool isGroundedLenient;
    public float isGroundedTimer = 0f;
    public float isGroundedTimerMax;
    public GameObject[] spawnPoints;
    public Vector3 spawnVector;

    public Transform pivotTransform;
    public float angleLimit;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        Global.fadeAmount = 2;
        Global.fadingIn = true;

        //Move to SpawnPoint
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject spawnPoint in spawnPoints)
        {
            if (spawnPoint.GetComponent<SpawnPointController>().ComesFrom == Global.exit)
            {
                player.transform.position = spawnPoint.transform.position;
                player.transform.rotation = spawnPoint.transform.rotation;
            }
        }

        spawnVector = transform.position;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (!Pause.isPaused)
        {

            //Interaction
            GetLookingAt();
            GameObject.Find("InteractMessage").GetComponent<CanvasGroup>().alpha = 0.0f;
            if (lookingAt != null)
            {
                if (lookingAt.tag == "Interact")
                {
                    lookingAtText = lookingAt.GetComponent<Interaction>().OnLookAt();
                    GameObject.Find("InteractMessage").GetComponent<CanvasGroup>().alpha = 1.0f;
                    GameObject.Find("InteractText").GetComponent<TMPro.TextMeshProUGUI>().text = lookingAtText;
                    if (Input.GetButtonDown("CROSS"))
                    {
                        lookingAt.GetComponent<Interaction>().OnInteract();
                    }
                }
                else if (lookingAt.tag == "LookAt")
                {
                    lookingAt.GetComponent<Interaction>().OnLookAt();
                }
            }


            //Rotation Input
            /*
            if (Input.GetButton("L2") ^ Input.GetButton("R2"))
            {
                if (Input.GetButton("L2"))
                {
                    player.transform.Rotate(new Vector3(0, -rotateSpeed, 0) * Time.deltaTime);
                }
                else if (Input.GetButton("R2"))
                {
                    player.transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
                }
            }
            */

            if (Input.GetAxis("MouseX") != 0f) { player.transform.Rotate(new Vector3(0, Input.GetAxis("MouseX") * (rotateSpeed / 10), 0) * Time.deltaTime); }
            if (Input.GetAxis("MouseY") != 0f) {
                pivotTransform.Rotate(new Vector3(Input.GetAxis("MouseY") * (rotateSpeed / 10) * Time.deltaTime, 0, 0));


                
                if (pivotTransform.rotation.eulerAngles.x > angleLimit && pivotTransform.rotation.eulerAngles.x < 180)
                {
                    
                    pivotTransform.localEulerAngles = new Vector3(angleLimit, 0, 0);
                }

                if (pivotTransform.rotation.eulerAngles.x < 360 - angleLimit && pivotTransform.rotation.eulerAngles.x > 180)
                {

                    pivotTransform.localEulerAngles = new Vector3(360 - angleLimit, 0, 0);
                }

            }

            //Lenient Ground Checking
            Global.Timer(ref isGroundedTimer, isGroundedTimerMax, ref isGroundedLenient, false);

            if (player.isGrounded)
            {
                isGroundedLenient = true;
                isGroundedTimer = 0;
            }

            //Movement Input
            if ((Input.GetAxis("Y Axis") > 0) || (Input.GetButton("Back")))
            {
                zSpeed -= transform.forward * (acceleration * 0.8f);
            }

            else if ((Input.GetAxis("Y Axis") < 0) || (Input.GetButton("Forward")))
            {
                zSpeed += transform.forward * acceleration;
            }

            else
            {
                zSpeed = Vector3.zero;
            }

            if ((Input.GetAxis("X Axis") < 0) || (Input.GetButton("Left")))
            {
                xSpeed -= transform.right * acceleration;
            }
            else if ((Input.GetAxis("X Axis") > 0) || (Input.GetButton("Right")))
            {
                xSpeed += transform.right * acceleration;
            }

            else
            {
                xSpeed = Vector3.zero;
            }

            zSpeed = Vector3.ClampMagnitude(zSpeed, maxSpeed);
            xSpeed = Vector3.ClampMagnitude(xSpeed, maxSpeed);

            lastDownSpeed = moveDirection.y;
            moveDirection = Vector3.ClampMagnitude((zSpeed + xSpeed), maxSpeed);
            moveDirection.y = lastDownSpeed;

            //Gravity
            
            if (player.isGrounded)
            {
                moveDirection.y = 0;
            }
            else
            {
                moveDirection.y -= gravityScale;
            }
            

            //Sound
            if (((moveDirection.x != 0f || moveDirection.z != 0f) && isGroundedLenient) && Time.timeScale != 0)
            {
                if (!walkAudio.isPlaying) { walkAudio.Play(); }

            }
            else
            {
                walkAudio.Stop();
            }

            player.Move(moveDirection * Time.deltaTime);
        }

        
    }

    void GetLookingAt()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.position, Camera.forward, out hit, 2))
        {
            lookingAt = hit.transform.gameObject;
            lookingAtPoint = hit.point;
        }
        else
        {
            lookingAt = null;
        }
    }

    public void ReturnToSpawn()
    {
        transform.position = spawnVector;
        Debug.Log(spawnVector[0] + ", " + transform.position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Body")
        {
            Debug.Log("TOUCH");
            ReturnToSpawn();
        }
    }
}
