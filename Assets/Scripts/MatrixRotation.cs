using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixRotation : MonoBehaviour
{
    public float Angle;
    public Vector3[] ModelSpaceVertices;

    void Start()
    {
        MeshFilter MF = GetComponent<MeshFilter>();

        ModelSpaceVertices = MF.sharedMesh.vertices;
    }

    void Update()
    {
        Angle += Time.deltaTime;

        //Define new array with correct size
        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];

        // Create Rotation Matrix
        Matrix4by4 RotateMatrix = new Matrix4by4(
            new Vector3(Mathf.Cos(Angle), 0, -Mathf.Sin(Angle)),
            new Vector3(0, 1, 0),
            new Vector3(Mathf.Sin(Angle), 0, Mathf.Cos(Angle)),
            Vector3.zero);

        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            // Rotation
            TransformedVertices[i] = RotateMatrix * ModelSpaceVertices[i];
        }

        MeshFilter MF = GetComponent<MeshFilter>();

        MF.mesh.vertices = TransformedVertices;

        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}