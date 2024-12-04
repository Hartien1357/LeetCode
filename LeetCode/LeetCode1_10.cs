using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class LeetCode1_10
{
    /* Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    You may assume that each input would have exactly one solution, and you may not use the same element twice.
    You can return the answer in any order.
    Input: nums = [2,7,11,15], target = 9
    Output: [0,1]
    Explanation: Because nums[0] + nums[1] == 9, we return [0, 1]. */
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int temp = nums[i];
            if (dic.ContainsKey(target - temp))
            {
                return new int[] { dic[target - temp], i };
            }
            dic[temp] = i;
        }
        return new int[] { 0 };
    }

    /* You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
    You may assume the two numbers do not contain any leading zero, except the number 0 itself. */
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        return AddTwoNumbers(l1, l2, 0);
    }

    private ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry) {
        if (l1 == null && l2 == null & carry == 0) return null;
        int total = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry;
        carry = total / 10;
        return new ListNode(total % 10, AddTwoNumbers(l1?.next, l2?.next, carry));
    }

    /* Given a string s, find the length of the longest substring without repeating characters. */
    public int LengthOfLongestSubstring(string s) {
        HashSet<char> chars = new HashSet<char>();
        int left = 0, right = 0, maxLen = 0;
        while (right < s.Length)
        {
            if (!chars.Contains(s[right]))
            {
                chars.Add(s[right]);
                right++;
                maxLen = Math.Max(maxLen, chars.Count);
            }else
            {
                chars.Remove(s[left++]);
            }
        }
        return maxLen;
    }
}
