using UnityEngine;

public class LinearPlatform : LinearMovemnet
{
    [SerializeField] private float speed;

    private void Update()
    {
        movement(movePoint[getIndex()], speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) collision.gameObject.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) collision.gameObject.transform.SetParent(null);
    }
}