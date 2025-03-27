using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // Make sure you have this using directive

public class SplitTwoParts : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int split = 14;
    public Material red, green;
    void Start()
    {
        GameObject partA = GameObject.Find("PartA");
        GameObject partB = GameObject.Find("PartB");

        for (int i = 0; i < 27; i++)
        {

            GameObject child = transform.GetChild(0).gameObject;
            Renderer childRenderer = child.GetComponent<Renderer>();
            
            if(i < split) {
                childRenderer.material = red;
                child.transform.SetParent(partA.transform);
            }
            else {
                childRenderer.material = green;
                child.transform.SetParent(partB.transform);
            }
            
        }

        CombineChildrenMeshes(partA);
        CombineChildrenMeshes(partB);


        MeshCollider mcA = partA.AddComponent<MeshCollider>();
        mcA.convex = true;  // Required for MeshColliders on dynamic objects.

        MeshCollider mcB = partB.AddComponent<MeshCollider>();
        mcB.convex = true;  // Required for MeshColliders on dynamic objects.\

        
    }
    void CombineChildrenMeshes(GameObject parent)
    {
        MeshFilter[] meshFilters = parent.GetComponentsInChildren<MeshFilter>();
        List<CombineInstance> combine = new List<CombineInstance>();

        Renderer r = meshFilters[0].GetComponent<Renderer>();

        Material sharedMaterial = r.sharedMaterial;
        foreach (MeshFilter mf in meshFilters)
        {
            // Skip the parent's own MeshFilter if it exists.
            if (mf.gameObject == parent)
                continue;

            CombineInstance ci = new CombineInstance();
            ci.mesh = mf.sharedMesh;
            // Convert each child's mesh to world space.
            ci.transform = mf.transform.localToWorldMatrix;
            combine.Add(ci);
            // Optionally disable the child game object so only the combined mesh is visible.
            mf.gameObject.SetActive(false);
        }


        Mesh combinedMesh = new Mesh();
        combinedMesh.CombineMeshes(combine.ToArray(), true, true);

        // Add (or get) a MeshFilter on the parent and assign the combined mesh.
        MeshFilter parentMeshFilter = parent.GetComponent<MeshFilter>();
        if (parentMeshFilter == null)
            parentMeshFilter = parent.AddComponent<MeshFilter>();
        parentMeshFilter.mesh = combinedMesh;

        // Also add a MeshRenderer if needed.
        MeshRenderer parentMeshRenderer = parent.GetComponent<MeshRenderer>();
        if (parentMeshRenderer == null)
            parentMeshRenderer = parent.AddComponent<MeshRenderer>();
        // Optionally assign a material here if desired.
        parentMeshRenderer.material = sharedMaterial;
        
        // put transform back to original parent
    
        
    }

}
