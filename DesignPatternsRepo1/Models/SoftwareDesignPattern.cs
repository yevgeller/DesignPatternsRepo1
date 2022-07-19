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
                case "proto": //Prototype
                case "sin": //Singleton
                case "ada": //Adapter
                case "bri": //Bridge
                case "sit": //Composite
                case "dec": //Decorator
                case "fas": //Facade
                case "fly": //Flyweight
                case "proxy": //Proxy
                case "cha": //Chain of Responsibility
                case "com": //Command
                case "int": //Interpreter
                case "ite": //Iterator
                case "med": //Mediator
                case "obs": //Observer
                case "sta": //State
                case "str": //Strategy
                case "tem": //Template Method
                case "vis": //Visitor
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
