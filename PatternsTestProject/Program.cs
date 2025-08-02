using MoreLinq;
using PatternsTestProject.Patterns.Adapter.Default;
using PatternsTestProject.Patterns.Builder.Default;
using PatternsTestProject.Patterns.Builder.Functional;
using PatternsTestProject.Patterns.Builder.Stepwise;
using PatternsTestProject.Patterns.Composite;
using PatternsTestProject.Patterns.Decorator;
using PatternsTestProject.Patterns.Factory.Abstract;
using PatternsTestProject.Patterns.Factory.Default;
using PatternsTestProject.Patterns.Observer;
using PatternsTestProject.Patterns.Prototype.Inheritance;
using PatternsTestProject.Patterns.Prototype.Serialization;
using PatternsTestProject.Patterns.Proxy;
using PatternsTestProject.Patterns.Singleton.Default;
using PatternsTestProject.Patterns.State;
using PatternsTestProject.Patterns.Strategy;
using PatternsTestProject.Patterns.Template;
using PatternsTestProject.Patterns.Visitor;
using static System.Console;

BuilderExample();
BuilderFluentExample();
BuilderStepwiseExample();
BuilderFunctionalExample();
BuilderFacadeExample();

FactoryExample();
FactoryAbstractExample();

PrototypeConstructorExample();
PrototypeInheritanceExample();
PrototypeSerializationExample();

SingletonDefaultExample();

AdapterExample();

CompositeExample();

DecoratorExample();

ProxyExample();

ChainOfResponsobilityExample();

CommandExample();

InterpreterExample();

IteratorExample();

MediatorExample();

ObserverExample();

StateMachineExample();

StrategyExample();

TemplateExample();

VisitorExample();

void VisitorExample()
{
  var e = new AdditionExpression(
      left: new DoubleExpression(1),
      right: new AdditionExpression(
        left: new DoubleExpression(2),
        right: new DoubleExpression(3)));
  var ep = new ExpressionPrinter();
  ep.Visit(e);
  WriteLine(ep.ToString());

  var calc = new ExpressionCalculator();
  calc.Visit(e);
  WriteLine($"{ep} = {calc.Result}");
}

void TemplateExample()
{
  var chess = new Chess();
  chess.Run();
}

void StrategyExample()
{
  var tp = new TextProcessor();
  tp.SetOutputFormat(OutputFormat.Markdown);
  tp.AppendList(new[] { "foo", "bar", "baz" });
  WriteLine(tp);

  tp.Clear();
  tp.SetOutputFormat(OutputFormat.Html);
  tp.AppendList(new[] { "foo", "bar", "baz" });
  WriteLine(tp);
}

void StateMachineExample()
{
  var state = State.OffHook;
  while (true)
  {
    WriteLine($"The phone is currently {state}");
    WriteLine("Select a trigger:");

    // foreach to for
    for (var i = 0; i < PhoneRules.rules[state].Count; i++)
    {
      var (t, _) = PhoneRules.rules[state][i];
      WriteLine($"{i}. {t}");
    }


    int input = int.Parse(Console.ReadLine());

    var (_, s) = PhoneRules.rules[state][input];
    state = s;
  }
}

void ObserverExample()
{
  var person = new PatternsTestProject.Patterns.Observer.Person();

  person.FallsIll += CallDoctor;

  person.CatchACold();
}
static void CallDoctor(object sender, FallsIllEventArgs eventArgs)
{
  Console.WriteLine($"A doctor has been called to {eventArgs.Address}");
}

void MediatorExample()
{
  var room = new ChatRoom();

  var john = new Person("John");
  var jane = new Person("Jane");

  room.Join(john);
  room.Join(jane);

  john.Say("hi room");
  jane.Say("oh, hey john");

  var simon = new Person("Simon");
  room.Join(simon);
  simon.Say("hi everyone!");

  jane.PrivateMessage("Simon", "glad you could join us!");
}

void IteratorExample()
{
  //   1
  //  / \
  // 2   3

  // in-order:  213
  // preorder:  123
  // postorder: 231

  var root = new Node<int>(1,
    new Node<int>(2), new Node<int>(3));

  // C++ style
  var it = new InOrderIterator<int>(root);

  while (it.MoveNext())
  {
    Write(it.Current.Value);
    Write(',');
  }
  WriteLine();

  // C# style
  var tree = new BinaryTree<int>(root);

  WriteLine(string.Join(",", tree.NaturalInOrder.Select(x => x.Value)));

  // duck typing!
  foreach (var node in tree)
    WriteLine(node.Value);
}

void InterpreterExample()
{
  var input = "(13+4)-(12+1)";
  var tokens = Interpreter.Lex(input);
  WriteLine(string.Join("\t", tokens));

  var parsed = Interpreter.Parse(tokens);
  WriteLine($"{input} = {parsed.Value}");
}

void CommandExample()
{
  var ba = new BankAccount();
  var commands = new List<BankAccountCommand>
      {
        new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100),
        new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 1000)
      };

  WriteLine(ba);

  foreach (var c in commands)
    c.Call();

  WriteLine(ba);

  foreach (var c in Enumerable.Reverse(commands))
    c.Undo();

  WriteLine(ba);
}

void ChainOfResponsobilityExample()
{
  var goblin = new Creature("Goblin", 2, 2);
  WriteLine(goblin);

  var root = new CreatureModifier(goblin);

  //root.Add(new NoBonusesModifier(goblin));

  WriteLine("Let's double goblin's attack...");
  root.Add(new DoubleAttackModifier(goblin));

  WriteLine("Let's increase goblin's defense");
  root.Add(new IncreaseDefenseModifier(goblin));

  // eventually...
  root.Handle();
  WriteLine(goblin);
}

void ProxyExample()
{
  ICar car = new CarProxy(new Driver(12)); // 22
  car.Drive();
}

void DecoratorExample()
{
  var cb = new CodeBuilder();
  cb.AppendLine("class Foo")
    .AppendLine("{")
    .AppendLine("}");
  WriteLine(cb);
}

void CompositeExample()
{
  var drawing = new GraphicObject { Name = "My Drawing" };
  drawing.Children.Add(new Square { Color = "Red" });
  drawing.Children.Add(new Circle { Color = "Yellow" });

  var group = new GraphicObject();
  group.Children.Add(new Circle { Color = "Blue" });
  group.Children.Add(new Square { Color = "Blue" });
  drawing.Children.Add(group);

  WriteLine(drawing);
}

void AdapterExample()
{
  List<VectorObject> vectorObjects = new List<VectorObject>
    {
      new VectorRectangle(1, 1, 10, 10),
      new VectorRectangle(3, 3, 6, 6)
    };

  // the interface we have
  void DrawPoint(PatternsTestProject.Patterns.Adapter.Default.Point p)
  {
    Write(".");
  }

  Draw();
  Draw();

  void Draw()
  {
    foreach (var vo in vectorObjects)
    {
      foreach (var line in vo)
      {
        var adapter = new LineToPointAdapter(line);
        adapter.ForEach(DrawPoint);
      }
    }
  }
}

void SingletonDefaultExample()
{
  var db = SingletonDatabase.Instance;

  var city = "Tokyo";
  WriteLine($"{city} has population {db.GetPopulation(city)}");
}

void PrototypeSerializationExample()
{
  Foo foo = new Foo { Stuff = 42, Whatever = "abc" };

  Foo foo2 = foo.DeepCopyXml();

  foo2.Whatever = "xyz";
  WriteLine(foo);
  WriteLine(foo2);
}

static void BuilderExample()
{
  var builder = new HtmlBuilder("ul");
  builder.AddChild("li", "hello");
  builder.AddChild("li", "world");
  WriteLine(builder.ToString());

  builder.Clear();
  builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
  WriteLine(builder);
}

static void BuilderFluentExample()
{
  var me = PatternsTestProject.Patterns.Builder.Fluent.Person.New
    .Called("Dmitri")
    .WorksAsA("Quant")
    .Born(DateTime.UtcNow)
    .Build();
  WriteLine(me);
}

static void BuilderStepwiseExample()
{
  var car = CarBuilder.Create()
          .OfType(CarType.Crossover)
          .WithWheels(18)
          .Build();
  WriteLine(car);
}

static void BuilderFunctionalExample()
{
  var pb = new PersonBuilder();
  var person = pb.Called("Dmitri").WorksAsA("Programmer").Build();

  WriteLine(person);
}

static void BuilderFacadeExample()
{
  var pbFacade = new PatternsTestProject.Patterns.Builder.Facade.PersonBuilder();
  PatternsTestProject.Patterns.Builder.Facade.Person personFacade = pbFacade
      .Lives
          .At("123 London Road")
          .In("London")
          .WithPostcode("SW12BC")
      .Works
          .At("Fabrikam")
          .AsA("Engineer")
          .Earning(123000);

  WriteLine(personFacade);
}

static void FactoryExample()
{
  var point = PatternsTestProject.Patterns.Factory.Default.Point.NewPolarPoint(23, Math.PI);
  WriteLine(point);
}

static void FactoryAbstractExample()
{
  var machine = new HotDrinkMachine();
  IHotDrink drink = machine.MakeDrink();
  drink.Consume();
}

static void PrototypeConstructorExample()
{
  var john = new PatternsTestProject.Patterns.Prototype.CopyConstructor.Employee("John", new PatternsTestProject.Patterns.Prototype.CopyConstructor.Address("123 London Road", "London", "UK"));
  var chris = new PatternsTestProject.Patterns.Prototype.CopyConstructor.Employee(john);
  chris.Name = "Chris";

  WriteLine(john);
  WriteLine(chris);
}

static void PrototypeInheritanceExample()
{
  var john = new Employee();
  john.Names = new[] { "John", "Doe" };
  john.Address = new Address { HouseNumber = 123, StreetName = "London Road" };
  john.Salary = 321000;
  var copy = john.DeepCopy();

  copy.Names[1] = "Smith";
  copy.Address.HouseNumber++;
  copy.Salary = 123000;

  WriteLine(john);
  WriteLine(copy);
}