namespace DesignPatternsRepo1.Models
{
    public class SoftwareDesignPattern
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }

        public SoftwareDesignPattern()
        {
            this.Name = "No name";
            this.Group = "No group";
            this.Summary = "Pattern summary";
            this.Icon = "fa-folder-open";
        }

        public SoftwareDesignPattern(string code)
        {
            switch (code.ToLower())
            {
                case "fac":
                    this.Name = "Factory";
                    this.Group = "Creational";
                    this.Summary = "Creation of objects that conform to the same interface without specifying concrete classes";
                    this.Icon = "fa-industry";
                    break;
                default:
                    this.Name = "Abstract Factory";
                    this.Group = "Creational";
                    this.Summary = "Same as Factory (Creation of objects that conform to the same interface without specifying concrete classes) but to 'families' of objects";
                    this.Icon = "fa-boxes-stacked";
                    break;
            }
        }

    }
}
