//
// Chase.cs
//
// Author:
//       Rafael Julio <Rafael_Julio11@hotmail.com>
//
// Copyright (c) 2017 Acre Company
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using UnityEngine;

public class Chase : MonoBehaviour {
  public Transform player;
  public int EnemySightInMeters;

  Animator anim;

	// Use this for initialization
	void Start () {
    anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
    anim.SetBool("enemyFound", true);

    if(Vector3.Distance(player.position, transform.position) < EnemySightInMeters) {
      Vector3 direction = player.position - transform.position;
      direction.y = 0;
      
      transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 01f);
    
      if(direction.magnitude < 5) {
        transform.Translate(0, 0, 0.09f);
      }
    }
	}
}