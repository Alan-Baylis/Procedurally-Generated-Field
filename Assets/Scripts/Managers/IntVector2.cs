using UnityEngine;
using System.Collections;

[System.Serializable]
public struct IntVector2 {
    public int x, z;
    public IntVector2 (int x, int z) {
        this.x = x;
        this.z = z;
    }
    
    // Operator overloading, allows the + operator to be used to add 2 vectors.
    public static IntVector2 operator + (IntVector2 a, IntVector2 b) {
        a.x += b.x;
        a.z += b.z;
        return a;
    }
}
