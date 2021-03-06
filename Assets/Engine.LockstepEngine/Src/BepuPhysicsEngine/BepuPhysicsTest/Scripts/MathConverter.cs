using FixMath.NET;
using UnityEngine;

namespace ConversionHelper
{
    /// <summary>
    /// Helps convert between XNA math types and the BEPUphysics replacement math types.
    /// A version of this converter could be created for other platforms to ease the integration of the engine.
    /// </summary>
    public static class MathConverter
    {
        //Vector2
        public static Vector2 Convert(BEPUutilities.Vector2 bepuVector)
        {
            Vector2 toReturn;
            toReturn.x = (float)bepuVector.X;
            toReturn.y = (float)bepuVector.Y;
            return toReturn;
        }

        public static void Convert(ref BEPUutilities.Vector2 bepuVector, out Vector2 xnaVector)
        {
            xnaVector.x = (float)bepuVector.X;
            xnaVector.y = (float)bepuVector.Y;
        }

        public static BEPUutilities.Vector2 Convert(Vector2 xnaVector)
        {
            BEPUutilities.Vector2 toReturn;
            toReturn.X = (Fix64)xnaVector.x;
            toReturn.Y = (Fix64)xnaVector.y;
            return toReturn;
        }

        public static void Convert(ref Vector2 xnaVector, out BEPUutilities.Vector2 bepuVector)
        {
            bepuVector.X = (Fix64)xnaVector.x;
            bepuVector.Y = (Fix64)xnaVector.y;
        }

        //Vector3
        public static Vector3 Convert(BEPUutilities.Vector3 bepuVector)
        {
            Vector3 toReturn;
            toReturn.x = (float)bepuVector.X;
            toReturn.y = (float)bepuVector.Y;
            toReturn.z = (float)bepuVector.Z;
            return toReturn;
        }

        public static void Convert(ref BEPUutilities.Vector3 bepuVector, out Vector3 xnaVector)
        {
            xnaVector.x = (float)bepuVector.X;
            xnaVector.y = (float)bepuVector.Y;
            xnaVector.z = (float)bepuVector.Z;
        }

        public static BEPUutilities.Vector3 Convert(Vector3 xnaVector)
        {
            BEPUutilities.Vector3 toReturn;
            toReturn.X = (Fix64)xnaVector.x;
            toReturn.Y = (Fix64)xnaVector.y;
            toReturn.Z = (Fix64)xnaVector.z;
            return toReturn;
        }

        public static void Convert(ref Vector3 xnaVector, out BEPUutilities.Vector3 bepuVector)
        {
            bepuVector.X = (Fix64)xnaVector.x;
            bepuVector.Y = (Fix64)xnaVector.y;
            bepuVector.Z = (Fix64)xnaVector.z;
        }

        public static Vector3[] Convert(BEPUutilities.Vector3[] bepuVectors)
        {
            Vector3[] xnaVectors = new Vector3[bepuVectors.Length];
            for (int i = 0; i < bepuVectors.Length; i++)
            {
                Convert(ref bepuVectors[i], out xnaVectors[i]);
            }
            return xnaVectors;

        }

        public static BEPUutilities.Vector3[] Convert(Vector3[] xnaVectors)
        {
            var bepuVectors = new BEPUutilities.Vector3[xnaVectors.Length];
            for (int i = 0; i < xnaVectors.Length; i++)
            {
                Convert(ref xnaVectors[i], out bepuVectors[i]);
            }
            return bepuVectors;

        }

        //Matrix
        public static Matrix4x4 Convert(BEPUutilities.Matrix matrix)
        {
            Matrix4x4 toReturn;
            Convert(ref matrix, out toReturn);
            return toReturn;
        }

        public static BEPUutilities.Matrix Convert(Matrix4x4 matrix)
        {
            BEPUutilities.Matrix toReturn;
            Convert(ref matrix, out toReturn);
            return toReturn;
        }

        public static void Convert(ref BEPUutilities.Matrix matrix, out Matrix4x4 xnaMatrix)
        {
            xnaMatrix.m00 = (float)matrix.M11;
            xnaMatrix.m01 = (float)matrix.M12;
            xnaMatrix.m02 = (float)matrix.M13;
            xnaMatrix.m03 = (float)matrix.M14;

            xnaMatrix.m10 = (float)matrix.M21;
            xnaMatrix.m11 = (float)matrix.M22;
            xnaMatrix.m12 = (float)matrix.M23;
            xnaMatrix.m13 = (float)matrix.M24;

            xnaMatrix.m20 = (float)matrix.M31;
            xnaMatrix.m21 = (float)matrix.M32;
            xnaMatrix.m22 = (float)matrix.M33;
            xnaMatrix.m23 = (float)matrix.M34;

            xnaMatrix.m30 = (float)matrix.M41;
            xnaMatrix.m31 = (float)matrix.M42;
            xnaMatrix.m32 = (float)matrix.M43;
            xnaMatrix.m33 = (float)matrix.M44;

        }

        public static void Convert(ref Matrix4x4 matrix, out BEPUutilities.Matrix bepuMatrix)
        {
            bepuMatrix.M11 = (Fix64)matrix.m00;
            bepuMatrix.M12 = (Fix64)matrix.m01;
            bepuMatrix.M13 = (Fix64)matrix.m02;
            bepuMatrix.M14 = (Fix64)matrix.m03;

            bepuMatrix.M21 = (Fix64)matrix.m10;
            bepuMatrix.M22 = (Fix64)matrix.m11;
            bepuMatrix.M23 = (Fix64)matrix.m12;
            bepuMatrix.M24 = (Fix64)matrix.m13;

            bepuMatrix.M31 = (Fix64)matrix.m20;
            bepuMatrix.M32 = (Fix64)matrix.m21;
            bepuMatrix.M33 = (Fix64)matrix.m22;
            bepuMatrix.M34 = (Fix64)matrix.m23;

            bepuMatrix.M41 = (Fix64)matrix.m30;
            bepuMatrix.M42 = (Fix64)matrix.m31;
            bepuMatrix.M43 = (Fix64)matrix.m32;
            bepuMatrix.M44 = (Fix64)matrix.m33;

        }

        public static Matrix4x4 Convert(BEPUutilities.Matrix3x3 matrix)
        {
            Matrix4x4 toReturn;
            Convert(ref matrix, out toReturn);
            return toReturn;
        }

        public static void Convert(ref BEPUutilities.Matrix3x3 matrix, out Matrix4x4 xnaMatrix)
        {
            xnaMatrix.m00 = (float)matrix.M11;
            xnaMatrix.m01 = (float)matrix.M12;
            xnaMatrix.m02 = (float)matrix.M13;
            xnaMatrix.m03 = 0;

            xnaMatrix.m10 = (float)matrix.M21;
            xnaMatrix.m11 = (float)matrix.M22;
            xnaMatrix.m12 = (float)matrix.M23;
            xnaMatrix.m13 = 0;

            xnaMatrix.m20 = (float)matrix.M31;
            xnaMatrix.m21 = (float)matrix.M32;
            xnaMatrix.m22 = (float)matrix.M33;
            xnaMatrix.m23 = 0;

            xnaMatrix.m30 = 0;
            xnaMatrix.m31 = 0;
            xnaMatrix.m32 = 0;
            xnaMatrix.m33 = 1;
        }

        public static void Convert(ref Matrix4x4 matrix, out BEPUutilities.Matrix3x3 bepuMatrix)
        {
            bepuMatrix.M11 = (Fix64)matrix.m00;
            bepuMatrix.M12 = (Fix64)matrix.m01;
            bepuMatrix.M13 = (Fix64)matrix.m02;

            bepuMatrix.M21 = (Fix64)matrix.m10;
            bepuMatrix.M22 = (Fix64)matrix.m11;
            bepuMatrix.M23 = (Fix64)matrix.m12;

            bepuMatrix.M31 = (Fix64)matrix.m20;
            bepuMatrix.M32 = (Fix64)matrix.m21;
            bepuMatrix.M33 = (Fix64)matrix.m22;

        }

        //Quaternion
        public static Quaternion Convert(BEPUutilities.Quaternion quaternion)
        {
            Quaternion toReturn;
            toReturn.x = (float)quaternion.X;
            toReturn.y = (float)quaternion.Y;
            toReturn.z = (float)quaternion.Z;
            toReturn.w = (float)quaternion.W;
            return toReturn;
        }

        public static BEPUutilities.Quaternion Convert(Quaternion quaternion)
        {
            BEPUutilities.Quaternion toReturn;
            toReturn.X = (Fix64)quaternion.x;
            toReturn.Y = (Fix64)quaternion.y;
            toReturn.Z = (Fix64)quaternion.z;
            toReturn.W = (Fix64)quaternion.w;
            return toReturn;
        }

        public static void Convert(ref BEPUutilities.Quaternion bepuQuaternion, out Quaternion quaternion)
        {
            quaternion.x = (float)bepuQuaternion.X;
            quaternion.y = (float)bepuQuaternion.Y;
            quaternion.z = (float)bepuQuaternion.Z;
            quaternion.w = (float)bepuQuaternion.W;
        }

        public static void Convert(ref Quaternion quaternion, out  BEPUutilities.Quaternion bepuQuaternion)
        {
            bepuQuaternion.X = (Fix64)quaternion.x;
            bepuQuaternion.Y = (Fix64)quaternion.y;
            bepuQuaternion.Z = (Fix64)quaternion.z;
            bepuQuaternion.W = (Fix64)quaternion.w;
        }

    }
}
