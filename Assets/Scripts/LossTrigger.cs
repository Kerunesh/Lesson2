using UnityEngine;

public class LossTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Stones"))
        {

            if (other.transform.position.y < transform.position.y)
            {
                GameManager.Instance.GameOver();
                Destroy(other.gameObject);

            }
        }
    }
}
