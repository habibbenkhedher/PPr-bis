using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace UI
{
    class DataContent
    {
            
    }
    class Programm
    {

        public string Name { get; set; }
        public string Path { get; set; }


        public Programm(string Name, string Path)
        {
            this.Name = Name;
            this.Path = Path;
        }
        ObservableCollection<Programm> listProgramm = new ObservableCollection<Programm>();
        public ObservableCollection<Programm> GetProgramms()
        {
            listProgramm.Add(new Programm("MicrosoftWord", "C://"));
            listProgramm.Add(new Programm("Paint", "C://"));
            listProgramm.Add(new Programm("NotePad++", "C://"));
            return listProgramm;
        }
    }  
}
