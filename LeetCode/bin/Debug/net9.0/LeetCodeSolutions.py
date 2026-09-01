
from typing import List
from collections import defaultdict

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

def pyContainsDuplicate(nums: List[int]) -> bool:
        """
        :type nums: List[int]
        :rtype: bool
        """
        parsedNums = dict()
        for index,num in enumerate(nums):
            if nums[index] in parsedNums:
                return True
            else:
                parsedNums[nums[index]] = index
        return False

def pyIsAnagram(s: str, t: str)->bool:
        """
        :type s: str
        :type t: str
        :rtype: bool
        """
        if len(s) != len(t):
            return False
        arr = [0] * 26
        for i in range(len(s)):
            zeroBasedIndexS = ord(s[i]) - ord('a')
            zeroBasedIndexT = ord(t[i]) - ord('a')
            arr[zeroBasedIndexS] += 1
            arr[zeroBasedIndexT] -= 1
        
        for val in arr:
            if val != 0:
                return False
        return True
def pyGroupAnagrams(strs: list[str]) ->list[list[str]]:
        """
        :type strs: List[str]
        :rtype: List[List[str]]
        """
        finalMap = defaultdict(list)
        for elem in strs:
            key = [0] * 26
            for character in elem:
                index = ord(character) - ord("a")
                key[index] += 1
            hashLookup = tuple(key)
            finalMap[hashLookup].append(elem)
           
        return list(finalMap.values())

def pyTopKFrequentBruteForce(nums: list[int], k:int) ->list[int]:
        """
        :type nums: List[int]
        :type k: int
        :rtype: List[int]
        """
        dictionary = defaultdict(int)
        for elem in nums:
            dictionary[elem] += 1

        dictList = []
        for key,count in dictionary.items():
            dictList.append((key,count))

        for i in range(len(dictList)):
            for j in range(i+1,len(dictList)):
                temp = []
                if dictList[j][1] > dictList[i][1]:
                    temp = dictList[i]
                    dictList[i] = dictList[j]
                    dictList[j] = temp

        results = []
        for index in range(k):
            results.append(dictList[index][0])
        return results
def pyTopKFrequent(nums: list[int], k:int) ->list[int]:
        """
        :type nums: List[int]
        :type k: int
        :rtype: List[int]
        """
        #count frequency
        freqMap = {}
        for elem in nums:
            if elem in freqMap:
                freqMap[elem] += 1
            else: 
                freqMap[elem] = 1

        #sort into list by index = frequency
        lengthRange = len(nums)+1
        sortedList = [[] for _ in range(lengthRange)]
        for key in freqMap:
            (sortedList[freqMap[key]]).append(key)

        #grab the highest two
        result = []
        for index in range(lengthRange):
            for elem in sortedList[len(nums) - index]:
                if elem != [] and k>0:
                    result.append(elem)
                    k -= 1

        return result
def pyIsPalindrome(s: str) -> bool:
        """
        :type s: str
        :rtype: bool
        """
        newS = "".join(char for char in s if char.isalnum())
        s = newS.lower()
        strLen = len(s)

        for i in range(strLen):
            left = s[i]
            right = s[strLen - i-1]
            
            if left.lower() != right.lower():
                return False
        return True

def pyReverseListNewList(head: ListNode) ->ListNode:
        """
        :type head: Optional[ListNode]
        :rtype: Optional[ListNode]
        """
        firstBackDummy = ListNode()
        newBackDummy = firstBackDummy

        if head == None:
            return None

        while head != None:
            newNode = ListNode()
            newNode.val = head.val
            newNode.next = newBackDummy

            if newNode.next == firstBackDummy:
                newNode.next = None
                
            newBackDummy = newNode
            head = head.next

        return newBackDummy
def pyReverseList(head: ListNode) ->ListNode:
    """
    :type head: Optional[ListNode]
    :rtype: Optional[ListNode]
    """
    prev = None
    curr = head

    while curr != None:
        oldNext = curr.next
        curr.next = prev
        prev = curr
        curr = oldNext

    return prev
        




            

        
        

