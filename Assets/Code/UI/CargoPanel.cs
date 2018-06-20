using System.Collections.Generic;
using System.Linq;
using Code.Level;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class CargoPanel : MonoBehaviour
    {
        public ManifestItem[] ManifestItems;
        public Image FillBar;

        void Start()
        {
            foreach (var mi in ManifestItems)
            {
                mi.gameObject.SetActive(false);
            }

            FillBar.fillAmount = 0f;
        }

        public void AddMineral(Mineral mineral)
        {
            ManifestItems.First(x => x.MineralType == mineral).gameObject.SetActive(true);
        }

        public void UpdateManifest(Dictionary<Mineral, float> manifest)
        {
            foreach (var mineral in manifest.Keys)
            {
                ManifestItems.First(x => x.MineralType == mineral).MineralLabel.SetLabel(manifest[mineral].ToString("0.0"));
            }
        }

        public void UpdateCargoFillBar(float max, float current)
        {
            FillBar.fillAmount = current / max;
        }
    }
}
