public class FileSystem {

    private Node fs;

    public FileSystem() {
        fs = new Node{Name = "/"};
    }
    
    public IList<string> Ls(string path) {
        var dir = Navigate(path);
        var ls = new List<string>();

        if(dir.IsFile){
            ls.Add(dir.Name);
            return ls;
        }

        if(dir.Children == null)
            return ls;

        foreach(var kv in dir.Children)
            ls.Add(kv.Key);

        return ls;
    }
    
    public void Mkdir(string path) {
        Navigate(path);
    }
    
    public void AddContentToFile(string filePath, string content) {
        var f = Navigate(filePath);
        f.IsFile = true;
        f.Content = f.Content == null ? content : f.Content + content;
    }
    
    public string ReadContentFromFile(string filePath) {
        var f = Navigate(filePath);
        return f.Content;
    }

    private Node Navigate(string path){
        var cur = fs;
        
        foreach(var name in path.Split('/'))
            if(!string.IsNullOrEmpty(name))
                cur = cur.GetAddChild(name);

        return cur;
    }

    private class Node{
        public string Name;
        public SortedDictionary<string, Node> Children;
        public string Content;
        public bool IsFile;

        public Node GetAddChild(string name){
            if(Children == null)
                Children = new SortedDictionary<string, Node>();

            if(!Children.ContainsKey(name))
                Children[name] = new Node{Name = name};

            return Children[name];
        }
    }
}
