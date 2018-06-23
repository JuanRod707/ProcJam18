using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Level
{
    public class SectionBounds : MonoBehaviour
    {
        public string MapTag;
        public string PlayerTag;

        private IEnumerable<MeshRenderer> meshes;

        public bool HasBeenMapped { get; private set; }
        private Cave Cave { get { return GetComponentInParent<Cave>(); } }

        void Start()
        {
            meshes = transform.parent.GetComponentsInChildren<MeshRenderer>().Where(x => x.CompareTag(MapTag));
            HideMeshes();
            HasBeenMapped = false;
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
            if (meshes != null)
            {
                foreach (var m in meshes)
                {
                    m.enabled = true;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!HasBeenMapped)
            {
                if (other.CompareTag(PlayerTag))
                {
                    ShowMeshes();
                    HasBeenMapped = true;
                    Cave.DiscoveredSection();
                }
            }
        }
    }
}
