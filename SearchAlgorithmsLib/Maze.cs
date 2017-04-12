using System;


    public class Maze
    {
        public string Name { get; set; }
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public Position InitialPos { get; set; }
        public Position GoalPos { get; set; }
        private CellType[,] cells;
        public string ToJSON()
        {
            JObject mazeObj = new JObject();
            mazeObj["Name"] = Name;
            mazeObj["Rows"] = Rows;
            mazeObj["Cols"] = Cols;
            JObject startObj = new JObject();
            startObj["Row"] = InitialPos.Row;
            startObj["Col"] = InitialPos.Col;
            mazeObj["Start"] = startObj;
            JObject goalObj = new JObject();
            startObj["Row"] = GoalPos.Row;
            startObj["Col"] = GoalPos.Col;
            mazeObj["Start"] = goalObj;
        return mazeObj.ToString();
        }
    public static Maze FromJSON(string str)
    {
        Maze maze = new Maze();
        JObject mazeObj = JObject.Parse(str);
        maze.Name = (string)mazeObj["Name"];
        maze.Rows = (int)mazeObj["Rows"];
        maze.Cols = (int)mazeObj["Cols"];

        maze.InitialPos = new Position((int)mazeObj["Start"]["Row"], (int)mazeObj["Start"]["Col"]);
        maze.GoalPos = new Position((int)mazeObj["Goal"]["Row"], (int)mazeObj["Goal"]["Col"]); 
 
 return maze;
    }
}
