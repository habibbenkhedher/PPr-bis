using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UI_Test
{
    [testc]
    class Programm
    {
        public string Name { get; set; }
        public string Path { get; set; }

        [testm]
        public Programm(string Name, string Path)
        {
            this.Name = Name;
            this.Path = Path;
        }
    }
    [testc]
    class Programmlisting
    {
        ObservableCollection<Programm> listProgramm = new ObservableCollection<Programm>();

        [testm]
        public ObservableCollection<Programm> GetProgramms()
        {
            listProgramm.Add(new Programm("MicrosoftWord", "C://"));
            listProgramm.Add(new Programm("Paint", "C://"));
            listProgramm.Add(new Programm("NotePad++", "C://"));
            return listProgramm;
        }

    }
    
}
