
from typing import List

class ListNode(object):
    def __init__(self, val=0, next=None):
            self.val = val
            self.next = next

def pyTwoSum(nums: List[int], target: int) -> List[int]:
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        """
        dictionary = {}
        for index,num in enumerate(nums):
            valToCheck = target-num
            if valToCheck in dictionary:
                #found it
                return [index, dictionary[valToCheck]]
            else:
                #add to dict
                dictionary[num] = index

def pyAddTwoNumbers(l1: ListNode, l2: ListNode):
        """
        :type l1: Optional[ListNode]
        :type l2: Optional[ListNode]
        :rtype: Optional[ListNode]
        """
        carry = 0
        dummy = ListNode()
        lastNode = dummy
        while l1 or l2 or carry > 0:
            newNode = ListNode()
            v1 = l1.val if l1 else 0
            v2 = l2.val if l2 else 0
            totalSum = v1 + v2 + carry

            finalVal = totalSum % 10
            carry = totalSum // 10

            newNode.val = finalVal
            lastNode.next = newNode
            lastNode = newNode

            l1 = l1.next if l1 else None
            l2 = l2.next if l2 else None
        return dummy.next 
