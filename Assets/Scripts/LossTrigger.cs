using UnityEngine;

public class LossTrigger : MonoBehaviour
{
    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Stones"))
        {
            Rigidbody stoneRB = other.GetComponent<Rigidbody>();

            if (stoneRB != null && stoneRB.linearVelocity.y > 0.01f)
            {
                GameManager.Instance.GameOver();
                Destroy(other.gameObject);

            }
        }
    }
}
