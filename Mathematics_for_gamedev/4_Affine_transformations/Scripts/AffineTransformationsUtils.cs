using UnityEngine;

namespace Holistic3D_courses.Mathematics_for_gamedev._Affine_transformations
{
    public static class AffineTransformationsUtils
    {
        public static Vector3 Translate(Vector3 source, Vector3 vector)
        {
            var point = new Vector4(source.x, source.y, source.z, 1);
            /*
             * Translation matrix:
             * | 1 0 0 vector.x |
             * | 0 1 0 vector.y |
             * | 0 0 1 vector.z |
             * | 0 0 0 1        |
             */
            var translationMatrix = Matrix4x4.Translate(vector);
            
            var result = translationMatrix * point;
            return new Vector3(result.x, result.y, result.z);
        }

        public static Vector3 Scale(Vector3 source, Vector3 scale, Vector3 center)
        {
            var point = new Vector4(source.x, source.y, source.z, 1);
            /*
             * Scale matrix:
             * | scale.x 0       0       0 |
             * | 0       scale.y 0       0 |
             * | 0       0       scale.z 0 |
             * | 0       0       0       1 |
             */
            var scaleMatrix = Matrix4x4.Scale(scale);
            
            //scale only around center point;
            var translationMatrix = Matrix4x4.Translate(center);
            var inverseSignTranslationMatrix = translationMatrix;
            inverseSignTranslationMatrix.m03 *= -1f;
            inverseSignTranslationMatrix.m13 *= -1f;
            inverseSignTranslationMatrix.m23 *= -1f;

            var result = inverseSignTranslationMatrix * point;
            result = scaleMatrix * result;
            result = translationMatrix * result;
            
            return new Vector3(result.x, result.y, result.z);
        }

        public static Vector3 Rotate(Vector3 source, Vector3 eulerAngles, Vector3 center)
        {
            var point = new Vector4(source.x, source.y, source.z, 1);
            /*
             * Rotation matrix:
             * X:
             * | 1 0            0             0 |
             * | 0 cos(euler.x) -sin(euler.x) 0 |
             * | 0 sin(euler.x) cos(euler.x)  0 |
             * | 0 0            0             1 |
             *
             * Y:
             * | cos(euler.y)  0 sin(euler.y) 0 |
             * | 0             1 0            0 |
             * | -sin(euler.y) 0 cos(euler.x) 0 |
             * | 0             0 0            1 |
             *
             * Z:
             * | cos(euler.z) -sin(euler.z) 0 0 |
             * | sin(euler.z) cos(euler.z)  0 0 |
             * | 0            0             1 0 |
             * | 0            0             0 1 |
             */
            var quaternion = Quaternion.Euler(eulerAngles);
            var rotationMatrix = Matrix4x4.Rotate(quaternion);
            
            //rotate only around center point;
            var translationMatrix = Matrix4x4.Translate(center);
            var inverseSignTranslationMatrix = translationMatrix;
            inverseSignTranslationMatrix.m03 *= -1f;
            inverseSignTranslationMatrix.m13 *= -1f;
            inverseSignTranslationMatrix.m23 *= -1f;
            
            var result = inverseSignTranslationMatrix * point;
            result = rotationMatrix * result;
            result = translationMatrix * result;
            return new Vector3(result.x, result.y, result.z);
        }
    }
}