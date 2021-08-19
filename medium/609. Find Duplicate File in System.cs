public class Solution {
    public IList<IList<string>> FindDuplicate(string[] paths) {
        var map = new Dictionary<string, List<string>>();
        foreach(var path in paths){
            var infos = path.Split(" ");
            if(infos.Length <= 1)
                continue;
            var dir = infos[0];
            foreach(var file in infos.Skip(1)){
                var fileInfo = file.Split("(");
                var name = dir + "/" + fileInfo[0];
                var content = fileInfo[1];
                if(map.ContainsKey(content)){
                    map[content].Add(name);
                } else{
                    map[content] = new List<string>{name};
                }
            }
        }
        return map
            .Where(kv => kv.Value.Count > 1)
            .Select(kv => (IList<string>)kv.Value)
            .ToList();
    }
}