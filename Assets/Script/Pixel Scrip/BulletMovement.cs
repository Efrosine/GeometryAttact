using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}