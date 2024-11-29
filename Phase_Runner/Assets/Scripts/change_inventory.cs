using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_inventory : MonoBehaviour
{
    private static float max_pos;
    private static float min_pos;
    public static Vector3[] slot_pos = new Vector3[5]; 
    public static change_inventory instance;
    public static int cur_slot = 0;
    private float plus = 100.0f;
    private float minus = -100.0f;
    public ChangeHold hand;

    public void Start()
    {
        max_pos = transform.position.x + 400;
        min_pos = transform.position.x;
        SetSlotPos();
    }

    public void SetSlotPos()
    {
        for (int i = 0; i < slot_pos.Length; i++)
        {
            slot_pos[i] = new Vector3((min_pos + (plus * i)), 50, 0);
        }
    }
  
    public void Update()
    {
        float mouse_wheel = Input.GetAxis("Mouse ScrollWheel");
        if(input_pw.isPWobjON == false)
        {
            if (mouse_wheel > 0)
            {
                if (transform.position.x <= min_pos)
                    return;
                else
                {
                    this.transform.Translate(minus, 0, 0);
                    if (this.transform.position == slot_pos[0])
                        cur_slot = 0;
                    else if (this.transform.position == slot_pos[1])
                        cur_slot = 1;
                    else if (this.transform.position == slot_pos[2])
                        cur_slot = 2;
                    else if (this.transform.position == slot_pos[3])
                        cur_slot = 3;
                    else if (this.transform.position == slot_pos[4])
                        cur_slot = 4;
                }

            }
            else if (mouse_wheel < 0)
            {
                if (transform.position.x >= max_pos)
                    return;
                else
                {
                    this.transform.Translate(plus, 0, 0);
                    if (this.transform.position == slot_pos[0])
                        cur_slot = 0;
                    else if (this.transform.position == slot_pos[1])
                        cur_slot = 1;
                    else if (this.transform.position == slot_pos[2])
                        cur_slot = 2;
                    else if (this.transform.position == slot_pos[3])
                        cur_slot = 3;
                    else if (this.transform.position == slot_pos[4])
                        cur_slot = 4;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                cur_slot = 0;
                this.transform.position = MoveSlot(cur_slot);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                cur_slot = 1;
                this.transform.position = MoveSlot(cur_slot);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                cur_slot = 2;
                this.transform.position = MoveSlot(cur_slot);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                cur_slot = 3;
                this.transform.position = MoveSlot(cur_slot);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                cur_slot = 4;
                this.transform.position = MoveSlot(cur_slot);
            }

        }
        

		hand.LoadHoldObject();
	}

    public static Vector3 MoveSlot(int i)
    {
        Vector3 cur_slot_pos = slot_pos[i];
        return cur_slot_pos;
    }
}
