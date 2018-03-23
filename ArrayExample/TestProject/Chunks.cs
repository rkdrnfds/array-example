using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject
{
    public class Chunks
    {
        public int Id { get; set; }
        public int[] ChunkList { get; set; }

        public Chunks()
        {
        }
    }
}