using System;
using System.Collections;
using System.Collections.Generic;
using Abstract_Factory = Design_Patterns.Creational.Abstract_Factory;
using Builder = Design_Patterns.Creational.Builder;
using Factory_Method = Design_Patterns.Creational.Factory_Method;
using Prototype = Design_Patterns.Creational.Prototype;
using Singleton = Design_Patterns.Creational.Singleton;
using Adapter = Design_Patterns.Structural.Adapter;
using Brigde = Design_Patterns.Structural.Brigde;
using Composite = Design_Patterns.Structural.Composite;
using Decorator = Design_Patterns.Structural.Decorator;
using Facade = Design_Patterns.Structural.Facade;
using Flyweight = Design_Patterns.Structural.Flyweight;
using Proxy = Design_Patterns.Structural.Proxy;
using Chain_of_Reponsibility = Design_Patterns.Behavioral.Chain_of_Reponsibility;
using Command = Design_Patterns.Behavioral.Command;
using Interpreter = Design_Patterns.Behavioral.Interpreter;
using Iterator = Design_Patterns.Behavioral.Iterator;
using Mediator = Design_Patterns.Behavioral.Mediator;
using Memento =  Design_Patterns.Behavioral.Memento;
using Observer = Design_Patterns.Behavioral.Observer;
using State = Design_Patterns.Behavioral.State;
using Strategy = Design_Patterns.Behavioral.Strategy;
using Template_Method = Design_Patterns.Behavioral.Template_Method;
using Visitor = Design_Patterns.Behavioral.Visitor;

namespace TestDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Teste_Visitor_Teste();
        }

        #region: Creational

        #region: Abstract Factory

        static void Test_Abstract_Factory_Modelo()
        {            
            // Abstract factory #1            
            Abstract_Factory.Modelo.AbstractFactory factory1 = new Abstract_Factory.Modelo.ConcreteFactory1();
            Abstract_Factory.Modelo.Client client1 = new Abstract_Factory.Modelo. Client(factory1);
            client1.Run();

            // Abstract factory #2
            Abstract_Factory.Modelo.AbstractFactory factory2 = new Abstract_Factory.Modelo.ConcreteFactory2();
            Abstract_Factory.Modelo.Client client2 = new Abstract_Factory.Modelo.Client(factory2);
            client2.Run();

            // Wait for user input
            Console.ReadKey();
        }

        static void Test_Abstract_Factory_Test()
        {
            // Create and run the African animal world
            Abstract_Factory.Teste.ContinentFactory africa = new Abstract_Factory.Teste.AfricaFactory();
            Abstract_Factory.Teste.AnimalWorld world = new Abstract_Factory.Teste.AnimalWorld(africa);
            world.RunFoodChain();

            // Create and run the American animal world
            Abstract_Factory.Teste.ContinentFactory america = new Abstract_Factory.Teste.AmericaFactory();
            world = new Abstract_Factory.Teste.AnimalWorld(america);
            world.RunFoodChain();

            // Wait for user input
            Console.ReadKey();
        }

        #endregion

        #region: Builder

        static void Test_Builder_Modelo() 
        {
            // Create director and builders
            
            Builder.Modelo.Director director = new Builder.Modelo.Director();

            Builder.Modelo.Builder b1 = new Builder.Modelo.ConcreteBuilder1();
            Builder.Modelo.Builder b2 = new Builder.Modelo.ConcreteBuilder2();

            // Construct two products
            director.Construct(b1);
            Builder.Modelo.Product p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            Builder.Modelo.Product p2 = b2.GetResult();
            p2.Show();

            // Wait for user
            Console.ReadKey();
        }

        static void Test_Builder_Test()
        {            
            Builder.Teste.VehicleBuilder builder;

            // Create shop with vehicle builders
            Builder.Teste.Shop shop = new Builder.Teste.Shop();

            // Construct and display vehicles
            builder = new Builder.Teste.ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new Builder.Teste.CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new Builder.Teste.MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: Factory Method
        static void Test_Factory_Method_Modelo()
        {
            // An array of creators            
            Factory_Method.Modelo.Creator[] creators = new Factory_Method.Modelo.Creator[2];

            creators[0] = new Factory_Method.Modelo.ConcreteCreatorA();
            creators[1] = new Factory_Method.Modelo.ConcreteCreatorB();

            // Iterate over creators and create products
            foreach (Factory_Method.Modelo.Creator creator in creators)
            {
                Factory_Method.Modelo.Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}",
                  product.GetType().Name);
            }

            // Wait for user
            Console.ReadKey();
        }

        static void Test_Factory_Method_Teste() 
        {
            // Note: constructors call Factory Method
            Factory_Method.Teste.Document[] documents = new Factory_Method.Teste.Document[2];

            documents[0] = new Factory_Method.Teste.Resume();
            documents[1] = new Factory_Method.Teste.Report();

            // Display document pages
            foreach (Factory_Method.Teste.Document document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (Factory_Method.Teste.Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: Prototype

        static void Teste_Prototype_Modelo() 
        {
            // Create two instances and clone each

            Prototype.Modelo.ConcretePrototype1 p1 = new Prototype.Modelo.ConcretePrototype1("I");
            Prototype.Modelo.ConcretePrototype1 c1 = (Prototype.Modelo.ConcretePrototype1)p1.Clone();
            Console.WriteLine("Cloned: {0}", c1.Id);

            Prototype.Modelo.ConcretePrototype2 p2 = new Prototype.Modelo.ConcretePrototype2("II");
            Prototype.Modelo.ConcretePrototype2 c2 = (Prototype.Modelo.ConcretePrototype2)p2.Clone();
            Console.WriteLine("Cloned: {0}", c2.Id);

            // Wait for user
            Console.ReadKey();
        }

        static void Teste_Prototype_Teste() 
        {
            Prototype.Teste.ColorManager colormanager = new Prototype.Teste.ColorManager();

            // Initialize with standard colors
            colormanager["red"] = new Prototype.Teste.Color(255, 0, 0);
            colormanager["green"] = new Prototype.Teste.Color(0, 255, 0);
            colormanager["blue"] = new Prototype.Teste.Color(0, 0, 255);

            // User adds personalized colors
            colormanager["angry"] = new Prototype.Teste.Color(255, 54, 0);
            colormanager["peace"] = new Prototype.Teste.Color(128, 211, 128);
            colormanager["flame"] = new Prototype.Teste.Color(211, 34, 20);

            // User clones selected colors
            Prototype.Teste.Color color1 = colormanager["red"].Clone() as Prototype.Teste.Color;
            Prototype.Teste.Color color2 = colormanager["peace"].Clone() as Prototype.Teste.Color;
            Prototype.Teste.Color color3 = colormanager["flame"].Clone() as Prototype.Teste.Color;

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: Singleton

        static void Teste_Singleton_Modelo()
        {
            // Constructor is protected -- cannot use new
            Singleton.Modelo.Singleton s1 = Singleton.Modelo.Singleton.Instance();
            Singleton.Modelo.Singleton s2 = Singleton.Modelo.Singleton.Instance();

            // Test for same instance
            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }

            // Wait for user
            Console.ReadKey();
        }

        static void Teste_Singleton_Teste() 
        {
            Singleton.Teste.LoadBalancer b1 = Singleton.Teste.LoadBalancer.GetLoadBalancer();
            Singleton.Teste.LoadBalancer b2 = Singleton.Teste.LoadBalancer.GetLoadBalancer();
            Singleton.Teste.LoadBalancer b3 = Singleton.Teste.LoadBalancer.GetLoadBalancer();
            Singleton.Teste.LoadBalancer b4 = Singleton.Teste.LoadBalancer.GetLoadBalancer();

            // Same instance?
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Load balance 15 server requests
            Singleton.Teste.LoadBalancer balancer = Singleton.Teste.LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #endregion

        #region: Structural

        #region: Adapter
        
        public static void Teste_Adapter_Modelo()
        {
            // Create adapter and place a request
            Adapter.Modelo.Target target = new Adapter.Modelo.Adapter();
            target.Request();

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Adapter_Teste()
        {
            // Non-adapted chemical compound
            Adapter.Teste.Compound unknown = new Adapter.Teste.Compound("Unknown");
            unknown.Display();

            // Adapted chemical compounds
            Adapter.Teste.Compound water = new Adapter.Teste.RichCompound("Water");
            water.Display();

            Adapter.Teste.Compound benzene = new Adapter.Teste.RichCompound("Benzene");
            benzene.Display();

            Adapter.Teste.Compound ethanol = new Adapter.Teste.RichCompound("Ethanol");
            ethanol.Display();

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: Brigde

        public static void Teste_Brigde_Modelo()
        {
            Brigde.Modelo.Abstraction ab = new Brigde.Modelo.RefinedAbstraction();

            // Set implementation and call
            ab.Implementor = new Brigde.Modelo.ConcreteImplementorA();
            ab.Operation();

            // Change implemention and call
            ab.Implementor = new Brigde.Modelo.ConcreteImplementorB();
            ab.Operation();

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Brigde_Teste() 
        {
            // Create RefinedAbstraction
            Brigde.Teste.Customers customers = new Brigde.Teste.Customers("Chicago");

            // Set ConcreteImplementor
            customers.Data = new Brigde.Teste.CustomersData();

            // Exercise the bridge
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Add("Henry Velasquez");

            customers.ShowAll();

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: Composite

        public static void Teste_Composite_Modelo() 
        {
            Composite.Modelo.Composite root = new Composite.Modelo.Composite("root");
            root.Add(new Composite.Modelo.Leaf("Leaf A"));
            root.Add(new Composite.Modelo.Leaf("Leaf B"));

            Composite.Modelo.Composite comp = new Composite.Modelo.Composite("Composite X");
            comp.Add(new Composite.Modelo.Leaf("Leaf XA"));
            comp.Add(new Composite.Modelo.Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Composite.Modelo.Leaf("Leaf C"));

            // Add and remove a leaf
            Composite.Modelo.Leaf leaf = new Composite.Modelo.Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            // Recursively display tree
            root.Display(1);

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Composite_Teste() 
        {
            Composite.Teste.CompositeElement root = new Composite.Teste.CompositeElement("Picture");
            root.Add(new Composite.Teste.PrimitiveElement("Red Line"));
            root.Add(new Composite.Teste.PrimitiveElement("Blue Circle"));
            root.Add(new Composite.Teste.PrimitiveElement("Green Box"));

            // Create a branch
            Composite.Teste.CompositeElement comp =
              new Composite.Teste.CompositeElement("Two Circles");
            comp.Add(new Composite.Teste.PrimitiveElement("Black Circle"));
            comp.Add(new Composite.Teste.PrimitiveElement("White Circle"));
            root.Add(comp);

            // Add and remove a PrimitiveElement
            Composite.Teste.PrimitiveElement pe =
              new Composite.Teste.PrimitiveElement("Yellow Line");
            root.Add(pe);
            root.Remove(pe);

            // Recursively display nodes
            root.Display(1);

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: Decorator

        public static void Teste_Decorator_Modelo() 
        {
            Decorator.Modelo.ConcreteComponent c = new Decorator.Modelo.ConcreteComponent();
            Decorator.Modelo.ConcreteDecoratorA d1 = new Decorator.Modelo.ConcreteDecoratorA();
            Decorator.Modelo.ConcreteDecoratorB d2 = new Decorator.Modelo.ConcreteDecoratorB();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Decorator_Teste() 
        {
            // Create book
            Decorator.Teste.Book book = new Decorator.Teste.Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            // Create video
            Decorator.Teste.Video video = new Decorator.Teste.Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display
            Console.WriteLine("\nMaking video borrowable:");

            Decorator.Teste.Borrowable borrowvideo = new Decorator.Teste.Borrowable(video);
            borrowvideo.BorrowItem("Customer #1");
            borrowvideo.BorrowItem("Customer #2");

            borrowvideo.Display();

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: Façade

        public static void Teste_Facade_Modelo()
        {
            Facade.Modelo.Facade facade = new Facade.Modelo.Facade();

            facade.MethodA();
            facade.MethodB();

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Facade_Teste() 
        {
            // Facade
            Facade.Teste.Mortgage mortgage = new Facade.Teste.Mortgage();

            // Evaluate mortgage eligibility for customer
            Facade.Teste.Customer customer = new Facade.Teste.Customer("Ann McKinsey");
            bool eligible = mortgage.IsEligible(customer, 125000);

            Console.WriteLine("\n" + customer.Name +
                " has been " + (eligible ? "Approved" : "Rejected"));

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: Flyweight

        public static void Teste_Flyweight_Modelo() 
        {
            // Arbitrary extrinsic state
            int extrinsicstate = 22;

            Flyweight.Modelo.FlyweightFactory factory = new Flyweight.Modelo.FlyweightFactory();

            // Work with different flyweight instances
            Flyweight.Modelo.Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Flyweight.Modelo.Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            Flyweight.Modelo.Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);

            Flyweight.Modelo.UnsharedConcreteFlyweight fu = new
              Flyweight.Modelo.UnsharedConcreteFlyweight();

            fu.Operation(--extrinsicstate);

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Flyweight_Teste()
        {
            // Build a document with text
            string document = "AAZZBBZB";
            char[] chars = document.ToCharArray();

            Flyweight.Teste.CharacterFactory factory = new Flyweight.Teste.CharacterFactory();

            // extrinsic state
            int pointSize = 10;

            // For each character use a flyweight object
            foreach (char c in chars)
            {
                pointSize++;
                Flyweight.Teste.Character character = factory.GetCharacter(c);
                character.Display(pointSize);
            }

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: Proxy

        public static void Teste_Proxy_Modelo() 
        {
            // Create proxy and request a service
            Proxy.Modelo.Proxy proxy = new Proxy.Modelo.Proxy();
            proxy.Request();

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Proxy_Teste() 
        {
            // Create math proxy
            Proxy.Teste.MathProxy proxy = new Proxy.Teste.MathProxy();

            // Do the math
            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #endregion

        #region: Behavioral

        #region: Chain of Responsibility

        public static void Teste_Chain_of_Reponsibility_Modelo()
        {
            // Setup Chain of Responsibility
            Chain_of_Reponsibility.Modelo.Handler h1 = new Chain_of_Reponsibility.Modelo.ConcreteHandler1();
            Chain_of_Reponsibility.Modelo.Handler h2 = new Chain_of_Reponsibility.Modelo.ConcreteHandler2();
            Chain_of_Reponsibility.Modelo.Handler h3 = new Chain_of_Reponsibility.Modelo.ConcreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            // Generate and process request
            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Chain_of_Reponsibility_Teste() 
        {
            // Setup Chain of Responsibility
            Chain_of_Reponsibility.Teste.Approver larry = new Chain_of_Reponsibility.Teste.Director();
            Chain_of_Reponsibility.Teste.Approver sam = new Chain_of_Reponsibility.Teste.VicePresident();
            Chain_of_Reponsibility.Teste.Approver tammy = new Chain_of_Reponsibility.Teste.President();

            larry.SetSuccessor(sam);
            sam.SetSuccessor(tammy);

            // Generate and process purchase requests
            Chain_of_Reponsibility.Teste.Purchase p = new Chain_of_Reponsibility.Teste.Purchase(2034, 350.00, "Assets");
            larry.ProcessRequest(p);

            p = new Chain_of_Reponsibility.Teste.Purchase(2035, 32590.10, "Project X");
            larry.ProcessRequest(p);

            p = new Chain_of_Reponsibility.Teste.Purchase(2036, 122100.00, "Project Y");
            larry.ProcessRequest(p);

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: Command

        public static void Teste_Command_Modelo()
        {
            // Create receiver, command, and invoker
            Command.Modelo.Receiver receiver = new Command.Modelo.Receiver();
            Command.Modelo.Command command = new Command.Modelo.ConcreteCommand(receiver);
            Command.Modelo.Invoker invoker = new Command.Modelo.Invoker();

            // Set and execute command
            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Command_Teste()
        {
            // Create user and let her compute
            Command.Teste.User user = new Command.Teste.User();

            // User presses calculator buttons
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Undo 4 commands
            user.Undo(4);

            // Redo 3 commands
            user.Redo(3);

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: Interpreter

        public static void Teste_Interpreter_Modelo()
        {
            Interpreter.Modelo.Context context = new Interpreter.Modelo.Context();

            // Usually a tree 
            ArrayList list = new ArrayList();

            // Populate 'abstract syntax tree' 
            list.Add(new Interpreter.Modelo.TerminalExpression());
            list.Add(new Interpreter.Modelo.NonterminalExpression());
            list.Add(new Interpreter.Modelo.TerminalExpression());
            list.Add(new Interpreter.Modelo.TerminalExpression());

            // Interpret
            foreach (Interpreter.Modelo.AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Interpreter_Teste() 
        {
            string roman = "MCMXXVIII";
            Interpreter.Teste.Context context = new Interpreter.Teste.Context(roman);

            // Build the 'parse tree'
            List<Interpreter.Teste.Expression> tree = new List<Interpreter.Teste.Expression>();
            tree.Add(new Interpreter.Teste.ThousandExpression());
            tree.Add(new Interpreter.Teste.HundredExpression());
            tree.Add(new Interpreter.Teste.TenExpression());
            tree.Add(new Interpreter.Teste.OneExpression());

            // Interpret
            foreach (Interpreter.Teste.Expression exp in tree)
            {
                exp.Interpret(context);
            }

            Console.WriteLine("{0} = {1}",
              roman, context.Output);

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: Iterator

        public static void Teste_Iterator_Modelo()
        {
            Iterator.Modelo.ConcreteAggregate a = new Iterator.Modelo.ConcreteAggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            // Create Iterator and provide aggregate
            Iterator.Modelo.ConcreteIterator i = new Iterator.Modelo.ConcreteIterator(a);

            Console.WriteLine("Iterating over collection:");

            object item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Iterator_Teste()
        {
            Iterator.Teste.Collection collection = new Iterator.Teste.Collection();
            collection[0] = new Iterator.Teste.Item("Item 0");
            collection[1] = new Iterator.Teste.Item("Item 1");
            collection[2] = new Iterator.Teste.Item("Item 2");
            collection[3] = new Iterator.Teste.Item("Item 3");
            collection[4] = new Iterator.Teste.Item("Item 4");
            collection[5] = new Iterator.Teste.Item("Item 5");
            collection[6] = new Iterator.Teste.Item("Item 6");
            collection[7] = new Iterator.Teste.Item("Item 7");
            collection[8] = new Iterator.Teste.Item("Item 8");

            // Create iterator
            Iterator.Teste.Iterator iterator = new Iterator.Teste.Iterator(collection);

            // Skip every other item
            iterator.Step = 2;

            Console.WriteLine("Iterating over collection:");

            for (Iterator.Teste.Item item = iterator.First();
                !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Name);
            }

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: Mediator

        public static void Teste_Mediator_Modelo()
        {
            Mediator.Modelo.ConcreteMediator m = new Mediator.Modelo.ConcreteMediator();

            Mediator.Modelo.ConcreteColleague1 c1 = new Mediator.Modelo.ConcreteColleague1(m);
            Mediator.Modelo.ConcreteColleague2 c2 = new Mediator.Modelo.ConcreteColleague2(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;

            c1.Send("How are you?");
            c2.Send("Fine, thanks");

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Mediator_Teste()
        {

            Mediator.Teste.Chatroom chatroom = new Mediator.Teste.Chatroom();

            // Create participants and register them
            Mediator.Teste.Participant George = new Mediator.Teste.Beatle("George");
            Mediator.Teste.Participant Paul = new Mediator.Teste.Beatle("Paul");
            Mediator.Teste.Participant Ringo = new Mediator.Teste.Beatle("Ringo");
            Mediator.Teste.Participant John = new Mediator.Teste.Beatle("John");
            Mediator.Teste.Participant Yoko = new Mediator.Teste.NonBeatle("Yoko");

            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);

            // Chatting participants
            Yoko.Send("John", "Hi John!");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");

            // Wait for user
            Console.ReadKey();        
        }
        
        #endregion

        #region: Memento 
        
        public static void Teste_Memento_Modelo()
        {
            Memento.Modelo.Originator o = new Memento.Modelo.Originator();
            o.State = "On";

            // Store internal state
            Memento.Modelo.Caretaker c = new Memento.Modelo.Caretaker();
            c.Memento = o.CreateMemento();

            // Continue changing originator
            o.State = "Off";

            // Restore saved state
            o.SetMemento(c.Memento);

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Memento_Teste()
        {
            Memento.Teste.SalesProspect s = new Memento.Teste.SalesProspect();
            s.Name = "Noel van Halen";
            s.Phone = "(412) 256-0990";
            s.Budget = 25000.0;

            // Store internal state
            Memento.Teste.ProspectMemory m = new Memento.Teste.ProspectMemory();
            m.Memento = s.SaveMemento();

            // Continue changing originator
            s.Name = "Leo Welch";
            s.Phone = "(310) 209-7111";
            s.Budget = 1000000.0;

            // Restore saved state
            s.RestoreMemento(m.Memento);

            // Wait for user
            Console.ReadKey();
        }
        
        #endregion

        #region: Observer

        public static void Teste_Observer_Modelo()
        {
            Observer.Modelo.ConcreteSubject s = new Observer.Modelo.ConcreteSubject();

            s.Attach(new Observer.Modelo.ConcreteObserver(s, "X"));
            s.Attach(new Observer.Modelo.ConcreteObserver(s, "Y"));
            s.Attach(new Observer.Modelo.ConcreteObserver(s, "Z"));

            // Change subject and notify observers
            s.SubjectState = "ABC";
            s.Notify();

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Observer_Teste()
        {
            // Create IBM stock and attach investors
            Observer.Teste.IBM ibm = new Observer.Teste.IBM("IBM", 120.00);
            ibm.Attach(new Observer.Teste.Investor("Sorros"));
            ibm.Attach(new Observer.Teste.Investor("Berkshire"));

            // Fluctuating prices will notify investors
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;

            // Wait for user
            Console.ReadKey();
        }

        #endregion

        #region: State

        public static void Teste_State_Modelo()
        {
            // Setup context in a state
            State.Modelo.Context c = new State.Modelo.Context(new State.Modelo.ConcreteStateA());

            // Issue requests, which toggles state
            c.Request();
            c.Request();
            c.Request();
            c.Request();

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_State_Teste()
        {
            // Open a new account
            State.Teste.Account account = new State.Teste.Account("Jim Johnson");

            // Apply financial transactions
            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);

            // Wait for user
            Console.ReadKey();
        }
        
        #endregion

        #region: Strategy

        public static void Teste_Strategy_Modelo()
        {
            Strategy.Modelo.Context context;

            // Three contexts following different strategies
            context = new Strategy.Modelo.Context(new Strategy.Modelo.ConcreteStrategyA());
            context.ContextInterface();

            context = new Strategy.Modelo.Context(new Strategy.Modelo.ConcreteStrategyB());
            context.ContextInterface();

            context = new Strategy.Modelo.Context(new Strategy.Modelo.ConcreteStrategyC());
            context.ContextInterface();

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Strategy_Teste()
        {
            // Two contexts following different strategies
            Strategy.Teste.SortedList studentRecords = new Strategy.Teste.SortedList();

            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");

            studentRecords.SetSortStrategy(new Strategy.Teste.QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new Strategy.Teste.ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new Strategy.Teste.MergeSort());
            studentRecords.Sort();

            // Wait for user
            Console.ReadKey();
        }
        
        #endregion

        #region: Template Method

        public static void Teste_Template_Method_Modelo()
        {
            Template_Method.Modelo.AbstractClass aA = new Template_Method.Modelo.ConcreteClassA();
            aA.TemplateMethod();

            Template_Method.Modelo.AbstractClass aB = new Template_Method.Modelo.ConcreteClassB();
            aB.TemplateMethod();

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Template_Method_Teste()
        {
            Template_Method.Teste.DataAccessObject daoCategories = new Template_Method.Teste.Categories();
            daoCategories.Run();

            Template_Method.Teste.DataAccessObject daoProducts = new Template_Method.Teste.Products();
            daoProducts.Run();

            // Wait for user
            Console.ReadKey();
        }
        
        #endregion

        #region: Visitor

        public static void Teste_Visitor_Modelo()
        {
            Visitor.Modelo.ObjectStructure o = new Visitor.Modelo.ObjectStructure();
            o.Attach(new Visitor.Modelo.ConcreteElementA());
            o.Attach(new Visitor.Modelo.ConcreteElementB());

            // Create visitor objects
            Visitor.Modelo.ConcreteVisitor1 v1 = new Visitor.Modelo.ConcreteVisitor1();
            Visitor.Modelo.ConcreteVisitor2 v2 = new Visitor.Modelo.ConcreteVisitor2();

            // Structure accepting visitors
            o.Accept(v1);
            o.Accept(v2);

            // Wait for user
            Console.ReadKey();
        }

        public static void Teste_Visitor_Teste()
        {

            Visitor.Teste.Employees e = new Visitor.Teste.Employees();
            e.Attach(new Visitor.Teste.Clerk());
            e.Attach(new Visitor.Teste.Director());
            e.Attach(new Visitor.Teste.President());

            // Employees are 'visited'
            e.Accept(new Visitor.Teste.IncomeVisitor());
            e.Accept(new Visitor.Teste.VacationVisitor());

            // Wait for user
            Console.ReadKey();
        
        }
        
        #endregion

        #endregion
    }
}
