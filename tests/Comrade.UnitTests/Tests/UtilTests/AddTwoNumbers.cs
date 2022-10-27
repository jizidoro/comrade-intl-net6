using Xunit;

namespace Comrade.UnitTests.Tests.UtilTests;

public class AddTwoNumbers
{
    [Fact]
    public void AddTwoNumbersTests()
    {
        // [2,4,3]
        var l1 = new ListNode(9, new ListNode(9, new ListNode(9)));

        // [5,6,4]
        var l2 = new ListNode(9, new ListNode(9, new ListNode(9)));

        var tes1 = RecFun(l1, new List<int>());
        var tes2 = RecFun(l2, new List<int>());

        var oto3 = new List<int>();

        var stack1 = new Stack<int>(tes1);
        var stack2 = new Stack<int>(tes2);
        var resto = 0;
        while (stack1.Count > 0 || stack2.Count > 0)
        {
            var oto1 = stack1.TryPeek(out var result1);
            var oto2 = stack2.TryPeek(out var result2);

            if (resto > 0)
            {
                result1 = result1 + resto;
                resto = 0;
            }

            if (oto1 || oto2 || result1 > 0)
            {
                var val = result1 + result2;

                if (val >= 10)
                {
                    val = val -10;
                    resto = 1;
                }
                
                if(oto1)
                {
                    stack1.Pop();
                }

                if(oto2){
                    stack2.Pop();
                }
                oto3.Add(val);
            }
        }

        oto3.Reverse();
        var result = new Stack<int>(oto3.ToArray());
        var response = new ListNode(result.Pop());

        while (result.Count > 0)
        {
            var asd = result.TryPeek(out var result1);
            if (asd)
            {
                ResponseAssembly(response, result1);
                result.Pop();
            }
        }

        var tes22 = response;
    }


    public List<int> RecFun(ListNode node, List<int> tes)
    {
        if (node.next != null)
        {
            RecFun(node.next, tes);
        }

        tes.Add(node.val);
        return tes;
    }

    public ListNode ResponseAssembly(ListNode node, int value)
    {
        if (node.next == null)
        {
            node.next = new ListNode(value);
        }
        else
        {
            ResponseAssembly(node.next, value);
        }


        return node;
    }
}

public class ListNode
{
    public ListNode? next;
    public int val;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}
