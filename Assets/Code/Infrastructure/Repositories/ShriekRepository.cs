using System.Collections.Generic;
using System.Linq;
using Code.Helpers;
using Code.Level;
using UnityEngine;

namespace Code.Infrastructure.Repositories
{
    public class ShriekRepository : MonoBehaviour
    {
        public GameObject[] Shrieks;

        public GameObject GetRandomShriek()
        {
            return Shrieks.PickOne();
        }
    }
}
