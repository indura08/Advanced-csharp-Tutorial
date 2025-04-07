using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_c__tutorial.Generics._1_Introduction.GenericsBasics
{
    public class SortArray
    {

        public void BubbleSort(object[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // dna me if eka blnna : me if eke apita godak type casting krnna wenwa ehma type casting
                    //karalal thami apita  meke compare krna ewa krnna wenne , generic use nokalam thiyna awasiya mekai

                    if (((IComparable)arr[j]).CompareTo(arr[j+1]) > 0)
                    {
                        Swap(arr, j);
                    }
                }
            }
        }

        private void Swap(object[] arr, int j)
        {
            object temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;
        }
    }
}
