using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    // ------------ VARIBALES/REFERENCES ------------
    public float speed;
    public Rigidbody RBbullet;

    // Start is called before the first frame update
    void Start()
    {
        RBbullet = GetComponent<Rigidbody>();
        RBbullet.velocity = transform.right * speed;
    }

    private void OnTriggerEnter(Collider info)
    {
        Debug.Log("Bullet hit a: " + info.tag);
        Destroy(gameObject);
    }
}
