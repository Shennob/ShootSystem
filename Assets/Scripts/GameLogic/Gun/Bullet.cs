using UnityEngine;

namespace GameLogic.Gun
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _destroyTime;
        [SerializeField] private float _speed;

        private Vector3 _direction;

        private void Start() => 
            Destroy(gameObject, _destroyTime);

        private void OnCollisionEnter(Collision _) => 
            DestoyBullet();

        private void OnTriggerEnter(Collider other) =>
            DestoyBullet();

        private void Update() => 
            Move();

        private void Move() => 
            transform.position += _direction * _speed * Time.deltaTime;

        public void Init(Vector3 direction)
        {
            _direction = direction;
            transform.rotation = Quaternion.LookRotation(_direction, Vector3.up);
        }

        private void DestoyBullet() => 
            Destroy(gameObject);
    }
}
