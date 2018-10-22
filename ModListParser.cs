using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections.Specialized;
using System.Xml.XPath;


namespace ArmaWorkshopUpdater
{
    class ModListParser
    {
        private XmlDocument ModListDocument;
        private List<Tuple<string, string>> ModList { get; set; }
        //Constructor, instantiates class variables.
        // PARAM: uri, a string
        public ModListParser(string uri)
        {
            ModListDocument = new XmlDocument();
            ModListDocument.Load(uri);
            ModList = new List<Tuple<string, string>>();
        }

        // Legacy code, this used to parse through a converted HTML file 
        // into an XML to add to the modlist.
        //public void ParseModList()
        //{
        //    var xml = ModListDocument.CreateNavigator().Select("/html/body/table/tr");
        //    var name_rows = xml.Current.Select("//td[@data-type='DisplayName']");
        //    var link_rows = xml.Current.Select("//td/a[@data-type='Link']");
        //    while (name_rows.MoveNext() && link_rows.MoveNext())
        //    {
        //        ModList.Add(new Tuple<string, string>(name_rows.Current.Value, link_rows.Current.Value));
        //    }
        //}

        // Parses thorugh the Mod List,
        // Functions by iterating through an xml document then adds it to a Tuple 
        // Data structure. 
        public void ParseModList()
        {
            foreach (XmlNode node in ModListDocument.DocumentElement) {
                ModList.Add(new Tuple<string, string>(node["modname"].InnerText, node["link"].InnerText));
            }
        }

        // Getter, returns the mod-list
        // RETURN: ModList
        public List<Tuple<string, string>> getMods()
        {
            return ModList;
        }
    }
}
