using UnityEngine;

public class BombEfect : MonoBehaviour
{
    [SerializeField]
    private readonly float ray = 1.0f;
    private readonly float power = 15.5f;
    private Vector3 bombPosition;
    private Collider[] colliders;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        bombPosition = transform.position;
        colliders = Physics.OverlapSphere(bombPosition, ray);

        foreach (var hit in colliders)
        {
            rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, bombPosition, ray, 2.0f, ForceMode.Impulse);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, ray);
    }
}