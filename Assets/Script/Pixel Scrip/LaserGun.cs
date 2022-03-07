using UnityEngine;

public class LaserGun : MonoBehaviour
{
    private Transform laserBeam;
    [SerializeField] private LayerMask layerToHit;

    // Start is called before the first frame update
    private void Start()
    {
        laserBeam = transform.GetChild(0);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mPost = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 direction = mPost - (Vector2)transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            RaycastHit2D hit = Physics2D.Raycast(laserBeam.transform.position, direction, 50f, layerToHit);
            if (hit.collider == null)
            {
                laserBeam.localScale = new Vector2(50f, laserBeam.localScale.y);
                return;
            }
            laserBeam.localScale = new Vector2(hit.distance / 2, laserBeam.localScale.y);
            return;
        }

        transform.rotation = Quaternion.Euler(Vector3.zero);
        laserBeam.localScale = new Vector3(0, laserBeam.localScale.y);
    }
}