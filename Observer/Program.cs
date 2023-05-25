using Observer;

class Test
{
	static void Main(string[] args)
	{
		Coucou test = new Coucou();
		Observer1 o = new Observer1();
		test.Attach(o);
		test.CoucouMessage = "OLA Péager";
		(new Run()).Test2(test);
		test.Detach(o);
		test.CoucouMessage = "NIKKKK";
	}
	
	
}

class Run
{
	public void Test2(Coucou test)
	{
		Observer1 o = new Observer1();
		test.Attach(o);
		test.CoucouMessage = "MAIS NILLLLL";
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

	public override void Update(String value)
	{
		Console.WriteLine(value + "! Denis");
	}
}