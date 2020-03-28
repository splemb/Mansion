using UnityEngine;

public class DoorController : Interaction
{
    //Variables
    public bool open;
    private float startAngle;
    private float newAngle = -90f;
    public bool right;
    public bool locked;
    private AudioSource sound;
    public GameObject model;
    public DoorController pair;
    public AudioClip[] sounds = new AudioClip[3];

    private string ID;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            ID = GetComponent<UniqueID>().ID;
            if (Global.CheckUsed(ID))
            {
                locked = false ;
            }
        }
        catch
        {
            Debug.LogError("OBJECT HAS NO ID BUT SHOULD!");
        }

        if (right) { newAngle *= -1; }

        startAngle = model.transform.eulerAngles.y;
        if (open)
        {
            model.transform.eulerAngles += new Vector3(0,newAngle,0);
        }

        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (open)
        {
            Quaternion newRotation = Quaternion.AngleAxis(startAngle + newAngle, Vector3.up);
            model.transform.rotation = Quaternion.Slerp(model.transform.rotation, newRotation, 0.1f);
        }
        else if (!open)
        {
            Quaternion newRotation = Quaternion.AngleAxis(startAngle, Vector3.up);
            model.transform.rotation = Quaternion.Slerp(model.transform.rotation, newRotation, 0.1f);
        }
    }

    public override void OnInteract()
    {
        if (locked)
        {
            if (Global.keyCount > 0)
            {
                Global.keyCount--;
                locked = false;
                open = true;
                Global.usedObjects.Add(ID);
                if (pair != null) { pair.open = open; pair.locked = locked; }
            } else
            {
                sound.PlayOneShot(sounds[0]);
                
            }
        }
        else
        {
            open = !open;
            if (pair != null) { pair.open = open; }
        }

        if (open)
        {
            sound.PlayOneShot(sounds[1]);
        } else if (!open)
        {
            sound.PlayOneShot(sounds[2]);
        }
    }

    public override string OnLookAt()
    {
        if (locked)
        {
            return ("UNLOCK");
        } else if (!open)
        {
            return ("OPEN");
        } else if (open)
        {
            return ("CLOSE");
        } else
        {
            return ("");
        }
        
    }

}
