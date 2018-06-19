using System.Collections;
using UnityEngine;

namespace Code.Weapons
{
    public class PlasmaShot : MonoBehaviour
    {
        public GameObject HitPrefab;

        private void OnTriggerEnter(Collider other)
        {
            Instantiate(HitPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
