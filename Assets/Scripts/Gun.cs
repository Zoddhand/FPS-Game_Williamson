using UnityEngine;

public class Gun : MonoBehaviour
{
    public float dmg = 5.0f;
    public float range = 100f;
    public Camera cam;
    public ParticleSystem muzzle;
    public GameObject impact;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        muzzle.Play();
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            GameObject impactF = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactF, 0.5f);
        }
    }
}//
