using System;
using UnityEngine;

namespace Holistic3D_courses.Mathematics_for_gamedev.Vectors
{
    public static class VectorUtils
    {
        public static FrontalRelationType GetFrontalRelationType(Vector3 forward, Vector3 direction)
        {
            var dot = Vector3.Dot(forward, direction);
            return dot switch
            {
                > 0f => FrontalRelationType.AHEAD,
                < 0f => FrontalRelationType.BEHIND,
                _ => FrontalRelationType.SAME
            };
        }

        public static LateralRelationType GetLateralRelation(Vector3 forward, Vector3 direction)
        {
            var cross = Vector3.Cross(forward, direction);
            return cross.z switch
            {
                > 0f => LateralRelationType.LEFT,
                < 0f => LateralRelationType.RIGHT,
                _ => LateralRelationType.SAME
            };
        }

        public static float Angle(Vector3 forward, Vector3 direction)
        {
            var dot = Vector3.Dot(forward, direction);
            var forwardLength = forward.magnitude;
            var directionLength = direction.magnitude;

            var angleRad = Mathf.Acos(dot / (forwardLength * directionLength));
            return angleRad * Mathf.Rad2Deg;
        }
    }

    [Flags]
    public enum FrontalRelationType
    {
        AHEAD = 1 << 0,
        BEHIND = 1 << 1,
        SAME = 1 << 2,
    }

    [Flags]
    public enum LateralRelationType
    {
        RIGHT = 1 << 0,
        LEFT = 1 << 1,
        SAME = 1 << 2,
    }
}