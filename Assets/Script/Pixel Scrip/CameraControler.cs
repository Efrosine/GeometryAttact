using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y+2.7f, transform.position.z);
    }
}