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
                case "abs":
                    this.Name = "Abstract Factory";
                    this.Group = "Creational";
                    this.Summary = "Same as Factory (Creation of objects that conform to the same interface without specifying concrete classes) but to 'families' of objects";
                    this.Icon = "fa-boxes-stacked";
                    break;
                case "bui": //Builder
                    this.Name = "Builder";
                    this.Group = "Creational";
                    this.Summary = "Construction of complex objects by extracting the steps and centralizing the control of what happens at each step";
                    this.Icon = "fa-helmet-safety";
                    break;
                case "proto": //Prototype
                    this.Name = "Prototype";
                    this.Group = "Creational";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "sin": //Singleton
                    this.Name = "Singleton";
                    this.Group = "Creational";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "ada": //Adapter
                    this.Name = "Adapter";
                    this.Group = "Structural";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "bri": //Bridge
                    this.Name = "";
                    this.Group = "Structural";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "sit": //Composite
                    this.Name = "";
                    this.Group = "Structural";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "dec": //Decorator
                    this.Name = "";
                    this.Group = "Structural";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "fas": //Facade
                    this.Name = "";
                    this.Group = "Structural";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "fly": //Flyweight
                    this.Name = "";
                    this.Group = "Structural";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "proxy": //Proxy
                    this.Name = "";
                    this.Group = "Structural";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "cha": //Chain of Responsibility
                    this.Name = "";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "com": //Command
                    this.Name = "";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "int": //Interpreter
                    this.Name = "";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "ite": //Iterator
                    this.Name = "";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "med": //Mediator
                    this.Name = "";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "obs": //Observer
                    this.Name = "";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "sta": //State
                    this.Name = "";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "str": //Strategy
                    this.Name = "";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "tem": //Template Method
                    this.Name = "";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
                    break;
                case "vis": //Visitor
                    this.Name = "";
                    this.Group = "Behavioral";
                    this.Summary = "";
                    this.Icon = "fa-";
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
