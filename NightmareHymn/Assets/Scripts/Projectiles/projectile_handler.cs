using UnityEngine;

public class projectile_handler : MonoBehaviour
{
    // ------------ VARIBALES/REFERENCES ------------
    public float speed;
    public Rigidbody RBbullet;
    public float damage;

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

    public float GetDamage() {
        return damage;
    }
}
