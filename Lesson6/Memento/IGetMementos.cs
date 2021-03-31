using System.Collections.Generic;

namespace Memento
{
    public interface IGetMementos
    {
        List<IMemento> MementoList { get; }        
    }
}
