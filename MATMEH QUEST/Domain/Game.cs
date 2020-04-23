using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using System.Linq;

namespace MATMEH_QUEST.Domain
{
    public class Game
    {
        public World World;
        public Player Player;
        public Inventory Inventory;
        public Game()
        {
            
        }

        public void New(World world)
        {
            this.World = world;
            Player = new Player(new Point(0,0),100);
            Inventory = new Inventory();
            Save();
        }

        public void Load()
        {
            XDocument xdoc = XDocument.Load("Data/SaveData.xml");
            XElement save = xdoc.Element("saves").Elements("save").ToList().First();
        }

        public void Save()
        {
            XDocument xdoc = XDocument.Load("Data/SaveData.xml");
            XElement root = xdoc.Element("saves");
            root.Add(new XElement("save",
                new XAttribute("name", "NewSave"),
                new XElement("World", World),
                new XElement("Player", Player),
                new XElement("Inventory", Inventory)));
            xdoc.Save("Data/SaveData.xml");
        }
    }
}