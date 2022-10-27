using Comrade.Application.Extensions;
using IdentityModel.OidcClient;
using Xunit;

namespace Comrade.UnitTests.Tests.UtilTests;

public class FindMedianSortedArrays
{
    [Fact]
    public void FindMedianSortedArraysTests() {

        //eu ia pegar os dos arrays, pegar o tamanho e somar
        //eu ai achar a posicao da mediana
        //iterar sobre os arrays ate tirar a posicao da mediana de dentro dos arrays

        int[] nums1 = {0,0};
        int[] nums2 = {0,0};

        var stack1 = new Stack<int>(nums1);
        var stack2 = new Stack<int>(nums2);

        double mediana = (nums1.Length + nums2.Length)/2.0;

        double oto = 0;

        if (mediana % 1 == 0)
        {
            for (int i = 1; i < (int)mediana +1; i++)
            {
                var tes1 = stack1.TryPeek(out int result1);
                var tes2 = stack2.TryPeek(out int result2);

                if (i == (int)mediana)
                {
                    var qwe = new List<int>();
                    for (int j = 0; j < 2; j++)
                    {
                        tes1 = stack1.TryPeek(out int resultF1);
                        tes2 = stack2.TryPeek(out int resultF2);
                        if (resultF1 > resultF2)
                        {
                            if (tes1)
                            {
                                qwe.Add(stack1.Pop());
                            }
                            else
                            {
                                qwe.Add(stack2.Pop());
                            }
                        }
                        else
                        {
                            if (tes2)
                            {
                                qwe.Add(stack2.Pop());
                            }
                            else
                            {
                                qwe.Add(stack1.Pop());
                            }
                                
                        }
                    }

                    oto = (qwe[0] + qwe[1])/2.0;

                }
                else
                {
                    if (result1 > result2)
                    {
                        if (tes1)
                        {
                            oto = stack1.Pop();
                        }
                    }
                    else
                    {
                        if (tes2)
                        {
                            oto = stack2.Pop();
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < mediana; i++)
            {
                var tes1 = stack1.TryPeek(out int result1);
                var tes2 = stack2.TryPeek(out int result2);

                if (result1 > result2)
                {
                    if (tes1)
                    {
                        oto = stack1.Pop();
                    }
                    else
                    {
                        if (tes2)
                        {
                            oto = stack2.Pop();
                        }
                    }
                }
                else
                {
                    if (tes2)
                    {
                        oto = stack2.Pop();
                    }
                    else
                    {
                        if (tes1)
                        {
                            oto = stack1.Pop();
                        }
                    }
                }
            }
        }

        var oto2 = oto;
    }
}

