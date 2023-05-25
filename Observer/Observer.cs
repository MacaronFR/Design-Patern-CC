namespace Observer
{
	public abstract class Observer<T>
	{
		public abstract void Update(T value);
	}

	public abstract class Subject<T>
	{
		private List<WeakReference> _observers = new List<WeakReference>();

		public void Attach(Observer<T> observer)
		{
			_observers.Add(new WeakReference(observer, false));
		}

		public bool Detach(Observer<T> observer)
		{
			WeakReference? reference = _observers.Find(v => v.Target == observer);
			if (reference == null)
			{
				return false;
			}
			return _observers.Remove(reference);
		}

		public void Notify(T value)
		{
			_observers.ForEach(reference =>
			{
				Observer<T>? observer = reference.Target as Observer<T>;
				if (observer == null)
				{
					_observers.Remove(reference);
				}
				else
				{
					observer.Update(value);
				}
			});
		}
	}
}