using UnityEngine;

public class Gun : MonoBehaviour
{
    public float bulletSpeed = 5.0f;
    //public ParticleSystem muzzle;
   // public GameObject impact;
    public GameObject bulletPrefab;
    Animator animator;
    private Camera cam;
    GameObject tempObj;

    private void Start()
    {
        animator = GetComponent<Animator>();
        cam = Camera.main;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Destroy(tempObj);
        animator.SetBool("Firing", false);
        if (Input.GetButton("Fire1"))
        {
            Bullet();
            Shoot(); 
        }

        if (tempObj != null)
        {
            //Get the Rigidbody that is attached to that instantiated bullet
            Rigidbody projectile = tempObj.GetComponent<Rigidbody>();

            //Shoot the Bullet 
            projectile.velocity = cam.transform.forward * bulletSpeed;
        }
    }
    void Shoot()
    {
        animator.SetBool("Firing", true);
        //muzzle.Play();
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.transform.position, cam.transform.transform.forward, out hit, 100))
        {
            Debug.Log(hit.transform.name);
        }  
    }
    void Bullet()
    {
        if(tempObj == null)
        {
            tempObj = Instantiate(bulletPrefab) as GameObject;

            //Set position  of the bullet in front of the player
            tempObj.transform.position = transform.position + cam.transform.forward;
        }
    }
    void Destroy(GameObject d)
    { 
        Destroy(d,2.0f);
    }
}

