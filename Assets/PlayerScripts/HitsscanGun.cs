using UnityEngine;
using System.Collections;

public class HitscanGun : MonoBehaviour
{
    [Header("Gun Settings")]
    public float range = 100f;
    public float damage = 25f;
    public float fireRate = 0.1f;

    [Header("References")]
    public Camera playerCam;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffectPrefab;
    public GameObject bulletTrailPrefab;
    public float trailDuration = 0.05f;

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }
void Shoot()
{
    if (muzzleFlash) muzzleFlash.Play();

    Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
    RaycastHit hit;

    Vector3 endPoint;

    if (Physics.Raycast(ray, out hit, range))
    {
        Debug.Log("Hit: " + hit.collider.name);

        // ✅ FIXED: Use GetComponentInParent instead of GetComponent
        Target target = hit.collider.GetComponentInParent<Target>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }

        // Hit effect
        if (hitEffectPrefab)
        {
            GameObject impactGO = Instantiate(hitEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }

        endPoint = hit.point;
    }
    else
    {
        endPoint = ray.origin + ray.direction * range;
    }

    StartCoroutine(SpawnTrail(ray.origin, endPoint));
}


    IEnumerator SpawnTrail(Vector3 start, Vector3 end)
    {
        if (bulletTrailPrefab != null)
        {
            GameObject trail = Instantiate(bulletTrailPrefab, start, Quaternion.identity);
            LineRenderer lr = trail.GetComponent<LineRenderer>();

            if (lr != null)
            {
                lr.SetPosition(0, start);
                lr.SetPosition(1, end);
            }

            yield return new WaitForSeconds(trailDuration);
            Destroy(trail);
        }
    }
}
