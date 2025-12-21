using UnityEngine;

namespace Holistic3D_courses.Mathematics_for_gamedev.Intersections
{
    public static class IntersectionUtils
    {
        public static RelationType ReflectOnPlane(Ray ray, Transform planeTransform, Vector2 halfSize,
            out Vector3 hitPoint, out Vector3 reflected)
        {
            hitPoint = Vector3.zero;
            reflected = Vector3.zero;
            
            var axisX = planeTransform.right;
            var axisY = planeTransform.forward;
            var normal = Vector3.Cross(axisX, axisY).normalized;
            var rayNormalDot = Vector3.Dot(normal, ray.direction.normalized);
            if (Mathf.Abs(rayNormalDot) < 1e-6f)
                return RelationType.PARALLEL;
            
            if (rayNormalDot < 0f)
                return RelationType.BEHIND;
            
            var t = Vector3.Dot(-1 * normal, (ray.origin - planeTransform.position)) / rayNormalDot;
            if (t < 0f)
                return RelationType.BEHIND;

            var p = ray.origin + ray.direction.normalized * t;
            var v = p - planeTransform.position;
            var projX = Vector3.Dot(v, axisX);
            var projY = Vector3.Dot(v, axisY);

            if (Mathf.Abs(projX) > halfSize.x || Mathf.Abs(projY) > halfSize.y)
                return RelationType.OUTSIDE;

            hitPoint = p;
            var toHitPointVector = hitPoint - ray.origin;
            reflected = toHitPointVector - 2 * Vector3.Dot(normal, toHitPointVector) * normal;
            return RelationType.AHEAD;
        }
    }
    
    public enum RelationType
    {
        AHEAD,
        BEHIND,
        OUTSIDE,
        PARALLEL
    }
}