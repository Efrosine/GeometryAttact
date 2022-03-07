using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeReference] private float range, timeBettwenShoot;

    private float nextTimetoShoot;

    [SerializeField] private GameObject target, bullet;
    private GameObject currentTarget;
    private Transform pivot, barell;

    // Start is called before the first frame update
    private void Start()
    {
        nextTimetoShoot = Time.time;
        pivot = transform.GetChild(0);
        barell = pivot.transform.GetChild(0);
    }

    // Update is called once per frame
    private void Update()
    {
        checkRange();

        if (currentTarget == null)
        {
            return;
        }

        barellMove();

        if (Time.time > nextTimetoShoot)
        {
            nextTimetoShoot = Time.time + timeBettwenShoot;
            shoot();
        }
    }

    private bool checkRange()
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);

        return currentTarget = distance > range ? null : target;
    }

    private void shoot()
    {
        Instantiate(bullet, barell.position, pivot.rotation);
    }

    private void barellMove()
    {
        Vector2 relative = currentTarget.transform.position - transform.position;
        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        pivot.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}