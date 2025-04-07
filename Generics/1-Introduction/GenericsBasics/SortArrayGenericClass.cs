using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_c__tutorial.Generics._1_Introduction.GenericsBasics
{
    public class SortArrayGenericClass<T> where T : IComparable<T>
    {
        //meke me where T kiyla Icomparable interface eka implement krla thiynne ai?
        // eke theruma thami , me sortarray class ek samnya premitive datat types withrk newi user generated data types such as Employee class , Student class wae watath support krnwa kiyla kiynnai
        //e wagema where T : IComparable<T> kiyna kalle theruma thami api me sortarray generi class ek use krna data type ek Icomparable interface ek implement krnna one saha e wagema , icomprable interface k e class ekt generic type icomparable class ekk widiyt hdla thiyennath one

        public void BubbbleSort(T[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        Swap(arr, j);
                    }
                }

            }
        }

        private void Swap(T[] arr, int j)
        {
            T temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;
        }

    }
}
