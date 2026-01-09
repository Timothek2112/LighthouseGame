using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();

    public void Put(Items item, int count)
    {
        int left = count;

        foreach(var slot in slots)
        {
            if(slot.item == item)
            {
                slot.count += count;
                left = 0;
            }
        }

        if(left > 0)
        {
            var slot = New(item);
            slot.count = left;
        }
    }

    public void Take(Items item, int count)
    {
        int deleted = 0;
        int left = count;

        foreach(var slot in slots)
        {
            if(slot.item == item)
            {
                if(left > slot.count)
                {
                    deleted += slot.count;
                    left -= slot.count;
                    slot.count = 0;
                }
                else
                {
                    deleted += left;
                    slot.count -= left;
                    left = 0;
                }
            }

            if (left == 0)
                break;
        }
    }

    public Slot New(Items item)
    {
        slots.Add(new Slot());
        return slots[slots.Count - 1];
    }

    public bool Check(Items item, int count)
    {
        int have = slots.Where(slot => slot.item == item).Sum(slot => slot.count);

        return have >= count;
    }
}
