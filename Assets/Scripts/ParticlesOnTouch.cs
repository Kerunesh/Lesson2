using UnityEngine;

public class ParticlesOnTouch : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _delay;

    private void OnCollisionEnter(Collision collision)
    {
        if (_mask.Contains(collision.gameObject.layer))
        {
            _particleSystem.transform.parent = null;
            _particleSystem.Play();
            Destroy(gameObject, _delay);
        }
    }
    
}
