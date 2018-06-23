using Code.Common;
using Code.Helpers;
using UnityEngine;

namespace Code.Shrieks
{
    public class ShriekBrain : MonoBehaviour
    {
        public float DistanceToSearch;
        public FloatRange NavigateViewDistance;
        public FloatRange ViewDistance;

        private Transform surveyor;
        private ShriekMovement movement;
        private float viewDistance;
        private float navigateViewDistance;

        private bool surveyorInRange {
            get { return Vector3.Distance(transform.position, surveyor.position) < DistanceToSearch; }
        }

        private bool surveyorInSight
        {
            get
            {
                var ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit, viewDistance))
                {
                    return hit.collider.CompareTag("Player");
                }

                return false;
            }
        }

        private bool wallInSight
        {
            get
            {
                var ray = new Ray(transform.position, transform.forward);
                return Physics.Raycast(ray, navigateViewDistance);
            }
        }

        private bool WallToTheRigt
        {
            get
            {
                var ray = new Ray(transform.position, -transform.up);
                return Physics.Raycast(ray, navigateViewDistance);
            }
        }

        private bool SurveyorOnRight
        {
            get { return transform.InverseTransformPoint(surveyor.position).y < 0; }
        }

        void Start()
        {
            viewDistance = MathHelper.SelectFromRange(ViewDistance);
            navigateViewDistance = MathHelper.SelectFromRange(NavigateViewDistance);

            surveyor = GlobalReferences.Surveyor;
            movement = GetComponent<ShriekMovement>();
        }

        void Update()
        {
            if (surveyorInRange)
            {
                if (surveyorInSight)
                {
                    movement.Charge();
                }
                else
                {
                    if (SurveyorOnRight)
                    {
                        movement.TurnRight();
                    }
                    else
                    {
                        movement.TurnLeft();
                    }
                }
            }
            else
            {
                Navigate();
            }

            movement.MoveForward();
        }

        void Navigate()
        {
            if (wallInSight)
            {
                if (WallToTheRigt)
                {
                    movement.TurnLeft();
                }
                else
                {
                    movement.TurnRight();
                }
            }
        }
    }
}
