using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _force;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var MmousePos = Input.mousePosition;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var worldPos = Camera.main.ScreenToWorldPoint(MmousePos);
            var projectileinstance = Instantiate (_projectile, worldPos, Quaternion.identity);
            var projectileRB = projectileinstance.GetComponent<Rigidbody>();

            if (projectileRB != null )
            {
                projectileRB.AddForce(ray.direction * _force);
            }
        }   
        
    }
}
