namespace Task01.FriendsOfPesho
{
    public class Node
    {
        public Node(int toNode, int weight)
        {
            this.ToNode = toNode;
            this.Weight = weight;
        }

        public int ToNode { get; set; }

        public int Weight { get; set; }        
    }
}
