using UnityEngine;

public enum TeamColour
{
    Blue,
    Red,
    Green,
    Yellow,
}

public class Ball : MonoBehaviour
{
    public TeamColour TeamColour;
    public ObjectPooler Pooler;
    public Canon Canon;

    Rigidbody _rigidBody;
    Vector3 _lastVelocity = Vector3.zero;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _lastVelocity = _rigidBody.linearVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            Vector3 normal = collision.GetContact(0).normal;
            Vector3 reflected = Vector3.Reflect(_lastVelocity, normal);

            _rigidBody.linearVelocity = reflected;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var gridCell = other.GetComponent<GridCell>();
        if (gridCell != null)
        {
            if (gridCell.TeamColour != this.TeamColour)
            {
                gridCell.SetTileColour(this.TeamColour);
                Pooler.ReturnToPool(gameObject);
            }
        }
    }
}
