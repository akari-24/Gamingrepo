using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
	[Header("Floats")]
	public float speed;
	public float patrolTime;


	[Header("Bools")]
	public bool xPatrol;
	public bool zPatrol;
    public bool movePlayer;

	[Header("Refs")]
	public Vector3 direction;
    public CharacterController playerController;

    // Start is called before the first frame update
            void Start()
            {
                direction = Vector3.left;
                //this is to call the while loop
                StartCoroutine(xRoutine());
                StartCoroutine(zRoutine());
                playerController = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
            }

            // Update is called once per frame
            void Update()
            {
                transform.Translate(direction * Time.deltaTime * speed);

                if (movePlayer)
                {
                    playerController.Move(direction * Time.deltaTime * speed);
                }

            }




            IEnumerator xRoutine()
        {
            while(xPatrol)
            {
                direction = Vector3.left;

                //patrol quals the side to side time
                yield return new WaitForSeconds(patrolTime);

                direction = Vector3.right;

                yield return new WaitForSeconds(patrolTime);
            }
        }


            IEnumerator zRoutine()
             {
                 while(xPatrol)
                 {
                        direction = Vector3.forward;

                        //patrol quals the side to side time
                        yield return new WaitForSeconds(patrolTime);

                        direction = Vector3.back;

                        yield return new WaitForSeconds(patrolTime);
                 }
            }

}
