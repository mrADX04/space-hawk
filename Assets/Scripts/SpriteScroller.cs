using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// **Gary Pettie's method which is included in the course "Laser Defender".**
// public class SpriteScroller : MonoBehaviour
// {
//    [SerializeField] Vector2 movespeed;

//     Vector2 offset;
//     Material material;

//     void Awake()
//     {
//         material = GetComponent<SpriteRenderer>().material;
//     }

//     void Update()
//     {
//         offset = movespeed*Time.deltaTime;
//         material.mainTextureOffset += offset;
//     }
// }

public class SpriteScroller : MonoBehaviour
{
   [SerializeField] Vector2 moveSpeed; // control X and Y movespeed in Unity Inspector
 
   void Start()
   {
       Renderer renderer = GetComponent<SpriteRenderer>();
       MaterialPropertyBlock propBlock = new MaterialPropertyBlock();
       renderer.GetPropertyBlock(propBlock);
 
       propBlock.SetFloat("_XSpeed", moveSpeed.x);
       propBlock.SetFloat("_YSpeed", moveSpeed.y);
 
       renderer.SetPropertyBlock(propBlock);
   }
}
