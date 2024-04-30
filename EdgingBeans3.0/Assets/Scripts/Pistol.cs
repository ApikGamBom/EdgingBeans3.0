using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float Damage = 10f;
    public float Range = 100f;
    
    public Camera Camera;

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, Range))
        {
            Debug.Log("Shoot!");
            Debug.Log(hit.transform.name);
        }
        
    }
}
