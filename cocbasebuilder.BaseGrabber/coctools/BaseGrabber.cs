using cocbasebuilder.BaseGrabber.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cocbasebuilder.Model;

namespace cocbasebuilder.BaseGrabber.coctools
{
    public class BaseGrabber : IBaseGrabber
    {
        public string URL { get; set; }
        private string[] _buildingsMaster;
        //List<Dictionary<string buildingName, Dictionary<string[top|left|level], string>>>
        private List<Building> _buildings;

        

        public BaseGrabber(string URL)
        {
            _buildingsMaster =
                "cannon,archer,air,xbow,goldstorage,elixerstorage,delixerstorage,mortar,wizard,herobarbarian,heroarcher,gold,elixer,delixer,tesla,bigbomb,bomb,spring,airbomb,airmine,barracks,dbarracks,spells,townhall,research,army,builder,castle,inferno,skeleton,airsweeper,darkspells,herowarden,eagle".Split(',');
            this.URL = URL;
            _buildings = new List<Building>();
        }
        public void Process()
        {
        }

        public List<Building> ParseData()
        { 
            var hashTag = Utility.Expand(Utility.GetHashTag(URL));
            var townHallLevel = hashTag.Substring(0, 1);

            var elements = hashTag.Substring(1).Split('-');

            
            var cocToolsbuildings = elements[0].Split('_');
            var levels = elements[2].Split('_');

            var buildings = new List<Building>();

            for (int i = 0; i < cocToolsbuildings.Length; i++)
            {
                var cocToolsbuilding = cocToolsbuildings[i];

                
                for (int j = 0; j < cocToolsbuilding.Length / 2; j++)
                {
                    buildings.Add(
                        new Building
                        {
                            Name = _buildingsMaster[i],
                            Left = getPositionNumber(cocToolsbuilding[j * 2]),
                            Top = getPositionNumber(cocToolsbuilding[j * 2 + 1])
                        }
                    );
                }

            }
            return buildings;
        }

        private int getPositionNumber(char c)
        {
            return Encoding.ASCII.GetBytes(new char[] { c })[0] - 96;
        }

        

    }
}
