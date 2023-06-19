using Observer;

class Test
{
	static void Main(string[] args)
	{
		Coucou test = new Coucou();
		Observer1 o = new Observer1("Denis");
		test.Attach(o);
		test.CoucouMessage = "Bonjour";
		(new Run()).Test2(test);
		test.CoucouMessage = "Ohayo";
		test.Detach(o);
		test.CoucouMessage = "Ola";
	}
	
	
}

class Run
{
	public void Test2(Coucou test)
	{
		Observer1 o = new Observer1("Mathieu");
		test.Attach(o);
		test.CoucouMessage = "Hello";
	}
}

class Coucou : Subject<String>
{
	public Coucou(string message)
	{
		_coucouMessage = message;
	}

	public Coucou()
	{
		_coucouMessage = "Coucou";
	}
	
	private string _coucouMessage;
	public string CoucouMessage
	{
		get => _coucouMessage;
		set
		{
			_coucouMessage = value;
			Notify(value);
		}
	}
}

class Observer1 : Observer<String>
{

	public Observer1(String name) : base(name) { }
	
	public override void Update(String value)
	{
		Console.WriteLine(value + " " + Name + "!");
	}
}