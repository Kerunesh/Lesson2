using UnityEngine;

public class ParticlesOnTouch : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private GameObject _explosionPrefab; 
    [SerializeField] private float _delay = 0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (_mask.Contains(collision.gameObject.layer))
        {
            
            if (_explosionPrefab != null)
            {
                Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            }

            GameManager.Instance.AddScore(1);
            Destroy(gameObject, _delay);
        }
    }
}