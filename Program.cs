using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAAAssignment7
{
    class Program
    {
        public string _sortBy = "D";
        public string _buildHeap = "Y";
        static void Main(string[] args)
        {
            var ob = new Program();
            string sortAlgorithm = "H";
            var nSize = Convert.ToInt32(args[0]);
            ob._sortBy = args[1];
            ob._buildHeap = args[2];
            sortAlgorithm = args[3];


            int[] lstRandomNumbers = ob.GenerateRandomNumbers(nSize);

            var watch = new System.Diagnostics.Stopwatch();
            if (ob._buildHeap.ToUpper() == "N")
            {
                switch (sortAlgorithm.ToUpper())
                {
                    case "H":
                        watch.Restart();
                        ob.HeapSort(lstRandomNumbers);
                        watch.Stop();
                        break;
                    case "R":
                        if (ob._sortBy.ToUpper() == "A")
                        {
                            watch.Restart();
                            RadixSort(lstRandomNumbers, nSize);
                            watch.Stop();
                        }
                        else if (ob._sortBy.ToUpper() == "D")
                        {
                            watch.Restart();
                            ob.RadixDescSort(lstRandomNumbers, nSize);
                            watch.Stop();
                        }
                        break;
                }
            }
            else
            {
                for (int i = nSize / 2 - 1; i >= 0; i--)
                    ob.Heapify(lstRandomNumbers, nSize, i);
            }
            Console.WriteLine("Sorted Array:");
            //printArray(lstRandomNumbers);
            Console.WriteLine("");
            Console.WriteLine($"Execution Time : {watch.ElapsedMilliseconds} ms");
            Console.Read();
        }

        public int[] GenerateRandomNumbers(int nSize)
        {
            int[] randomNumbers = new int[nSize];
            var random = new Random();
            for (var i = 0; i < nSize; i++)
            {
                int number;

                do number = random.Next(0, nSize * 2);
                while (randomNumbers.Contains(number));

                randomNumbers[i] = number;
            }
            return randomNumbers;

        }

        #region HeapSort

        public void HeapSort(int[] arr)
        {
            int n = arr.Length;

            // Build heap (rearrange array) 
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);

            // One by one extract an element from heap 
            for (int i = n - 1; i >= 0; i--)
            {
                // Move current root to end 
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // call max heapify on the reduced heap 
                Heapify(arr, i, 0);
            }
        }
        void Heapify(int[] arr, int n, int i)
        {
            int largest = i; // Initialize largest as root 
            int l = 2 * i + 1; // left = 2*i + 1 
            int r = 2 * i + 2; // right = 2*i + 2 

            if (_sortBy.ToUpper() == "A")
            {
                // If left child is larger than root 
                if (l < n && arr[l] > arr[largest])
                    largest = l;

                // If right child is larger than largest so far 
                if (r < n && arr[r] > arr[largest])
                    largest = r;
            }
            else if (_sortBy.ToUpper() == "D")
            {
                // If left child is larger than root 
                if (l < n && arr[l] < arr[largest])
                    largest = l;

                // If right child is larger than largest so far 
                if (r < n && arr[r] < arr[largest])
                    largest = r;
            }

            // If largest is not root 
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Recursively heapify the affected sub-tree 
                Heapify(arr, n, largest);
            }
        }
        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
        }

        #endregion

        #region RadixSort

        public static int getMax(int[] arr, int n)
        {
            int mx = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > mx)
                    mx = arr[i];
            return mx;
        }

        public static void countSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n]; // output array  
            int i;
            int[] count = new int[10];

            //initializing all elements of count to 0 
            for (i = 0; i < 10; i++)
                count[i] = 0;

            // Store count of occurrences in count[]  
            for (i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            // Change count[i] so that count[i] now contains actual  
            //  position of this digit in output[]  
            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the output array  
            for (i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now  
            // contains sorted numbers according to current digit  
            for (i = 0; i < n; i++)
                arr[i] = output[i];
        }
        public static void RadixSort(int[] arr, int n)
        {
            // Find the maximum number to know number of digits  
            int m = getMax(arr, n);

            // Do counting sort for every digit. Note that instead  
            // of passing digit number, exp is passed. exp is 10^i  
            // where i is current digit number  
            for (int exp = 1; m / exp > 0; exp *= 10)
                countSort(arr, n, exp);
        }
        void RadixDescSort(int[] a, int n)
        {
            int i, m = 0, exp = 1;
            int[] b = new int[n];
            for (i = 0; i < n; i++)
                if (a[i] > m)
                    m = a[i];
            while (m / exp > 0)
            {
                int[] bucket = new int[n];
                for (i = 0; i < n; i++)
                    bucket[9 - a[i] / exp % 10]++;
                for (i = 1; i < 10; i++)
                    bucket[i] += bucket[i - 1];
                for (i = n - 1; i >= 0; i--)
                    b[--bucket[9 - a[i] / exp % 10]] = a[i];
                for (i = 0; i < n; i++)
                {
                    a[i] = b[i];
                }
                exp *= 10;
            }
        }
        #endregion
    }
}
