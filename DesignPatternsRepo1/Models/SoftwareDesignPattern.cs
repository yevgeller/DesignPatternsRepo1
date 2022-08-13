namespace DesignPatternsRepo1.Models
{
    public enum PatternGroup
    {
        Behavioral = 1,
        Creational = 0,
        Structural = 2,
    }

    public class SoftwareDesignPattern
    {
        public string Name { get; set; } = "No name";
        public string Group { get; set; } = "No group";
        public string Header { get; set; } = "Pattern summary";
        public string Icon { get; set; } = "fa-folder-open";
        public string Hyperlink { get; set; } = "/index";
        public string InformalDescription { get; set; } = "";
        public List<string> RecipeSteps { get; set; } = new List<string>();
        public PatternGroup GroupEnum { get; set; } = PatternGroup.Creational;

        public string RecipeForDisplay()
        {
            string ret = "Recipe pending";
            if(RecipeSteps.Count == 1) 
                ret = "Recipe: " + RecipeSteps[0];
            else if(RecipeSteps.Count > 1)
            {
                ret = "<h6 class='has-text-centered'>Recipe</h6> <ul>";
                foreach(string r in this.RecipeSteps)
                {
                    ret += "<li>" + r + "</li>";
                }
                ret += "</ul>";
            }

            return ret;
        }

        public SoftwareDesignPattern(string code)
        {
            switch (code.ToLower())
            {
                case "fac":
                    this.Name = "Factory";
                    this.Group = "Creational";
                    this.Header = "Creation of objects that conform to the same interface without specifying concrete classes";
                    this.Icon = "fa-industry";
                    this.Hyperlink = "/Creational/Factory";
                    this.InformalDescription = "Centralize creation of different types of objects as long as they" +
                        " conform to the same interface. Create a separate 'factory' class, pass parameters differentiating " +
                        "what object needs to be created, return an object of an interface.";
                    this.RecipeSteps = new List<string> { "Extract interface from objects", 
                        "Create a 'Factory' class", 
                        "Put in a switch case or other logic to create objects of different type (but same interface) into the factory class. " 
                    };
                    this.GroupEnum = PatternGroup.Creational;
                    break;
                case "abs":
                    this.Name = "Abstract Factory";
                    this.Group = "Creational";
                    this.Header = "Same as Factory (Creation of objects that conform to the same interface without specifying concrete classes) but to 'families' of objects";
                    this.Icon = "fa-boxes-stacked";
                    this.Hyperlink = "/Creational/Abstract";
                    this.InformalDescription = "A \"layer\" above the factory, where creation is centralized, but for groups of objects at a time. Essentially a factory squared, where " +
                        "a created item consists of a set of items that also conform to an interface. Like a soccer team, for example, there's a goalie, defenders, attackers. " +
                        "They may be on different teams (Factory), but in order to create a league, each team must be instantiated. Abstract factory to the rescue.";
                    this.RecipeSteps = new List<string>
                    {
                        "Extract and declare an interface for each piece of a \"family\" of items (blueprint of a type of player: defender, attacker, quarter back).",
                        "Extract and declare an interface for the \"family\" of items (blueprint of a team: Barcelona, Washington Capitals, New England Patriots)",
                        "Create a factory that can create a family of items -- step towards creating a league"
                    };
                    this.GroupEnum = PatternGroup.Creational;
                    break;
                case "bui": //Builder
                    this.Name = "Builder";
                    this.Group = "Creational";
                    this.Header = "Construction of complex objects by extracting the steps and centralizing the control of what happens at each step";
                    this.Icon = "fa-helmet-safety";
                    this.Hyperlink = "/Creational/Builder";
                    this.GroupEnum = PatternGroup.Creational;
                    break;
                case "proto": //Prototype
                    this.Name = "Prototype";
                    this.Group = "Creational";
                    this.Header = "Copying of existing objects without a dependency on a concrete class that needs to be copied";
                    this.Icon = "fa-clone";
                    this.Hyperlink = "/Creational/Prototype";
                    this.GroupEnum = PatternGroup.Creational;
                    break;
                case "sin": //Singleton
                    this.Name = "Singleton";
                    this.Group = "Creational";
                    this.Header = "";
                    this.Icon = "fa-atom";
                    this.Hyperlink = "/Creational/Singleton";
                    this.GroupEnum = PatternGroup.Creational;
                    break;
                case "ada": //Adapter
                    this.Name = "Adapter";
                    this.Group = "Structural";
                    this.Header = "";
                    this.Icon = "fa-plug";
                    this.Hyperlink = "/Structural/Adapter";
                    this.GroupEnum = PatternGroup.Structural;
                    break;
                case "bri": //Bridge
                    this.Name = "Bridge";
                    this.Group = "Structural";
                    this.Header = "Decoupling Abstraction from Implementation";
                    this.Icon = "fa-left-right";
                    this.Hyperlink = "/Structural/Bridge";
                    this.GroupEnum = PatternGroup.Structural;
                    break;
                case "sit": //Composite
                    this.Name = "Composite";
                    this.Group = "Structural";
                    this.Header = "Working with tree-like components in a uniform way regardless of whether it's a leaf or a container";
                    this.Icon = "fa-magnifying-glass-arrow-right";
                    this.Hyperlink = "/Structural/Composite";
                    this.GroupEnum = PatternGroup.Structural;
                    break;
                case "dec": //Decorator
                    this.Name = "Decorator";
                    this.Group = "Structural";
                    this.Header = "Enhancing functionality while ensuring single responsibility";
                    this.Icon = "fa-chart-line";
                    this.Hyperlink = "/Structural/Decorator";
                    this.GroupEnum = PatternGroup.Structural;
                    break;
                case "fas": //Facade
                    this.Name = "Facade";
                    this.Group = "Structural";
                    this.Header = "Hiding complex procedures behind a wall and providing a push-button interface";
                    this.Icon = "fa-igloo";
                    this.Hyperlink = "/Structural/Facade";
                    this.GroupEnum = PatternGroup.Structural;
                    break;
                case "fly": //Flyweight
                    this.Name = "Flyweight";
                    this.Group = "Structural";
                    this.Header = "Creating a large number of similar objects while sharing some of their state to save memory";
                    this.Icon = "fa-bowl-rice";
                    this.Hyperlink = "/Structural/Flyweight";
                    this.GroupEnum = PatternGroup.Structural;
                    break;
                case "proxy": //Proxy
                    this.Name = "Proxy";
                    this.Group = "Structural";
                    this.Header = "A placeholder for another object for a few reasons";
                    this.Icon = "fa-door-open";
                    this.Hyperlink = "/Structural/Proxy";
                    this.GroupEnum = PatternGroup.Structural;
                    break;
                case "cha": //Chain of Responsibility
                    this.Name = "Chain of Responsibility";
                    this.Group = "Behavioral";
                    this.Header = "Standardizing similar separate functionality";
                    this.Icon = "fa-link";
                    this.Hyperlink = "/Behavioral/ChainOfResponsibility";
                    this.InformalDescription = "A set up for series of checks on an item. Checks must happen sequentially, but not necessarily from the beginning.";
                    this.RecipeSteps = new List<string>
                    {
                        "Set up a special interface for steps needing to be performed",
                        "Flesh out concrete steps",
                        "Connect steps in a chain",
                        "Work an item through the chain"
                    };
                    this.GroupEnum = PatternGroup.Behavioral;
                    break;
                case "com": //Command
                    this.Name = "Command";
                    this.Group = "Behavioral";
                    this.Header = "Abstracting callable actions such that they can be assigned to multiple callers and support undoing";
                    this.Icon = "fa-bullhorn";
                    this.Hyperlink = "/Behavioral/Command";
                    this.InformalDescription = "Approach a task from the other way around -- empower an object with methods and resources it needs to perform and undo actions. Inject access to databases, external resources -- whatever it takes. Then use the command object as a standalone unit that can do stuff.";
                    this.RecipeSteps = new List<string>
                    {
                        "Create an object and make it implement methods in ICommand interface: void execute(), boolean canExecute() (optional), void undo() (optional)"
                    };
                    this.GroupEnum = PatternGroup.Behavioral;
                    break;
                case "int": //Interpreter
                    this.Name = "Interpreter";
                    this.Group = "Behavioral";
                    this.Header = "Setting up grammar, sentence structure, and mechanism(s) for translating";
                    this.Icon = "fa-language";
                    this.Hyperlink = "/Behavioral/Interpreter";
                    this.InformalDescription = "Rails for converting something into another format";
                    this.RecipeSteps = new List<string>
                    {
                        "Declare a Context -- a reusable template class",
                        "Set context's input to what needs to be translated",
                        "Output does not need to be set, or start with some initial value",
                        "Declare an abstract class (usually called Expression) and declare one method -- Interpret, takes a Context as input and does the magic inside",
                        "Then create another class inheriting from Expression and flesh out implementation for the Interpret method",
                        "Then create as many other classes as needed to convert into other things",
                        "Need to identify if context has non-terminal expressions and handle those accordingly"
                    };
                    this.GroupEnum = PatternGroup.Behavioral;
                    break;
                case "ite": //Iterator
                    this.Name = "Iterator";
                    this.Group = "Behavioral";
                    this.Header = "Setting up a way to traverse a collection without exposing its inner structure";
                    this.Icon = "fa-arrow-up-right-dots";
                    this.Hyperlink = "/Behavioral/Iterator";
                    this.GroupEnum = PatternGroup.Behavioral;
                    break;
                case "med": //Mediator
                    this.Name = "Mediator";
                    this.Group = "Behavioral";
                    this.Header = "Abstracting communication function to a dedicated entity";
                    this.Icon = "fa-tower-cell";
                    this.Hyperlink = "/Behavioral/Mediator";
                    this.GroupEnum = PatternGroup.Behavioral;
                    break;
                case "mem": //Memento
                    this.Name = "Memento";
                    this.Group = "Behavioral";
                    this.Header = "An ability to provide and consume internal state via a predefined channel";
                    this.Icon = "fa-gift";
                    this.Hyperlink = "/Behavioral/Memento";
                    this.GroupEnum = PatternGroup.Behavioral;
                    break;
                case "obs": //Observer
                    this.Name = "Observer";
                    this.Group = "Behavioral";
                    this.Header = "Providing a choice for entities to subscribe/unsubscribe from notification";
                    this.Icon = "fa-eye";
                    this.Hyperlink = "/Behavioral/Observer";
                    this.GroupEnum = PatternGroup.Behavioral;
                    break;
                case "sta": //State
                    this.Name = "State";
                    this.Group = "Behavioral";
                    this.Header = "Changing functionality of a class in a maintainable and scalable way";
                    this.Icon = "fa-wand-sparkles";
                    this.Hyperlink = "/Behavioral/State";
                    this.GroupEnum = PatternGroup.Behavioral;
                    break;
                case "str": //Strategy
                    this.Name = "Strategy";
                    this.Group = "Behavioral";
                    this.Header = "Flexibility in actions based on circumstances";
                    this.Icon = "fa-chess-knight";
                    this.Hyperlink = "/Behavioral/Strategy";
                    this.GroupEnum = PatternGroup.Behavioral;
                    break;
                case "tem": //Template Method
                    this.Name = "Template Method";
                    this.Group = "Behavioral";
                    this.Header = "Allowing subclasses to vary a common algorithm";
                    this.Icon = "fa-train-tram";
                    this.Hyperlink = "/Behavioral/TemplateMethod";
                    this.GroupEnum = PatternGroup.Behavioral;
                    break;
                case "vis": //Visitor
                    this.Name = "Visitor";
                    this.Group = "Behavioral";
                    this.Header = "Separating algorithms from objects on which they operate";
                    this.Icon = "fa-person-circle-question";
                    this.Hyperlink = "/Behavioral/Visitor";
                    this.GroupEnum = PatternGroup.Behavioral;
                    break;
                default:
                    this.Name = "No name";
                    this.Group = "No group";
                    this.Header = "Pattern summary";
                    this.Icon = "fa-folder-open";
                    this.Hyperlink = "/index";
                    this.GroupEnum = PatternGroup.Creational;
                    break;
            }
        }

    }
}
