using System;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TestChunks();
        }

        static void TestChunks()
        {
            using (var context = new MyDbContext())
            {
                var chunk = new Chunks();

                chunk.Id = 1;
                chunk.ChunkList = new int[] {1, 2, 3};

                context.Chunks.Add(chunk);

                context.SaveChanges();
            }
        }
    }
}