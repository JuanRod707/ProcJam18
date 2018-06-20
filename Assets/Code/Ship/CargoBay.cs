using System.Collections.Generic;
using System.Linq;
using Code.Level;
using Code.UI;
using UnityEngine;

namespace Code.Ship
{
    public class CargoBay : MonoBehaviour
    {
        public float CargoCapacity;
        public CargoPanel CargoPanel;

        private Dictionary<Mineral, float> cargo = new Dictionary<Mineral, float>();

        private float cargoAvailable
        {
            get { return CargoCapacity - cargo.Values.Sum(); }
        }

        public void AddCargo(MineralYield manifest)
        {
            if (cargoAvailable < manifest.Amount)
            {
                manifest.Amount = cargoAvailable;
            }

            if (cargo.ContainsKey(manifest.Mineral))
            {
                cargo[manifest.Mineral] += manifest.Amount;
            }
            else
            {
                CargoPanel.AddMineral(manifest.Mineral);
                cargo.Add(manifest.Mineral, manifest.Amount);
            }

            CargoPanel.UpdateCargoFillBar(CargoCapacity, cargo.Values.Sum());
            CargoPanel.UpdateManifest(cargo);
        }
    }
}
