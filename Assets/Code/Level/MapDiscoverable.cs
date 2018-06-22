using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Level
{
    public class MapDiscoverable:MonoBehaviour
    {
        public string MapTag;
        public string PlayerTag;

        private bool hasBeenMapped = true;
        private IEnumerable<MeshRenderer> meshes;

        void Start()
        {
            meshes = transform.parent.GetComponentsInChildren<MeshRenderer>().Where(x => x.CompareTag(MapTag));
            HideMeshes();
            hasBeenMapped = false;
        }

        void HideMeshes()
        {
            foreach (var m in meshes)
            {
                m.enabled = false;
            }    
        }

        void ShowMeshes()
        {
            foreach (var m in meshes)
            {
                m.enabled = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!hasBeenMapped)
            {
                if (other.CompareTag(PlayerTag))
                {
                    ShowMeshes();
                    hasBeenMapped = true;
                }
            }
        }
    }
}
