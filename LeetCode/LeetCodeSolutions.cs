using System.Data.Common;
using System.Formats.Asn1;
using System.Runtime.ConstrainedExecution;

public class LeetCodeSolutions
{
    public int[] TwoSumBruteForce(int[] nums, int target) 
        {
            for (int firstNum = 0; firstNum < nums.Length; firstNum++)
            {

                for (int secondNum = 0; secondNum < nums.Length; secondNum++)
                {
                    //skip if same index
                    if (firstNum == secondNum)
                    {
                        continue;
                    }

                    if (nums[firstNum] + nums[secondNum] == target)
                    {
                        return [firstNum,secondNum];
                    }
                    
                }
            }
            //failure
            return [-1,-1];
        }
    public int[] TwoSum(int[] nums, int target) 
    {
        Dictionary<int, int> intDict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (intDict.ContainsKey(target-nums[i]))
            {   
                return [i,intDict[target-nums[i]]];
            }
            else if (!intDict.ContainsKey(nums[i]))
            {
                intDict.Add(nums[i],i);
            }
        }
        return [-1,-1];
    }
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
    {
        int carry = 0;
        ListNode dummy = new ListNode();
        ListNode lastNode = dummy;

        while(l1 !=null || l2 !=null || carry > 0)
        {
            ListNode newNode = new ListNode();
            //Case 1
            int finalValToAdd = 0;
            if (l1 != null && l2 != null)
            {
                finalValToAdd = l1.val + l2.val + carry;

                //List Traversal
                l1 = l1.next;
                l2 = l2.next;
                carry = 0;
            }
            //Case 2 
            else if (l1 != null)
            {
                finalValToAdd = l1.val + carry;
                l1 = l1.next;
                carry = 0;
                
            }
            //Case 3
            else if (l2 != null)
            {
                finalValToAdd = l2.val + carry;
                l2 = l2.next;
                carry = 0;
            }
            else if (carry > 0)
            {
                finalValToAdd = carry;
                carry = 0;
            }


            if (finalValToAdd >= 10)
            {
                carry = 1;
                finalValToAdd -= 10;
            }
            newNode.val = finalValToAdd;
            lastNode.next = newNode;
            lastNode = newNode;

        }
        
        return dummy.next;
    }

    public ListNode AddTwoNumbersMod(ListNode l1, ListNode l2)
    {
        int carry = 0;
        ListNode dummy = new ListNode();
        ListNode lastNode = dummy;

        while(l1 !=null || l2 !=null || carry > 0)
        {
            ListNode newNode = new ListNode();
            //Case 1
            int sum = 0;
            if (l1 != null && l2 != null)
            {
                sum = l1.val + l2.val + carry;

                //List Traversal
                l1 = l1.next;
                l2 = l2.next;
            
            }
            //Case 2 
            else if (l1 != null)
            {
                sum = l1.val + carry;
                l1 = l1.next;
            }
            //Case 3
            else if (l2 != null)
            {
                sum = l2.val + carry;
                l2 = l2.next;
            }
            else if (carry > 0)
            {
                sum = carry;
            }
            carry = sum / 10;
            int finalVal = sum % 10;

            newNode.val = finalVal;
            lastNode.next = newNode;
            lastNode = newNode;
        }
        return dummy.next;
    }

}

