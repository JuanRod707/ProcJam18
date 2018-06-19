using UnityEngine;

namespace Code.Infrastructure.Repositories
{
    namespace Code.Infrastructure.Repositories
    {
        public static class Repos
        {
            private static GameObject Repositories
            {
                get { return GameObject.Find("Repositories"); }
            }

            public static SectionRepository SectionsRepo
            {
                get { return Repositories.GetComponent<SectionRepository>(); }
            }

            public static MineralRepository MineralsRepo
            {
                get { return Repositories.GetComponent<MineralRepository>(); }
            }
        }
    }

}
