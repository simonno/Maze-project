using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class PlayerDirection
    {
        public string GameName
        {
            get; set;
        }
        public string Move
        {
            get; set;
        }

        public string ToJSON()
        {
            JObject obj = new JObject();
            obj["Name"] = GameName;
            obj["Direction"] = Move;
            return obj.ToString();
        }
        public static PlayerDirection FromJSON(string str)
        {
            PlayerDirection pd = new PlayerDirection();
            JObject obj = JObject.Parse(str);
            pd.GameName = (string) obj["Name"];
            pd.Move = (string) obj["Direction"];
            return pd;
        }
    }
}
