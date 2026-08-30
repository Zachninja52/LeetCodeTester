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

    public bool ContainsDuplicate(int[] nums) {
        Dictionary<int,int> checkedNums = new Dictionary<int,int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (checkedNums.ContainsKey(nums[i]))
            {
                return true;
            }
            else
            {
                checkedNums[nums[i]] = i;
            }
        }
        return false;
    }
    public bool IsAnagramUnicode(string s, string t) 
    {
        if (s.Length != t.Length)
        {
            return false;
        }
        
        Dictionary<char, int> dictS = new Dictionary<char,int>();
        Dictionary<char, int> dictT = new Dictionary<char,int>();
        //set up two dicts
        for (int i = 0; i < s.Length; i++)
        {
            //The value is the number of times that charater appears
            if (dictS.ContainsKey(s[i]))
            {
                dictS[s[i]]++;
            }   
            else
            {
                dictS[s[i]] = 1;
            }
            if (dictT.ContainsKey(t[i]))
            {
                dictT[t[i]]++;
            } 
            else
            {
                 dictT[t[i]] = 1;
            }
        }

        //compare
        for (int j = 0; j < t.Length; j++)
        {
            // if dicts doesnt have t's key or it doesnt have the right number of characters
            if (!dictS.ContainsKey(t[j]) || (dictS.ContainsKey(t[j]) &&  dictS[t[j]] != dictT[t[j]] ) )
            {
                return false;
            }
        }
        return true;

    }

    public bool IsAnagram(string s, string t) 
    {
        if (s.Length != t.Length)
        {
            return false;
        }
        int[] arr = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            int zeroBasedIndexS =  s[i] - 'a';
            int zeroBasedIndexT = t[i] - 'a' ;
            arr[zeroBasedIndexS]++;
            arr[zeroBasedIndexT]--;
        }
        foreach(int val in arr)
        {
            if (val != 0)
            {
                return false;
            }
        }
        return true;
    }
}

