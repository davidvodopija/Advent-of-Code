namespace AoC24_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int, int> queue1 = new PriorityQueue<int, int>();
            PriorityQueue<int, int> queue2 = new PriorityQueue<int, int>();

            Dictionary<int, (int Count, int Frequency)> dict = new Dictionary<int, (int Count, int Frequency)>();

            foreach (string line in File.ReadLines("C:\\Users\\david\\AoC\\AoC24_1\\input.txt"))
            {
                String[] inputs = line.Split("   ");
                var ints = inputs.Select(int.Parse).ToArray();

                queue1.Enqueue(ints[0], ints[0]);
                queue2.Enqueue(ints[1], ints[1]);

                if (dict.ContainsKey(ints[0]))
                {
                    var tuple = dict[ints[0]];
                    tuple.Count++;
                    dict[ints[0]] = tuple;

                }
                else {
                    dict[ints[0]] = (1, 0);
                }
                if (dict.ContainsKey(ints[1]))
                {
                    var tuple = dict[ints[1]];
                    tuple.Frequency++;
                    dict[ints[1]] = tuple;

                }
                else
                {
                    dict[ints[1]] = (0, 1);
                }
            }

            int diff = 0;
            int similarity = 0;

            while(queue1.Count > 0 && queue2.Count > 0) { 
                diff = diff + Math.Abs(queue1.Dequeue() - queue2.Dequeue());
            }

            foreach (var el in dict)
            {
                similarity = similarity + el.Key * el.Value.Frequency * el.Value.Count;
            }

            Console.WriteLine("Diff: " + diff);
            Console.WriteLine("Similarity: " + similarity);
        }
    }
}
